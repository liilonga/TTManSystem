using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class OfficeDeployment
    {
        public int OfficeDeploymentId { get; set; }

        [Required]
        public int TrafficOfficeId { get; set; }
        public TrafficOffice TrafficOffice { get; set; }

        [Required]
        public int TrafficOfficerId { get; set; }
        public InvestigationOfficer TrafficOfficer { get; set; }

    }
}