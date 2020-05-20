using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class WishList
    {
        public int WishListId { get; set; }
        public int PartsProductId { get; set; }
        public virtual PartsProduct PartsProduct { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime DateTime { get; set; }
    }
}
