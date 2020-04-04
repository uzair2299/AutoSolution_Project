using AutoSolution.Database.DataBaseContext;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class UnitOfWork
    {
        private readonly AutoSolutionContext _context;
        public UnitOfWork(AutoSolutionContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            City = new CityRepository(_context);
            Province = new ProvinceRepository(_context);
            ServiceCategory = new ServiceCategoryRepository(_context);
        }
        public IUserRepository User { get; private set; }
        public ICityRepository City { get; private set; }
        public IProvinceRepository Province { get; private set; }
        public IServiceCategoryRepository ServiceCategory { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
