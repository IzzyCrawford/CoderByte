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
    public class Client_ProductsController : Controller
    {
        private CoderByteDb db = new CoderByteDb();

        // GET: Client_Products
        public ActionResult Index()
        {
            var client_Products = db.Client_Products.Include(c => c.Client).Include(c => c.Product);
            return View(client_Products.ToList());
        }

        // GET: Client_Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Products client_Products = db.Client_Products.Find(id);
            if (client_Products == null)
            {
                return HttpNotFound();
            }
            return View(client_Products);
        }

        // GET: Client_Products/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name");
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Client_Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientID,ProductID,Discount,ActiveDate,InactiveDate")] Client_Products client_Products)
        {
            if (ModelState.IsValid)
            {
                db.Client_Products.Add(client_Products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name", client_Products.ClientID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name", client_Products.ProductID);
            return View(client_Products);
        }

        // GET: Client_Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Products client_Products = db.Client_Products.Find(id);
            if (client_Products == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name", client_Products.ClientID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name", client_Products.ProductID);
            return View(client_Products);
        }

        // POST: Client_Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientID,ProductID,Discount,ActiveDate,InactiveDate")] Client_Products client_Products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_Products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "Id", "Name", client_Products.ClientID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Name", client_Products.ProductID);
            return View(client_Products);
        }

        // GET: Client_Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_Products client_Products = db.Client_Products.Find(id);
            if (client_Products == null)
            {
                return HttpNotFound();
            }
            return View(client_Products);
        }

        // POST: Client_Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client_Products client_Products = db.Client_Products.Find(id);
            db.Client_Products.Remove(client_Products);
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
