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
    public class UrenBeschikbaarheidController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: UrenBeschikbaarheid
        public ActionResult Index()
        {
            return View(db.UrenBeschikbaarheids.ToList());
        }

        // GET: UrenBeschikbaarheid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrenBeschikbaarheid urenBeschikbaarheid = db.UrenBeschikbaarheids.Find(id);
            if (urenBeschikbaarheid == null)
            {
                return HttpNotFound();
            }
            return View(urenBeschikbaarheid);
        }

        // GET: UrenBeschikbaarheid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrenBeschikbaarheid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrenBeschikbaarheidId,TijdstipBeschikbaarheid,DagBeschikbaarheid")] UrenBeschikbaarheid urenBeschikbaarheid)
        {
            if (ModelState.IsValid)
            {
                db.UrenBeschikbaarheids.Add(urenBeschikbaarheid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urenBeschikbaarheid);
        }

        // GET: UrenBeschikbaarheid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrenBeschikbaarheid urenBeschikbaarheid = db.UrenBeschikbaarheids.Find(id);
            if (urenBeschikbaarheid == null)
            {
                return HttpNotFound();
            }
            return View(urenBeschikbaarheid);
        }

        // POST: UrenBeschikbaarheid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrenBeschikbaarheidId,TijdstipBeschikbaarheid,DagBeschikbaarheid")] UrenBeschikbaarheid urenBeschikbaarheid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urenBeschikbaarheid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urenBeschikbaarheid);
        }

        // GET: UrenBeschikbaarheid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrenBeschikbaarheid urenBeschikbaarheid = db.UrenBeschikbaarheids.Find(id);
            if (urenBeschikbaarheid == null)
            {
                return HttpNotFound();
            }
            return View(urenBeschikbaarheid);
        }

        // POST: UrenBeschikbaarheid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrenBeschikbaarheid urenBeschikbaarheid = db.UrenBeschikbaarheids.Find(id);
            db.UrenBeschikbaarheids.Remove(urenBeschikbaarheid);
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
