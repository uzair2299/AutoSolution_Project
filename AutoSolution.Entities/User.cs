using AutoSolution.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class User:BaseEntity
    {
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
        //province
        //image
        //servicesDescription
        //rating
        //usertype
        public string Address { get; set; }
        public int PasswordCount { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }





    }
}

