using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class TransmissionTypeController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/TransmissionType
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return PartialView("_AddNew");
        }

        [HttpPost]
        public ActionResult AddNew(TransmissionTypeViewModel transmissionTypeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TransmissionTypeRepository TransmissionTypeRepository = new TransmissionTypeRepository(new AutoSolutionContext());
                    bool IsExist = TransmissionTypeRepository.isExist(transmissionTypeViewModel.TransmissionTypeName);
                    if (!IsExist)
                    {
                        TransmissionType transmissionType = new TransmissionType();

                        transmissionType.TransmissionTypeName = transmissionTypeViewModel.TransmissionTypeName;
                        transmissionType.AddedDate = DateTime.Now;
                        transmissionType.UpdatedDate = DateTime.Now;
                        transmissionType.Description = transmissionTypeViewModel.Description;
                        transmissionType.ShortCode = transmissionTypeViewModel.ShortCode;
                        _unitOfWork.TransmissionType.Add(transmissionType);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                        return RedirectToAction("GetTransmissionType");

                    }
                    else
                    {
                        return RedirectToAction("GetTransmissionType");

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public ActionResult GetTransmissionType(int? pageNo)
        {
            try
            {
                var Items = _unitOfWork.TransmissionType.GetAll();
                TransmissionTypeViewModel transmissionTypeViewModel = new TransmissionTypeViewModel();
                int TotalCount = _unitOfWork.TransmissionType.Count();
                Pager pager = new Pager(TotalCount, pageNo, 10);
                transmissionTypeViewModel.TransmissionTypeList = Items;
                transmissionTypeViewModel.Pager = pager;
                return PartialView("_GetTransmissionType", transmissionTypeViewModel);
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

                var item = _unitOfWork.TransmissionType.GetByID(Convert.ToInt32(id));
                TransmissionTypeViewModel transmissionTypeViewModel = new TransmissionTypeViewModel();
                transmissionTypeViewModel.TransmissionTypeName = item.TransmissionTypeName;
                transmissionTypeViewModel.TransmissionTypeId = item.TransmissionTypeId;
                transmissionTypeViewModel.Description = item.Description;
                transmissionTypeViewModel.ShortCode = item.ShortCode;
                
                if (transmissionTypeViewModel != null)
                {
                    return PartialView("_EditTransmissionType", transmissionTypeViewModel);
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
        public ActionResult Edit(TransmissionTypeViewModel transmissionTypeViewModel)
        {
            TransmissionType EditTransmissionType = new TransmissionType();
            EditTransmissionType = _unitOfWork.TransmissionType.GetByID(transmissionTypeViewModel.TransmissionTypeId);
            EditTransmissionType.TransmissionTypeName = transmissionTypeViewModel.TransmissionTypeName;
            EditTransmissionType.Description = transmissionTypeViewModel.Description;
            EditTransmissionType.ShortCode = transmissionTypeViewModel.ShortCode;
            EditTransmissionType.UpdatedDate = DateTime.Now;
            _unitOfWork.TransmissionType.Update(EditTransmissionType);
            _unitOfWork.Complete();
            _unitOfWork.Dispose();
            return RedirectToAction("GetTransmissionType");
        }


        public ActionResult Details(string id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                TransmissionType transmissionType = _unitOfWork.TransmissionType.GetByID(Convert.ToInt32(id));
                TransmissionTypeViewModel transmissionTypeViewModel = new TransmissionTypeViewModel();
                transmissionTypeViewModel.TransmissionTypeName = transmissionType.TransmissionTypeName;
                transmissionTypeViewModel.Description = transmissionType.Description;
                transmissionTypeViewModel.ShortCode = transmissionType.ShortCode;
                transmissionTypeViewModel.AddedDate = transmissionType.AddedDate;
                transmissionTypeViewModel.UpdatedDate = transmissionType.UpdatedDate;
                
                if (transmissionTypeViewModel != null)
                {
                    return PartialView("_DetailsTransmissionType", transmissionTypeViewModel);
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