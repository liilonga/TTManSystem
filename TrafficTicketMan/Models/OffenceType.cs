using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class OffenceType
    {
        public int OffenceTypeId { get; set; }
        public string OffenceName { get; set; }
        public string OffenceDescription { get; set; }
    }
}