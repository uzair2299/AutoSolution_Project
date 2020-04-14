using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class UserRoles
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Roles")]
        public int RolesId { get; set; }
        public virtual Roles Roles { get; set; }
        public DateTime? AddedDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
