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
            RoleRepository autoSolutionRoleProvider = new RoleRepository(new AutoSolutionContext());
            user.FirstName = consumerViewModel.First_Name;
            user.LastName = consumerViewModel.Last_Name;
            user.Password = EncryptPassword.PasswordToEncrypt(consumerViewModel.Password);
            //user.Password = consumerViewModel.Password;
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
           
            user.RememberMe = false;
            user.ActivetionCode = Guid.NewGuid();
            user.CityId = Convert.ToInt32(consumerViewModel.SelectedCity);
            user.UserRoles = autoSolutionRoleProvider.AddRolesTOUser(consumerViewModel.Email,"User");
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
            UserServiceCatogoryRepository userServiceCatogoryRepository = new UserServiceCatogoryRepository(new AutoSolutionContext());
            RoleRepository autoSolutionRoleProvider = new RoleRepository(new AutoSolutionContext());
            user.FirstName = serviceProviderViewModel.First_Name;
            user.LastName = serviceProviderViewModel.Last_Name;
            user.Password = EncryptPassword.PasswordToEncrypt(serviceProviderViewModel.Password);
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
            user.RememberMe = false;
            user.ActivetionCode = Guid.NewGuid();
            user.CityId = Convert.ToInt32(serviceProviderViewModel.SelectedCity);
            user.UserRoles = autoSolutionRoleProvider.AddRolesTOUser(serviceProviderViewModel.Email, "Service Provider");
            user.UserServiceCatogories = userServiceCatogoryRepository.SelectedServiceCategories(serviceProviderViewModel.ServiceCategoriesList);
            return user;
        }

        public AdminSide GetServiceProviders(int PageNo, int TotalCount)
        {


            AdminSide adminSide = new AdminSide()
            {
                serviceProviderViewModelList = (from u in AutoSolutionContext.User
                   join ur in AutoSolutionContext.UserRoles
                   on u.UserId equals ur.UserId
                   //join r in AutoSolutionContext.Roles
                   //on ur.RolesId equals r.RolesId
                   where ur.RolesId == 6
                   orderby u.FirstName
                   select new ServiceProviderViewModel()
                   {

                       First_Name = u.FirstName,
                       Last_Name = u.LastName,
                       Email = u.MobileNumber1,
                       Gender = u.Gender,
                       MobileNumber = u.MobileNumber,
                       PhoneNumber = u.PhoneNumber,
                       serviceCategoriesListFor= (from u in AutoSolutionContext.User 
                                               join sc in AutoSolutionContext.UserServiceCatogories
                                               on u.UserId equals sc.UserId
                                               where sc.UserId ==u.UserId
                                               select new ServiceCategoryViewModel()
                                               {
                                                   ServiceCategoryName=sc.ServiceCategory.ServiceCategoryName,
                                               }
                                               ).ToList()

                                               
                       
                       
                   }
                   ).Skip((PageNo - 1) * 10).Take(10).ToList(),

            Pager = new Pager(TotalCount, PageNo, 10)

            };
            return adminSide;
        }

        public int GetServiceProvidersCount()
        {
            return AutoSolutionContext.UserRoles.Where(x => x.RolesId == 6).Count();
        }
        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }

}
/*  1-- CreateConsumer
 *  2-- CreateServiceProvider
 *  3-- GetSignInViewModel
 * 
 * 
 * 
 */

//IsActive = u.IsActive,



//    FirstName = u.FirstName,
//    LastName=u.LastName,
//    Email=u.Email,
//    EmailSecondary=u.EmailSecondary,
//    DateOfBirth=u.DateOfBirth,
//    Address=u.Address,
//    Gender=u.Gender,
//    RegistrationDate=u.RegistrationDate,
//    MobileNumber=u.MobileNumber,
//    MobileNumber1=u.MobileNumber1,
//    PhoneNumber=u.PhoneNumber,
//    IsActive=u.IsActive,


//                ServiceCategoriesList = (from u in AutoSolutionContext.User
//            join sc in AutoSolutionContext.UserServiceCatogories
//            on u.UserId equals sc.ServiceCategoryId
//            select new
