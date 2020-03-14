using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    class ProvinceRepository:AutoSolutionRepository<Province>,IProvinceRepository
    {
        public ProvinceRepository(AutoSolutionContext context)
          : base(context)
        {
        }
    }
}
