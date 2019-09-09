using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerApplication.Models;

namespace CustomerApplication.Controllers
{
    public class HomeController : Controller
    {
        private DB db = new DB(); // dette objektet kan brukes av alle metodene i klassen

        protected override void Dispose(bool disposing)
        {
            // Denne vil dispose dbContext etter view´et er rendret ferdig!
            // Slik kan vi aksessere alleKundene via lazy loading der.
            // Dette har ikke noe med ToList() å gjøre.
            // Ved bruk av Using vil vi noen ganger få problemer med dette.
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            // sett opp mulighet for å se i output hvilke SQL´s som utføres!
            Debug.WriteLine("-----------------");
            db.Database.Log = melding => Debug.WriteLine(melding);

            // hent alle kundene og alle dataene for disse
            var allCustomers = db.Customer.ToList();

            return View(allCustomers);
        }


        // brukes under!
        private class Screws3mm
        {
            public string OrderDate { get; set; }
            public int Quantity { get; set; }
            public string ProductName { get; set; }
        }

        public ActionResult retrievalExamples()
        {
            // hent en kunde med primærnøkkel = 1, ikke funnet, null returneres.
            Customer customer1 = db.Customer.Find(1);

            // hent en kunde med navn Ole Olsen. Ikke funnet, en exeption kastes. Finner den første.
            Customer customer2 = db.Customer.First(k => k.FullName == "Ole Olsen");

            // hent en kunde med navn Ole Olsen. Ikke funnet, null returneres. Finner den første.
            Customer customer3 = db.Customer.FirstOrDefault(k => k.FullName == "Ole Olsen");

            // hent en kunde med navn Ole Olsen. Dersom det er flere enn en, eller ikke funnet, exeption kastes.
            Customer customer4 = db.Customer.Single(k => k.FullName == "Ole Olsen");

            // hent en kunde med navn Ole Olsen. Dersom det er flere enn en, eller ikke funnet, null returneres.
            Customer customer5 = db.Customer.SingleOrDefault(k => k.FullName == "Ole Olsen");

            // finn alle kundene med navn Ole Oslsen (dersom det er flere)

            // denne kan bare aksesseres via en foreach-løkke
            IEnumerable<Customer> customers1 = db.Customer.Where(k => k.FullName == "Ole Olsen");

            // denne kan brukes dersom man ønsker å spørre på et utdrag av collection i etterkant av spørringen
            // denne skjer så i SQL isteden for i minne
            IQueryable<Customer> customers2 = db.Customer.Where(k => k.FullName == "Ole Olsen");
            var customer21 = db.Customer.Where(k => k.FullName == "Ole Olsen"); // ved bruk av var blir det en IQueryable

            // må brukes dersom man ønsker å sette inn eller finne objekter via indexer etter innhenting
            List<Customer> customers3 = db.Customer.Where(k => k.FullName == "Ole Olsen").ToList();

            // hent alle ordrelinjer som har varer med navnet "Skruer 3mm"
            IEnumerable<OrderLine> orderlines1 = db.OrderLine.Where(o => o.Product.ProductName == "Skruer 3mm");

            // hent alle ordre, med dato og antall, som har ordrelinjer som har varer med navnet "Skruer 3mm"

            IQueryable<Screws3mm> OrderScrews3mm = db.Order.Join(db.OrderLine,
                                                        o => o.Id,
                                                        ol => ol.Id,
                                                        (o, ol) => new Screws3mm
                                                        {
                                                            OrderDate = o.Date,
                                                            Quantity = ol.Quantity,
                                                            ProductName = ol.Product.ProductName
                                                        })
                                                        .Where(orderOrderLine => orderOrderLine.ProductName == "Screws 3mm");
            return View();
        }

        public ActionResult addExample()
        {
            Customer newCustomer = new Customer();
            newCustomer.FullName = "Line Jensen";
            db.Customer.Add(newCustomer);
            db.SaveChanges();

            // for mer komplek insert - se DBInit.cs 
            return View();
        }

        public ActionResult deleteExample()
        {
            // hent det ønskede elementet man vil slette
            Customer removalObject = db.Customer.Find(1);
            // slett objektet
            db.Customer.Remove(removalObject);
            // lagre endringene
            db.SaveChanges();
            return View();
        }

        public ActionResult changeExample()
        {
            // hent det ønskede elementet man vil endre
            Customer changeObject = db.Customer.Find(1);
            // endre en attributt
            changeObject.FullName = "Per Hansen";
            // lagre endringene
            db.SaveChanges();
            return View();
        }
    }
}