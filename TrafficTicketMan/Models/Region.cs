using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        [Required]
        public string RegionName { get; set; }
    }
}