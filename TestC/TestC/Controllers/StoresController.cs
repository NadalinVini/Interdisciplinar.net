using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestC.Context;
using TestC.Models;

namespace TestC.Controllers
{
    public class StoresController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Stores
        public ActionResult Index()
        {
            return View(context.Stores.OrderBy(
            c => c.Name));
        }
        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            context.Stores.Add(store);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //	GET:Stores/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Store store = context.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //	POST: Stores/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                context.Entry(store).State =
                                                   EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }
        //	GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Store store = context.Stores.
                            Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }
        //	GET:	Stores/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Store store = context
                .Stores
                .Include("Produtos.Client")                .FirstOrDefault(s => s.StoreId == id.Value);

            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }
        //	POST:	Stores/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Store store = context.Stores.
                            Find(id);
            context.Stores.Remove(store);
            context.SaveChanges();
            TempData["Message"] = "Store	" +
                                store.Name.ToUpper() + "	was	removed";
            return RedirectToAction("Index");
        }


    }
}