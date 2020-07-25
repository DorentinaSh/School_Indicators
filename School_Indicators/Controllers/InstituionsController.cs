using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Indicators.Controllers
{
    public class InstituionController : Controller
    {
        // GET: Instituions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View("Create", new Institution());
        }
    }
}