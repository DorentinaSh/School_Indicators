using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Indicators_BLL;

namespace School_Indicators.Controllers
{
    public class InstitutionController : Controller
    {
        InstitutionService InstitutionService = new InstitutionService();
        CityService CityService = new CityService();
        // GET: Instituions
        public ActionResult Index()
        {
            return View(InstitutionService.GetInstitutions());
        }

        public ActionResult Create()
        {
            Institution institution = new Institution();
            ViewBag.City = new SelectList(CityService.GetCities(), "ID", "Name1");
            return View(institution);
        }

        [HttpPost]
        public ActionResult Create(Institution model)
        {
            try
            {
                bool value = InstitutionService.SaveInstitution(model);
                return Json(new { success = value }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult Edit(int id)
        {
            Institution model = new Institution();
            model = InstitutionService.GetInstitutionById(id);
            ViewBag.City = new SelectList(CityService.GetCities(), "ID", "Name1",model.CityID);
            return View(model);
        }

       // [HttpPost]
      //  public JsonResult UpdateInstitution(Institution model)
       // {
            //try
            //{
            //    InstitutionService.UpdateInstitution(model);
            //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
      //  }


        [HttpPost]
        public JsonResult DeleteInstitution(int id)
        {
            try
            {
                InstitutionService.DeleteInstitution(id);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}