using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class TemplateViewModel
    {
        public int TemplateId { get; set; }
        [Display(Name = "Template Short Code")]
        public string TemplateShortCode { get; set; }
        [Display(Name = "Template Title")]
        public string TemplateTitle { get; set; }

        [Display(Name = "Template Body")]
        [Column(TypeName = "Text")]
        public string TemplateBody { get; set; }
        public List<Template> TemplateList { get; set; }
        [Display(Name = "Search Term")]
        public string SearchTerm { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedTime { get; set; }
        public Pager Pager { get; set; }

    }
}
