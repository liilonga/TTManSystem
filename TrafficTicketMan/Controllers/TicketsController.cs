using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafficTicketMan.Models;
using TrafficTicketMan.ViewModels;

namespace TrafficTicketMan.Controllers
{
    public class TicketsController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Tickets/

        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Entity).Include(t => t.PoliceStation).Include(t => t.InvestigationOfficer).Include(t => t.OffenceType).Include(t => t.OffenderDriver).Include(t => t.OffenderVehicle).Include(t => t.PeaceOfficerCapacity);
            return View(tickets.ToList());
        }

        //
        // GET: /Tickets/Details/5

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Tickets/Create

        public ActionResult Create()
        {
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityName");
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "StationName");

            var InvestigationOfficers = from a in db.InvestigationOfficers
                                        select new
                                        {
                                            InvestigationOfficerId = a.InvestigationOfficerId,
                                            InvestigationOfficerFullName = a.FName + " " + a.LName
                                        };

            ViewBag.InvestigationOfficerId = new SelectList(InvestigationOfficers, "InvestigationOfficerId", "InvestigationOfficerFullName");
            //ViewBag.InvestigationOfficerId = new SelectList(db.InvestigationOfficers, "InvestigationOfficerId", "EmpNo");
            ViewBag.OffenceTypeId = new SelectList(db.OffenceTypes, "OffenceTypeId", "OffenceName");
            ViewBag.OffenderDriverId = new SelectList(db.OffenderDrivers, "OffenderDriverId", "DrivingLicenseNumber");
            ViewBag.OffenderVehicleId = new SelectList(db.OffenderVehicles, "OffenderVehicleId", "OffenderVehicleId");
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.PeaceOfficerCapacityId = new SelectList(db.PeaceOfficerCapacities, "PeaceOfficerCapacityId", "Capacity");

            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "Country");
            ViewBag.IDTypeId = new SelectList(db.IDTypes, "IDTypeId", "IDDescription");
            //ViewBag.SexId = new SelectList(db.Sex, "SexId", "SexType");
            ViewBag.SexId = new SelectList(db.Sex, "SexId", "SexType");

            return View();
        }

        //
        // POST: /Tickets/Create

        [HttpPost]
        [ValidateAntiForgeryToken]  
        public ActionResult Create(TicketDriverVehicleViewModel ticketDriverVehicleViewModel, int EntityId, int InvestigationOfficerId,
            int OffenceTypeId, int SexId, int? OffenderDriverId, int? OffenderVehicleId, int PeaceOfficerCapacityId, int NationalityId, int IDTypeId,
            int PoliceStationId)   
        {

            var ticket1 = new Ticket()
            {
                TicketNo = ticketDriverVehicleViewModel.Ticket.TicketNo,
                EntityId = EntityId,
                PoliceStationId = PoliceStationId,
                CRnumber = ticketDriverVehicleViewModel.Ticket.CRnumber,
                PlaceOfTrial = ticketDriverVehicleViewModel.Ticket.PlaceOfTrial,
                InvestigationOfficerId = InvestigationOfficerId,
                CourtNo = ticketDriverVehicleViewModel.Ticket.CourtNo,
                TrialDate = ticketDriverVehicleViewModel.Ticket.TrialDate,
                OffenceTypeId = OffenceTypeId,
                //OffenderDriverId = driverId,
                //OffenderVehicleId = vehicleId,
                TicketAmount = ticketDriverVehicleViewModel.Ticket.TicketAmount,
                TicketDiscrption = ticketDriverVehicleViewModel.Ticket.TicketDiscrption,
                IssueDate = ticketDriverVehicleViewModel.Ticket.IssueDate,
                ExpiryDate = ticketDriverVehicleViewModel.Ticket.ExpiryDate,
                CapturedDate = DateTime.Now,
                UserId = 1,
                IssuePlace = ticketDriverVehicleViewModel.Ticket.IssuePlace,
                PeaceOfficerCapacityId = PeaceOfficerCapacityId
            };

            if (ticketDriverVehicleViewModel != null)
            {
                Utility utility = new Utility();
                int driverId = 0;
                int vehicleId = 0;

                //Save Driver
                if (ticketDriverVehicleViewModel.OffenderDriver != null)
                {
                    var postedDriver = ticketDriverVehicleViewModel.OffenderDriver;

                    OffenderDriver driver = utility.GetDriver(postedDriver.IDNumber, postedDriver.DrivingLicenseNumber);

                    //Check if driver exists already in the database
                    if (driver != null)
                        driverId = driver.OffenderDriverId;
                    else
                    {
                        var newDriver = new OffenderDriver()
                        {
                            DrivingLicenseNumber = postedDriver.DrivingLicenseNumber,
                            FName = postedDriver.FName,
                            LName = postedDriver.LName,
                            ContactNumber = postedDriver.ContactNumber,
                            ResidentialAddress = postedDriver.ResidentialAddress,
                            BusinessAddress = postedDriver.BusinessAddress,
                            PostalAddress = postedDriver.PostalAddress,
                            Occupation = postedDriver.Occupation,
                            SexId = SexId,
                            NationalityId = NationalityId,
                            IDTypeId = IDTypeId,
                            IDNumber = postedDriver.IDNumber
                        };

                        db.OffenderDrivers.Add(newDriver);
                        db.SaveChanges();

                        driverId = newDriver.OffenderDriverId;
                    }

                    //Assign driver Id to ticket
                    ticket1.OffenderDriverId = driverId;
                }
                //Save Vehicle
                else if (ticketDriverVehicleViewModel.OffenderVehicle != null)
                {
                    var postedVehicle = ticketDriverVehicleViewModel.OffenderVehicle;

                    OffenderVehicle vehicle = utility.GetVehicle(postedVehicle.VehicelRegistrationNumber);
                    //Check if driver exists already in the database
                    if (vehicle != null)
                        vehicleId = vehicle.OffenderVehicleId;
                    else
                    {
                        var newVehicle = new OffenderVehicle()
                        {
                            VehicelRegistrationNumber = postedVehicle.VehicelRegistrationNumber
                        };

                        db.OffenderVehicles.Add(newVehicle);
                        db.SaveChanges();

                        vehicleId = newVehicle.OffenderVehicleId;
                    }
                    //Assign vehicle Id to ticket
                    ticket1.OffenderVehicleId = vehicleId;
                }

                db.Tickets.Add(ticket1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityName", ticketDriverVehicleViewModel.Ticket.EntityId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", ".TicketPoliceStationId", ticketDriverVehicleViewModel.Ticket.PoliceStationId);

            var InvestigationOfficers = from a in db.InvestigationOfficers
                                        select new
                                        {
                                            InvestigationOfficerId = a.InvestigationOfficerId,
                                            InvestigationOfficerFullName = a.FName + " " + a.LName
                                        };

            ViewBag.InvestigationOfficerId = new SelectList(InvestigationOfficers, "InvestigationOfficerId", "InvestigationOfficerFullName", ticketDriverVehicleViewModel.Ticket.InvestigationOfficerId);
            ViewBag.OffenceTypeId = new SelectList(db.OffenceTypes, "OffenceTypeId", "OffenceName", ticketDriverVehicleViewModel.Ticket.OffenceTypeId);
            ViewBag.OffenderDriverId = new SelectList(db.OffenderDrivers, "OffenderDriverId", "DrivingLicenseNumber", ticketDriverVehicleViewModel.Ticket.OffenderDriverId);
            ViewBag.OffenderVehicleId = new SelectList(db.OffenderVehicles, "OffenderVehicleId", "OffenderVehicleId", ticketDriverVehicleViewModel.Ticket.OffenderVehicleId);
            ViewBag.PeaceOfficerCapacityId = new SelectList(db.PeaceOfficerCapacities, "PeaceOfficerCapacityId", "Capacity", ticketDriverVehicleViewModel.Ticket.PeaceOfficerCapacityId);
            return View(ticketDriverVehicleViewModel);

        }

        //
        // GET: /Tickets/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityName", ticket.EntityId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationId", ticket.PoliceStationId);
            ViewBag.InvestigationOfficerId = new SelectList(db.InvestigationOfficers, "InvestigationOfficerId", "EmpNo", ticket.InvestigationOfficerId);
            ViewBag.OffenceTypeId = new SelectList(db.OffenceTypes, "OffenceTypeId", "OffenceName", ticket.OffenceTypeId);
            ViewBag.OffenderDriverId = new SelectList(db.OffenderDrivers, "OffenderDriverId", "DrivingLicenseNumber", ticket.OffenderDriverId);
            ViewBag.OffenderVehicleId = new SelectList(db.OffenderVehicles, "OffenderVehicleId", "OffenderVehicleId", ticket.OffenderVehicleId);
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", ticket.UserId);
            ViewBag.PeaceOfficerCapacityId = new SelectList(db.PeaceOfficerCapacities, "PeaceOfficerCapacityId", "Capacity", ticket.PeaceOfficerCapacityId);
            return View(ticket);
        }

        //
        // POST: /Tickets/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityName", ticket.EntityId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationId", ticket.PoliceStationId);
            ViewBag.InvestigationOfficerId = new SelectList(db.InvestigationOfficers, "InvestigationOfficerId", "EmpNo", ticket.InvestigationOfficerId);
            ViewBag.OffenceTypeId = new SelectList(db.OffenceTypes, "OffenceTypeId", "OffenceName", ticket.OffenceTypeId);
            ViewBag.OffenderDriverId = new SelectList(db.OffenderDrivers, "OffenderDriverId", "DrivingLicenseNumber", ticket.OffenderDriverId);
            ViewBag.OffenderVehicleId = new SelectList(db.OffenderVehicles, "OffenderVehicleId", "OffenderVehicleId", ticket.OffenderVehicleId);
            //ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", ticket.UserId);
            ViewBag.PeaceOfficerCapacityId = new SelectList(db.PeaceOfficerCapacities, "PeaceOfficerCapacityId", "Capacity", ticket.PeaceOfficerCapacityId);
            return View(ticket);
        }

        //
        // GET: /Tickets/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Tickets/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}