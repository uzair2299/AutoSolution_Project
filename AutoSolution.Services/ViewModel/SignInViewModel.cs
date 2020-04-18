using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class SignInViewModel
    {

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "*Email is Requierd")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "*Password is Requierd")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
