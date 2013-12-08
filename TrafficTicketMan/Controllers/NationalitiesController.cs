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
    public class NationalitiesController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Nationalities/

        public ActionResult Index()
        {
            return View(db.Nationalities.ToList());
        }

        //
        // GET: /Nationalities/Details/5

        public ActionResult Details(int id = 0)
        {
            Nationality nationality = db.Nationalities.Find(id);
            if (nationality == null)
            {
                return HttpNotFound();
            }
            return View(nationality);
        }

        //
        // GET: /Nationalities/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Nationalities/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                db.Nationalities.Add(nationality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nationality);
        }

        //
        // GET: /Nationalities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Nationality nationality = db.Nationalities.Find(id);
            if (nationality == null)
            {
                return HttpNotFound();
            }
            return View(nationality);
        }

        //
        // POST: /Nationalities/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nationality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nationality);
        }

        //
        // GET: /Nationalities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Nationality nationality = db.Nationalities.Find(id);
            if (nationality == null)
            {
                return HttpNotFound();
            }
            return View(nationality);
        }

        //
        // POST: /Nationalities/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nationality nationality = db.Nationalities.Find(id);
            db.Nationalities.Remove(nationality);
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