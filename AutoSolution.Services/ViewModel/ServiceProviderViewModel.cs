using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
   public class ServiceProviderViewModel
    {
        public ServiceProviderViewModel()
        {
            SelectedServiceCategories = new List<ServiceCategoryUtility>();
        }
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }


        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
        public String Gender { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Display(Name = "Confrim Password")]
        public string ConfrimPassword { get; set; }
        public bool IsTermAndConditionAccepted { get; set; }


        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }


        [Display(Name = "Business Description")]
        public string BusinessDescription { get; set; }

        public List<ServiceCategoryUtility> SelectedServiceCategories { get; set; }
        public IEnumerable<ServiceCategoryUtility> ServiceCategoriesList { get; set; }

        /// <summary>
        /// selected province id  holds the unique key for entity.The unique key of the selected value will be the same as one of the elements of the SelectListItem.
        /// </summary>
        ///

        [Display(Name = "Select Province")]
        public string SelectedProvince { get; set; }
        public IEnumerable<SelectListItem> ProvincesList { get; set; }


        [Display(Name = "Select City")]
        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CitiesList { get; set; }
    }
}
