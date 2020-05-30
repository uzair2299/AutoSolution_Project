using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }


        public string MobileNumber { get; set; }
        public String MobileNumberCode { get; set; }
        public bool MobileIsConfirmed { get; set; }

        public string ShippingAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SubTotal { get; set; }
        //public bool OrderFlag { get; set; }
        public int?UserId { get; set; }
        public virtual User User { get; set; }

        public int? CityId { get; set; }
        public virtual City Cities { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
