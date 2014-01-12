using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrafficTicketMan.Models
{
    public class TTMDataContextInitializer : DropCreateDatabaseIfModelChanges<TTMDataContext>
    {
        protected override void Seed(TTMDataContext context)
        {
            //Districts
            context.Districts.Add(new District() { DistrictName = "Otjiwarongo" });
            context.Districts.Add(new District() { DistrictName = "Okahandja" });
            context.Districts.Add(new District() { DistrictName = "Windhoek" });

            //Police Stations
            context.PoliceStations.Add(new PoliceStation() { DistrictId = 1, StationName = "Otjiwarongo" });
            context.PoliceStations.Add(new PoliceStation() { DistrictId = 2, StationName = "Okahandja" });
            context.PoliceStations.Add(new PoliceStation() { DistrictId = 3, StationName = "Windhoek" });

            //Investigation Officer
            context.InvestigationOfficers.Add(new InvestigationOfficer() { EmpNo = "123",  FName="Leonard", LName="Iilonga"});
            context.InvestigationOfficers.Add(new InvestigationOfficer() { EmpNo = "456", FName = "Lazarus", LName = "Kanime" });

            //Ticket Issued On
            context.Entities.Add(new Entity(){EntityName = "Driver"});
            context.Entities.Add(new Entity() { EntityName = "Vehicle" });

            //Nationality
            context.Nationalities.Add(new Nationality() { Country = "Namibia" });
            context.Nationalities.Add(new Nationality() { Country = "Zambia" });
            context.Nationalities.Add(new Nationality() { Country = "Angola" });

            //ID Type
            context.IDTypes.Add(new IDType() { IDDescription="ID Card"});
            context.IDTypes.Add(new IDType() { IDDescription = "Passport" });

            //Offence Type
            context.OffenceTypes.Add(new OffenceType() { OffenceName = "Drink and Drive", OffenceDescription = "Driving while under the influence of alcohol" });
            context.OffenceTypes.Add(new OffenceType() { OffenceName = "Speeding", OffenceDescription = "" });

            //Peace Officer Capacity
            context.PeaceOfficerCapacities.Add(new PeaceOfficerCapacity() { Capacity="Traffic Officer"});

            //Sex
            context.Sex.Add(new Sex() { SexType = "Male" });
            context.Sex.Add(new Sex() { SexType = "Female" });
        }
    }
}