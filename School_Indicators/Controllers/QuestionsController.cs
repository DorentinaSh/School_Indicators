using Newtonsoft.Json;
using School_Indicators.BO;
using School_Indicators_BLL;
using School_Indicators_BO.BO.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_Indicators.Controllers
{
    public class QuestionsController : Controller
    {
        private QuestionService service = new QuestionService();
        private OpsionService opsionService = new OpsionService();
        private EvaluationService EvaluationService = new EvaluationService();
        private CategoryQuestionnaireQuestionService categoryQuestionnaireService = new CategoryQuestionnaireQuestionService();
        private QuestionnaireService questionnaireService = new QuestionnaireService();
        private QuestionCategoryService categoryService = new QuestionCategoryService();
        private QuestionTypeService questionTypeService = new QuestionTypeService();
        // GET: Questions
        public ActionResult Index(int id)
        {
            ViewBag.QuestionnaireID = id;
            ViewBag.Name = questionnaireService.GetQuestionnaireNameById(id);
            List<Question> model = new List<Question>();
            model = service.GetQuestionsByQuestionnaireId(id);
            return View(model);
        }


        public ActionResult Create(int id)
        {
            QuestionOpstionsDTO model = new QuestionOpstionsDTO();
            model.Question = new Question();
            ViewBag.Rate = JsonConvert.SerializeObject(EvaluationService.GetRate().OrderByDescending(x=>x.Value));
            ViewBag.Name = questionnaireService.GetQuestionnaireNameById(id);
            ViewBag.QuestionnaireId = id;
            ViewBag.Indicators = new SelectList(categoryService.GetCategories(), "Id", "Name1");
            return View(model);
        }

        [HttpPost]
        public JsonResult CreateQuestion(Question question, List<QuestionOption> optionsList, CategoryQuestionnaireQuestion catQuest)
        {
            try
            {
                int questionId = service.SaveQuestions(question);
                opsionService.SaveOptions(optionsList, questionId);
                catQuest.QuestionId = questionId;
                categoryQuestionnaireService.SaveCategoryQuestionnaireQuestion(catQuest);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
       

        public ActionResult Edit(int id)
        {
            QuestionOpstionsDTO model = new QuestionOpstionsDTO();
            model.Question = service.GetQuestionById(id);
            model.Options = opsionService.OptionList(id);
            ViewBag.QuestionnaireId = model.Question.QuestionnaireID;
            ViewBag.Rate = JsonConvert.SerializeObject(EvaluationService.GetRate().OrderByDescending(x=>x.Value));
            ViewBag.Options = JsonConvert.SerializeObject(model.Options);
            ViewBag.Indicators = new SelectList(categoryService.GetCategories(), "Id", "Name1",model.Question.IndicatorId);
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateQuestion(Question question, List<QuestionOption> optionsList, CategoryQuestionnaireQuestion catQuest)
        {
            try
            {
                int questionID = service.UpdateQuestions(question);
                opsionService.UpdateOptions(optionsList,questionID);
                catQuest.QuestionId = questionID;
                categoryQuestionnaireService.SaveCategoryQuestionnaireQuestion(catQuest);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public JsonResult DeleteQuestion(int id)
        {
            try
            {
                categoryQuestionnaireService.DeleteIndicatorDetails(id);
                opsionService.DeleteOptions(id);
                service.DeleteQuestion(id);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult GetAll(/*int questionnaireID*/)
        {
            var questionList = service.GetQuestionsByQuestionnaireId(1);
            return Json(new { data = questionList }, JsonRequestBehavior.AllowGet);
        }
    }
}