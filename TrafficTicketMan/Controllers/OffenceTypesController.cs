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
    public class OffenceTypesController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /OffenceTypes/

        public ActionResult Index()
        {
            return View(db.OffenceTypes.ToList());
        }

        //
        // GET: /OffenceTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            OffenceType offencetype = db.OffenceTypes.Find(id);
            if (offencetype == null)
            {
                return HttpNotFound();
            }
            return View(offencetype);
        }

        //
        // GET: /OffenceTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OffenceTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OffenceType offencetype)
        {
            if (ModelState.IsValid)
            {
                db.OffenceTypes.Add(offencetype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(offencetype);
        }

        //
        // GET: /OffenceTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OffenceType offencetype = db.OffenceTypes.Find(id);
            if (offencetype == null)
            {
                return HttpNotFound();
            }
            return View(offencetype);
        }

        //
        // POST: /OffenceTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OffenceType offencetype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offencetype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offencetype);
        }

        //
        // GET: /OffenceTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OffenceType offencetype = db.OffenceTypes.Find(id);
            if (offencetype == null)
            {
                return HttpNotFound();
            }
            return View(offencetype);
        }

        //
        // POST: /OffenceTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OffenceType offencetype = db.OffenceTypes.Find(id);
            db.OffenceTypes.Remove(offencetype);
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