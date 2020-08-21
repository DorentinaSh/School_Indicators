using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BO.BO
{
    public class Indicator : Base
    {
        [Display(Name = "Name in Albanian")]
        public string Name1 { get; set; }
        [Display(Name = "Name in English")]
        public string Name2 { get; set; }
        [Display(Name = "Name in Srpsko")]
        public string Name3 { get; set; }
        public bool IsActive { get; set; }
    }
}
