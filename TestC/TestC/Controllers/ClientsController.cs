using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestC.Context;

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
    }
}