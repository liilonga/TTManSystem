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
    public class IDTypesController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /IDTypes/

        public ActionResult Index()
        {
            return View(db.IDTypes.ToList());
        }

        //
        // GET: /IDTypes/Details/5

        public ActionResult Details(int id = 0)
        {
            IDType idtype = db.IDTypes.Find(id);
            if (idtype == null)
            {
                return HttpNotFound();
            }
            return View(idtype);
        }

        //
        // GET: /IDTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /IDTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IDType idtype)
        {
            if (ModelState.IsValid)
            {
                db.IDTypes.Add(idtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idtype);
        }

        //
        // GET: /IDTypes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            IDType idtype = db.IDTypes.Find(id);
            if (idtype == null)
            {
                return HttpNotFound();
            }
            return View(idtype);
        }

        //
        // POST: /IDTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IDType idtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idtype);
        }

        //
        // GET: /IDTypes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            IDType idtype = db.IDTypes.Find(id);
            if (idtype == null)
            {
                return HttpNotFound();
            }
            return View(idtype);
        }

        //
        // POST: /IDTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IDType idtype = db.IDTypes.Find(id);
            db.IDTypes.Remove(idtype);
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