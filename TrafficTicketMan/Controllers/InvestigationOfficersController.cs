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
    public class InvestigationOfficersController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /InvestigationOfficers/

        public ActionResult Index()
        {
            return View(db.InvestigationOfficers.ToList());
        }

        //
        // GET: /InvestigationOfficers/Details/5

        public ActionResult Details(int id = 0)
        {
            InvestigationOfficer investigationofficer = db.InvestigationOfficers.Find(id);
            if (investigationofficer == null)
            {
                return HttpNotFound();
            }
            return View(investigationofficer);
        }

        //
        // GET: /InvestigationOfficers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /InvestigationOfficers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvestigationOfficer investigationofficer)
        {
            if (ModelState.IsValid)
            {
                db.InvestigationOfficers.Add(investigationofficer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investigationofficer);
        }

        //
        // GET: /InvestigationOfficers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InvestigationOfficer investigationofficer = db.InvestigationOfficers.Find(id);
            if (investigationofficer == null)
            {
                return HttpNotFound();
            }
            return View(investigationofficer);
        }

        //
        // POST: /InvestigationOfficers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvestigationOfficer investigationofficer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investigationofficer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investigationofficer);
        }

        //
        // GET: /InvestigationOfficers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InvestigationOfficer investigationofficer = db.InvestigationOfficers.Find(id);
            if (investigationofficer == null)
            {
                return HttpNotFound();
            }
            return View(investigationofficer);
        }

        //
        // POST: /InvestigationOfficers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestigationOfficer investigationofficer = db.InvestigationOfficers.Find(id);
            db.InvestigationOfficers.Remove(investigationofficer);
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