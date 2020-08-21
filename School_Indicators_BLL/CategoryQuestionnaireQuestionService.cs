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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    IndicatorsDetail catQ = new IndicatorsDetail
                    {
                        IndicatorID = catQuest.IndicatorId,
                        QuestionID = catQuest.QuestionId,
                        QuestionnaireID = catQuest.QuestionnaireId,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.IndicatorsDetails.Add(catQ);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteIndicatorDetails(int questionID)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    List<IndicatorsDetail> question = db.IndicatorsDetails.Where(x => x.QuestionID == questionID).ToList();
                    if (question != null)
                    {
                        db.IndicatorsDetails.RemoveRange(question);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
