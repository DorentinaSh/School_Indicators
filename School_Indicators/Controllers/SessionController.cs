using School_Indicators.BO;
using School_Indicators_BLL;
using School_Indicators_BO.BO.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace School_Indicators.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        private InstitutionService institutionService = new InstitutionService();
        private QuestionnaireService questionnaireService = new QuestionnaireService();
        public ActionResult Index()
        {
            ViewBag.Institutions = new SelectList(institutionService.GetInstitutions(), "Id", "Name1");
            ViewBag.Questionnaires = new SelectList(questionnaireService.GetQuestionnairesWithQuestion(), "Id", "Name1");

            return View();
        }

         public async Task<PartialViewResult> QuestionnaireForm(int questionnaireID)
        {
            Task<List<QuestionOptDTO>> model = questionnaireService.GetQuestionnairFormData(questionnaireID);
            Questionnaries temp = questionnaireService.CreateQuestionaireFormModel(model.Result);
            return PartialView("QuestionnaireForm", temp);
        }

        [HttpPost]
        public JsonResult CreateSession(Session session, List<SessionDetails> optionsList)
        {
            try
            {
                int sessionId; //save session get ID
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}