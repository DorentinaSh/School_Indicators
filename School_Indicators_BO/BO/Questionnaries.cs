using School_Indicators_BO.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class Questionnaries:Base
    {
        //public int Id { get; set; }
        //Name in Albanian Language
        [Display(Name = "Name in Albanian")]
        public string Name1 { get; set; }

        //Name in English Language
        [Display(Name = "Name in English")]
        public string Name2 { get; set; }

        //Name in Serbian Language
        [Display(Name = "Name in Srpsko")]
        public string Name3 { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int OrderBy { get; set; }
        public List<Indicator> Indicators { get; set; }
    }
}