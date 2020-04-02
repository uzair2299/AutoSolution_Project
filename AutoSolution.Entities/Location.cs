using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public class Location
    {
        public Location()
        {
            this.Provinces = new Province();
            this.Cities = new City();
        }
        [Key]
        public int LocationId { get; set; }
        public virtual ICollection<User> User { get; set; }

        public int CityId { get; set; }
        public virtual City Cities { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Provinces { get; set; }

    }
}
