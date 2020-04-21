using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class PartsProductsCategoryViewModel
    {
        public int PartsProductsCategoryId { get; set; }
        public string PartsProductsCategoryName { get; set; }

        public string SearchTerm { get; set; }
        public List<PartsProductsCategory> PartsProductsCategoryList { get; set; }

        public Pager Pager { get; set; }
    }
}
