using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
    public interface IPartsProductsCategoryRepository : IRepository<PartsProductsCategory>
    {
        bool isExist(string GetPartsProductCategory);
        PartsProductsCategoryViewModel GetPartsProductsCategory(int PageNo, int TotalCount);

        PartsProductsCategoryViewModel GetPartsProductsCategory(int PageNo, int TotalCount, string SearchTerm);

        int GetPartsProductsCategoryCount(string SearchTerm);

    }
}
