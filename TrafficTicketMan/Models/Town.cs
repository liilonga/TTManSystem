using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class Town
    {
        public int TownId { get; set; }
        [Required]
        public string TownName { get; set; }
    }
}