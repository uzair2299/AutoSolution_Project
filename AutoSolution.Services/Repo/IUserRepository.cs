using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
    public interface IUserRepository: IRepository<User>
    {
        ServiceProviderWraper GetServiceProviders(int PageNo, int TotalCount);
        ServiceProviderWraperForHome GetServiceProviders(int PageNo, int TotalCount, string id);

        ConsumerWraper GetUsers(int PageNo, int TotalCount);
        int GetServiceProvidersCount();
        int GetServiceProviderCountWRTId(string id);
        int GetServiceProviderCountWRTHomeSearch(SelectYourInterest selectYourInterest);
        ServiceProviderWraperForHome GetServiceProvidersHomeSearch(int PageNo, int TotalCount, SelectYourInterest selectYourInterest);
        int GetUsersCount();
        ServiceProviderViewModel CreateServiceProvider();
        ConsumerViewModel CreateConsumer();
        DashboardPersonalInformation GetUser(int id);
        User CreateConsumer(ConsumerViewModel consumerViewModel);
        //SignInViewModel GetSignInViewModel();
    }
}
