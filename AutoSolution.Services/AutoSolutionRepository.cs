using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSolution.Database.DataBaseContext;
using System.Data.Entity;
using System.Collections;
using System.Linq.Expressions;

namespace AutoSolution.Services
{
    public class AutoSolutionRepository<T> : IRepository<T> where T : class
    {


        protected readonly DbContext Context;
        //protected DbSet<T> dbSet;


        public AutoSolutionRepository(DbContext context)
        {
            this.Context = context;
            //this.dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        public void Remove(int id)
        {
           T entity=  GetByID(id);
            Context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public bool Update(T entity)
        {
            if (entity == null)
            {
                return false;
            }
            else
            {
                Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            
            
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = Context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public int Count()
        {
            return Context.Set<T>().Count();
        }

        //public bool CheckIfExists<t>(Expression<Func<T, bool>> expr)
        //{
        //        return Context.Set<T>().Any(expr);   
        //}
    }
}
