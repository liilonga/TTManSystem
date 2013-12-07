using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrafficTicketMan.Models;

namespace TrafficTicketMan.Controllers
{
    public class TicketsController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Tickets/

        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Entity).Include(t => t.PoliceStation).Include(t => t.InvestigationOfficer).Include(t => t.OffenceType).Include(t => t.OffenderDriver).Include(t => t.OffenderVehicle).Include(t => t.User).Include(t => t.PeaceOfficerCapacity);
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
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.PeaceOfficerCapacityId = new SelectList(db.PeaceOfficerCapacities, "PeaceOfficerCapacityId", "Capacity");

            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "NationalityId");
            ViewBag.IDTypeId = new SelectList(db.IDTypes, "IDTypeId", "IDDescription");

            return View();
        }

        //
        // POST: /Tickets/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Entities, "EntityId", "EntityName", ticket.EntityId);
            ViewBag.PoliceStationId = new SelectList(db.PoliceStations, "PoliceStationId", "PoliceStationId", ticket.PoliceStationId);

            var InvestigationOfficers = from a in db.InvestigationOfficers
                                        select new 
                                        {
                                            InvestigationOfficerId = a.InvestigationOfficerId,
                                            InvestigationOfficerFullName = a.FName +" "+a.LName
                                        };

            ViewBag.InvestigationOfficerId = new SelectList(InvestigationOfficers, "InvestigationOfficerId", "InvestigationOfficerFullName", ticket.InvestigationOfficerId);
            ViewBag.OffenceTypeId = new SelectList(db.OffenceTypes, "OffenceTypeId", "OffenceName", ticket.OffenceTypeId);
            ViewBag.OffenderDriverId = new SelectList(db.OffenderDrivers, "OffenderDriverId", "DrivingLicenseNumber", ticket.OffenderDriverId);
            ViewBag.OffenderVehicleId = new SelectList(db.OffenderVehicles, "OffenderVehicleId", "OffenderVehicleId", ticket.OffenderVehicleId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", ticket.UserId);
            ViewBag.PeaceOfficerCapacityId = new SelectList(db.PeaceOfficerCapacities, "PeaceOfficerCapacityId", "Capacity", ticket.PeaceOfficerCapacityId);
            return View(ticket);
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
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", ticket.UserId);
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
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", ticket.UserId);
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