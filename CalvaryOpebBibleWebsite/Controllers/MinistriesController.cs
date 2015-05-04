using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CalvaryOpebBibleWebsite.DAL;
using CalvaryOpebBibleWebsite.Models;

namespace CalvaryOpebBibleWebsite.Controllers
{
    public class MinistriesController : Controller
    {
        private CalvaryContext db = new CalvaryContext();

        // GET: Ministries
        public ActionResult Index()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult Admin()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult Adults()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult Children()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult College()
        {

            MinistriesViewModel ministries = new MinistriesViewModel();
            var college = new List<MinistriesViewModel>();
            foreach (var p in db.Ministries)
            {
                ministries.MinitriesID = p.MinitriesID;
                ministries.MinistriesLeader = p.MinistriesLeader;
                ministries.MinistriesPosition = p.MinistriesPosition;
                foreach(var e in db.Event)
                {
                    ministries.Event.EventType = e.EventType;
                    ministries.Event.EventName = e.EventName;
                    ministries.Event.EventDescription = e.EventDescription;
                    ministries.Event.StartDate = e.StartDate;
                    ministries.Event.EndtDate = e.EndDate;
                
                }

                college.Add(ministries);
            

            }
            return View(college.ToList());
        }

        public ActionResult HighSchool()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult MiddleSchool()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult Seniors()
        {
            return View(db.Ministries.ToList());
        }

        // GET: Ministries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministries ministries = db.Ministries.Find(id);
            if (ministries == null)
            {
                return HttpNotFound();
            }
            return View(ministries);
        }

        // GET: Ministries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ministries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MinitriesID,MinistriesLeader,MinistriesPosition")] Ministries ministries)
        {
            if (ModelState.IsValid)
            {
                db.Ministries.Add(ministries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ministries);
        }

        // GET: Ministries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministries ministries = db.Ministries.Find(id);
            if (ministries == null)
            {
                return HttpNotFound();
            }
            return View(ministries);
        }

        // POST: Ministries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MinitriesID,MinistriesLeader,MinistriesPosition")] Ministries ministries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ministries);
        }

        // GET: Ministries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ministries ministries = db.Ministries.Find(id);
            if (ministries == null)
            {
                return HttpNotFound();
            }
            return View(ministries);
        }

        // POST: Ministries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ministries ministries = db.Ministries.Find(id);
            db.Ministries.Remove(ministries);
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
