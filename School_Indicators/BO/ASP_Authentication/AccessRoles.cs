using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO.ASP_Authentication
{
    public class AccessRoles
    {
        public int ID { get; set; }
        public int AuthenticationID { get; set; }
        public int RoleID { get; set; }
        public bool Read { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool Create { get; set; }
        public bool Show { get; set; }
    }
}