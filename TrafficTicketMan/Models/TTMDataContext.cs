using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class TTMDataContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<TrafficOffice> TrafficOffices { get; set; }
        public DbSet<User> Users { get; set; }
    }
}