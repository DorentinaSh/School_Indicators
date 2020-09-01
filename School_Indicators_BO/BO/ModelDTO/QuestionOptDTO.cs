using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BO.BO.ModelDTO
{
    public class QuestionOptDTO:Base
    {
        public int QuestionnaireID { get; set; }
        public string QuestionnaireName { get; set; }
        public string QuestionnaireDescription { get; set; }
        public DateTime QuestionnaireCreatedDate { get; set; }
        public int IndicatorID { get; set; }
        public string IndicatorName { get; set; }
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public int OptionID { get; set; }
        public string OptionName { get; set; }
    }
}
