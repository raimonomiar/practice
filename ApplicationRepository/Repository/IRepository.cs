using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationRepository.Repository
{
    public interface IRepository<T>:IDisposable where T : class
    {
        IEnumerable<T> All();

        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        IQueryable<T>    Filter(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        bool Contains(Expression<Func<T, bool>> predicate);

        T Find(params object[] keys);

        T Find(Expression<Func<T, bool>> predicate);

        T Create(T t);

        int Count { get; }

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        IEnumerable<T> GetOrderBy(Expression<Func<T, bool>> filter = null,
            Expression<Func<T, bool>> orderBy = null,
            string includeProperties = "");

        T GetById(object id);

        IEnumerable<T> GetWithSql(string query, params object[] parameters);

        void Insert(T t);

        void Delete(object id);

        void Delete(T t);

        int Update(T t);

        void Update(T oldT, T newT);

        void DetachAndUpdate(System.Data.Entity.DbContext ctxt, T orginalT, T updatedT);

        Boolean Exists(T t);

        int Delete(Expression<Func<T, bool>> predicate);

        int ExecWithStoreProcedure(string query, params object[] parameters);

        IEnumerable<T> ExecReadWithStoreProcedure(string query, params object[] parameters);

        List<T> ExecuteSPwithParameterForList(string query, params object[] parameters);


    }
}
