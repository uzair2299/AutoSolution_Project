using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class ChangePassword
    {
        public int UserId { get; set; }
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "*OTP is requierd")]
        public string OTP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Password is requierd")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters are required")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "*Only Alphabets and Numbers allowed.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Confirm Password is requierd")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Minimum 8 characters are required")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "*Only Alphabets and Numbers allowed.")]
        [Compare("Password", ErrorMessage = "*Confirm Password should match with Password")]
        public string ConfirmPassword { get; set; }
    }
}
