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
        // GET: Categories
        public ActionResult Index(int id)
        {
            List<CategoryOfQuestion> model = service.GetQuestionCategoryByQuestionnarireId(id);
            return View(model);
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}