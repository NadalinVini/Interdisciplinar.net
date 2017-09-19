using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestC.Context;
using TestC.Models;

namespace TestC.Controllers
{
    public class StoresController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Clients
        public ActionResult Index()
        {
            return View(context.Stores.OrderBy(
            c => c.Name));
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
        
       


    }
}