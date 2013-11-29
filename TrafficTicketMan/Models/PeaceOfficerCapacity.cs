using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TrafficTicketMan.Models
{
    public class PeaceOfficerCapacity
    {
        public int PeaceOfficerCapacityId { get; set; }
        [Required]
        public string Capacity { get; set; }
    }
}
