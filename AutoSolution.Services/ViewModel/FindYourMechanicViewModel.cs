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
        [Required(ErrorMessage = "*City Area/Town is Requierd")]
        [Display(Name = "City Area Name")]
        public string SelectedCityAreaName { get; set; }
        [Display(Name = "Select Province")]
        [Required(ErrorMessage = "*Province is Requierd")]
        public int SelectedProvince { get; set; }
        public IEnumerable<SelectListItem> ProvinceList { get; set; }
        [Required(ErrorMessage = "*City is Requierd")]
        [Display(Name = "Select City")]
        public int SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CityList { get; set; }
        [Required(ErrorMessage = "*Service Category is Requierd")]
        public int SelectedServiceCategory { get; set; }
        public IEnumerable<SelectListItem> ServiceCategoryList { get; set; }
        //public List<CityArea> CityAreaList { get; set; }
        //public string SelectedCityArea { get; set; }
    }
}