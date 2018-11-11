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
    public class AuthenticatorController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: Authenticator
        public ActionResult Index()
        {
            var authenticators = db.Authenticators.Include(a => a.Persoon);
            return View(authenticators.ToList());
        }

        // GET: Authenticator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authenticator authenticator = db.Authenticators.Find(id);
            if (authenticator == null)
            {
                return HttpNotFound();
            }
            return View(authenticator);
        }

        // GET: Authenticator/Create
        public ActionResult Create()
        {
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam");
            return View();
        }

        // POST: Authenticator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthenticatorId,Persoon_Id,Code,Timestamp")] Authenticator authenticator)
        {
            if (ModelState.IsValid)
            {
                db.Authenticators.Add(authenticator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", authenticator.Persoon_Id);
            return View(authenticator);
        }

        // GET: Authenticator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authenticator authenticator = db.Authenticators.Find(id);
            if (authenticator == null)
            {
                return HttpNotFound();
            }
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", authenticator.Persoon_Id);
            return View(authenticator);
        }

        // POST: Authenticator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthenticatorId,Persoon_Id,Code,Timestamp")] Authenticator authenticator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authenticator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Persoon_Id = new SelectList(db.Persoons, "PersoonId", "PersoonVoornaam", authenticator.Persoon_Id);
            return View(authenticator);
        }

        // GET: Authenticator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authenticator authenticator = db.Authenticators.Find(id);
            if (authenticator == null)
            {
                return HttpNotFound();
            }
            return View(authenticator);
        }

        // POST: Authenticator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authenticator authenticator = db.Authenticators.Find(id);
            db.Authenticators.Remove(authenticator);
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
