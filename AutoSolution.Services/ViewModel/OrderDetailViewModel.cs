using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
    public class OrderDetailViewModel
    {
        public string PartsProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ProductUnitPrice { get; set; }

    }
}
