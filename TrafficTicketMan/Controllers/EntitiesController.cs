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
    public class EntitiesController : Controller
    {
        private TTMDataContext db = new TTMDataContext();

        //
        // GET: /Entities/

        public ActionResult Index()
        {
            return View(db.Entities.ToList());
        }

        //
        // GET: /Entities/Details/5

        public ActionResult Details(int id = 0)
        {
            Entity entity = db.Entities.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        //
        // GET: /Entities/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Entities/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entity entity)
        {
            if (ModelState.IsValid)
            {
                db.Entities.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        //
        // GET: /Entities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Entity entity = db.Entities.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        //
        // POST: /Entities/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Entity entity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        //
        // GET: /Entities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Entity entity = db.Entities.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        //
        // POST: /Entities/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entity entity = db.Entities.Find(id);
            db.Entities.Remove(entity);
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