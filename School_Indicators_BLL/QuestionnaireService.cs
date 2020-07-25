using System;
using System.Collections.Generic;
using System.Linq;
using School_Indicators.BO;
using School_Indicators_DAL;

namespace School_Indicators_BLL
{
    public class QuestionnaireService
    {
        public List<Questionnaries> GetQuestionnaries()
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<Questionnaries> model = (from e in db.tblQuestionnaires
                                                  select new Questionnaries
                                                  {
                                                      Id = e.Id,
                                                      Name1 = e.QuestName,
                                                      Name2 = e.QuestName2,
                                                      Name3 = e.QuestName3
                                                  }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveQuestionnaire(Questionnaries model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblQuestionnaire q = new tblQuestionnaire
                    {
                        QuestName = model.Name1,
                        QuestName2 = model.Name2,
                        QuestName3 = model.Name3,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblQuestionnaires.Add(q);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateQuestionnaire(Questionnaries model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblQuestionnaire q = db.tblQuestionnaires.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.QuestName = model.Name1;
                    q.QuestName2 = model.Name2;
                    q.QuestName3 = model.Name3;
                    q.LUB = "admin";
                    q.LUD = DateTime.Now;
                    db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Questionnaries GetQuestionnarieById(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    Questionnaries model = (from e in db.tblQuestionnaires
                                            where e.Id == id
                                            select new Questionnaries
                                            {
                                                Id = e.Id,
                                                Name1 = e.QuestName,
                                                Name2 = e.QuestName2,
                                                Name3 = e.QuestName3
                                            }).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteQuestionnaire(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblQuestionnaire q = db.tblQuestionnaires.Where(x => x.Id == id).FirstOrDefault();
                    db.tblQuestionnaires.Remove(q);
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
