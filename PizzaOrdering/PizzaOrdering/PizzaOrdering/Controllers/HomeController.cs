using PizzaOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaOrdering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult List()
        {
            var db = new PizzaDB();
            List<Pizza> allOrders = db.listAllOrders();
            return View(allOrders);
        }

        public ActionResult Order()
        {
            return View();
        }
    }
}