using AutoSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.ViewModel
{
   public class ProvinceViewModel
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public string AddedBy { get; set; }
        public bool IsActive { get; set; }
        public List<Province> ProvinceList { get; set; }
        public Pager Pager { get; set; }
    }
}
