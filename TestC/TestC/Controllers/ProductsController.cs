using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestC.Controllers
{
    public class ProductsController : Controller
    {
        private static IList<Product> products = new List<Product>()
        {
            new Product() { ProductId = 1, Name = "Gtx 1080", Type = "Placa de video", Brand = "Nvidea", Price = 1200},
            new Product() { ProductId = 2, Name = "H110", Type = "Placa mãe", Brand = "Asus", Price = 500},
            new Product() { ProductId = 3, Name = "RazzerPad", Type = "MousePad", Brand = "Razzer", Price = 70},
            new Product() { ProductId = 4, Name = "i5 7k", Type = "Processador", Brand = "Intel", Price = 800},
            new Product() { ProductId = 5, Name = "Fonte 500W", Type = "Fonte", Brand = "Corsair", Price = 300},
        };

        // GET: Product
        public ActionResult Index()
        {
            return View(new List<Product>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            products.Add(product);
            product.ProductId =
                products.Select(m => m.ProductId).Max() + 1;
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long id)
        {
            return View(products.Where(
                m => m.ProductId == id).First());
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            products.Remove(products.Where(
                c => c.ProductId == product.ProductId).First());
            products.Add(product);
            return RedirectToAction("Index");
        }
    }



}