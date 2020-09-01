using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BO.BO.ModelDTO
{
    class QuestionnaireDTO
    {
        public int QuestionnaireID { get; set; }
        public string QuestionnaireName { get; set; }
        public string QuestionnaireDescription { get; set; }
        public DateTime QuestionnaireCreatedDate { get; set; }
    }
}
