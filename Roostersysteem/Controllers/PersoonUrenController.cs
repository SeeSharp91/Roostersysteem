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
    public class PersoonUrenController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: PersoonUren
        public ActionResult Index()
        {
            var persoonUrens = db.PersoonUrens.Include(p => p.Persoon).Include(p => p.UrenBeschikbaarheid);
            return View(persoonUrens.ToList());
        }

        // GET: PersoonUren/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoonUren persoonUren = db.PersoonUrens.Find(id);
            if (persoonUren == null)
            {
                return HttpNotFound();
            }
            return View(persoonUren);
        }

        // GET: PersoonUren/Create
        public ActionResult Create()
        {
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam");
            ViewBag.UrenBeschikbaarheid_Id = new SelectList(db.UrenBeschikbaarheids, "UrenBeschikbaarheidId", "DagBeschikbaarheid");
            return View();
        }

        // POST: PersoonUren/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrenBeschikbaarheid_Id,Persoon_Id,PersoonUren_Id")] PersoonUren persoonUren)
        {
            if (ModelState.IsValid)
            {
                db.PersoonUrens.Add(persoonUren);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", persoonUren.Persoon_Id);
            ViewBag.UrenBeschikbaarheid_Id = new SelectList(db.UrenBeschikbaarheids, "UrenBeschikbaarheidId", "DagBeschikbaarheid", persoonUren.UrenBeschikbaarheid_Id);
            return View(persoonUren);
        }

        // GET: PersoonUren/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoonUren persoonUren = db.PersoonUrens.Find(id);
            if (persoonUren == null)
            {
                return HttpNotFound();
            }
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", persoonUren.Persoon_Id);
            ViewBag.UrenBeschikbaarheid_Id = new SelectList(db.UrenBeschikbaarheids, "UrenBeschikbaarheidId", "DagBeschikbaarheid", persoonUren.UrenBeschikbaarheid_Id);
            return View(persoonUren);
        }

        // POST: PersoonUren/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrenBeschikbaarheid_Id,Persoon_Id,PersoonUren_Id")] PersoonUren persoonUren)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoonUren).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", persoonUren.Persoon_Id);
            ViewBag.UrenBeschikbaarheid_Id = new SelectList(db.UrenBeschikbaarheids, "UrenBeschikbaarheidId", "DagBeschikbaarheid", persoonUren.UrenBeschikbaarheid_Id);
            return View(persoonUren);
        }

        // GET: PersoonUren/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoonUren persoonUren = db.PersoonUrens.Find(id);
            if (persoonUren == null)
            {
                return HttpNotFound();
            }
            return View(persoonUren);
        }

        // POST: PersoonUren/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersoonUren persoonUren = db.PersoonUrens.Find(id);
            db.PersoonUrens.Remove(persoonUren);
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
