using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoSolution.Database.DataBaseContext;

namespace AutoSolution.Services
{
    public class AutoSolutionRepository<T>:IRepository<T> where T:class
    {
        protected readonly AutoSolutionContext _autoSolutionContext = null;
        public AutoSolutionRepository(AutoSolutionContext _autoSolutionContext)
        {
            this._autoSolutionContext = _autoSolutionContext;
        }
    }
}