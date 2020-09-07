using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using School_Indicators.BO;
using School_Indicators_BO.BO;
using School_Indicators_BO.BO.ModelDTO;
using School_Indicators_DAL;

namespace School_Indicators_BLL
{
    public class QuestionnaireService
    {
        public List<Questionnaries> GetQuestionnaries()
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    List<Questionnaries> model = (from e in db.tblQuestionnaires
                                                  select new Questionnaries
                                                  {
                                                      Id = e.Id,
                                                      Name1 = e.QuestName,
                                                      Name2 = e.QuestName2,
                                                      Name3 = e.QuestName3,
                                                      Description=e.Description,
                                                      IsActive=e.IsActive
                                                  }).ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<QuestionOptDTO>> GetQuestionnairFormData(int questinnaireId) 
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    var query = @"select qq.Id as 'QuestionnaireID',qq.QuestName as 'QuestionnaireName'
                                ,qq.Description as 'QuestionnaireDescription'
                                ,qq.InsertDate as 'QuestionnaireCreatedDate',
                                q.Id as 'QuestionID',q.QuestionName1 as 'QuestionName',i.Id as 'IndicatorID'
                                ,i.IndicatorName as 'IndicatorName'
                                ,qo.Id as 'OptionID',qo.QuestOptName as 'OptionName' from tblQuestion q
                                left join IndicatorsDetails id on q.Id=id.QuestionID
                                left join tblQuestionnaire qq on id.QuestionnaireID=qq.Id
                                left join tblIndicators i on id.IndicatorID= i.Id
                                left join tblQuestionOption qo on qo.QuestionID=q.Id
                                where qq.Id = @QuestionnaireID
                                group by qq.Id,qq.QuestName,qq.Description,qq.InsertDate,q.Id
                                ,q.QuestionName1,i.Id,i.IndicatorName,qo.Id,qo.QuestOptName
                                order by i.Id";

                    IDbConnection dbConnection = db.Database.Connection;
                    var res = dbConnection.QueryMultiple(query, new { QuestionnaireID = questinnaireId });
                    List<QuestionOptDTO> model = res.Read<QuestionOptDTO>().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void SaveQuestionnaire(Questionnaries model)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblQuestionnaire q = new tblQuestionnaire
                    {
                        QuestName = model.Name1,
                        QuestName2 = model.Name2,
                        QuestName3 = model.Name3,
                        Description = model.Description,
                        InsertDate = DateTime.Now,
                        InsertBy = "admin",
                        IsActive = model.IsActive
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    tblQuestionnaire q = db.tblQuestionnaires.Where(x => x.Id == model.Id).FirstOrDefault();
                    q.QuestName = model.Name1;
                    q.QuestName2 = model.Name2;
                    q.QuestName3 = model.Name3;
                    q.Description = model.Description;
                    q.IsActive = model.IsActive;
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
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    Questionnaries model = (from e in db.tblQuestionnaires
                                            where e.Id == id
                                            select new Questionnaries
                                            {
                                                Id = e.Id,
                                                Name1 = e.QuestName,
                                                Name2 = e.QuestName2,
                                                Name3 = e.QuestName3,
                                                Description = e.Description,
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

        public void DeleteQuestionnaire(int id)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
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

        public string GetQuestionnaireNameById(int id)
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    string name = db.tblQuestionnaires.Where(x => x.Id == id).FirstOrDefault().QuestName;
                    return name;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Questionnaries CreateQuestionaireFormModel(List<QuestionOptDTO> model) 
        {
            try
            {
                int tempIndicator = 0;
                int tempQuestion = 0;
                Indicator indicator = new Indicator();
                Question question = new Question();
                Questionnaries questionnaries = new Questionnaries 
                {
                    Id = model.FirstOrDefault().QuestionnaireID,
                    Name1 = model.FirstOrDefault().QuestionnaireName,
                    Description = model.FirstOrDefault().QuestionnaireDescription,
                    InsertDate = model.FirstOrDefault().QuestionnaireCreatedDate,
                    Indicators = new List<Indicator>()
                };
                foreach (QuestionOptDTO item in model)
                {
                    if (tempQuestion != item.QuestionID)
                    {
                        if (tempIndicator != item.IndicatorID)
                        {
                            indicator = new Indicator
                            {
                                Id = item.IndicatorID,
                                Name1 = item.IndicatorName,
                                Questions = new List<Question>()
                            };
                            questionnaries.Indicators.Add(indicator);
                        }
                        question = new Question
                        {
                            Id = item.QuestionID,
                            Name1 = item.QuestionName,
                            Options = new List<QuestionOption>()
                        };
                        indicator.Questions.Add(question);
                    }
                    QuestionOption option = new QuestionOption 
                    {
                        Id = item.OptionID,
                        Name1 = item.OptionName
                    };
                    question.Options.Add(option);
                    tempIndicator = item.IndicatorID;
                    tempQuestion = item.QuestionID;
                }

                //QuestionnaireFormDTO form = new QuestionnaireFormDTO
                //{
                //    QuestionnaireID = model.FirstOrDefault().QuestionnaireID,
                //    QuestionnaireName = model.FirstOrDefault().QuestionnaireName,
                //    QuestionnaireDescription = model.FirstOrDefault().QuestionnaireDescription,
                //    QuestionnaireCreatedDate = model.FirstOrDefault().QuestionnaireCreatedDate,
                //    ListOfQuestOption = new List<QuestOptionTempDTO>()
                //};
                //foreach (QuestionOptDTO item in model)
                //{
                //    QuestOptionTempDTO option = new QuestOptionTempDTO
                //    {
                //        IndicatorID = item.IndicatorID,
                //        IndicatorName = item.IndicatorName,
                //        QuestionID = item.QuestionID,
                //        QuestionName = item.QuestionName,
                //        OptionID = item.OptionID,
                //        OptionName = item.OptionName
                //    };
                //    form.ListOfQuestOption.Add(option);
                //}
                return questionnaries;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Questionnaries> GetQuestionnairesWithQuestion() 
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities()) 
                { 
                    var query = @"select qq.Id as 'Id',qq.QuestName as 'Name1',qq.QuestName2 as 'Name2'
                                ,qq.QuestName3 as 'Name3',qq.InsertDate  as 'CreatedDate',qq.Description from tblQuestion q
                                left join IndicatorsDetails id on q.Id=id.QuestionID
                                left join tblQuestionnaire qq on id.QuestionnaireID=qq.Id
                                left join tblIndicators i on id.IndicatorID= i.Id
                                left join tblQuestionOption qo on qo.QuestionID=q.Id
                                Where qq.Id is not null and qq.IsActive='True'
                                group by qq.Id,qq.QuestName,qq.QuestName2,qq.QuestName3,qq.InsertDate,qq.Description ";

                    IDbConnection dbConnection = db.Database.Connection;
                    var res = dbConnection.QueryMultiple(query);
                    List<Questionnaries> model = res.Read<Questionnaries>().ToList();
                    return model;
                }
                   
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
