using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Indicators_BO.BO;
using School_Indicators_DAL;
using AutoMapper;
using System.Data;
using Dapper;


namespace School_Indicators_BLL
{
    public class QuestionService
    {
        public List<Question> GetQuestionsByCategoryId(int id)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    List<Question> model = (from e in db.tblQuestions
                                            where e.Id == id
                                            select new Question
                                            {
                                                Id = e.Id,
                                                Name1 = e.QuestionName1,
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    var query = @"select q.Id as Id,q.IndicatorID as IndicatorId,q.QuestionName1 as Name1,q.QuestionName2 as Name2,q.QuestionName3 as Name3,i.IndicatorName as IndicatorName,qq.QuestName as QuestionnaireName,q.IsActive as IsActive from tblQuestion q 
	                              join IndicatorsDetails id on id.QuestionID=q.Id
	                              join tblIndicators i on id.IndicatorID=i.Id
	                              join tblQuestionnaire qq on id.QuestionnaireID=qq.Id
	                              Where qq.Id=@QuestionnaireID
	                              group by q.Id,q.IndicatorID,q.QuestionName1,q.QuestionName2,q.QuestionName3,i.IndicatorName,qq.QuestName,q.IsActive";

                    IDbConnection dbConnection = db.Database.Connection;
                    var res = dbConnection.QueryMultiple(query, new { QuestionnaireID = id });
                    List<Question> model = res.Read<Question>().ToList();

                    //var model = (from e in db.tblQuestions
                    //             join cq in db.IndicatorsDetails on e.Id equals cq.QuestionID
                    //             join c in db.tblIndicators on cq.IndicatorID equals c.Id
                    //             join q in db.tblQuestionnaires on cq.QuestionnaireID equals q.Id
                    //             where cq.QuestionnaireID == id
                    //             select new Question
                    //             {
                    //                 Id = e.Id,
                    //                 IndicatorId = c.Id,
                    //                 QuestionnaireName = q.QuestName,
                    //                 IndicatorName = c.IndicatorName,
                    //                 Name1 = e.QuestionName1,
                    //                 Name2 = e.QuestionName2,
                    //                 Name3 = e.QuestionName3,
                    //                 IsActive = e.IsActive
                    //             }).ToList();


                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Question GetQuestionById(int id)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    Question model = (from e in db.tblQuestions
                                      join c in db.IndicatorsDetails on e.Id equals c.QuestionID
                                      join q in db.tblQuestionnaires on c.QuestionnaireID equals q.Id
                                      join i in db.tblIndicators on c.IndicatorID equals i.Id
                                      where e.Id == id
                                      select new Question
                                      {
                                          Id = e.Id,
                                          IndicatorId = i.Id,
                                          QuestionnaireID = q.Id,
                                          IndicatorName = i.IndicatorName,
                                          Name1 = e.QuestionName1,
                                          Name2 = e.QuestionName2,
                                          Name3 = e.QuestionName3,
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
        public int SaveQuestions(Question model)
        {
            try
            {
                int id = 0;
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblQuestion q = new tblQuestion
                    {
                        IndicatorID = model.IndicatorId,
                        QuestionName1 = model.Name1,
                        QuestionName2 = model.Name2,
                        QuestionName3 = model.Name3,
                        IsActive = model.IsActive,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                    };
                    db.tblQuestions.Add(q);
                    db.SaveChanges();
                    id = q.Id;
                }
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int UpdateQuestions(Question model)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblQuestion q = db.tblQuestions.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.IndicatorID = model.IndicatorId;
                    q.QuestionName1 = model.Name1;
                    q.QuestionName2 = model.Name2;
                    q.QuestionName3 = model.Name3;
                    q.IsActive = model.IsActive;
                    q.LUB = "admin";
                    q.LUD = DateTime.Now;
                    db.Entry(q).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return model.Id;
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblQuestion question = db.tblQuestions.Where(x => x.Id == id).FirstOrDefault();
                    if (question != null)
                    {
                        db.tblQuestions.Remove(question);
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
