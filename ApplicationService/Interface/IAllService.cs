using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interface
{
    public interface IAllService<T> where T : class
    {
        void Add(T model);

        void Update(T model);

        void Delete(object id);

        T GetEmptyModel();

        T GetOneModel(int Id);

        List<T> GetAllT();

    }
}
