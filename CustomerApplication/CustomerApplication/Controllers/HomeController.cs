using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerApplication.Models;

namespace CustomerApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB();
            IEnumerable<Customer> allCustomers = db.Customer;
            return View(allCustomers);
        }

        public ActionResult RegisterCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterCustomer(Customer inCustomer)
        {
            var db = new DB();
            db.Customer.Add(inCustomer);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var db = new DB();
            Customer chosenCustomer = db.Customer.Find(id);
            db.Customer.Remove(chosenCustomer);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}