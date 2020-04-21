using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSolution.Services
{
    public class PartsProductsCategoryRepository: AutoSolutionRepository<PartsProductsCategory>, IPartsProductsCategoryRepository
    {
        public PartsProductsCategoryRepository(AutoSolutionContext context) : base(context) { }

        public bool isExist(string GetPartsProductCategory)
        {
            return AutoSolutionContext.PartsProductsCategories.Any(x => x.PartsProductsCategoryName.Trim().ToLower() == GetPartsProductCategory.Trim().ToLower());
        }

        public PartsProductsCategoryViewModel GetPartsProductsCategory(int PageNo, int TotalCount)
        {
            var PartsProductsCategoryViewModel = new PartsProductsCategoryViewModel()
            {
                PartsProductsCategoryList = AutoSolutionContext.PartsProductsCategories.OrderBy(x => x.PartsProductsCategoryName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return PartsProductsCategoryViewModel;
        }

        public PartsProductsCategoryViewModel GetPartsProductsCategory(int PageNo, int TotalCount, string SearchTerm)
        {
            var PartsProductsCategoryViewModel = new PartsProductsCategoryViewModel()
            {

                PartsProductsCategoryList = AutoSolutionContext.PartsProductsCategories.OrderBy(x => x.PartsProductsCategoryName).Where(x => x.PartsProductsCategoryName.Contains(SearchTerm)).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return PartsProductsCategoryViewModel;

        }

        public int GetPartsProductsCategoryCount(string SearchTerm)
        {

            return AutoSolutionContext.PartsProductsCategories.OrderBy(x => x.PartsProductsCategoryName).Where(x => x.PartsProductsCategoryName.Contains(SearchTerm)).Count();
        }
        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
