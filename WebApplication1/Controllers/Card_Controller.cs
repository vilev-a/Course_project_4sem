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
    public class Card_Controller : Controller
    {
        private Course_workEntities db = new Course_workEntities();

        // GET: Card_
        public ActionResult Index()
        {
            var card_ = db.Card_.Include(c => c.AttendanceMode).Include(c => c.Client);
            return View(card_.ToList());
        }

        // GET: Card_/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card_ card_ = db.Card_.Find(id);
            if (card_ == null)
            {
                return HttpNotFound();
            }
            return View(card_);
        }

        // GET: Card_/Create
        public ActionResult Create()
        {
            ViewBag.AttendanceModeID = new SelectList(db.AttendanceMode, "ID", "Title");
            ViewBag.ClientID = new SelectList(db.Client, "ID", "FirstName");
            return View();
        }

        // POST: Card_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClientID,AttendanceModeID")] Card_ card_)
        {
            if (ModelState.IsValid)
            {
                db.Card_.Add(card_);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AttendanceModeID = new SelectList(db.AttendanceMode, "ID", "Title", card_.AttendanceModeID);
            ViewBag.ClientID = new SelectList(db.Client, "ID", "FirstName", card_.ClientID);
            return View(card_);
        }

        // GET: Card_/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card_ card_ = db.Card_.Find(id);
            if (card_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttendanceModeID = new SelectList(db.AttendanceMode, "ID", "Title", card_.AttendanceModeID);
            ViewBag.ClientID = new SelectList(db.Client, "ID", "FirstName", card_.ClientID);
            return View(card_);
        }

        // POST: Card_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientID,AttendanceModeID")] Card_ card_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(card_).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AttendanceModeID = new SelectList(db.AttendanceMode, "ID", "Title", card_.AttendanceModeID);
            ViewBag.ClientID = new SelectList(db.Client, "ID", "FirstName", card_.ClientID);
            return View(card_);
        }

        // GET: Card_/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Card_ card_ = db.Card_.Find(id);
            if (card_ == null)
            {
                return HttpNotFound();
            }
            return View(card_);
        }

        // POST: Card_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Card_ card_ = db.Card_.Find(id);
            db.Card_.Remove(card_);
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
