using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Ajax.Models;
using System.Web.Script.Serialization;

namespace MVC_Ajax.Controllers
{
    public class KundeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string hentAlleNavn()
        {
            var db = new KundeDB();
            List <kunde> alleKunder= db.hentAlleKunder();
            
            var alleNavn = new List<jsKunde>();
            foreach (kunde k in alleKunder)
            {
                var ettNavn = new jsKunde();
                ettNavn.id = k.id;
                ettNavn.navn = k.fornavn + " " + k.etternavn;
                alleNavn.Add(ettNavn);
            }
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(alleKunder);
            return json;
        }

        public string hentKundeInfo(int id)
        {
            var db = new KundeDB();
            kunde enKunde = db.hentEnKunde(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enKunde);
            return json;
        }

        public string register(kunde innKunde)
        {
            var db = new KundeDB();
            db.lagreEnKunde(innKunde);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }
    }
}