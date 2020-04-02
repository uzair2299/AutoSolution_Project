using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoSolution.Entities
{
    public class City
    {
        //public City()
        //{
        //    this.Province = new Province();
        //}
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public bool IsDelete { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }


        //public virtual ICollection<Location> Location { get; set; }
        
        

    }
}

