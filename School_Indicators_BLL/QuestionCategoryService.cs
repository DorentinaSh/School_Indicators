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
        public List<CategoryOfQuestion> GetCategories()
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<CategoryOfQuestion> model = (from e in db.tblCategoryOfQuestionnaires
                                                      select new CategoryOfQuestion
                                                      {
                                                          Id = e.Id,
                                                          IsActive = e.IsActive,
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
                        IsActive = model.IsActive,
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
                    q.CategoryName = model.CategoryName;
                    q.IsActive = model.IsActive;
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
                                                where e.Id == id
                                                select new CategoryOfQuestion
                                                {
                                                    Id = e.Id,
                                                    IsActive = e.IsActive,
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
