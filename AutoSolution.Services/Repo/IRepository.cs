using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
   public interface IRepository<T> where T:class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        List<T> GetAll();
        T GetByID(int ModelId);
        T Add(T obj);
        bool  Update(T obj);
        void Remove(int Id);

        int Count();
    }
}
