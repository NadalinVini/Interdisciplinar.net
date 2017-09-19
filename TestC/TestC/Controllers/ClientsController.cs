using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestC.Context;
using TestC.Models;

namespace TestC.Controllers
{
    public class ClientsController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Clients
        public ActionResult Index()
        {
            return View(context.Clients.OrderBy(
            c => c.Name));
        }
        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //	GET:Clients/Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                    HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }
            Client client = context.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        
        //	POST: Clients/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                context.Entry(client).State =
                                                   EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }
        //	GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Client client = context.Clients.
                            Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        //	GET:	Clients/Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                                HttpStatusCode.BadRequest);
            }
            Client client = context.Clients.
                Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        //	POST:	Clients/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Client client = context.Clients.
                            Find(id);
            context.Clients.Remove(client);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}