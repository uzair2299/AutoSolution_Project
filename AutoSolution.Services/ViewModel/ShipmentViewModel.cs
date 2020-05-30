using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.ViewModel
{
    public class ShipmentViewModel
    {
        public int? UserId { get; set; }
        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "*First Name is Requierd")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "*Second Name is Requierd")]
        [StringLength(50)]
        public string Last_Name { get; set; }


        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public String MobileNumberCode { get; set; }
        public bool MobileIsConfirmed { get; set; }

        public string ShippingAddress { get; set; }

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
        public CartWrapper CartWrapper { get; set; } 
    }
}
