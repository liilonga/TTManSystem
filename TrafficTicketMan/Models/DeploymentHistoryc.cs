using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class DeploymentHistory
    {
        public int DeploymentHistoryId { get; set; }

        [Required]
        public int TrafficOfficeId { get; set; }
        public TrafficOffice TrafficOffice { get; set; }

        [Required]
        public int TrafficOfficerId { get; set; }
        public TrafficOfficer TrafficOfficer { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }


    }
}