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
    public class DriversController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Drivers/

        public ActionResult Index()
        {
            var offenderdrivers = db.OffenderDrivers.Include(o => o.Nationality).Include(o => o.IDType);
            return View(offenderdrivers.ToList());
        }

        //
        // GET: /Drivers/Details/5

        public ActionResult Details(int id = 0)
        {
            OffenderDriver offenderdriver = db.OffenderDrivers.Find(id);
            if (offenderdriver == null)
            {
                return HttpNotFound();
            }
            return View(offenderdriver);
        }

        //
        // GET: /Drivers/Create

        public ActionResult Create()
        {
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "NationalityId");
            ViewBag.IDTypeId = new SelectList(db.IDTypes, "IDTypeId", "IDDescription");
            return View();
        }

        //
        // POST: /Drivers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffenderDriver offenderdriver)
        {
            if (ModelState.IsValid)
            {
                db.OffenderDrivers.Add(offenderdriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "NationalityId", offenderdriver.NationalityId);
            ViewBag.IDTypeId = new SelectList(db.IDTypes, "IDTypeId", "IDDescription", offenderdriver.IDTypeId);
            return View(offenderdriver);
        }

        //
        // GET: /Drivers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OffenderDriver offenderdriver = db.OffenderDrivers.Find(id);
            if (offenderdriver == null)
            {
                return HttpNotFound();
            }
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "NationalityId", offenderdriver.NationalityId);
            ViewBag.IDTypeId = new SelectList(db.IDTypes, "IDTypeId", "IDDescription", offenderdriver.IDTypeId);
            return View(offenderdriver);
        }

        //
        // POST: /Drivers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OffenderDriver offenderdriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offenderdriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "NationalityId", offenderdriver.NationalityId);
            ViewBag.IDTypeId = new SelectList(db.IDTypes, "IDTypeId", "IDDescription", offenderdriver.IDTypeId);
            return View(offenderdriver);
        }

        //
        // GET: /Drivers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OffenderDriver offenderdriver = db.OffenderDrivers.Find(id);
            if (offenderdriver == null)
            {
                return HttpNotFound();
            }
            return View(offenderdriver);
        }

        //
        // POST: /Drivers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffenderDriver offenderdriver = db.OffenderDrivers.Find(id);
            db.OffenderDrivers.Remove(offenderdriver);
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