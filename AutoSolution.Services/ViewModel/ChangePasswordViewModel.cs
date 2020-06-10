using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class ChangePasswordViewModel
    {
        public int UserId { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        [Required(ErrorMessage = "*Password is required")]
        public string CurrentPassword { get; set; }


        [Display(Name = "New Password")]
        [Required(ErrorMessage = "*Password is required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters are required")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "*Only Alphabets and Numbers allowed.")]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "*Confirm password is required")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "*The Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
