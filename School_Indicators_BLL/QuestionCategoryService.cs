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
        public List<Indicator> GetCategories()
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    List<Indicator> model = (from e in db.tblIndicators
                                                      select new Indicator
                                                      {
                                                          Id = e.Id,
                                                          IsActive = e.IsActive,
                                                          Name1 = e.IndicatorName,
                                                          Name2 = e.IndicatorName2,
                                                          Name3 = e.IndicatorName3
                                                      }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveCategory(Indicator model)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblIndicator q = new tblIndicator
                    {
                        IsActive = model.IsActive,
                        IndicatorName = model.Name1,
                        IndicatorName2 = model.Name2,
                        IndicatorName3 = model.Name3,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblIndicators.Add(q);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateCategory(Indicator model)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblIndicator q = db.tblIndicators.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.IndicatorName = model.Name1;
                    q.IsActive = model.IsActive;
                    q.IndicatorName2 = model.Name2;
                    q.IndicatorName3 = model.Name3;
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

        public Indicator GetCategoryById(int id)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    Indicator model = (from e in db.tblIndicators
                                                where e.Id == id
                                                select new Indicator
                                                {
                                                    Id = e.Id,
                                                    IsActive = e.IsActive,
                                                    Name1 = e.IndicatorName,
                                                    Name2 = e.IndicatorName2,
                                                    Name3 = e.IndicatorName3
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblIndicator q = db.tblIndicators.Where(x => x.Id == id).FirstOrDefault();
                    db.tblIndicators.Remove(q);
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
