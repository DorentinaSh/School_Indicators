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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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
                        Status = model.Status,
                        Level = model.Level,
                        NrOfStudentsTotal_Female = model.TotalNr_Female,
                        NrOfStudentsTotal_Male = model.TotalNr_Male,
                        EnrollmentsPerYear_Female = model.EnrollmentsPerYear_Female,
                        EnrollmentsPerYear_Male = model.EnrollmentsPerYear_Male,
                        StudentsWDissabilitiesTotal_Female = model.Students_WithDisabilities_Female,
                        StudentsWDissabilitiesTotal_Male = model.Students_WithDisabilities_Male,
                        NrOfStudentsTotal = model.TotalNr_Male + model.TotalNr_Female,
                        EnrollmentsPerYearTotal = model.EnrollmentsPerYear_Male + model.EnrollmentsPerYear_Female,
                        StudentsWDissabilitiesTotal = model.Students_WithDisabilities_Male + model.Students_WithDisabilities_Female,
                        IsActive = true,
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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
                    q.Level = model.Level;
                    q.Status = model.Status;
                    q.NrOfStudentsTotal_Female = model.TotalNr_Female;
                    q.NrOfStudentsTotal_Male = model.TotalNr_Male;
                    q.NrOfStudentsTotal = model.TotalNr_Male + model.TotalNr_Female;
                    q.EnrollmentsPerYear_Female = model.EnrollmentsPerYear_Female;
                    q.EnrollmentsPerYear_Male = model.EnrollmentsPerYear_Male;
                    q.EnrollmentsPerYearTotal = model.EnrollmentsPerYear_Male + model.EnrollmentsPerYear_Female;
                    q.StudentsWDissabilitiesTotal_Female = model.Students_WithDisabilities_Female;
                    q.StudentsWDissabilitiesTotal_Male = model.Students_WithDisabilities_Male;
                    q.StudentsWDissabilitiesTotal = model.Students_WithDisabilities_Female + model.Students_WithDisabilities_Male;
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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
                                             IsActive = e.IsActive,
                                             Status = e.Status,
                                             Level = e.Level,
                                             TotalNr_Female = e.NrOfStudentsTotal_Female,
                                             TotalNr_Male = e.NrOfStudentsTotal_Male,
                                             EnrollmentsPerYear_Female = e.EnrollmentsPerYear_Female,
                                             EnrollmentsPerYear_Male = e.EnrollmentsPerYear_Male,
                                             Students_WithDisabilities_Female = e.StudentsWDissabilitiesTotal_Female,
                                             Students_WithDisabilities_Male = e.StudentsWDissabilitiesTotal_Male
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
