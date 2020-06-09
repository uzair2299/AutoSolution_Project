using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;

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
            //user.UserFullName = consumerViewModel.First_Name + " " + consumerViewModel.Last_Name;
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
            user.UserRoles = autoSolutionRoleProvider.AddRolesTOUser(consumerViewModel.Email, "User");
            return user;
        }

        public DashboardPersonalInformation GetUser(int id)
        {
            var user = GetByID(id);
           
            RoleRepository roleRepository = new RoleRepository(new AutoSolutionContext());
            var UserRole =roleRepository.CheckIsUserInRole(user.Email);
            var province = new ProvinceRepository(new AutoSolutionContext());
            var city = new CityRepository(new AutoSolutionContext());
            var CityArea = new CityAreaRepository(new AutoSolutionContext());
            DashboardPersonalInformation ServiceProviderViewModel = new DashboardPersonalInformation()
            {

                First_Name = user.FirstName,
                Last_Name = user.LastName,
                Gender = user.Gender,
                userRole = UserRole[0].ToString(),
                PhoneNumber = user.PhoneNumber,
                MobileNumber = user.MobileNumber,
                Email = user.Email,
                SelfAddress = "Dummy",
                RegistrationDate = user.RegistrationDate,
               
                City = user.Cities.CityName,
                ProvincesList = province.GetProvincesForHome(),
                SelectedProvince = user.Cities.Province.ProvinceId.ToString(),
                CitiesList= city.GetCitiesForHome(user.Cities.Province.ProvinceId.ToString()),
                SelectedCity=user.CityId.ToString(),
               
            };

            if(UserRole[0]== "Service Provider") { 
            ServiceProviderViewModel.CityArea = user.CityArea?.CityAreaName;
            ServiceProviderViewModel.SelectedCityAreaName = user.CityArea.CityAreaName;
            ServiceProviderViewModel.SelectedCityAreaId = user.CityAreaID.ToString();
            }
            return ServiceProviderViewModel;
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
            //user.UserFullName = serviceProviderViewModel.First_Name + " " + serviceProviderViewModel.Last_Name;
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
            user.CityAreaID = Convert.ToInt32(serviceProviderViewModel.SelectedCityAreaId);
            user.UserRoles = autoSolutionRoleProvider.AddRolesTOUser(serviceProviderViewModel.Email, "Service Provider");
            user.UserServiceCatogories = userServiceCatogoryRepository.SelectedServiceCategories(serviceProviderViewModel.ServiceCategoriesList);
            return user;
        }

        public ServiceProviderWraper GetServiceProviders(int PageNo, int TotalCount)
        {

            ServiceProviderWraper serviceProviderWraper = new ServiceProviderWraper()
            {
                serviceProviderViewModelList = (from u in AutoSolutionContext.User
                                                join ur in AutoSolutionContext.UserRoles
                                                on u.UserId equals ur.UserId
                                                //join r in AutoSolutionContext.Roles
                                                //on ur.RolesId equals r.RolesId
                                                where ur.RolesId == 6
                                                orderby u.UserId
                                                select new ServiceProviderViewModel()
                                                {

                                                    First_Name = u.FirstName,
                                                    Last_Name = u.LastName,
                                                    Email = u.Email,
                                                    MobileNumber = u.MobileNumber,
                                                    PhoneNumber = u.PhoneNumber,
                                                    SelectedCity = u.Cities.CityName,
                                                    Address = u.Address,
                                                    BusinessDescription = u.BusinessDescription,
                                                    ImagePath = u.ImagePath,
                                                    IsActive = u.IsActive,
                                                    serviceCategoriesListFor = AutoSolutionContext.UserServiceCatogories.Where(x => x.UserId == u.UserId).Select(x => new ServiceCategoryViewModel
                                                    {
                                                        ServiceCategoryName = x.ServiceCategory.ServiceCategoryName
                                                    }).ToList()
                                                }
                   ).Skip((PageNo - 1) * 10).Take(10).ToList(),

                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return serviceProviderWraper;
        }
        public ServiceProviderWraperForHome GetServiceProviders(int PageNo, int TotalCount, string id)
        {
            int Id = Convert.ToInt32(id);
            ServiceCategoryRepository serviceCategoryRepository = new ServiceCategoryRepository(new AutoSolutionContext());
            ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
            CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
            CityAreaRepository cityAreaRepository = new CityAreaRepository(new AutoSolutionContext());
            ServiceProviderWraperForHome serviceProviderWraperForHome = new ServiceProviderWraperForHome()
            {
                FindYourMechanicViewModel =
                {
                    ServiceCategoryList = serviceCategoryRepository.GetServiceCategoryDropDown(),
                    ProvinceList=provinceRepository.GetProvincesForHome(),
                    CityList= cityRepository.GetCitiesForHome()
                },
                ServiceCategoriesList = AutoSolutionContext.ServiceCategories.ToList(),
                ServiceCategoryName = AutoSolutionContext.ServiceCategories.Where(x => x.ServiceCategoryId == Id).FirstOrDefault(),
                serviceProviderViewModelList = (from u in AutoSolutionContext.User
                                                join ur in AutoSolutionContext.UserRoles
                                                on u.UserId equals ur.UserId
                                                join USC in AutoSolutionContext.UserServiceCatogories
                                                on u.UserId equals USC.UserId
                                                where ur.RolesId == 6 && USC.ServiceCategoryId == Id
                                                orderby u.UserId
                                                select new ServiceProviderViewModel()
                                                {

                                                    First_Name = u.FirstName,
                                                    Last_Name = u.LastName,
                                                    Email = u.Email,
                                                    MobileNumber = u.MobileNumber,
                                                    PhoneNumber = u.PhoneNumber,
                                                    SelectedCity = u.Cities.CityName,
                                                    Address = u.Address,
                                                    BusinessDescription = u.BusinessDescription,
                                                    ImagePath = u.ImagePath,
                                                    IsActive = u.IsActive,
                                                    serviceCategoriesListFor = AutoSolutionContext.UserServiceCatogories.Where(x => x.UserId == u.UserId).Select(x => new ServiceCategoryViewModel
                                                    {
                                                        ServiceCategoryName = x.ServiceCategory.ServiceCategoryName
                                                    }).ToList()
                                                }

                   ).Skip((PageNo - 1) * 10).Take(10).ToList(),

                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return serviceProviderWraperForHome;
        }
        public ConsumerWraper GetUsers(int PageNo, int TotalCount)
        {

            ConsumerWraper consumerWraper = new ConsumerWraper()
            {
                consumerViewModelViewModelList = (from u in AutoSolutionContext.User
                                                  join ur in AutoSolutionContext.UserRoles
                                                  on u.UserId equals ur.UserId
                                                  //join r in AutoSolutionContext.Roles
                                                  //on ur.RolesId equals r.RolesId
                                                  where ur.RolesId == 6
                                                  orderby u.UserId
                                                  select new ConsumerViewModel()
                                                  {

                                                      First_Name = u.FirstName,
                                                      Last_Name = u.LastName,
                                                      Email = u.Email.Trim(),
                                                      MobileNumber = u.MobileNumber,
                                                      PhoneNumber = u.PhoneNumber,
                                                      SelectedCity = u.Cities.CityName
                                                  }
                   ).Skip((PageNo - 1) * 10).Take(10).ToList(),

                Pager = new Pager(TotalCount, PageNo, 10)
            };
            return consumerWraper;
        }
        public int GetServiceProviderCountWRTId(string id)
        {
            int Id = Convert.ToInt32(id);
            return AutoSolutionContext.UserServiceCatogories.Where(x => x.ServiceCategoryId == Id).Count();
        }

        public ServiceProviderWraperForHome GetServiceProvidersHomeSearch(int PageNo, int TotalCount, SelectYourInterest selectYourInterest)
        {
            int Id = selectYourInterest.findYourMechanic.SelectedServiceCategory;
            ServiceCategoryRepository serviceCategoryRepository = new ServiceCategoryRepository(new AutoSolutionContext());
            ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
            CityRepository cityRepository = new CityRepository(new AutoSolutionContext());
            CityAreaRepository cityAreaRepository = new CityAreaRepository(new AutoSolutionContext());
            ServiceProviderWraperForHome serviceProviderWraperForHome = new ServiceProviderWraperForHome()
            {
                FindYourMechanicViewModel =
                {
                    ServiceCategoryList = serviceCategoryRepository.GetServiceCategoryDropDown(),
                    ProvinceList=provinceRepository.GetProvincesForHome(),
                    CityList= cityRepository.GetCitiesForHome()
                },
                ServiceCategoriesList = AutoSolutionContext.ServiceCategories.ToList(),
                ServiceCategoryName = AutoSolutionContext.ServiceCategories.Where(x => x.ServiceCategoryId == Id).FirstOrDefault(),
                serviceProviderViewModelList = (from u in AutoSolutionContext.User
                                                join ur in AutoSolutionContext.UserRoles
                                                on u.UserId equals ur.UserId
                                                join USC in AutoSolutionContext.UserServiceCatogories
                                                on u.UserId equals USC.UserId
                                                where ((ur.RolesId == 6) && (USC.ServiceCategoryId == Id) &&
                                                (u.Cities.Province.ProvinceId == selectYourInterest.findYourMechanic.SelectedProvince) &&
                                                (u.Cities.CityId == selectYourInterest.findYourMechanic.SelectedCity) &&
                                                (u.CityAreaID == selectYourInterest.findYourMechanic.CityAreaID))
                                                orderby u.UserId
                                                select new ServiceProviderViewModel()
                                                {

                                                    First_Name = u.FirstName,
                                                    Last_Name = u.LastName,
                                                    Email = u.Email,
                                                    MobileNumber = u.MobileNumber,
                                                    PhoneNumber = u.PhoneNumber,
                                                    SelectedCity = u.Cities.CityName,
                                                    SelectedCityAreaName =u.CityArea.CityAreaName,
                                                    Address = u.Address,
                                                    BusinessDescription = u.BusinessDescription,
                                                    ImagePath = u.ImagePath,
                                                    IsActive = u.IsActive,
                                                    serviceCategoriesListFor = AutoSolutionContext.UserServiceCatogories.Where(x => x.UserId == u.UserId).Select(x => new ServiceCategoryViewModel
                                                    {
                                                        ServiceCategoryName = x.ServiceCategory.ServiceCategoryName
                                                    }).ToList()
                                                }

                   ).Skip((PageNo - 1) * 10).Take(10).ToList(),

                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return serviceProviderWraperForHome;
        }
        public int GetServiceProviderCountWRTHomeSearch(SelectYourInterest selectYourInterest)
        {
            int Id = selectYourInterest.findYourMechanic.SelectedServiceCategory;
            return (from u in AutoSolutionContext.User
                    join ur in AutoSolutionContext.UserRoles
                    on u.UserId equals ur.UserId
                    join USC in AutoSolutionContext.UserServiceCatogories
                    on u.UserId equals USC.UserId
                    where (
                    (ur.RolesId == 6) && (USC.ServiceCategoryId == Id) &&
                    (u.Cities.Province.ProvinceId == selectYourInterest.findYourMechanic.SelectedProvince) &&
                    (u.Cities.CityId == selectYourInterest.findYourMechanic.SelectedCity)&&
                   (u.CityAreaID == selectYourInterest.findYourMechanic.CityAreaID))
                    select new object() { }).Count();
        }
        public int GetServiceProvidersCount()
        {
            return AutoSolutionContext.UserRoles.Where(x => x.RolesId == 6).Count();
        }
        public int GetUsersCount()
        {
            return AutoSolutionContext.UserRoles.Where(x => x.RolesId == 5).Count();
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
//serviceCategoriesListFor= (from u in AutoSolutionContext.User
//                                              join usc in AutoSolutionContext.UserServiceCatogories
//                                              on u.UserId equals usc.UserId
//                                              join sc in AutoSolutionContext.ServiceCategories
//                                              on usc.ServiceCategoryId equals sc.ServiceCategoryId
//                                              where u.UserId == usc.UserId
//                                              select new ServiceCategoryViewModel()
//{
//    ServiceCategoryName = sc.ServiceCategoryName
//                                               }
//                                               ).ToList()


