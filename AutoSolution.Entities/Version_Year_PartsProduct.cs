using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public  class Version_Year_PartsProduct
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("CarVersion")]
        public int CarVersionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("CarYearOfManufacture")]

        public int CarYearOfManufactureId { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("PartsProduct")]

        public int PartsProductId { get; set; }

        public virtual CarVersion CarVersion { get; set; }
        public virtual CarYearOfManufacture CarYearOfManufacture { get; set; }
        public virtual PartsProduct PartsProduct { get; set; }
    }
}
