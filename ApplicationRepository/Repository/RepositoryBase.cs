using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepository.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        internal practiceEntities context;

        private readonly DbSet<T> dbSet;

        public RepositoryBase()
        {
            context = new practiceEntities();
        }

        public RepositoryBase(practiceEntities _context)
        {
            context = _context;
            dbSet = _context.Set<T>();
        }

        protected DbSet<T> DbSet {
            get
            {
                return context.Set<T>();
            }
        }
        public int Count { get
            {
                return dbSet.Count();
            }
        }

        public IEnumerable<T> All() => DbSet.AsEnumerable<T>().ToList();

        public bool Contains(Expression<Func<T, bool>> predicate) => dbSet.Count(predicate) > 0;

        public T Create(T t)
        {
            try
            {
                var newEntry = DbSet.Add(t);

                context.SaveChanges();

                return newEntry;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var error in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                      error.Entry.Entity.GetType().Name, error.Entry.State);
                    foreach (var ve in error.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual void Delete(object id)
        {
            T tToDelete = DbSet.Find(id);

            Delete(tToDelete);
        }

        public virtual void Delete(T t)
        {
            if (context.Entry(t).State==System.Data.Entity.EntityState.Detached)
            {
                DbSet.Attach(t);
            }

            DbSet.Remove(t);

            context.SaveChanges();
        }

        public  int Delete(Expression<Func<T, bool>> predicate)
        {
            var obj = Filter(predicate);

            foreach (var objects in obj)
            {
                DbSet.Remove(objects);
            }

            return context.SaveChanges();

        }

        public virtual void DetachAndUpdate(DbContext ctxt, T orginalT, T updatedT)
        {
            var objContext = ((IObjectContextAdapter)ctxt).ObjectContext;

            var objSet = objContext.CreateObjectSet<T>();

            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, orginalT);

            Object foundT;

            var exists = objContext.TryGetObjectByKey(entityKey, out foundT);

            if (!exists)
            {
                ctxt.Set<T>().Attach(updatedT);

                ctxt.Entry(updatedT).State = EntityState.Modified;
            }
            else
            {
                objContext.Detach(foundT);

                ctxt.Entry(updatedT).State = EntityState.Modified;
            }

        }

        public IEnumerable<T> ExecReadWithStoreProcedure(string query, params object[] parameters) => context.Database.SqlQuery<T>(query, parameters);

        public List<T> ExecuteSp(string sql) => context.Database.SqlQuery<T>(sql).ToList();

        public T ExecuteSPwithParameterForSingleRow(string sql, params object[] parameters) => context.Database.SqlQuery<T>(sql, parameters).FirstOrDefault();


        public List<T> ExecuteSPwithParameterForList(string query, params object[] parameters) => context.Database.SqlQuery<T>(query, parameters).ToList();

        public int ExecWithStoreProcedure(string query, params object[] parameters) => context.Database.ExecuteSqlCommand(query, parameters);

        public virtual bool Exists(T t)
        {
            var objContext = ((IObjectContextAdapter)context).ObjectContext;

            var objSet = objContext.CreateObjectSet<T>();

            var tKey = objContext.CreateEntityKey(objSet.EntitySet.Name, t);

            Object foundT;

            var exists = objContext.TryGetObjectByKey(tKey, out foundT);

            if (exists)
            {
                objContext.Detach(foundT);
            }

            return (exists);
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate) => DbSet.Where(predicate).AsQueryable();

        public IQueryable<T> Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;

            var resetSet = filter != null ? dbSet.Where(filter).AsQueryable() : dbSet.AsQueryable();

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);

            total = resetSet.Count();

            return resetSet.AsQueryable();
        }

        public T Find(params object[] keys) => DbSet.Find(keys);

        public T Find(Expression<Func<T, bool>> predicate) => dbSet.SingleOrDefault(predicate);

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter!=null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeproperty) => current.Include(includeproperty));

            if (orderBy!=null)
            {
                return orderBy(query).AsEnumerable();
            }

            return query.AsEnumerable();
        }

       

        public virtual T GetById(object id) => DbSet.Find(id);

        public virtual IEnumerable<T> GetOrderBy(Expression<Func<T, bool>> filter = null, Expression<Func<T, bool>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter!=null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeproperty) => current.Include(includeproperty));

            if (orderBy!=null)
            {
                return query.OrderBy(orderBy);
            }

            return query.AsEnumerable();
        }

        public virtual IEnumerable<T> GetWithSql(string query, params object[] parameters) => dbSet.SqlQuery(query, parameters).ToList();

        public void Insert(T t) => dbSet.Add(t);
        public virtual int Update(T t)
        {
            if (!Exists(t))
            {
                dbSet.Attach(t);
            }

            context.Entry(t).State = EntityState.Modified;

            return context.SaveChanges();
        }

        public virtual void Update(T oldT, T newT)
        {
            if (!Exists(newT))
            {
                DbSet.Attach(newT);
            }

            context.Entry(oldT).State = EntityState.Modified;

            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        public object SortDirection { get; private set; }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RepositoryBase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            // TODO: uncomment the following line if the finalizer is overridden above.
            if (context!=null)
            {
                context.Dispose();
            }
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
