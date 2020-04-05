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
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PhoneNumber { get; set; }
        public int MobileNumber { get; set; }
        public int MobileNumber1 { get; set; }
        public string Email { get; set; }
        public string EmailSecondary { get; set; } 
        public bool IsConfrimEmail { get; set; }
        public int EmailSendCounter { get; set; }
        public DateTime? EmailSendTime { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
        public int PasswordCount { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsTermAndConditionAccepted { get; set; }
        public bool RememberMe { get; set; }

        
        public virtual  ICollection<UserServiceCatogory> UserServiceCatogories { get; set; }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public int CityId { get; set; }
        public virtual City Cities { get; set; }
    }
}

