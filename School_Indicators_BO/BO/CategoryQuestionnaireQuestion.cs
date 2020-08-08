using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators.BO
{
    public class CategoryQuestionnaireQuestion
    {
        public int CategoryName { get; set; }
        public int QuestionnaireName { get; set; }
        public int QuestionName { get; set; }
        public int CategoryId { get; set; }
        public int QuestionnaireId { get; set; }
        public int QuestionId { get; set; }
    }
}
