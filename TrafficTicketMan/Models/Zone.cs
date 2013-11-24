using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class Zone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }

        [Required]
        [Display(Name = "Traffic Office")]
        public int TrafficOfficeId { get; set; }
        public TrafficOffice TrafficOffice { get; set; }
    }
}