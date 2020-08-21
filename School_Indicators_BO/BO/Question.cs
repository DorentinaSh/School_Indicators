using School_Indicators_BO.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class Question : Base
    {
        public int QuestionnaireID { get; set; }
        public string QuestionnaireName { get; set; }
        public int IndicatorId { get; set; }
        public string IndicatorName { get; set; }
        public Nullable<int> QuestionTypeID { get; set; }
        public string QuestionTypeName { get; set; }
        //Name in Albanian Language
        [Display(Name =  "Name in Albanian")]
        public string Name1 { get; set; }

        //Name in English Language
        [Display(Name = "Name in English")]
        public string Name2 { get; set; }

        //Name in Srpsko Language
        [Display(Name = "Name in Srpsko")]
        public string Name3 { get; set; }
        public int RelatedQuestionOptionID { get; set; }
        public bool IsActive { get; set; }
        public int OrderBy { get; set; }

        public List<Evaluation> Rate { get; set; }
    }
}