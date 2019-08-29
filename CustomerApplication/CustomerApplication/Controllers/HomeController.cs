using CustomerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Plenum_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB();
            IEnumerable<Customer> allCustomers = db.Customer;
            return View(allCustomers);
        }
        public ActionResult ShowCustomer()
        {
            var db = new DB();
            Customer aCustomer = db.Customer.Find(1);
            return View(aCustomer);
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