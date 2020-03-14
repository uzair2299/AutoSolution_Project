using AutoSolution.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AutoSolution.Entities
{
    public class City:BaseEntity
    {
        public string CityName { get; set; }
        public string CityCode { get; set; }
        public bool IsDelete { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<Location> Location { get; set; }
        
        

    }
}

