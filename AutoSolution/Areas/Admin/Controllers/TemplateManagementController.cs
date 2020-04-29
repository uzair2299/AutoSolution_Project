using AutoSolution.Database.DataBaseContext;
using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class TemplateManagementController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new AutoSolutionContext());
        // GET: Admin/TemplateManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNew()
        {
            return PartialView("_AddNewTemplate");
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult AddNew(JsonModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TemplateRepository templateRepository = new TemplateRepository(new AutoSolutionContext());
                    bool IsExist = templateRepository.isExist(model.TemplateShortCode);
                    if (!IsExist)
                    {

                        Template template = new Template();
                        template.TemplateTitle = model.TemplateTitle;
                        template.TemplateShortCode = model.TemplateShortCode;
                        template.AddedDate = DateTime.Now;
                        template.TemplateBody = model.TemplateBody;
                        _unitOfWork.Template.Add(template);
                        _unitOfWork.Complete();
                        _unitOfWork.Dispose();
                       return Json(new { Success = true, Message = ".." });
                    }
                    else
                    {
                        return Json(new { Success = true, Message = ".." });

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }



        public ActionResult GetTemplate(string search, int? pageNo)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.Template.Count();
                    var model = _unitOfWork.Template.GetTemplate(PageNo, TotalCount);
                    return PartialView("_GetTemplate", model);
                }
                else
                {
                    int PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
                    int TotalCount = _unitOfWork.Template.GetTemplateCount(search);
                    var model = _unitOfWork.Template.GetTemplate(PageNo, TotalCount, search);
                    return PartialView("_GetTemplate", model);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}