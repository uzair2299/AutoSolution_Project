using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AutoSolution.Services
{
    public class PartsSubCategoryRepository: AutoSolutionRepository<PartsProductsSubCategory>, IPartsSubCategoryRepository
    {
        public PartsSubCategoryRepository(AutoSolutionContext context)
           : base(context)
        {
        }

        public bool isExist(string PartsSubCategory)
        {
            return AutoSolutionContext.PartsProductsSubCategories.Any(x => x.PartsProductsSubCategoryName.Trim().ToLower() == PartsSubCategory.Trim().ToLower());
        }

        public IEnumerable<SelectListItem> GetPartsProductCategoryDropDown()
        {
            List<SelectListItem> items = Context.Set<PartsProductsCategory>().OrderBy(n => n.PartsProductsCategoryName).Select(n => new SelectListItem
            {
                Value = n.PartsProductsCategoryId.ToString(),
                Text = n.PartsProductsCategoryName
            }).ToList();

            var Tip = new SelectListItem()
            {
                Value = null,
                Text = "----------- Select Parts/Product Category ------------"
            };
            items.Insert(0, Tip);
            return new SelectList(items, "value", "Text");
        }

        public PartsSubCategoryViewModel AddNewPartsSubCategory()
        {
            var PartsSubCateforyViewModel = new PartsSubCategoryViewModel()
            {
                PartsProductsCategoryList = GetPartsProductCategoryDropDown() 
            };
            return PartsSubCateforyViewModel;
        }

        public PartsSubCategoryViewModel GetPartsSubCategory(int PageNo, int TotalCount)
        {
            var PartsSubCateforyViewModel = new PartsSubCategoryViewModel()
            {
                PartsProductsCategoryList = GetPartsProductCategoryDropDown(),
                PartsProductsSubCategoryList = AutoSolutionContext.PartsProductsSubCategories.OrderBy(x => x.PartsProductsSubCategoryName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return PartsSubCateforyViewModel;

        }


        public PartsSubCategoryViewModel GetPartsSubCategory(int PageNo, int TotalCount, string SearchTerm, string SelectedPartsProductsCategory)
        {
            int SelectedItem = Convert.ToInt32(SelectedPartsProductsCategory);
            var PartsSubCateforyViewModel = new PartsSubCategoryViewModel()
            {
                PartsProductsCategoryList = GetPartsProductCategoryDropDown(),
                PartsProductsSubCategoryList = AutoSolutionContext.PartsProductsSubCategories.OrderBy(x => x.PartsProductsSubCategoryName).Where(x => x.PartsProductsSubCategoryName.Contains(SearchTerm) && x.PartsProductsCategoryId == SelectedItem).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return PartsSubCateforyViewModel;

        }

        public int GetPartsSubCategoryCount(string SearchTerm, string SelectedPartsProductsCategory)
        {
            int SelectedItem = Convert.ToInt32(SelectedPartsProductsCategory);

            return AutoSolutionContext.PartsProductsSubCategories.OrderBy(x => x.PartsProductsSubCategoryName).Where(x => x.PartsProductsSubCategoryName.Contains(SearchTerm) && x.PartsProductsCategoryId == SelectedItem).Count();
        }
        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
