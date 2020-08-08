using School_Indicators.BO;
using School_Indicators_BLL;
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
            Question model = new Question();
            ViewBag.Name = questionnaireService.GetQuestionnaireNameById(id);
            ViewBag.QuestionnaireId = id;
            ViewBag.Categories = new SelectList(categoryService.GetCategories(), "Id", "CategoryName");
            ViewBag.QuestionTypes = new SelectList(questionTypeService.GetAllQuestionType(), "Id", "Type");
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
            Question model = new Question();
            //model = service.GetQuestionsById(id);
            //model.types = service.GetQuestionTypes();
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateQuestion(Question model)
        {
            try
            {
                service.UpdateQuestions(model);
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
                //service.DeleteQuestion(id);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public ActionResult GetAll()
        //{
        //    var questionnaireList = service.GetQuestionnaries();
        //    return Json(new { data = questionnaireList }, JsonRequestBehavior.AllowGet);
        //}
    }
}