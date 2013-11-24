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
        [Display(Name = "Ticket Issued On")]
        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        [Required]
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }

        public int TrafficOfficerId { get; set; }
        public TrafficOfficer TrafficOfficer { get; set; }

        [Display(Name = "Offender (Driver)")]
        public int OffenderDriverId { get; set; }
        public OffenderDriver OffenderDriver { get; set; }

        [Display(Name = "Offender (Vehicle)")]
        public int OffenderVehicleId { get; set; }
        public OffenderVehicle OffenderVehicle { get; set; }

        [Display(Name = "Offence")]
        public int OffenceTypeId { get; set; }
        public OffenceType OffenceType { get; set; }

        [Required]
        public double TicketAmount { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public DateTime CapturedDate { get; set; }

        [Required]
        [Display(Name = "Issued By")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}