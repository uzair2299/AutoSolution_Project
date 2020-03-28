using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    class UserViewModel
    {
        public User user { get; set; }
        public IEnumerable<ServiceCategory> serviceCategories { get; set; }
        public IEnumerable<Province> provinces { get; set; }
        public IEnumerable<City> cities { get; set; }

    }
}
