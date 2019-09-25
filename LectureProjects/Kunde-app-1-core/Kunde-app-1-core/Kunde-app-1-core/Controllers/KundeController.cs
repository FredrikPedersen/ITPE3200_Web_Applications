using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kunde_app_1_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kunde_app_1_core.Controllers
{
    public class KundeController : Controller
    {

        private readonly KundeContext _context;

        public KundeController(KundeContext context)
        {
            _context = context;
        }

        public ActionResult Liste()
        {
            var db = new DBKunde(_context);
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

            var db = new DBKunde(_context);
            bool OK = db.lagreKunde(innKunde);
            if (OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
        public ActionResult Endre(int id)
        {
            var db = new DBKunde(_context);
            Kunde enKunde = db.hentKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Endre(Kunde innKunde)
        {
            var db = new DBKunde(_context);
            bool OK = db.endreKunde(innKunde);
            if (OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }


        public ActionResult Slett(int id)
        {
            var db = new DBKunde(_context);
            bool OK = db.slett(id);
            if (OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
    }
}