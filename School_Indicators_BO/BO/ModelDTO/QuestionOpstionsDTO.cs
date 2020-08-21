using School_Indicators.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Indicators_BO.BO.ModelDTO
{
    public class QuestionOpstionsDTO
    {
        public Question Question { get; set; }
        public List<QuestionOption> Options { get; set; }
    }
}
