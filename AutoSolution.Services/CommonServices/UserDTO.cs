﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.CommonServices
{
    public class UserDTO
    {

        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string MobileNumber1 { get; set; }
        public string Email { get; set; }
        public string EmailSecondary { get; set; }
        public bool IsConfrimEmail { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsTermAndConditionAccepted { get; set; }
    }
}
