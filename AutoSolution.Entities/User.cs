using AutoSolution.Entities.BaseEntities;
using System;
using System.Collections.Generic;
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
        //city
        //province
        //image
        public string Address { get; set; }
        public string UserType { get; set; }
        public int PasswordCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public float UserRating { get; set; }
        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }

    }
}

