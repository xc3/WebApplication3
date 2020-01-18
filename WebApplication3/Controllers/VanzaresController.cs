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
    public class VanzaresController : Controller
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: Vanzares
        public ActionResult Index()
        {
            var vanzares = db.Vanzares.Include(v => v.Client).Include(v => v.Data).Include(v => v.Locatie).Include(v => v.Produs);
            return View(vanzares.ToList());
        }

        // GET: Vanzares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vanzare vanzare = db.Vanzares.Find(id);
            if (vanzare == null)
            {
                return HttpNotFound();
            }
            return View(vanzare);
        }

        // GET: Vanzares/Create
        public ActionResult Create()
        {
            ViewBag.vanzareId = new SelectList(db.Clients, "clientId", "descriere");
            ViewBag.vanzareId = new SelectList(db.Data, "dataId", "descriere");
            ViewBag.vanzareId = new SelectList(db.Locaties, "locatieId", "descriere");
            ViewBag.vanzareId = new SelectList(db.Produs, "produsId", "descriere");
            return View();
        }

        // POST: Vanzares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vanzareId,produsId,locatieId,dataId,clientId,pret,cantitate")] Vanzare vanzare)
        {
            if (ModelState.IsValid)
            {
                db.Vanzares.Add(vanzare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vanzareId = new SelectList(db.Clients, "clientId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Data, "dataId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Locaties, "locatieId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Produs, "produsId", "descriere", vanzare.vanzareId);
            return View(vanzare);
        }

        // GET: Vanzares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vanzare vanzare = db.Vanzares.Find(id);
            if (vanzare == null)
            {
                return HttpNotFound();
            }
            ViewBag.vanzareId = new SelectList(db.Clients, "clientId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Data, "dataId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Locaties, "locatieId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Produs, "produsId", "descriere", vanzare.vanzareId);
            return View(vanzare);
        }

        // POST: Vanzares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vanzareId,produsId,locatieId,dataId,clientId,pret,cantitate")] Vanzare vanzare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vanzare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vanzareId = new SelectList(db.Clients, "clientId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Data, "dataId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Locaties, "locatieId", "descriere", vanzare.vanzareId);
            ViewBag.vanzareId = new SelectList(db.Produs, "produsId", "descriere", vanzare.vanzareId);
            return View(vanzare);
        }

        // GET: Vanzares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vanzare vanzare = db.Vanzares.Find(id);
            if (vanzare == null)
            {
                return HttpNotFound();
            }
            return View(vanzare);
        }

        // POST: Vanzares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vanzare vanzare = db.Vanzares.Find(id);
            db.Vanzares.Remove(vanzare);
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
