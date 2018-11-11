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
    public class PersoonController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: Persoon
        public ActionResult Index()
        {
            return View(db.Persoons.ToList());
        }

        // GET: Persoon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.Persoons.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // GET: Persoon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persoon/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersoonId,PersoonVoornaam,PersoonAchternaam,PersoonTelefoonnummer,PersoonEmail,PersoonStraat,PersoonHuisnummer,PersoonToevoegingHuisnr,PersoonWoonplaats,PersoonPostcode,PersoonGebruikersnaam,PersoonWachtwoord,PersoonFunctie,PersoonContractUren")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Persoons.Add(persoon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persoon);
        }

        // GET: Persoon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.Persoons.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // POST: Persoon/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersoonId,PersoonVoornaam,PersoonAchternaam,PersoonTelefoonnummer,PersoonEmail,PersoonStraat,PersoonHuisnummer,PersoonToevoegingHuisnr,PersoonWoonplaats,PersoonPostcode,PersoonGebruikersnaam,PersoonWachtwoord,PersoonFunctie,PersoonContractUren")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persoon);
        }

        // GET: Persoon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.Persoons.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // POST: Persoon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persoon persoon = db.Persoons.Find(id);
            db.Persoons.Remove(persoon);
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
