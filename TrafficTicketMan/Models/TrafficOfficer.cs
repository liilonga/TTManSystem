using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class TrafficOfficer
    {
        public int TrafficOfficerId { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public string EmpNo { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
    }
}