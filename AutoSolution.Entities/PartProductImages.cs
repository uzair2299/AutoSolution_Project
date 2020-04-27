using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public class PartProductImages
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Image")]
        public int ImageId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("PartsProduct")]
        public int PartsProductId { get; set; }
        public virtual PartsProduct PartsProduct { get; set; }
        public virtual Image Image { get; set; }
    }
}
