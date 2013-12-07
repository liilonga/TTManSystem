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
    public class VehiclesController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Vehicles/

        public ActionResult Index()
        {
            return View(db.OffenderVehicles.ToList());
        }

        //
        // GET: /Vehicles/Details/5

        public ActionResult Details(int id = 0)
        {
            OffenderVehicle offendervehicle = db.OffenderVehicles.Find(id);
            if (offendervehicle == null)
            {
                return HttpNotFound();
            }
            return View(offendervehicle);
        }

        //
        // GET: /Vehicles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Vehicles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffenderVehicle offendervehicle)
        {
            if (ModelState.IsValid)
            {
                db.OffenderVehicles.Add(offendervehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offendervehicle);
        }

        //
        // GET: /Vehicles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OffenderVehicle offendervehicle = db.OffenderVehicles.Find(id);
            if (offendervehicle == null)
            {
                return HttpNotFound();
            }
            return View(offendervehicle);
        }

        //
        // POST: /Vehicles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OffenderVehicle offendervehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offendervehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offendervehicle);
        }

        //
        // GET: /Vehicles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OffenderVehicle offendervehicle = db.OffenderVehicles.Find(id);
            if (offendervehicle == null)
            {
                return HttpNotFound();
            }
            return View(offendervehicle);
        }

        //
        // POST: /Vehicles/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffenderVehicle offendervehicle = db.OffenderVehicles.Find(id);
            db.OffenderVehicles.Remove(offendervehicle);
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