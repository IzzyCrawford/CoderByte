using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoderByte.Models;

namespace CoderByte.Controllers
{
    public class User_LogController : Controller
    {
        private CoderByteDb db = new CoderByteDb();

        // GET: User_Log
        public ActionResult Index()
        {
            var user_Log = db.User_Log.Include(u => u.Product).Include(u => u.User);
            return View(user_Log.ToList());
        }

        // GET: User_Log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Log user_Log = db.User_Log.Find(id);
            if (user_Log == null)
            {
                return HttpNotFound();
            }
            return View(user_Log);
        }

        // GET: User_Log/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: User_Log/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User_Id,LoginDate,ProductID")] User_Log user_Log)
        {
            if (ModelState.IsValid)
            {
                db.User_Log.Add(user_Log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name", user_Log.ProductID);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Name", user_Log.User_Id);
            return View(user_Log);
        }

        // GET: User_Log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Log user_Log = db.User_Log.Find(id);
            if (user_Log == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name", user_Log.ProductID);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Name", user_Log.User_Id);
            return View(user_Log);
        }

        // POST: User_Log/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User_Id,LoginDate,ProductID")] User_Log user_Log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name", user_Log.ProductID);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Name", user_Log.User_Id);
            return View(user_Log);
        }

        // GET: User_Log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Log user_Log = db.User_Log.Find(id);
            if (user_Log == null)
            {
                return HttpNotFound();
            }
            return View(user_Log);
        }

        // POST: User_Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Log user_Log = db.User_Log.Find(id);
            db.User_Log.Remove(user_Log);
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
