using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
   public class UserViewModel
    { 
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
        public string Address { get; set; }
        public bool IsTermAndConditionAccepted { get; set; }
        public bool RememberMe { get; set; }

        public List<ServiceCategory> serviceCategories { get; set; }

        /// <summary>
        /// selected province id  holds the unique key for entity.The unique key of the selected value will be the same as one of the elements of the SelectListItem.
        /// </summary>
        public int SelectedProvinceId { get; set; }
        public IEnumerable<SelectListItem> ProvincesList { get; set; }


        public int SelectedCityId { get; set; }
        public IEnumerable<SelectListItem> CitiesList { get; set; }

    }
}
