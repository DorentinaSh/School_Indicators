using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class Questionnaries:Base
    {
        public int Id { get; set; }
        //Name in Albanian Language
        public string Name1 { get; set; }

        //Name in English Language
        public string Name2 { get; set; }

        //Name in Serbian Language
        public string Name3 { get; set; }
        public bool IsActive { get; set; }
        public int OrderBy { get; set; }
    }
}