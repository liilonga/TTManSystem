using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class Entity
    {
        [Display(Name = "Ticket Issued On")]
        public int EntityId { get; set; }
        [Required]
        [Display(Name = "Ticket Issued On")]
        public string EntityName { get; set; }
    }
}