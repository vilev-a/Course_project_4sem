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
    public class ActivityForCardsController : Controller
    {
        private Course_workEntities db = new Course_workEntities();

        // GET: ActivityForCards
        public ActionResult Index()
        {
            var activityForCard = db.ActivityForCard.Include(a => a.Activity).Include(a => a.Card_);
            return View(activityForCard.ToList());
        }

        // GET: ActivityForCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityForCard activityForCard = db.ActivityForCard.Find(id);
            if (activityForCard == null)
            {
                return HttpNotFound();
            }
            return View(activityForCard);
        }

        // GET: ActivityForCards/Create
        public ActionResult Create()
        {
            ViewBag.ActivityID = new SelectList(db.Activity, "ID", "Title");
            ViewBag.CardID = new SelectList(db.Card_, "ID", "ID");
            return View();
        }

        // POST: ActivityForCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CardID,ActivityID")] ActivityForCard activityForCard)
        {
            if (ModelState.IsValid)
            {
                db.ActivityForCard.Add(activityForCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityID = new SelectList(db.Activity, "ID", "Title", activityForCard.ActivityID);
            ViewBag.CardID = new SelectList(db.Card_, "ID", "ID", activityForCard.CardID);
            return View(activityForCard);
        }

        // GET: ActivityForCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityForCard activityForCard = db.ActivityForCard.Find(id);
            if (activityForCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityID = new SelectList(db.Activity, "ID", "Title", activityForCard.ActivityID);
            ViewBag.CardID = new SelectList(db.Card_, "ID", "ID", activityForCard.CardID);
            return View(activityForCard);
        }

        // POST: ActivityForCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CardID,ActivityID")] ActivityForCard activityForCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityForCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityID = new SelectList(db.Activity, "ID", "Title", activityForCard.ActivityID);
            ViewBag.CardID = new SelectList(db.Card_, "ID", "ID", activityForCard.CardID);
            return View(activityForCard);
        }

        // GET: ActivityForCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActivityForCard activityForCard = db.ActivityForCard.Find(id);
            if (activityForCard == null)
            {
                return HttpNotFound();
            }
            return View(activityForCard);
        }

        // POST: ActivityForCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityForCard activityForCard = db.ActivityForCard.Find(id);
            db.ActivityForCard.Remove(activityForCard);
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
