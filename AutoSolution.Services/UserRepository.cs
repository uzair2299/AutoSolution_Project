using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
   public class UserRepository : AutoSolutionRepository<User>, IUserRepository
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
                ProvincesList = province.GetProvinces(),
                CitiesList = city.GetCities(),
                

            };
            return consumer;
        }

        public User CreateConsumer(ConsumerViewModel consumerViewModel)
        {
            User user = new User();
            user.FirstName = consumerViewModel.First_Name;
            user.LastName = consumerViewModel.Last_Name;
            user.Password = consumerViewModel.Password;
            user.Email = consumerViewModel.Email;
            user.MobileNumber = consumerViewModel.MobileNumber;
            user.PhoneNumber = consumerViewModel.PhoneNumber;
            user.Gender = consumerViewModel.Gender;
            user.IsConfrimEmail = false;
            user.IsActive = false;
            user.IsTermAndConditionAccepted = consumerViewModel.IsTermAndConditionAccepted;
            user.IsDelete = false;
            user.DateOfBirth = DateTime.Now;
            user.LastUpdateDate = DateTime.Now;
            user.RegistrationDate = DateTime.Now;
            user.Address = "-";            
            user.PasswordCount = 0;
            user.UserTypeId = 1;
            user.RememberMe = false;
            user.CityId = Convert.ToInt32(consumerViewModel.SelectedCity);
            return user;
        }

        public ServiceProviderViewModel CreateServiceProvider()

        {
        var province = new ProvinceRepository(new AutoSolutionContext());
        var city = new CityRepository(new AutoSolutionContext());
        var serviceCategories = new ServiceCategoryRepository(new AutoSolutionContext());
            var serviceProvider = new ServiceProviderViewModel()
            {
                ProvincesList = province.GetProvinces(),
                CitiesList = city.GetCities(),
                ServiceCategoriesList = serviceCategories.GetServiceCategories()
        };
            return serviceProvider;
        }
        public User CreateServiceProvider(ServiceProviderViewModel serviceProviderViewModel)

        {
            User user = new User();
            user.FirstName = serviceProviderViewModel.First_Name;
            user.LastName = serviceProviderViewModel.Last_Name;
            user.Password = serviceProviderViewModel.Password;
            user.Email = serviceProviderViewModel.Email;
            user.MobileNumber = serviceProviderViewModel.MobileNumber;
            user.PhoneNumber = serviceProviderViewModel.PhoneNumber;
            user.Gender = serviceProviderViewModel.Gender;
            user.IsConfrimEmail = false;
            user.IsActive = false;
            user.IsTermAndConditionAccepted = serviceProviderViewModel.IsTermAndConditionAccepted;
            user.IsDelete = false;
            user.DateOfBirth = DateTime.Now;
            user.LastUpdateDate = DateTime.Now;
            user.RegistrationDate = DateTime.Now;
            user.Address = "-";
            user.PasswordCount = 0;
            user.UserTypeId = 1;
            user.RememberMe = false;
            user.CityId = Convert.ToInt32(serviceProviderViewModel.SelectedCity);
            return user;
        }


        public string SHA_256Password(string password)
        {
            SHA256 my256hash = SHA256.Create();
            byte[] hashPassword = my256hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder mybuilder = new StringBuilder();
            for (int i = 0; i < hashPassword.Length; i++)
            {
                mybuilder.Append(hashPassword[i].ToString("x2"));
            }
            return mybuilder.ToString();
        }
    }

}
