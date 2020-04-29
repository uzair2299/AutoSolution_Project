using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public class Template
    {
        public int TemplateId { get; set; }
        public string TemplateShortCode { get; set; }
        public string TemplateTitle { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedTime { get; set; }
        [Column(TypeName = "Text")]
        public string TemplateBody { get; set; } 
    }
}
