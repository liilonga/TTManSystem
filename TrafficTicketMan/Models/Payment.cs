using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        [Required]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PayamentDate { get; set; }

        public string PayedAt { get; set; }

        [Required]
        [Display(Name = "Captured By")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}