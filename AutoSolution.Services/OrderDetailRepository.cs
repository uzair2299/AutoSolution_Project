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
    public class OrderDetailRepository : AutoSolutionRepository<OrderDetail>, IorderDetailRepository
    {
        public OrderDetailRepository(AutoSolutionContext context) : base(context) { }
    }
}
