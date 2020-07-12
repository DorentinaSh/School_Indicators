using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO.ASP_Authentication
{
    public class AuthRoles
    {
        public int ID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        //Name in Albanian Language
        public string Name1 { get; set; }

        //Name in English Language
        public string Name2 { get; set; }

        //Name in Serbian Language
        public string Name3 { get; set; }
        public int ParentID { get; set; }
        public string EditMode { get; set; }
        public string Icon { get; set; }
        public int Dependent { get; set; }
        public int OrderBy { get; set; }
    }
}