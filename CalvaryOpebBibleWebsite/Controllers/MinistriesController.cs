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
    public class MinistriesController : Controller
    {
        private CalvaryContext db = new CalvaryContext();

        // GET: Ministries
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
             var ministries = from s in db.Ministries
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
                ministries = ministries.Where(s => s.MinistriesLeader.Contains(searchString)
                  || s.MinistriesPosition.Contains(searchString) || s.MinistriesType.Contains(searchString));
            }

            switch (currentFilter)
            {
                default:
                    ministries = ministries.OrderBy(s => s.MinistriesLeader);
                    break;
            }
            
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(ministries.ToPagedList(pageNumber, pageSize));


        }
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Admin()
        {
            return View(db.Ministries.ToList());
        }

        public ActionResult Adults()
        {
            var ministries = from a in db.Ministries  where a.MinistriesType == "Adults"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "Adults"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();

             foreach (Ministries a in ministries)
             {

                 ministriesVM.Add(new MinistriesViewModel()
                 {
                     MinitriesID = a.MinitriesID,
                     MinistriesLeader = a.MinistriesLeader,
                     MinistriesPosition = a.MinistriesPosition,
                 });
             }
                 foreach (Event b in events)
                 {


                     ministriesVM.Add(new MinistriesViewModel()
                     {
                         EventType = b.EventType,
                         EventName = b.EventName,
                         EventDescription = b.EventDescription,
                         StartDate = b.StartDate,
                         EventTime = b.EventTime,
                         EndDate = b.EndDate,
                     });
                 }
             




             return View(ministriesVM);
        }
        


        public ActionResult Children()
        {
            var ministries = from a in db.Ministries
                             where a.MinistriesType == "Children"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "Children"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();


            foreach (Ministries a in ministries)
            {

                ministriesVM.Add(new MinistriesViewModel()
                {
                    MinitriesID = a.MinitriesID,
                    MinistriesLeader = a.MinistriesLeader,
                    MinistriesPosition = a.MinistriesPosition,
                });
            }
            foreach (Event b in events)
            {


                ministriesVM.Add(new MinistriesViewModel()
                {
                    EventType = b.EventType,
                    EventName = b.EventName,
                    EventDescription = b.EventDescription,
                    StartDate = b.StartDate,
                    EventTime = b.EventTime,
                    EndDate = b.EndDate,
                });
            }





            return View(ministriesVM);
        }
        
        
        

        public ActionResult College()
        {
            var ministries = from a in db.Ministries
                             where a.MinistriesType == "College"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "College"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();


            foreach (Ministries a in ministries)
            {

                ministriesVM.Add(new MinistriesViewModel()
                {
                    MinitriesID = a.MinitriesID,
                    MinistriesLeader = a.MinistriesLeader,
                    MinistriesPosition = a.MinistriesPosition,
                });
            }
            foreach (Event b in events)
            {


                ministriesVM.Add(new MinistriesViewModel()
                {
                    EventType = b.EventType,
                    EventName = b.EventName,
                    EventDescription = b.EventDescription,
                    StartDate = b.StartDate,
                    EventTime = b.EventTime,
                    EndDate = b.EndDate,
                });
            }





            return View(ministriesVM);
        }
        
        public ActionResult CommunityGroups()
        {
            var ministries = from a in db.Ministries
                             where a.MinistriesType == "Community Groups"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "Community Groups"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();

          
             foreach (Ministries a in ministries)
             {

                 ministriesVM.Add(new MinistriesViewModel()
                 {
                     MinitriesID = a.MinitriesID,
                     MinistriesLeader = a.MinistriesLeader,
                     MinistriesPosition = a.MinistriesPosition,
                 });
             }
                 foreach (Event b in events)
                 {


                     ministriesVM.Add(new MinistriesViewModel()
                     {
                         EventType = b.EventType,
                         EventName = b.EventName,
                         EventDescription = b.EventDescription,
                         StartDate = b.StartDate,
                         EventTime = b.EventTime,
                         EndDate = b.EndDate,
                     });
                 }
             




             return View(ministriesVM);
        }
        
        
        public ActionResult HighSchool()
        {
            var ministries = from a in db.Ministries
                             where a.MinistriesType == "High School"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "High School"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();

            foreach (Ministries a in ministries)
            {

                ministriesVM.Add(new MinistriesViewModel()
                {
                    MinitriesID = a.MinitriesID,
                    MinistriesLeader = a.MinistriesLeader,
                    MinistriesPosition = a.MinistriesPosition,
                });
            }
            foreach (Event b in events)
            {


                ministriesVM.Add(new MinistriesViewModel()
                {
                    EventType = b.EventType,
                    EventName = b.EventName,
                    EventDescription = b.EventDescription,
                    StartDate = b.StartDate,
                    EventTime = b.EventTime,
                    EndDate = b.EndDate,
                });
            }





            return View(ministriesVM);
        }
        
        

        public ActionResult MiddleSchool()
        {
            var ministries = from a in db.Ministries
                             where a.MinistriesType == "Middle School"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "Middle School"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();

            foreach (Ministries a in ministries)
            {

                ministriesVM.Add(new MinistriesViewModel()
                {
                    MinitriesID = a.MinitriesID,
                    MinistriesLeader = a.MinistriesLeader,
                    MinistriesPosition = a.MinistriesPosition,
                });
            }
            foreach (Event b in events)
            {


                ministriesVM.Add(new MinistriesViewModel()
                {
                    EventType = b.EventType,
                    EventName = b.EventName,
                    EventDescription = b.EventDescription,
                    StartDate = b.StartDate,
                    EventTime = b.EventTime,
                    EndDate = b.EndDate,
                });
            }





            return View(ministriesVM);
        }
        
        
       

        public ActionResult Seniors()
        {
            var ministries = from a in db.Ministries
                             where a.MinistriesType == "Seniors"
                             select a;
            var events = from a in db.Event
                         where a.EventMinistry == "Seniors"
                         select a;
            var ministriesVM = new List<MinistriesViewModel>();

            foreach (Ministries a in ministries)
            {

                ministriesVM.Add(new MinistriesViewModel()
                {
                    MinitriesID = a.MinitriesID,
                    MinistriesLeader = a.MinistriesLeader,
                    MinistriesPosition = a.MinistriesPosition,
                });
            }
            foreach (Event b in events)
            {


                ministriesVM.Add(new MinistriesViewModel()
                {
                    EventType = b.EventType,
                    EventName = b.EventName,
                    EventDescription = b.EventDescription,
                    StartDate = b.StartDate,
                    EventTime = b.EventTime,
                    EndDate = b.EndDate,
                });
            }





            return View(ministriesVM);
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
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        // GET: Ministries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ministries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MinitriesID,MinistriesLeader,MinistriesPosition, MinistriesType")] Ministries ministries)
        {
            if (ModelState.IsValid)
            {
                db.Ministries.Add(ministries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ministries);
        }
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
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
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MinitriesID,MinistriesLeader,MinistriesPosition, MinistriesType")] Ministries ministries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ministries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ministries);
        }
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
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
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
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
