﻿using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSolution.Database.DataBaseContext;
using System.Data.Entity;
using System.Collections;

namespace AutoSolution.Services
{
    public class AutoSolutionRepository<T> : IRepository<T> where T : class
    {


        protected readonly DbContext Context;

        public AutoSolutionRepository(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
