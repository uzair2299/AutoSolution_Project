using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class PartProductwraperForHome
    {
        public PartProductwraperForHome()
        {
            FindYourPart = new FindYourPartViewModel();
            PartsProductsCategory = new PartsProductsCategory();
        }
        public List<PartsProductsViewModel> PartsProductsViewModelsList { get; set; }
        public List<PartsProductsCategory> PartsProductsCategoriesList { get; set; }
        public PartsProductsCategory PartsProductsCategory { get; set; }
        public  FindYourPartViewModel FindYourPart { get; set; }
        public Pager Pager { get; set; }
    }
}
