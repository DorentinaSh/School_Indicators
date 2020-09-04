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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    foreach (QuestionOption item in options)
                    {
                        tblQuestionOption o = new tblQuestionOption
                        {
                            QuestionID = questionId,
                            EvaluationID = item.EvaluationID,
                            QuestOptName = item.Name1,
                            QuestOptName2 = item.Name2,
                            QuestOptName3 = item.Name2,
                            IsActive = true,
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
        public void UpdateOptions(List<QuestionOption> model,int questionID)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    foreach (QuestionOption item in model)
                    {
                        tblQuestionOption q = db.tblQuestionOptions.Where(x => x.Id == item.Id).FirstOrDefault();
                        q.QuestionID = questionID;
                        q.EvaluationID = item.EvaluationID;
                        q.QuestOptName = item.Name1;
                        q.QuestOptName2 = item.Name2;
                        q.QuestOptName3 = item.Name3;
                        q.IsActive = item.IsActive;
                        q.LUB = "admin";
                        q.LUD = DateTime.Now;
                        db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<QuestionOption> OptionList(int questionID) 
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities()) 
                {
                    List<QuestionOption> model = (from o in db.tblQuestionOptions
                                                  join q in db.tblQuestions on o.QuestionID equals q.Id
                                                  join e in db.tblEvaluations on o.EvaluationID equals e.Id
                                                  where o.QuestionID == questionID
                                                  select new QuestionOption
                                                  {
                                                      Id = o.Id,
                                                      Name1 = o.QuestOptName,
                                                      Name2 = o.QuestOptName2,
                                                      Name3 = o.QuestOptName3,
                                                      EvaluationID = e.Id,
                                                      EvaluationValue = e.Value
                                                  }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void DeleteOptions(int questionID) 
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities()) 
                {
                    List<tblQuestionOption> options = db.tblQuestionOptions.Where(x => x.QuestionID == questionID).ToList();
                    if (options.Count>0 || options != null)
                    {
                        foreach (tblQuestionOption item in options)
                        {
                            db.tblQuestionOptions.Remove(item);
                            db.SaveChanges();
                        }
                        //db.tblQuestionOptions.RemoveRange(options);
                        //db.SaveChanges();
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
