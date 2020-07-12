using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class Base
    {
        public int ID { get; set; }
        public DateTime InsertDate { get; set; }
        public int InsertBy { get; set; }
        public int LUN { get; set; }
        public string LUB { get; set; }
        public DateTime LUD { get; set; }
    }
}