using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
   public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetByID(int ModelId);
        void Add(T obj);
        void  Update(T obj);
        void Delete(int ModelId);
        void Save();
    }
}
