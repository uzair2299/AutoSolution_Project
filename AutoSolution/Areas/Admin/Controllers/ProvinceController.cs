using AutoSolution.Entities;
using AutoSolution.Services;
using AutoSolution.Services.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoSolution.Areas.Admin.Controllers
{
    public class ProvinceController : Controller
    {
        private IRepository<Province> Repository;
        public ProvinceController()
        {
            this.Repository = new AutoSolutionRepository <Province>();
        }
        // GET: Admin/Province
        public ActionResult Index()
        {
            //Province model = null;
            var model = Repository.GetAll();
            return View(model);
        }

        public ActionResult ViewProvinces()
        {
            var model = Repository.GetAll();
            return View(model);
        }
        

       


    }
}