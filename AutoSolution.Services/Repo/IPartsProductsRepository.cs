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
   public  interface IPartsProductsRepository:IRepository<PartsProduct>
    {
        PartsProductsViewModel AddNewPartsProducts();
        PartsProductsViewModel GetPartsProducts(int PageNo, int TotalCount);
        PartsProductsViewModel GetPartsProducts(int PageNo, int TotalCount, string SearchTerm);
        PartProductwraperForHome GetPartsProducts(int PageNo, int TotalCount, int id);
        PartsProductsDetailViewModel PartProductDetail(string id);
        PartsProductsViewModel PartProductDetail(int? id,int Quantity);
        int GetPartProductCountWRTCategory(string id);
        int GetPartsProductsCount(string SearchTerm);
        bool isExist(string GetVehicleVersion, string SelectedPartProduct);
        OuterMostPartsViewModel GetPartsProductForHome();
    }
}
