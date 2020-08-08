using School_Indicators.BO;
using School_Indicators_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BLL
{
    public class CategoryQuestionnaireQuestionService
    {
        public void SaveCategoryQuestionnaireQuestion(CategoryQuestionnaireQuestion catQuest)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblCategoryQuestionnaireQuestion catQ = new tblCategoryQuestionnaireQuestion
                    {
                        CategoryId = catQuest.CategoryId,
                        QuestionId=catQuest.QuestionId,
                        QuestionnaireId =catQuest.QuestionnaireId,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblCategoryQuestionnaireQuestions.Add(catQ);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
