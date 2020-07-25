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
        public JsonResult CreateQuestionnarie(Questionnaries model)
        {
            try
            {
                service.SaveQuestionnaire(model);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            Questionnaries model = new Questionnaries();
            model = service.GetQuestionnarieById(id);
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateQuestionnarie(Questionnaries model)
        {
            try
            {
                service.UpdateQuestionnaire(model);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public JsonResult DeleteQuestionnarie(int id)
        {
            try
            {
                service.DeleteQuestionnaire(id);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}