using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Indicators.BO;
using School_Indicators_BLL;

namespace School_Indicators.Controllers
{
    public class QuestionnaireController : Controller
    {
        QuestionnaireService service = new QuestionnaireService();
        // GET: Questionnaire
        public ActionResult Index()
        {
            List<Questionnaries> model = new List<Questionnaries>();
            model = service.GetQuestionnaries();
            return View(model);
        }

        public ActionResult EX_Create()
        {
            return View();
        }

        public ActionResult Create()
        {
            Questionnaries model = new Questionnaries();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Questionnaries model)
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
    }
}