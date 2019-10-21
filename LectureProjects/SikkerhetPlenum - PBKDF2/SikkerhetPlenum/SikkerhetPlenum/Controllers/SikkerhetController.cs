using SikkerhetPlenum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Text;
using System.Security.Cryptography;

namespace SikkerhetPlenum.Controllers
{
    public class SikkerhetController : Controller
    {
        public ActionResult Index()
        {
            // vis innlogging
            if(Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(bruker innLogget)
        {
            // sjekk om innlogging OK
            if(bruker_i_db(innLogget))
            {
                // ja brukernavn og passord er OK!
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                // ja brukernavn og passord er OK!
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }
        public ActionResult Registrer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrer(bruker innBruker)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            using (var db = new BrukerContext())
            {
                try
                {
                    var nyBruker = new dbBruker();
                    byte[] salt = lagSalt();
                    byte[] hash = lagHash(innBruker.Passord,salt);
                    nyBruker.Navn = innBruker.Navn;
                    nyBruker.Passord = hash;
                    nyBruker.Salt = salt;
                    db.Brukere.Add(nyBruker);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception feil)
                {
                    return View();
                }
            }
        }
        private static byte[] lagHash(string innPassord, byte[] innSalt)
        {
            const int keyLength = 24;
            var pbkdf2 = new Rfc2898DeriveBytes(innPassord, innSalt, 1000); // 1000 angir hvor mange ganger hash funskjonen skal utføres for økt sikkerhet
            return pbkdf2.GetBytes(keyLength);
        }

        private static byte[] lagSalt()
        {
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[24];
            csprng.GetBytes(salt);
            return salt;
        }

        private static bool bruker_i_db (bruker innBruker)
        {
            using (var db = new BrukerContext())
            {
                dbBruker funnetBruker = db.Brukere.FirstOrDefault(b => b.Navn == innBruker.Navn);
                if(funnetBruker !=null)
                {
                    byte[] passordForTest = lagHash(innBruker.Passord,funnetBruker.Salt);
                    bool riktigBruker = funnetBruker.Passord.SequenceEqual(passordForTest);  // merk denne testen!
                    return riktigBruker;
                }
                else
                {
                    return false;
                }
            }
        }
        public ActionResult InnloggetSide()
        {
            if(Session["LoggetInn"]!=null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if(loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            return RedirectToAction("index");
        }

        public ActionResult DecryptHash()
        {
            return View();
        }
    }
}