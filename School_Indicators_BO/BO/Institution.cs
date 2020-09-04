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
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
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

        public int? CityID { get; set; }

        public string Address { get; set; }

        [Display(Name = "Telephone Number")]
        [DataType(DataType.PhoneNumber)]
        public string TelephoneNo { get; set; }

        public bool IsActive { get; set; }

        [Display(Name = "Female")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<long> TotalNr_Female { get; set; }

        [Display(Name = "Male")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<long> TotalNr_Male { get; set; }

        [Display(Name = "Female")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<long> Students_WithDisabilities_Female { get; set; }

        [Display(Name = "Male")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<long> Students_WithDisabilities_Male { get; set; }

        [Display(Name = "Female")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<long> EnrollmentsPerYear_Female { get; set; }

        [Display(Name = "Male")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public Nullable<long> EnrollmentsPerYear_Male { get; set; }

        public string Level { get; set; }
        public string Status { get; set; }
    }
}