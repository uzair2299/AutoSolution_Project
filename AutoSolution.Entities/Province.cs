using AutoSolution.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public class Province:BaseEntity
    {

        [DisplayName("Province Name")]
        public string ProvinceName { get; set; }
        //public string ProvinceCode { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Location> Location { get; set; }

    }

}
