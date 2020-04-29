using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class JsonModel
    {

        [Display(Name = "Template Short Code")]
        public string TemplateShortCode { get; set; }
        [Display(Name = "Template Title")]
        public string TemplateTitle { get; set; }

        [Display(Name = "Template Body")]
        [Column(TypeName = "Text")]
        public string TemplateBody { get; set; }
    }
}
