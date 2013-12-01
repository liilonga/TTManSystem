using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class PoliceStation
    {
        public int PoliceStationId { get; set; }

        [Required]
        [Display(Name = "Police Station")]
        public string StationName { get; set; }

        [Required]
        [Display(Name = "District/Division")]
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}