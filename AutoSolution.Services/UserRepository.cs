using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    class UserRepository : AutoSolutionRepository<User>, IUserRepository
    {
        public UserRepository(AutoSolutionContext context)
           : base(context)
        {
        }

        public ConsumerViewModel CreateConsumer()
        {
            var province = new ProvinceRepository(new AutoSolutionContext());
            var city = new CityRepository(new AutoSolutionContext());
            var consumer = new ConsumerViewModel()
            {
                CitiesList = city.GetCities(),
                ProvincesList = province.GetProvinces(),
            };
            return consumer;
        }

        public ServiceProviderViewModel CreateServiceProvider()
        {
            var province = new ProvinceRepository(new AutoSolutionContext());
            var city = new CityRepository(new AutoSolutionContext());
            var customer = new ServiceProviderViewModel()
            {
                CitiesList = city.GetCities(),
                ProvincesList = province.GetProvinces(),
        };
            return customer;
        }
    }

}
