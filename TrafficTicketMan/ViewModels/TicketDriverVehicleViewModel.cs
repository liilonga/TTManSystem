using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrafficTicketMan.Models;

namespace TrafficTicketMan.ViewModels
{
    public class TicketDriverVehicleViewModel
    {
        public Ticket Ticket { get; set; }
        public OffenderDriver OffenderDriver { get; set; }
        public OffenderVehicle OffenderVehicle { get; set; }
    }
}