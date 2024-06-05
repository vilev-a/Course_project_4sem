using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AttendanceModesController : Controller
    {
        private Course_workEntities db = new Course_workEntities();

        // GET: AttendanceModes
        public ActionResult Index()
        {
            return View(db.AttendanceMode.ToList());
        }

        // GET: AttendanceModes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceMode attendanceMode = db.AttendanceMode.Find(id);
            if (attendanceMode == null)
            {
                return HttpNotFound();
            }
            return View(attendanceMode);
        }

        // GET: AttendanceModes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AttendanceModes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] AttendanceMode attendanceMode)
        {
            if (ModelState.IsValid)
            {
                db.AttendanceMode.Add(attendanceMode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendanceMode);
        }

        // GET: AttendanceModes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceMode attendanceMode = db.AttendanceMode.Find(id);
            if (attendanceMode == null)
            {
                return HttpNotFound();
            }
            return View(attendanceMode);
        }

        // POST: AttendanceModes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] AttendanceMode attendanceMode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceMode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendanceMode);
        }

        // GET: AttendanceModes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceMode attendanceMode = db.AttendanceMode.Find(id);
            if (attendanceMode == null)
            {
                return HttpNotFound();
            }
            return View(attendanceMode);
        }

        // POST: AttendanceModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendanceMode attendanceMode = db.AttendanceMode.Find(id);
            db.AttendanceMode.Remove(attendanceMode);
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
