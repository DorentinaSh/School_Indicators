using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BO.BO
{
    public class CategoryOfQuestion : Base
    {
        [Display(Name = "Questionnaire")]
        public int QuestionnaireID { get; set; }
        public string QuestionnaireName { get; set; }
        public string CategoryName { get; set; }
        public string CategoryName2 { get; set; }
        public string CategoryName3 { get; set; }
    }
}
