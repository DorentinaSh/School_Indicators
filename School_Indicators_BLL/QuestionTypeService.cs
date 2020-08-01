using School_Indicators.BO;
using School_Indicators_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BLL
{
    public class QuestionTypeService
    {
        public List<QuestionType> GetAllQuestionType()
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
