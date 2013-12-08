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
    public class PeaceOfficerCapacitiesController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /PeaceOfficerCapacities/

        public ActionResult Index()
        {
            return View(db.PeaceOfficerCapacities.ToList());
        }

        //
        // GET: /PeaceOfficerCapacities/Details/5

        public ActionResult Details(int id = 0)
        {
            PeaceOfficerCapacity peaceofficercapacity = db.PeaceOfficerCapacities.Find(id);
            if (peaceofficercapacity == null)
            {
                return HttpNotFound();
            }
            return View(peaceofficercapacity);
        }

        //
        // GET: /PeaceOfficerCapacities/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PeaceOfficerCapacities/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PeaceOfficerCapacity peaceofficercapacity)
        {
            if (ModelState.IsValid)
            {
                db.PeaceOfficerCapacities.Add(peaceofficercapacity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peaceofficercapacity);
        }

        //
        // GET: /PeaceOfficerCapacities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PeaceOfficerCapacity peaceofficercapacity = db.PeaceOfficerCapacities.Find(id);
            if (peaceofficercapacity == null)
            {
                return HttpNotFound();
            }
            return View(peaceofficercapacity);
        }

        //
        // POST: /PeaceOfficerCapacities/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PeaceOfficerCapacity peaceofficercapacity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peaceofficercapacity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peaceofficercapacity);
        }

        //
        // GET: /PeaceOfficerCapacities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PeaceOfficerCapacity peaceofficercapacity = db.PeaceOfficerCapacities.Find(id);
            if (peaceofficercapacity == null)
            {
                return HttpNotFound();
            }
            return View(peaceofficercapacity);
        }

        //
        // POST: /PeaceOfficerCapacities/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PeaceOfficerCapacity peaceofficercapacity = db.PeaceOfficerCapacities.Find(id);
            db.PeaceOfficerCapacities.Remove(peaceofficercapacity);
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