using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.Repo;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class ProvinceController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());

        // GET: Admin/Province
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return PartialView("_AddNew");
        }
        [HttpPost]
        public ActionResult AddNew(ProvinceViewModel provinceViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProvinceRepository provinceRepository = new ProvinceRepository(new AutoSolutionContext());
                    bool IsExist = provinceRepository.isExist(provinceViewModel.ProvinceName);
                    if (!IsExist)
                    {
                        Province province = new Province();
                        province.ProvinceName = provinceViewModel.ProvinceName;
                        province.ProvinceCode = provinceViewModel.ProvinceCode;
                        province.IsActive = true;
                        _unitOfWork.Province.Add(province);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetProvince");

                    }
                    else
                    {
                        return RedirectToAction("GetProvince");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public ActionResult GetProvince(int? pageNo)
        {
            try
            {
                var Items = _unitOfWork.Province.GetAll();
                ProvinceViewModel provinceViewModel = new ProvinceViewModel();
                int TotalCount = _unitOfWork.Province.Count();
                Pager pager = new Pager(TotalCount, pageNo, 10);
                provinceViewModel.ProvinceList = Items;
                provinceViewModel.Pager = pager;
                return PartialView("_GetProvince", provinceViewModel);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }

        public ActionResult Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var item = _unitOfWork.Province.GetByID(Convert.ToInt32(id));
                ProvinceViewModel provinceViewModel = new ProvinceViewModel();
                provinceViewModel.ProvinceName = item.ProvinceName;
                provinceViewModel.ProvinceCode = item.ProvinceCode;
                provinceViewModel.IsActive = item.IsActive;
                if (provinceViewModel != null)
                {
                    return PartialView("_EditProvince", provinceViewModel);
                }
                else
                    return HttpNotFound();



            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(ProvinceViewModel provinceViewModel)
        {
            Province province = new Province();
            province = _unitOfWork.Province.GetByID(provinceViewModel.ProvinceId);
            province.ProvinceName = provinceViewModel.ProvinceName;
            province.ProvinceCode = provinceViewModel.ProvinceCode;
            province.IsActive = provinceViewModel.IsActive;
            province.ProvinceId = provinceViewModel.ProvinceId;
            _unitOfWork.Province.Update(province);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return RedirectToAction("GetProvince");
        }

        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                
                Province province =  _unitOfWork.Province.GetByID(Convert.ToInt32(id));
                ProvinceViewModel provinceViewModel = new ProvinceViewModel();

                provinceViewModel.ProvinceName = province.ProvinceName;
                provinceViewModel.ProvinceCode = province.ProvinceCode;
                provinceViewModel.IsActive = province.IsActive;
                if (provinceViewModel != null)
                {
                    return PartialView("_DetailsProvince", provinceViewModel);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }







    }
}