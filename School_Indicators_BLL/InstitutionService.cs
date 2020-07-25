using School_Indicators.BO;
using School_Indicators_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BLL
{
    public class InstitutionService
    {
        public List<Institution> GetInstitutions()
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<Institution> model = (from e in db.tblInstitutions
                                                  select new Institution
                                                  {
                                                      Id = e.Id,
                                                      Name1 = e.InstitutionsName1,
                                                      Name2 = e.InstitutionsName2,
                                                      Name3 = e.InstitutionsName3
                                                  }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SaveInstitution(Institution model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblInstitution q = new tblInstitution
                    {
                        InstitutionsName1 = model.Name1,
                        InstitutionsName2 = model.Name2,
                        InstitutionsName3 = model.Name3,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblInstitutions.Add(q);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateInstitution(Institution model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblInstitution q = db.tblInstitutions.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.InstitutionsName1 = model.Name1;
                    q.InstitutionsName2 = model.Name2;
                    q.InstitutionsName3 = model.Name3;
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

        public void DeleteInstitution(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblInstitution q = db.tblInstitutions.Where(x => x.Id == id).FirstOrDefault();
                    db.tblInstitutions.Remove(q);
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
