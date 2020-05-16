using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class InnerPartViewModel
    {
        public int PartsProductsSubCategoryId { get; set; }
        public string PartsProductsSubCategoryName { get; set; }
        public List<InnerMostPartViewModel> mostInnertPartViewModelList { get; set; }
    }
}
