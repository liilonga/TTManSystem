using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        [Display (Name="Issued By")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}