using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestC.Context;
using TestC.Models;

namespace TestC.Controllers
{
    public class BuysController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Buys
        public ActionResult Index()
        {
            var buys = db.Buys.Include(b => b.Storage);
            return View(buys.ToList());
        }

        // GET: Buys/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buys.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }

        // GET: Buys/Create
        public ActionResult Create()
        {
            ViewBag.StorageId = new SelectList(db.Stores, "StoreId", "Name");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
            return View();
        }

        // POST: Buys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuyId,Amount,Date_buy,Price,Form_Payment,Invoice,ClientId,StorageId")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                buy.Date_buy = DateTime.Now;
                db.Buys.Add(buy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageId", buy.StorageId);
            return View(buy);
        }

        // GET: Buys/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buys.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageId", buy.StorageId);
            return View(buy);
        }

        // POST: Buys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuyId,Amount,Date_buy,Price,Form_Payment,Invoice,ClientId,StorageId")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StorageId = new SelectList(db.Storages, "StorageId", "StorageId", buy.StorageId);
            return View(buy);
        }

        // GET: Buys/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buys.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }

        // POST: Buys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Buy buy = db.Buys.Find(id);
            db.Buys.Remove(buy);
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
