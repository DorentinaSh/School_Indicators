using School_Indicators_BO.BO;
using School_Indicators_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BLL
{
    public class EvaluationService
    {
        public List<Evaluation> GetRate()
        {
            try
            {
                using (School_IndicatorsEntities db = new School_IndicatorsEntities())
                {
                    List<Evaluation> model = (from e in db.tblEvaluations
                                        select new Evaluation
                                        {
                                            Id = e.Id,
                                            Value = e.Value
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
