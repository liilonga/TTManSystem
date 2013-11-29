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

        //[Required]
        //public int ZoneId { get; set; }
        //public Zone Zone { get; set; }

        [Required]
        [Display(Name = "Police Station")]
        public int PoliceStationId { get; set; }
        public PoliceStation PoliceStation { get; set; }

        [Display(Name = "CR No.")]
        public string CRnumber { get; set; }
        [Display(Name = "Place of Trial")]
        public string PlaceOfTrial { get; set; }

        public int InvestigationOfficerId { get; set; }
        public InvestigationOfficer InvestigationOfficer { get; set; }

        [Display(Name = "Court No.")]
        public string CourtNo { get; set; }

        [Display(Name = "TrialDate")]
        public DateTime TrialDate { get; set; }

        [Display(Name = "Offence")]
        public int OffenceTypeId { get; set; }
        public OffenceType OffenceType { get; set; }

        [Display(Name = "To (Driver)")]
        public int OffenderDriverId { get; set; }
        public OffenderDriver OffenderDriver { get; set; }

        [Display(Name = "To (Vehicle)")]
        public int OffenderVehicleId { get; set; }
        public OffenderVehicle OffenderVehicle { get; set; }

        [Required]
        public double TicketAmount { get; set; }

        [Required]
        public string TicketDiscrption { get; set; }
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

        [Required]
        [Display(Name = "Issue Place")]
        public string IssuePlace { get; set; }

        [Required]
        [Display(Name = "Peace Officer Capacity")]
        public int PeaceOfficerCapacityId { get; set; }
        public PeaceOfficerCapacity PeaceOfficerCapacity { get; set; }
    }
}