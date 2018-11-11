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
    public class VakUrenCollegeController : Controller
    {
        private RoosterDB db = new RoosterDB();

        // GET: VakUrenCollege
        public ActionResult Index()
        {
            var vakUrenColleges = db.VakUrenColleges.Include(v => v.UrenCollege).Include(v => v.Vak);
            return View(vakUrenColleges.ToList());

        }

        // GET: VakUrenCollege/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VakUrenCollege vakUrenCollege = db.VakUrenColleges.Find(id);
            if (vakUrenCollege == null)
            {
                return HttpNotFound();
            }
            return View(vakUrenCollege);
        }

        // GET: VakUrenCollege/Create
        public ActionResult Create()
        {
            ViewBag.UrenCollege_Id = new SelectList(db.UrenColleges, "UrenCollegeId", "CollegeNaam");
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam");
            return View();
        }

        // POST: VakUrenCollege/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Vak_Id,UrenCollege_Id,Vakduur,VakUrenCollege_Id")] VakUrenCollege vakUrenCollege)
        {
            if (ModelState.IsValid)
            {
                db.VakUrenColleges.Add(vakUrenCollege);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrenCollege_Id = new SelectList(db.UrenColleges, "UrenCollegeId", "CollegeNaam", vakUrenCollege.UrenCollege_Id);
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam", vakUrenCollege.Vak_Id);
            return View(vakUrenCollege);
        }

        // GET: VakUrenCollege/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VakUrenCollege vakUrenCollege = db.VakUrenColleges.Find(id);
            if (vakUrenCollege == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrenCollege_Id = new SelectList(db.UrenColleges, "UrenCollegeId", "CollegeNaam", vakUrenCollege.UrenCollege_Id);
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam", vakUrenCollege.Vak_Id);
            return View(vakUrenCollege);
        }

        // POST: VakUrenCollege/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vak_Id,UrenCollege_Id,Vakduur,VakUrenCollege_Id")] VakUrenCollege vakUrenCollege)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vakUrenCollege).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrenCollege_Id = new SelectList(db.UrenColleges, "UrenCollegeId", "CollegeNaam", vakUrenCollege.UrenCollege_Id);
            ViewBag.Vak_Id = new SelectList(db.Vaks, "VakId", "VakNaam", vakUrenCollege.Vak_Id);
            return View(vakUrenCollege);
        }

        // GET: VakUrenCollege/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VakUrenCollege vakUrenCollege = db.VakUrenColleges.Find(id);
            if (vakUrenCollege == null)
            {
                return HttpNotFound();
            }
            return View(vakUrenCollege);
        }

        // POST: VakUrenCollege/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VakUrenCollege vakUrenCollege = db.VakUrenColleges.Find(id);
            db.VakUrenColleges.Remove(vakUrenCollege);
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
