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
using PagedList;

namespace CalvaryOpebBibleWebsite.Controllers
{
    public class EventController : Controller
    {
        private CalvaryContext db = new CalvaryContext();

       public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var currentdate = DateTime.Now;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TypeSortParm = sortOrder == "Event Type" ? "event type" : "Event Type";
            ViewBag.MinistrySortParm = sortOrder == "Ministry" ? "ministry" : "Ministry";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var events = from s in db.Event where s.StartDate > currentdate
                           select s;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventMinistry.Contains(searchString)
                                   || s.EventLocation.Contains(searchString)
                                    || s.EventName.Contains(searchString)
                                    || s.EventDescription.Contains(searchString)
                                   || s.StartDate.ToString().Contains(searchString)
                                    );
            }
            switch (sortOrder)
            {
                case "Event Type":
                    events = events.OrderByDescending(s => s.EventType);
                    break;
                case "event type":
                    events = events.OrderBy(s => s.EventType);
                    break;
                case "Ministry":
                    events = events.OrderByDescending(s => s.EventMinistry);
                    break;
                case "ministry":
                    events = events.OrderBy(s => s.EventMinistry);
                    break;
                case "date_desc":
                    events = events.OrderBy(s => s.StartDate);
                    break;
                case "Date":
                    events = events.OrderByDescending(s => s.StartDate);
                    break;
                default:
                    events = events.OrderBy(s => s.StartDate);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(events.ToPagedList(pageNumber, pageSize));
        
        }
    
        // GET: Event
       [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
       public ActionResult Admin(string sortOrder, string currentFilter, string searchString, int? page)
       {
           var currentdate = DateTime.Now;
           ViewBag.CurrentSort = sortOrder;
           ViewBag.TypeSortParm = sortOrder == "Event Type" ? "event type" : "Event Type";
           ViewBag.MinistrySortParm = sortOrder == "Ministry" ? "ministry" : "Ministry";
           ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

           var events = from s in db.Event
                        where s.StartDate > currentdate
                        select s;

           if (searchString != null)
           {
               page = 1;
           }
           else
           {
               searchString = currentFilter;
           }

           ViewBag.CurrentFilter = searchString;

           if (!String.IsNullOrEmpty(searchString))
           {
               events = events.Where(s => s.EventMinistry.Contains(searchString)
                                      || s.EventLocation.Contains(searchString)
                                       || s.EventName.Contains(searchString)
                                       || s.EventCoordinator.Contains(searchString)
                                       || s.StartDate.ToString().Contains(searchString)
                                       );
           }
               switch (sortOrder)
               {
                   case "Event Type":
                       events = events.OrderByDescending(s => s.EventType);
                       break;
                   case "event type":
                       events = events.OrderBy(s => s.EventType);
                       break;

                   case "Ministry":
                       events = events.OrderByDescending(s => s.EventMinistry);
                       break;
                   case "ministry":
                       events = events.OrderBy(s => s.EventMinistry);
                       break;
                   default:
                       events = events.OrderBy(s => s.StartDate);
                       break;
                   case "date_desc":
                       events = events.OrderByDescending(s => s.StartDate);
                       break;
               }
               int pageSize = 10;
               int pageNumber = (page ?? 1);
               return View(events.ToPagedList(pageNumber, pageSize));
         
       }

        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult AdminAll(string sortOrder, string currentFilter, string searchString, int? page)
        {
            var currentdate = DateTime.Now;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TypeSortParm = sortOrder == "Event Type" ? "event type" : "Event Type";
            ViewBag.MinistrySortParm = sortOrder == "Ministry" ? "ministry" : "Ministry";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";


            var events = from s in db.Event
                         select s;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.EventMinistry.Contains(searchString)
                                     || s.EventLocation.Contains(searchString)
                                      || s.EventName.Contains(searchString)
                                      || s.EventCoordinator.Contains(searchString)
                                   || s.StartDate.ToString().Contains(searchString)
                                      );
            }
            switch (sortOrder)
            {
                case "Event Type":
                    events = events.OrderByDescending(s => s.EventType);
                    break;
                case "event type":
                    events = events.OrderBy(s => s.EventType);
                    break;
                case "Ministry":
                    events = events.OrderByDescending(s => s.EventMinistry);
                    break;
                case "ministry":
                    events = events.OrderBy(s => s.EventMinistry);
                    break;
                default:
                    events = events.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    events = events.OrderByDescending(s => s.StartDate);
                    break;
            }
            int pageSizes = 10;
            int pageNumbers = (page ?? 1);
            return View(events.ToPagedList(pageNumbers, pageSizes));
        }
        
        // GET: Event/Details/5
      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
          [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
          public ActionResult Create([Bind(Include = "EventID,EventType,EventMinistry,EventName,EventDescription,EventTime,EventLocation,StartDate,EndDate,EventCoordinator")] Event @event)
        {
            var events = @event;
             
            if (ModelState.IsValid)
            {
                if(@event.EventType == "Weekly Events")
                {
                  
                    for(int i = 1; i <= 4; i++)
                    {
                      
                        db.Event.Add(events);

                        db.SaveChanges();

                        events.StartDate = events.StartDate.AddDays(7);
                    }

                }
                else {
                db.Event.Add(events);
                db.SaveChanges();
                }
               
                return RedirectToAction("Admin");
            }

            return View(@event);
        }

        // GET: Event/Edit/5
          [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
          public ActionResult Edit([Bind(Include = "EventID,EventType,EventMinistry,EventName,EventDescription,EventLocation,EventTime,StartDate,EndDate,EventCoordinator")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
          [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("AdminAll");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Calendar()
        {
            return View(db.Event.ToList());
        }

        public ActionResult Calendar2()
        {
            return View(db.Event.ToList());
        }
    }

}
