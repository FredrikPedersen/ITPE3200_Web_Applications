using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerApplication.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            Session["Customers"] = new List<Models.Customer>();
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Customer customerIn)
        {
            var allCustomers = (List<Models.Customer>)Session["Customers"];
            allCustomers.Add(customerIn);
            Session["Customers"] = allCustomers;

            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var allCustomers = (List<Models.Customer>)Session["Customers"];
            return View(allCustomers);
        }

        public ActionResult Delete(String deleteName)
        {
            var allCustomers = (List<Models.Customer>)Session["Customers"];

            for (var i = 0; i < allCustomers.Count; i++)
            {
                if (allCustomers[i].Name == deleteName)
                {
                    allCustomers.RemoveAt(i);
                }
            }

            Session["Customers"] = allCustomers;

            return RedirectToAction("List");
        }
    }
}