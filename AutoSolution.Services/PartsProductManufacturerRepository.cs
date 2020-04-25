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
    public class PartsProductManufacturerRepository : AutoSolutionRepository<PartsProductManufacturer>, IPartsProductManufacturerRepository
    {
        public PartsProductManufacturerRepository(AutoSolutionContext context) : base(context) { }
        public IEnumerable<SelectListItem> GetPPManufacturerDropDown()
        {
            List<SelectListItem> items = Context.Set<PartsProductManufacturer>().OrderBy(n => n.PartsProductManufacturerName).Select(n => new SelectListItem
            {
                Value = n.PartsProductManufacturerId.ToString(),
                Text = n.PartsProductManufacturerName
            }).ToList();

            var CityTip = new SelectListItem()
            {
                Value = (-1).ToString(),
                Text = "-------------- Select Parts/Product Manufacturer & Maker  --------------"
            };
            items.Insert(0, CityTip);
            return new SelectList(items, "value", "Text");
        }

        public IEnumerable<SelectListItem> GetPPManufacturerDropDownEmpty()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "------------- Select Part/Product Manufacturer -------------"
                }
            };
            return new SelectList(items, "value", "Text");
        }

        public bool isExist(string PPPPManufacturer)
        {
            return AutoSolutionContext.PartsProductManufacturers.Any(x => x.PartsProductManufacturerName.Trim().ToLower() == PPPPManufacturer.Trim().ToLower());
        }

        public PartsProductManuVeiwModel GetPartsProductManu(int PageNo, int TotalCount)
        {
            var partsProductManuVeiwModel = new PartsProductManuVeiwModel()
            {
                PartsProductManufacturerList = AutoSolutionContext.PartsProductManufacturers.OrderBy(x => x.PartsProductManufacturerName).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };
            return partsProductManuVeiwModel;
        }

        public PartsProductManuVeiwModel GetPartsProductManu(int PageNo, int TotalCount, string SearchTerm)
        {

            var partsProductManuVeiwModel = new PartsProductManuVeiwModel()
            {

                PartsProductManufacturerList = AutoSolutionContext.PartsProductManufacturers.OrderBy(x => x.PartsProductManufacturerName).Where(x => x.PartsProductManufacturerName.Contains(SearchTerm)).Skip((PageNo - 1) * 10).Take(10).ToList(),
                Pager = new Pager(TotalCount, PageNo, 10)

            };

            return partsProductManuVeiwModel;
        }

        public int GetPartsProductManuCount(string SearchTerm)
        {
            return AutoSolutionContext.PartsProductManufacturers.OrderBy(x => x.PartsProductManufacturerName).Where(x => x.PartsProductManufacturerName.Contains(SearchTerm)).Count();

        }

        public AutoSolutionContext AutoSolutionContext
        {
            get { return Context as AutoSolutionContext; }
        }
    }
}
