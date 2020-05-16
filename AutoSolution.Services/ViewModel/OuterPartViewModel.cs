using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public  class OuterPartViewModel
    {
        public int PartsProductsCategoryId { get; set; }
        public string PartsProductsCategoryName { get; set; }
        public List<InnerPartViewModel> partInnerViewModelList { get; set; }
            public List<PartsProductsViewModel> PartsProductsViewModelsList { get; set; }
    }
}
