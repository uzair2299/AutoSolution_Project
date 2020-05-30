using AutoSolution.Entities;
using AutoSolution.Services.CommonServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
   public class ServiceProviderViewModel
    {
        public ServiceProviderViewModel()
        {
            ServiceCategoriesList = new List<ServiceCategoryUtility>();  
         }
        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "*First name is required")]
        public string First_Name { get; set; }


        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "*Last name is required")]
        public string Last_Name { get; set; }


        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Select City Area/Town Name")]
        [Required(ErrorMessage = "*City area/town is required")]
        public string SelectedCityAreaName { get; set; }

        public string SelectedCityAreaId { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "*Mobile phone is required")]

        [RegularExpression(@"^((\+92)|(0092))-{0,1}\d{3}-{0,1}\d{7}$|^\d{11}$|^\d{4}-\d{7}$", ErrorMessage = "Please enter a valid mobile number")]
        //[RegularExpression("^03\\d{9}$", ErrorMessage = "*Please enter a valid mobile number")]
        public string MobileNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber1 { get; set; }


        [Required(ErrorMessage = "*Please select your gender")]
        public string Gender { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "*Enter your email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters are required")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "*Only Alphabets and Numbers allowed.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*Confirm password is required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "*The Password and Confirm Password do not match.")]
        public string ConfrimPassword { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage = "*Accept terms and conditions before sign up")]

        public bool IsTermAndConditionAccepted { get; set; }
        public bool IsActive { get; set; }


        [Display(Name = "Bussiness Address")]
        public string Address { get; set; }
        [Display(Name = "Address")]
        public string SelfAddress { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Registration Date")]
        public DateTime? RegistrationDate { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }


        [Display(Name = "Business Description")]
        [Required(ErrorMessage = "*Business description is required")]
        public string BusinessDescription { get; set; }
        [Required(ErrorMessage = "Select your services")]

        public List<ServiceCategoryUtility> ServiceCategoriesList { get; set; }

        /// <summary>
        /// selected province id  holds the unique key for entity.The unique key of the selected value will be the same as one of the elements of the SelectListItem.
        /// </summary>
        ///

        [Display(Name = "Select Province")]
        [Required(ErrorMessage = "*Select province")]

        public string SelectedProvince { get; set; }
        public IEnumerable<SelectListItem> ProvincesList { get; set; }


        [Display(Name = "Select City")]
        [Required(ErrorMessage = "*Select City")]

        public string SelectedCity { get; set; }
        public IEnumerable<SelectListItem> CitiesList { get; set; }
        public int TotalNumberOfServiceProvider { get; set; }
        public List<ServiceCategoryViewModel> serviceCategoriesListFor { get; set; }
        public List<ServiceCategory> serviceCategoriesNew { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "City Area/Town")]

        public string CityArea { get; set; }


    }
}
