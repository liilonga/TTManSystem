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
    public class DistrictsController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Districts/

        public ActionResult Index()
        {
            return View(db.Districts.ToList());
        }

        //
        // GET: /Districts/Details/5

        public ActionResult Details(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // GET: /Districts/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Districts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(district);
        }

        //
        // GET: /Districts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // POST: /Districts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(district);
        }

        //
        // GET: /Districts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // POST: /Districts/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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