using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        [Required]
        [Display(Name = "District/Division")]
        public string DistrictName { get; set; }
    }
}