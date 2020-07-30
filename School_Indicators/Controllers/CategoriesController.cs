using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School_Indicators.BO;
using School_Indicators_BLL;
using School_Indicators_BO.BO;

namespace School_Indicators.Controllers
{
    public class CategoriesController : Controller
    {
        QuestionCategoryService service = new QuestionCategoryService();
        QuestionnaireService qservice = new QuestionnaireService();
        // GET: Categories
        public ActionResult Index()
        {
            //ViewBag.QID = id;
            //ViewBag.Name = qservice.GetQuestionnaireNameById(id);
            List<CategoryOfQuestion> model = service.GetCategories();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Questionnaires = new SelectList(qservice.GetQuestionnaries(), "Id", "Name1");
            return View(new CategoryOfQuestion());
        }

        [HttpPost]
        public JsonResult CreateCategory(CategoryOfQuestion model)
        {
            try
            {
                service.SaveCategory(model);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Edit(int id)
        {
            CategoryOfQuestion model = new CategoryOfQuestion();
            model = service.GetCategoryById(id);
            ViewBag.Questionnaires = new SelectList(qservice.GetQuestionnaries(), "Id", "Name1", model.QuestionnaireID);
            return View(model);
        }

        [HttpPost]
        public JsonResult UpdateCategory(CategoryOfQuestion model)
        {
            try
            {
                service.UpdateCategory(model);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public JsonResult DeleteCategory(int id)
        {
            try
            {
                service.DeleteCategory(id);
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}