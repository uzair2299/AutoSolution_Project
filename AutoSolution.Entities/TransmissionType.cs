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

        public ICollection<CarVersion> CarVersions { get; set; }

    }
}
