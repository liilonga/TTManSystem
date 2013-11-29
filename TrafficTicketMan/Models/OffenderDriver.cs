using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class OffenderDriver
    {
        public int OffenderDriverId { get; set; }

        public string DrivingLicenseNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

       [Display(Name = "Contact Number")]
       public string ContactNumber { get; set; }

       [Display(Name = "Residentia lAddress")]
       public string ResidentialAddress { get; set; }

       [Display(Name = "Business Address")]
       public string BusinessAddress { get; set; }

       [Display(Name = "Postal Address")]
       public string PostalAddress { get; set; }

       [Display(Name = "Occupation or Status")]
       public string Occupation { get; set; }

       //[Display(Name = "Sex")]
       public string Sex { get; set; }

       public int NationalityId { get; set; }
       public Nationality Nationality { get; set; }

       [Required]
       [Display(Name = "Identity Description")]
       public int IDTypeId { get; set; }
       public IDType IDType { get; set; }

       [Required]
       [Display(Name = "Identity Number")]
       public string IDNumber { get; set; }

    }
}