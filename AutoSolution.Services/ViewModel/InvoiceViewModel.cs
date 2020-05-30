using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
  public   class InvoiceViewModel
    {
        public int OrderId { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string MobileNumber { get; set; }

        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SubTotal { get; set; }



        public string SelectedCity { get; set; }
        public string SelectedProvince { get; set; }

        public List<OrderDetailViewModel> orderDetails { get; set; }
    }
}
