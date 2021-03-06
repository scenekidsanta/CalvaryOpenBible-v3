﻿using System;
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

namespace CalvaryOpebBibleWebsite.Views
{
    public class PastorsController : Controller
    {
        private CalvaryContext db = new CalvaryContext();

        // GET: Pastors
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PastorSortParm = sortOrder == "Pastor" ? "pastor" : "Pastor";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title" : "Title";
            var pastors = from s in db.Pastor
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
                pastors = pastors.Where(s => s.PastorName.Contains(searchString)
                                       || s.Title.Contains(searchString));
                                       
            }
            switch (sortOrder)
            {
                case "Pastor":
                    pastors = pastors.OrderBy(s => s.PastorName);
                    break;
                case "pastor":
                    pastors = pastors.OrderByDescending(s => s.PastorName);
                    break;
                case "Title":
                    pastors = pastors.OrderBy(s => s.Title);
                    break;
                case "title":
                    pastors = pastors.OrderByDescending(s => s.Title);
                    break;
                default:
                    pastors = pastors.OrderByDescending(s => s.PastorName);
                    break;

            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(pastors.ToPagedList(pageNumber, pageSize));
        }
      
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Admin(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PastorSortParm = sortOrder == "Pastor" ? "pastor" : "Pastor";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title" : "Title";
            var pastors = from s in db.Pastor
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
                pastors = pastors.Where(s => s.PastorName.Contains(searchString)
                                       || s.Title.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "Pastor":
                    pastors = pastors.OrderByDescending(s => s.PastorName);
                    break;
                case "pastor":
                    pastors = pastors.OrderBy(s => s.PastorName);
                    break;
                case "Title":
                    pastors = pastors.OrderBy(s => s.Title);
                    break;
                case "title":
                    pastors = pastors.OrderByDescending(s => s.Title);
                    break;
                default:
                    pastors = pastors.OrderBy(s => s.PastorName); 
                    break;

            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(pastors.ToPagedList(pageNumber, pageSize));
        }

        // GET: Pastors/Details/5
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastor pastor = db.Pastor.Find(id);
            if (pastor == null)
            {
                return HttpNotFound();
            }
            return View(pastor);
        }

        // GET: Pastors/Create
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Create()
        {
            return View();
        }
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        // POST: Pastors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PastorID,PastorName,Title, PastorImagePath,Details")] Pastor pastor, HttpPostedFileBase file)
        {
            
                  if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/Images/")
                                                          + file.FileName);
                    pastor.PastorImagePath = file.FileName;
                }
             
                db.Pastor.Add(pastor);
                db.SaveChanges();
                return RedirectToAction("Admin");
            

           // return View(pastor);
        }

        // GET: Pastors/Edit/5
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastor pastor = db.Pastor.Find(id);
            if (pastor == null)
            {
                return HttpNotFound();
            }
            return View(pastor);
        }

        // POST: Pastors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Edit([Bind(Include = "PastorID,PastorName,PastorImagePath,Title,Details")] Pastor pastor, HttpPostedFileBase file)
        {
            
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Content/Images/")
                                                          + file.FileName);
                    pastor.PastorImagePath = file.FileName;
                }
                db.Entry(pastor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            
        }

        // GET: Pastors/Delete/5
         [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pastor pastor = db.Pastor.Find(id);
            if (pastor == null)
            {
                return HttpNotFound();
            }
            return View(pastor);
        }

        // POST: Pastors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pastor pastor = db.Pastor.Find(id);
            db.Pastor.Remove(pastor);
            db.SaveChanges();
            return RedirectToAction("Admin");
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
