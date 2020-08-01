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

        public List<CategoryOfQuestion> GetCategories()
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<CategoryOfQuestion> model = (from e in db.tblCategoryOfQuestionnaires
                                                      join q in db.tblQuestionnaires on e.QuestionnaireID equals q.Id into con
                                                      from q in con.DefaultIfEmpty()
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


        public void SaveCategory(CategoryOfQuestion model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblCategoryOfQuestionnaire q = new tblCategoryOfQuestionnaire
                    {
                        QuestionnaireID = model.QuestionnaireID,
                        CategoryName = model.CategoryName,
                        CategoryName2 = model.CategoryName2,
                        CategoryName3 = model.CategoryName3,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblCategoryOfQuestionnaires.Add(q);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateCategory(CategoryOfQuestion model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblCategoryOfQuestionnaire q = db.tblCategoryOfQuestionnaires.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.QuestionnaireID = model.QuestionnaireID;
                    q.CategoryName = model.CategoryName;
                    q.CategoryName2 = model.CategoryName2;
                    q.CategoryName3 = model.CategoryName3;
                    //q. = model.CategoryName3;
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

        public CategoryOfQuestion GetCategoryById(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    CategoryOfQuestion model = (from e in db.tblCategoryOfQuestionnaires
                                                join q in db.tblQuestionnaires on e.QuestionnaireID equals q.Id
                                                where e.Id == id
                                                select new CategoryOfQuestion
                                                {
                                                    Id = e.Id,
                                                    QuestionnaireID = e.QuestionnaireID,
                                                    QuestionnaireName = q.QuestName,
                                                    CategoryName = e.CategoryName,
                                                    CategoryName2 = e.CategoryName2,
                                                    CategoryName3 = e.CategoryName3
                                                }).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<tblQuestionOfQuestionnaire> questions = db.tblQuestionOfQuestionnaires.Where(x => x.CategoryOfQuestionnaireID == id).ToList();
                    if (questions != null)
                    {
                        foreach (var item in questions)
                        {
                            List<tblQuestionOption> options = db.tblQuestionOptions.Where(x => x.QuestionID == item.Id).ToList();
                            if (options != null)
                            {
                                db.tblQuestionOptions.RemoveRange(options);
                                db.SaveChanges();
                            }
                        }
                        db.tblQuestionOfQuestionnaires.RemoveRange(questions);
                        db.SaveChanges();
                    }
                    tblCategoryOfQuestionnaire q = db.tblCategoryOfQuestionnaires.Where(x => x.Id == id).FirstOrDefault();
                    db.tblCategoryOfQuestionnaires.Remove(q);
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
