using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using School_Indicators.BO;
using School_Indicators_DAL;

namespace School_Indicators_BLL
{
    public class QuestionnaireService
    {
        School_CardsEntities db = new School_CardsEntities();
        public List<Questionnaries> GetQuestionnaries()
        {
            List<Questionnaries> model = (from e in db.tblQuestionnaires
                                          select new Questionnaries
                                          {

                                          }).ToList();
            return model;
        }

    }
}
