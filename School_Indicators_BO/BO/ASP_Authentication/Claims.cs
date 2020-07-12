using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO.ASP_Authentication
{
    public class Claims
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}