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
    public class PoliceStationsController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /PoliceStations/

        public ActionResult Index()
        {
            var policestations = db.PoliceStations.Include(p => p.District);
            return View(policestations.ToList());
        }

        //
        // GET: /PoliceStations/Details/5

        public ActionResult Details(int id = 0)
        {
            PoliceStation policestation = db.PoliceStations.Find(id);
            if (policestation == null)
            {
                return HttpNotFound();
            }
            return View(policestation);
        }

        //
        // GET: /PoliceStations/Create

        public ActionResult Create()
        {
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName");
            return View();
        }

        //
        // POST: /PoliceStations/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PoliceStation policestation)
        {
            if (ModelState.IsValid)
            {
                db.PoliceStations.Add(policestation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", policestation.DistrictId);
            return View(policestation);
        }

        //
        // GET: /PoliceStations/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PoliceStation policestation = db.PoliceStations.Find(id);
            if (policestation == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", policestation.DistrictId);
            return View(policestation);
        }

        //
        // POST: /PoliceStations/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PoliceStation policestation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policestation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "DistrictName", policestation.DistrictId);
            return View(policestation);
        }

        //
        // GET: /PoliceStations/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PoliceStation policestation = db.PoliceStations.Find(id);
            if (policestation == null)
            {
                return HttpNotFound();
            }
            return View(policestation);
        }

        //
        // POST: /PoliceStations/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoliceStation policestation = db.PoliceStations.Find(id);
            db.PoliceStations.Remove(policestation);
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