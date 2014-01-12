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
        //public DbSet<User> Users { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<PeaceOfficerCapacity> PeaceOfficerCapacities { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Sex> Sex { get; set; }

        ////http://msdn.microsoft.com/en-US/data/jj591620
        ////http://forums.asp.net/p/1940806/5527150.aspx?EF+tables+causing+cause+cycles+or+multiple+cascade+paths+error+why+
        ////Error: Additional information: Introducing FOREIGN KEY constraint 'FK_dbo.Payments_dbo.Users_UserId' on table 'Payments' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO 
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Payment>().HasRequired(c => c.User).WithMany().WillCascadeOnDelete(false);
        //} 
    }
}