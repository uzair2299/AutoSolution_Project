using AutoSolution.Entities;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services.Repo
{
    public interface IPartsSubCategoryRepository: IRepository<PartsProductsSubCategory>
    {
        bool isExist(string PartsSubCategory);
        PartsSubCategoryViewModel AddNewPartsSubCategory();
        PartsSubCategoryViewModel GetPartsSubCategory(int PageNo, int TotalCount);
        PartsSubCategoryViewModel GetPartsSubCategory(int PageNo, int TotalCount, string SearchTerm, string SelectedPartsProductsCategory);
        int GetPartsSubCategoryCount(string SearchTerm, string SelectedPartsProductsCategory);

    }
}
