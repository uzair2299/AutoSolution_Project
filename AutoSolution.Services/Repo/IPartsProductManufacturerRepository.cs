using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services.Repo
{
    public  interface IPartsProductManufacturerRepository : IRepository<PartsProductManufacturer>
    {
        IEnumerable<SelectListItem> GetPPManufacturerDropDown();


        PartsProductManuVeiwModel GetPartsProductManu(int PageNo, int TotalCount);

        PartsProductManuVeiwModel GetPartsProductManu(int PageNo, int TotalCount, string SearchTerm);

        int GetPartsProductManuCount(string SearchTerm);
        bool isExist(string PPPPManufacturer);
    }
}
