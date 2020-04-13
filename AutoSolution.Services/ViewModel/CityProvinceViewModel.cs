using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
    public class CityProvinceViewModel
    {
        public CityProvinceViewModel()
        {
            CitiesList = new List<City>();
        }

        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Display(Name = "Province Name")]
        public string ProvinceName { get; set; }

        [Display(Name = "City Code")]
        public String CityCode { get; set; }
        public List<City> CitiesList { get; set; }
        
        [Display(Name = "Select Province")]
        public string SelectedProvince { get; set; }
        public IEnumerable<SelectListItem> ProvincesList { get; set; }
        public Pager Pager { get; set; }
    }
}
