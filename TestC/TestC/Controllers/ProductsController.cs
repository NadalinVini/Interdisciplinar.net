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
            var produtos = context.Products.Include(c => c.Client).
                            Include(f => f.Store).OrderBy(n => n.Name);
            return View(produtos);
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(context.Clients.
                            OrderBy(b => b.Name), "ClientId", "Nome do fudido");
            ViewBag.StoresId = new SelectList(context.Stores.
                            OrderBy(b => b.Name), "StoresId", "Nome da favela");
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
                return new HttpStatusCodeResult(HttpStatusCode.
                    BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(context.Clients.
            OrderBy(b => b.Name), "CategoriaId", "Nome", product.
                    ClientId);
            ViewBag.FabricanteId = new SelectList(context.Stores.
            OrderBy(b => b.Name), "FabricanteId", "Nome", product.
            StoreId);
            return View(product);
        }

        //	POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }
        //	GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.
                                BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId ==
                          id).Include(c => c.Client).Include(f => f.Store).
                            First();
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
                return new HttpStatusCodeResult(HttpStatusCode.
                                BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId ==
                          id).Include(c => c.Client).Include(f => f.Store).
                            First();
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
            try
            {
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                TempData["Message"] = "Produto	" + product.Name.ToUpper()
        + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}