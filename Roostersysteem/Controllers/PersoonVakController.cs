using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Roostersysteem.Models;

namespace Roostersysteem.Controllers
{
    public class PersoonVakController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: PersoonVak
        public ActionResult Index()
        {
            var persoonVaks = db.PersoonVaks.Include(p => p.Persoon).Include(p => p.Vak);
            return View(persoonVaks.ToList());
        }

        // GET: PersoonVak/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoonVak persoonVak = db.PersoonVaks.Find(id);
            if (persoonVak == null)
            {
                return HttpNotFound();
            }
            return View(persoonVak);
        }

        // GET: PersoonVak/Create
        public ActionResult Create()
        {
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam");
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam");
            return View();
        }

        // POST: PersoonVak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Persoon_Id,Vak_Id,PersoonVak_Id")] PersoonVak persoonVak)
        {
            if (ModelState.IsValid)
            {
                db.PersoonVaks.Add(persoonVak);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", persoonVak.Persoon_Id);
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam", persoonVak.Vak_Id);
            return View(persoonVak);
        }

        // GET: PersoonVak/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoonVak persoonVak = db.PersoonVaks.Find(id);
            if (persoonVak == null)
            {
                return HttpNotFound();
            }
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", persoonVak.Persoon_Id);
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam", persoonVak.Vak_Id);
            return View(persoonVak);
        }

        // POST: PersoonVak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Persoon_Id,Vak_Id,PersoonVak_Id")] PersoonVak persoonVak)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoonVak).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", persoonVak.Persoon_Id);
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam", persoonVak.Vak_Id);
            return View(persoonVak);
        }

        // GET: PersoonVak/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoonVak persoonVak = db.PersoonVaks.Find(id);
            if (persoonVak == null)
            {
                return HttpNotFound();
            }
            return View(persoonVak);
        }

        // POST: PersoonVak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersoonVak persoonVak = db.PersoonVaks.Find(id);
            db.PersoonVaks.Remove(persoonVak);
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
