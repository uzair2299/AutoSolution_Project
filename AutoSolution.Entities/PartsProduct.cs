using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class PartsProduct
    {
        public int PartsProductId { get; set; }
        public string PartsProductName { get; set; }
        public DateTime? AddedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public int? startYear { get; set; }
        public int? EndYear { get; set; }
        public decimal UnitPrice { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int PartsProductsSubCategoryId { get; set; }
        public virtual PartsProductsSubCategory PartsProductsSubCategory { get; set; }

        public int? VehicleModelId { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }

        //public int? VehicleVersionId { get; set; }
        //public virtual VehicleVersion VehicleVersion { get; set; }

        public int? VehicleManufacturerId { get; set; }
        public virtual VehicleManufacturer VehicleManufacturer { get; set; }


        public int? PartsProductManufacturerId { get; set; }
        public virtual PartsProductManufacturer PartsProductManufacturer { get; set; }
        public virtual ICollection<PartsProductSupplier> PartsProductSuppliers { get; set; }
       public virtual ICollection<PartProductImages> PartProductImages { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
