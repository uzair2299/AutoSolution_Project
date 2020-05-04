using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
   public  class CityArea
    {
        public int CityAreaID { get; set; }
        public string CityAreaName { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
