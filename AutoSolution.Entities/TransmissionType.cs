using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class TransmissionType
    {
        public int TransmissionTypeId { get; set; }
        public string TransmissionTypeName { get; set; }
        public string ShortCode { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }



    }
}
