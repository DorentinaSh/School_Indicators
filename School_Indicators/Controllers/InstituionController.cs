using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Indicators_BLL;

namespace School_Indicators.Controllers
{
    public class InstituionController : Controller
    {
        InstitutionService InstitutionService = new InstitutionService();
        // GET: Instituions
        public ActionResult Index()
        {
            return View(InstitutionService.GetInstitutions());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}