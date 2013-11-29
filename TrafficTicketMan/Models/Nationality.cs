using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TrafficTicketMan.Models
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        [Required]
        public int Country { get; set; }
    }
}
