using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Indicators_BO;
using School_Indicators_BLL;

namespace School_Indicators.Controllers
{
    public class HomeController : Controller
    {
        InstitutionService institutionService = new InstitutionService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetSchools(string query)
        {
            try
             {
                List<BO.Institution> model = new List<BO.Institution>();
                model = institutionService.SearchSchools(query);
                return Json(model, JsonRequestBehavior.AllowGet);
                //return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}