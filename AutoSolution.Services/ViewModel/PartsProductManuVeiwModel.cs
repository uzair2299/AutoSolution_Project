using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class PartsProductManuVeiwModel
    {
        public int PartsProductManufacturerId { get; set; }
        [Display(Name = "Parts/Products Manufacturer Name : ")]
        public string PartsProductManufacturerName { get; set; }
        [Display(Name = "Parts/Products Manufacturer Code : ")]
        public string PartsProductManufacturerCode { get; set; }

        public string SearchTerm { get; set; }
        public List<PartsProductManufacturer> PartsProductManufacturerList { get; set; }

        public Pager Pager { get; set; }
    }
}
