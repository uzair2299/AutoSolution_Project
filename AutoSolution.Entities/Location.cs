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
        [Key]
        public int LocationId { get; set; }
        public virtual ICollection<User> User { get; set; }

        public virtual City Cities { get; set; }
        public virtual Province Provinces { get; set; }

    }
}
