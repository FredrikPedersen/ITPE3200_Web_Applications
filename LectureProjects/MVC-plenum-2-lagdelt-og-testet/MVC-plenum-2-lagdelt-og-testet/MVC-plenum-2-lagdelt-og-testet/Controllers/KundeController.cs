using MVC_plenum_2.Model;
using MVC_plenum_2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_plenum_2.Controllers
{
    public class KundeController : Controller
    {
        private IKundeLogikk _kundeBLL;
        
        public KundeController()
        {
            _kundeBLL = new KundeLogikk();
        }

        public KundeController(IKundeLogikk stub)
        {
            _kundeBLL = stub;
        }
        
        public ActionResult Liste()
        {
            List<Kunde> alleKunder = _kundeBLL.hentAlle();
            return View(alleKunder);
        }

        public ActionResult Detaljer(int id)
        {
            Kunde enKunde = _kundeBLL.hentEnKunde(id);
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
                bool insertOK = _kundeBLL.settInnKunde(innKunde);
                if (insertOK)
                {
                    return RedirectToAction("Liste");
                }
            }
            return View();
        }

        public ActionResult Endre(int id)
        {
            Kunde enKunde = _kundeBLL.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Endre(int id, Kunde endreKunde)
        {
            bool endringOK = _kundeBLL.endreKunde(id, endreKunde);
            if(endringOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }

        public ActionResult Slett(int id)
        {
            Kunde enKunde = _kundeBLL.hentEnKunde(id);
            return View(enKunde);
        }

        [HttpPost]
        public ActionResult Slett(int id, Kunde slettKunde)
        {
            bool slettOK = _kundeBLL.slettKunde(id);
            if(slettOK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
    }
}
