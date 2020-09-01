using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BO.BO.ModelDTO
{
    public class QuestionnaireFormDTO:Base
    {
        public int QuestionnaireID { get; set; }
        public string QuestionnaireName { get; set; }
        public string QuestionnaireDescription { get; set; }
        public DateTime QuestionnaireCreatedDate { get; set; }
        public List<QuestOptionTempDTO> ListOfQuestOption { get; set;  }
    }
}
