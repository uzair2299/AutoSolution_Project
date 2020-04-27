using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string ContentType { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
