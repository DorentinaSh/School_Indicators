using School_Indicators.BO;
using School_Indicators_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BLL
{
    public class OpsionService
    {
        public void SaveOptions(List<QuestionOption> options,int questionId)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    foreach (QuestionOption item in options)
                    {
                        tblQuestionOption o = new tblQuestionOption
                        {
                            QuestionID = questionId,
                            QuestOptName = item.Name1,
                            QuestOptName2 = item.Name2,
                            QuestOptName3 = item.Name2,
                            InsertDate = DateTime.Now,
                            InsertBy = "admin",
                        };
                        db.tblQuestionOptions.Add(o);
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
