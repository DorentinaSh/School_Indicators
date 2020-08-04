using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Indicators_BO.BO;
using School_Indicators_DAL;

namespace School_Indicators_BLL
{
    public class QuestionService
    {
        public List<Question> GetQuestionsByCategoryId(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<Question> model = (from e in db.tblQuestionOfQuestionnaires
                                            join c in db.tblCategoryOfQuestionnaires on e.CategoryOfQuestionnaireID equals c.Id
                                            join t in db.tblQuestionTypes on e.QuestionTypeID equals t.Id
                                            where e.CategoryOfQuestionnaireID == id
                                            select new Question
                                            {
                                                Id = e.Id,
                                                CategoryId = c.Id,
                                                CategoryName = c.CategoryName,
                                                QuestionTypeID = e.QuestionTypeID,
                                                QuestionTypeName = t.Name1,
                                                Name1 = e.QuestionName,
                                                Name2 = e.QuestionName2,
                                                Name3 = e.QuestionName3
                                            }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Question> GetQuestionsByQuestionnaireId(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<Question> model = (from e in db.tblQuestionOfQuestionnaires
                                            join c in db.tblCategoryOfQuestionnaires on e.CategoryOfQuestionnaireID equals c.Id
                                            join t in db.tblQuestionTypes on e.QuestionTypeID equals t.Id
                                            //where q.Id == id
                                            select new Question
                                            {
                                                Id = e.Id,
                                                CategoryId = c.Id,
                                                CategoryName = c.CategoryName,
                                                QuestionTypeID = e.QuestionTypeID,
                                                QuestionTypeName = t.Name1,
                                                Name1 = e.QuestionName,
                                                Name2 = e.QuestionName2,
                                                Name3 = e.QuestionName3,
                                                IsActive=e.isActive
                                            }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Question GetQuestionsById(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    Question model = (from e in db.tblQuestionOfQuestionnaires
                                      join c in db.tblCategoryOfQuestionnaires on e.CategoryOfQuestionnaireID equals c.Id
                                      join t in db.tblQuestionTypes on e.QuestionTypeID equals t.Id
                                      where e.Id == id
                                      select new Question
                                      {
                                          Id = e.Id,
                                          CategoryId = c.Id,
                                          CategoryName = c.CategoryName,
                                          QuestionTypeID = e.QuestionTypeID,
                                          QuestionTypeName = t.Name1,
                                          Name1 = e.QuestionName,
                                          Name2 = e.QuestionName2,
                                          Name3 = e.QuestionName3,
                                          IsActive = e.isActive
                                      }).First();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Question GetCategory(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    Question model = (from e in db.tblCategoryOfQuestionnaires
                                      where e.Id == id
                                      select new Question
                                      {
                                          CategoryId = e.Id,
                                          CategoryName = e.CategoryName,
                                      }).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveQuestions(Question model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblQuestionOfQuestionnaire q = new tblQuestionOfQuestionnaire
                    {
                        CategoryOfQuestionnaireID = model.CategoryId,
                        QuestionTypeID = model.QuestionTypeID,
                        QuestionName = model.Name1,
                        QuestionName2 = model.Name2,
                        QuestionName3 = model.Name3,
                        isActive = model.IsActive,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblQuestionOfQuestionnaires.Add(q);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateQuestions(Question model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblQuestionOfQuestionnaire q = db.tblQuestionOfQuestionnaires.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.CategoryOfQuestionnaireID = model.CategoryId;
                    q.QuestionTypeID = model.QuestionTypeID;
                    q.QuestionName = model.Name1;
                    q.QuestionName2 = model.Name2;
                    q.QuestionName3 = model.Name3;
                    q.isActive = model.IsActive;
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

        public void DeleteQuestion(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblQuestionOfQuestionnaire question = db.tblQuestionOfQuestionnaires.Where(x => x.CategoryOfQuestionnaireID == id).FirstOrDefault();
                    List<tblQuestionOption> options = db.tblQuestionOptions.Where(x => x.QuestionID == question.Id).ToList();
                    if (options != null)
                    {
                        db.tblQuestionOptions.RemoveRange(options);
                        db.SaveChanges();
                    }
                    db.tblQuestionOfQuestionnaires.Remove(question);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<QuestionType> GetQuestionTypes()
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<QuestionType> model = (from t in db.tblQuestionTypes
                                                select new QuestionType
                                                {
                                                    Id = t.Id,
                                                    Type = t.Type,
                                                    Name1 = t.Name1
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
