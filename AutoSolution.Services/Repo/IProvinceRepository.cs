﻿using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
   public interface IProvinceRepository:IRepository<Province>
    {
        IEnumerable<SelectListItem> GetProvinces();
        IEnumerable<SelectListItem> GetProvincesForHome();
        bool isExist(string Province);
    }
}
