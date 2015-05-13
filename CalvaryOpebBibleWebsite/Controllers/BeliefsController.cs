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
    public class BeliefsController : Controller
    {
        private CalvaryContext db = new CalvaryContext();

        // GET: Beliefs
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BeliefSortParm = String.IsNullOrEmpty(sortOrder) ? "Belief" : "";
            var beliefs = from s in db.Belief
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
                beliefs = beliefs.Where(s => s.BeliefTitle.Contains(searchString));
                                       

            }
            switch (sortOrder)
            {
                default:
              
                    beliefs = beliefs.OrderByDescending(s => s.BeliefTitle);
                    break;
                case "Belief":
                    beliefs = beliefs.OrderBy(s => s.BeliefTitle);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(beliefs.ToPagedList(pageNumber, pageSize));
        }
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Admin(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BeliefSortParm = String.IsNullOrEmpty(sortOrder) ? "Belief" : "";
            var beliefs = from s in db.Belief
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
                beliefs = beliefs.Where(s => s.BeliefTitle.Contains(searchString));


            }
            switch (sortOrder)
            {
                default:

                    beliefs = beliefs.OrderByDescending(s => s.BeliefTitle);
                    break;
                case "Belief":
                    beliefs = beliefs.OrderBy(s => s.BeliefTitle);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(beliefs.ToPagedList(pageNumber, pageSize));
        }
        // GET: Beliefs/Details/5
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belief belief = db.Belief.Find(id);
            if (belief == null)
            {
                return HttpNotFound();
            }
            return View(belief);
        }

        // GET: Beliefs/Create
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beliefs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Create([Bind(Include = "BeliefID,BeliefTitle,BeliefDetails")] Belief belief)
        {
            if (ModelState.IsValid)
            {
                db.Belief.Add(belief);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(belief);
        }

        // GET: Beliefs/Edit/5
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belief belief = db.Belief.Find(id);
            if (belief == null)
            {
                return HttpNotFound();
            }
            return View(belief);
        }

        // POST: Beliefs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        public ActionResult Edit([Bind(Include = "BeliefID,BeliefTitle,BeliefDetails")] Belief belief)
        {
            if (ModelState.IsValid)
            {
                db.Entry(belief).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(belief);
        }
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]

        // GET: Beliefs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Belief belief = db.Belief.Find(id);
            if (belief == null)
            {
                return HttpNotFound();
            }
            return View(belief);
        }
        [Authorize(Users = "jpoet1291@gmail.com,Parafin07!")]
        // POST: Beliefs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Belief belief = db.Belief.Find(id);
            db.Belief.Remove(belief);
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