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
    public class ProdusController : Controller
    {
        private WebApplication3Context db = new WebApplication3Context();

        // GET: Produs
        public ActionResult Index()
        {
            var produs = db.Produs.Include(p => p.Vanzare);
            return View(produs.ToList());
        }

        // GET: Produs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = db.Produs.Find(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        // GET: Produs/Create
        public ActionResult Create()
        {
            ViewBag.produsId = new SelectList(db.Vanzares, "vanzareId", "vanzareId");
            return View();
        }

        // POST: Produs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "produsId,descriere")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Produs.Add(produs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.produsId = new SelectList(db.Vanzares, "vanzareId", "vanzareId", produs.produsId);
            return View(produs);
        }

        // GET: Produs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = db.Produs.Find(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            ViewBag.produsId = new SelectList(db.Vanzares, "vanzareId", "vanzareId", produs.produsId);
            return View(produs);
        }

        // POST: Produs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "produsId,descriere")] Produs produs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.produsId = new SelectList(db.Vanzares, "vanzareId", "vanzareId", produs.produsId);
            return View(produs);
        }

        // GET: Produs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produs produs = db.Produs.Find(id);
            if (produs == null)
            {
                return HttpNotFound();
            }
            return View(produs);
        }

        // POST: Produs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produs produs = db.Produs.Find(id);
            db.Produs.Remove(produs);
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
