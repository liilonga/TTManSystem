using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class TrafficOffice
    {
        public int TrafficOfficeId { get; set; }
        [Required]
        public string OfficeName { get; set; }
    }
}