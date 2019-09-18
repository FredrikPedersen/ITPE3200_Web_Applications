using Kunde_app_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kunde_app_1.Controllers
{
    public class KundeController : Controller
    {
        public ActionResult Liste()
        {
            var db = new DBKunde();
            List<Kunde> alleKunder = db.alleKunder();
            return View(alleKunder);
        }

        public ActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Reg(Kunde innKunde)
        {

            var db = new DBKunde();
            bool OK = db.lagreKunde(innKunde);
            if (OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
        public ActionResult Endre(int id)
        {
            var db = new DBKunde();
            Kunde enKunde = db.hentKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Endre(Kunde innKunde)
        {
            var db = new DBKunde();
            bool OK = db.endreKunde(innKunde);
            if (OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }


        public ActionResult Slett(int id)
        {
            var db = new DBKunde();
            bool OK = db.slett(id);
            if (OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
    }
}