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
    public class ConsumerViewModel
    {
        //public ConsumerViewModel()
        //{
           
        //}
        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "First Name is requierd")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Second Name is requierd")]
        [StringLength(75)]
        public string Last_Name { get; set; }


        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public int MobileNumber { get; set; }
        public String Gender { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        public string ConfrimPassword { get; set; }
        public bool IsTermAndConditionAccepted { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public Nullable<System.Guid> ActivetionCode { get; set; }
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
