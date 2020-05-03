﻿using AutoSolution.Entities;
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
        AdminSide GetServiceProviders(int PageNo, int TotalCount);
        int GetServiceProvidersCount();
        ServiceProviderViewModel CreateServiceProvider();
        ConsumerViewModel CreateConsumer();
        User CreateConsumer(ConsumerViewModel consumerViewModel);
        //SignInViewModel GetSignInViewModel();
    }
}
