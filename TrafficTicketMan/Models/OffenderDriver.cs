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
        [Display(Name = "Identity Description")]
        public int IDTypeId { get; set; }
        public IDType IDType { get; set; }

        [Required]
        [Display(Name = "Identity Number")]
        public string IDNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

    }
}