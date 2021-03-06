﻿using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
    public interface ICityRepository: IRepository<City>
    {


        IEnumerable<SelectListItem> GetCities();
        IEnumerable<SelectListItem> GetCities(string Id);

        IEnumerable<SelectListItem> GetCitiesForHome();
        IEnumerable<SelectListItem> GetCitiesForHome(string Id);

    }
}
