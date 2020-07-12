using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class InstitutionUser:Base
    {
        public int UserID { get; set; }
        public int InstitutionID { get; set; }
        public bool IsDefault { get; set; }
    }
}