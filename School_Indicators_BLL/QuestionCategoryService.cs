using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Indicators.BO;
using School_Indicators_BO.BO;
using School_Indicators_DAL;

namespace School_Indicators_BLL
{
    public class QuestionCategoryService
    {
        public List<CategoryOfQuestion> GetQuestionCategoryByQuestionnarireId(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<CategoryOfQuestion> model = (from e in db.tblCategoryOfQuestionnaires
                                                      join q in db.tblQuestionnaires on e.QuestionnaireID equals q.Id
                                                      where e.QuestionnaireID == id
                                                      select new CategoryOfQuestion
                                                      {
                                                          Id = e.Id,
                                                          QuestionnaireID = e.QuestionnaireID,
                                                          QuestionnaireName = q.QuestName,
                                                          CategoryName = e.CategoryName,
                                                          CategoryName2 = e.CategoryName2,
                                                          CategoryName3 = e.CategoryName3
                                                      }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
