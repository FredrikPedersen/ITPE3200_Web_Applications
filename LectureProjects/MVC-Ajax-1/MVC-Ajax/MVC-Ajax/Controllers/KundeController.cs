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
            Console.WriteLine("GetAllRoutes is accessed");
            var db = new KundeDB();
            List <domeneKunde> alleKunder= db.hentAlleKunder();
            
            var alleNavn = new List<jsKunde>();
            foreach (domeneKunde k in alleKunder)
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
            domeneKunde enDomeneKunde = db.hentEnKunde(id);
            var jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(enDomeneKunde);
            return json;
        }

        public string register(domeneKunde innDomeneKunde)
        {
            var db = new KundeDB();
            db.lagreEnKunde(innDomeneKunde);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
        }
    }
}