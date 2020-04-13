using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public class PartsProductSupplier
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("PartsProduct")]
        public int PartsProductId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual PartsProduct PartsProduct { get; set; }

    }
}
