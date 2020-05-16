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
    public class FindYourMechanicViewModel
    {
        public int CityAreaID { get; set; }
        [Display(Name = "City Area Name")]
        public string SelectedCityAreaName { get; set; }
        [Display(Name = "Select Province")]
        public string SelectedProvince { get; set; }
        public IEnumerable<SelectListItem> ProvinceList { get; set; }
        [Display(Name = "Select City")]
        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        public string SelectedServiceCategory { get; set; }
        public IEnumerable<SelectListItem> ServiceCategoryList { get; set; }
        public List<CityArea> CityAreaList { get; set; }
    }
}
