using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class CartWrapper
    {
        public List<PartsProductsViewModel> PartsProductsViewModelList { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal ShipingCharges { get; set; } 
    }
}
