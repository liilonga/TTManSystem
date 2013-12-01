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
        public DbSet<TrafficOffice> TrafficOffices { get; set; }
        public DbSet<InvestigationOfficer> InvestigationOfficers { get; set; }
        public DbSet<Region> Regions { get; set; }
        //public DbSet<Town> Towns { get; set; }
        //public DbSet<Zone> Zones { get; set; }
        public DbSet<Entity> Entities { get; set; }
        public DbSet<IDType> IDTypes { get; set; }
        public DbSet<OffenderDriver> OffenderDrivers { get; set; }
        public DbSet<OffenderVehicle> OffenderVehicles { get; set; }
        public DbSet<OffenceType> OffenceTypes { get; set; }
        public DbSet<OfficeDeployment> OfficeDeployment { get; set; }
        public DbSet<DeploymentHistory> DeploymentHistory { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<PeaceOfficerCapacity> PeaceOfficerCapacities { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
    }
}