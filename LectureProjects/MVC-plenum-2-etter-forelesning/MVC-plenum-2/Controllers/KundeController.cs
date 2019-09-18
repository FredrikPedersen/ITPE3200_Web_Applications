using MVC_plenum_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_plenum_2.Controllers
{
    public class KundeController : Controller
    {
        public ActionResult Liste()
        {
            var kundeDb = new DBKunde();
            List<Kunde> alleKunder = kundeDb.hentAlle();
            return View(alleKunder);
        }

        public ActionResult Detaljer(int id)
        {
            var kundeDb = new DBKunde();
            Kunde enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        public ActionResult Registrer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrer(Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                var kundeDb = new DBKunde();
                bool insertOK = kundeDb.settInn(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public ActionResult Endre(int id)
        {
            var kundeDb = new DBKunde();
            Kunde enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Endre(int id, Kunde endreKunde)
        {

            if (ModelState.IsValid)
            {
                var kundeDb = new DBKunde();
                bool endringOK = kundeDb.endreKunde(id, endreKunde);
                if (endringOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public ActionResult Slett(int id)
        {
            var kundeDb = new DBKunde();
            Kunde enKunde = kundeDb.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Slett(int id, Kunde slettKunde)
        {
            var kundeDb = new DBKunde();
            bool slettOK = kundeDb.slettKunde(id);
            if(slettOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
    }
}
