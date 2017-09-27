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
    public class ProductsController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Products
        public ActionResult Index()
        {
            return View(context.Products.OrderBy(
            c => c.Name));
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //	GET:Products/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //	POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Entry(product).State =
                                                   EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        //	GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Product product = context.Products.
                            Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        //	GET:	Products/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Product product = context.Products.
                Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        //	POST:	Products/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Product product = context.Products.
                            Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            TempData["Message"] = "Product	" +
                                product.Name.ToUpper() + "	was	removed";
            return RedirectToAction("Index");            
        }


    }
}