using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public bool IsConfrimEmail { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
        public int  PhoneNumber { get; set; }
        public int MobileNumber { get; set; }
        public string WebSiteLink { get; set; }
        public string FacebookPageLink { get; set; }
        //image
        //servicesDescription
        //rating
        //usertype
        public string Address { get; set; }
        public int PasswordCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsTermAndConditionAccepted { get; set; }
        public bool RememberMe { get; set; }

        
        public ICollection<ServiceCategory> serviceCategories { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}

