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
    public class UrenCollegeController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: UrenCollege
        public ActionResult Index()
        {
            return View(db.UrenColleges.ToList());
        }

        // GET: UrenCollege/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrenCollege urenCollege = db.UrenColleges.Find(id);
            if (urenCollege == null)
            {
                return HttpNotFound();
            }
            return View(urenCollege);
        }

        // GET: UrenCollege/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrenCollege/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UrenCollegeId,CollegeNaam")] UrenCollege urenCollege)
        {
            if (ModelState.IsValid)
            {
                db.UrenColleges.Add(urenCollege);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urenCollege);
        }

        // GET: UrenCollege/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrenCollege urenCollege = db.UrenColleges.Find(id);
            if (urenCollege == null)
            {
                return HttpNotFound();
            }
            return View(urenCollege);
        }

        // POST: UrenCollege/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UrenCollegeId,CollegeNaam")] UrenCollege urenCollege)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urenCollege).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urenCollege);
        }

        // GET: UrenCollege/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrenCollege urenCollege = db.UrenColleges.Find(id);
            if (urenCollege == null)
            {
                return HttpNotFound();
            }
            return View(urenCollege);
        }

        // POST: UrenCollege/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UrenCollege urenCollege = db.UrenColleges.Find(id);
            db.UrenColleges.Remove(urenCollege);
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
