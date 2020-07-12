using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class Session:Base
    {
        public int InstitutionID { get; set; }
        public int InstitutionUserID { get; set; }
        public int QuestionnaireID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}