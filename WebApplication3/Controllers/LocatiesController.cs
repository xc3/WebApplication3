using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LocatiesController : Controller
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: Locaties
        public ActionResult Index()
        {
            var locaties = db.Locaties.Include(l => l.Vanzare);
            return View(locaties.ToList());
        }

        // GET: Locaties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.Locaties.Find(id);
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // GET: Locaties/Create
        public ActionResult Create()
        {
            ViewBag.locatieId = new SelectList(db.Vanzares, "vanzareId", "vanzareId");
            return View();
        }

        // POST: Locaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "locatieId,descriere")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                db.Locaties.Add(locatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.locatieId = new SelectList(db.Vanzares, "vanzareId", "vanzareId", locatie.locatieId);
            return View(locatie);
        }

        // GET: Locaties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.Locaties.Find(id);
            if (locatie == null)
            {
                return HttpNotFound();
            }
            ViewBag.locatieId = new SelectList(db.Vanzares, "vanzareId", "vanzareId", locatie.locatieId);
            return View(locatie);
        }

        // POST: Locaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "locatieId,descriere")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.locatieId = new SelectList(db.Vanzares, "vanzareId", "vanzareId", locatie.locatieId);
            return View(locatie);
        }

        // GET: Locaties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locatie locatie = db.Locaties.Find(id);
            if (locatie == null)
            {
                return HttpNotFound();
            }
            return View(locatie);
        }

        // POST: Locaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Locatie locatie = db.Locaties.Find(id);
            db.Locaties.Remove(locatie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
