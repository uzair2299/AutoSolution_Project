using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public class UserServiceCatogory
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? IsDeleteTime { get; set; }
        public DateTime ServiceAddedDate { get; set; }
        public virtual User User { get; set; }
        public  virtual ServiceCategory ServiceCategory { get; set; }

    }
}
