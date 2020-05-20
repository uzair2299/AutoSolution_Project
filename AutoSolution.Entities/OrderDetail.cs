using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public  class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("PartsProduct")]
        public int PartsProductId { get; set; }
        public virtual PartsProduct PartsProduct { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }


        public int Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; }

        public decimal Discount { get; set; }
        public decimal ProductUnitPriceAfterDiscount { get; set; }

    }
}
