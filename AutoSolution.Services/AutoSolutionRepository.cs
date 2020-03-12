using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSolution.Database.DataBaseContext;
using System.Data.Entity;

namespace AutoSolution.Services
{
    public class AutoSolutionRepository<T>:IRepository<T> where T:class
    {
        protected readonly AutoSolutionContext _autoSolutionContext = null;
        protected DbSet<T> DbEntity = null;

        public AutoSolutionRepository()
        {
            this._autoSolutionContext = new AutoSolutionContext();
            DbEntity = _autoSolutionContext.Set<T>();
        }

        

        public void Add(T obj)
        {
            DbEntity.Add(obj);
            _autoSolutionContext.SaveChanges();
        }

        public void Delete(int ModelId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return DbEntity.ToList();
        }

        public T GetByID(int ModelId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _autoSolutionContext.SaveChanges();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}