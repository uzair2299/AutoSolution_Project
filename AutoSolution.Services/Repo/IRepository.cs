using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
   public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        T GetByID(int ModelId);
        T Add(T obj);
        void  Update(T obj);
        void Remove(int Id);
    }
}
