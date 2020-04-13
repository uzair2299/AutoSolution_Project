using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.CommonServices
{
   public  class ForgotPassword
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "User Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Email Id Required")]
        public string EmailId { get; set; }
    }
}
