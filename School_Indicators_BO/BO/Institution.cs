using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace School_Indicators.BO
{
    public class Institution:Base
    {
        [Display(Name = "Institutions No")]
        [Required]
        [MinLength(0)]
        public string InstitutionsNo { get; set; }

        //Name in Albanian Language
        [Display(Name = "Name in Albanian")]
        public string Name1 { get; set; }

        //Name in English Language
        [Display(Name = "Name in English")]
        public string Name2 { get; set; }

        //Name in Serbian Language
        [Display(Name = "Name in Srpsko")]
        public string Name3 { get; set; }
        public string Location { get; set; }
        public int CityID { get; set; }
        public string Address { get; set; }
        [Display(Name = "Telephone Number")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNo { get; set; }
        public bool IsActive { get; set; }
    }
}