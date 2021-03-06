﻿using AutoSolution.Entities;
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
      
        
        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "*First Name is Requierd")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "*Second Name is Requierd")]
        [StringLength(50)]
        public string Last_Name { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "*Please select Gender Type")]
        public String Gender { get; set; }

        [Display(Name = "E-mail")]

        [Required(ErrorMessage = "*Email is Requierd")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters are required")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The Password and Confirm Password do not match.")]
        public string ConfrimPassword { get; set; }
        [Required(ErrorMessage = "*Please Accept the Terms and Conditions before register")]
        
        public bool IsTermAndConditionAccepted { get; set; }

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
