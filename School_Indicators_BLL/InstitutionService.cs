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
                                                   Name3 = e.InstitutionsName3,
                                                   InstitutionsNo = e.InstitutionsNo,
                                                   Location = e.Location,
                                                   Address = e.Address,
                                                   CityID = e.CityID,
                                                   TelephoneNo = e.TelNo,
                                                   IsActive = e.IsActive
                                               }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveInstitution(Institution model)
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
                        InstitutionsNo = model.InstitutionsNo,
                        Location = model.Location,
                        Address = model.Address,
                        CityID = model.CityID,
                        TelNo = model.TelephoneNo,
                        IsActive = model.IsActive,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblInstitutions.Add(q);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateInstitution(Institution model)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    tblInstitution q = db.tblInstitutions.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.InstitutionsName1 = model.Name1;
                    q.InstitutionsName2 = model.Name2;
                    q.InstitutionsName3 = model.Name3;
                    q.InstitutionsNo = model.InstitutionsNo;
                    q.Location = model.Location;
                    q.Address = model.Address;
                    q.CityID = model.CityID;
                    q.TelNo = model.TelephoneNo;
                    q.IsActive = model.IsActive;
                    q.LUB = "admin";
                    q.LUD = DateTime.Now;
                    db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Institution GetInstitutionById(int id)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    Institution model = (from e in db.tblInstitutions
                                         where e.Id == id
                                         select new Institution
                                         {
                                             Id = e.Id,
                                             Name1 = e.InstitutionsName1,
                                             Name2 = e.InstitutionsName2,
                                             Name3 = e.InstitutionsName3,
                                             InstitutionsNo = e.InstitutionsNo,
                                             Location = e.Location,
                                             Address = e.Address,
                                             CityID = e.CityID,
                                             TelephoneNo = e.TelNo,
                                             IsActive = e.IsActive
                                         }).FirstOrDefault();
                    return model;
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

        public List<Institution> SearchSchools(string query)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<Institution> model = (from e in db.tblInstitutions
                                         where e.InstitutionsName1.Contains(query)
                                         select new Institution
                                         {
                                             Id = e.Id,
                                             Name1 = e.InstitutionsName1,
                                             Name2 = e.InstitutionsName2,
                                             Name3 = e.InstitutionsName3,
                                             InstitutionsNo = e.InstitutionsNo,
                                             Location = e.Location,
                                             Address = e.Address,
                                             CityID = e.CityID,
                                             TelephoneNo = e.TelNo,
                                             IsActive = e.IsActive
                                         }).ToList();
                    return model;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Institution> GetSchoolsByCity(string city)
        {
            try
            {
                using (School_CardsEntities db = new School_CardsEntities())
                {
                    List<Institution> model = (from e in db.tblInstitutions
                                               join c in db.tblCities on e.CityID equals c.Id
                                               where c.Name1 == city
                                               select new Institution
                                               {
                                                   Id = e.Id,
                                                   Name1 = e.InstitutionsName1,
                                                   Name2 = e.InstitutionsName2,
                                                   Name3 = e.InstitutionsName3,
                                                   InstitutionsNo = e.InstitutionsNo,
                                                   Location = e.Location,
                                                   Address = e.Address,
                                                   CityID = e.CityID,
                                                   TelephoneNo = e.TelNo,
                                                   IsActive = e.IsActive
                                               }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
