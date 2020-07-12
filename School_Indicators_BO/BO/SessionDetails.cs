using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class SessionDetails:Base
    {
        public int SessionID { get; set; }
        public int QuestionID { get; set; }
        public int QuestionOptionID { get; set; }
        public string QuestionAnswer { get; set; }
        public string Description { get; set; }
    }
}