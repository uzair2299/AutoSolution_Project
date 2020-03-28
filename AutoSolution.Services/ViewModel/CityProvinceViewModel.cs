using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class CityProvinceViewModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }

        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }

        public Pager pager { get; set; }

    }
}
