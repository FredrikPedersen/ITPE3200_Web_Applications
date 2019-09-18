using EF_2.Models;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace EF_2.Controllers
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
            var alleKundene = db.Kunde.ToList();
            
            return View(alleKundene);
        }


        // brukes under!
        private class Skurer3mm
        {
            public string OrdreDato { get; set; }
            public int Antall { get; set; }
            public string VareNavn { get; set; }
        }

        public ActionResult HenteEksempeler()
        {
            // hent en kunde med primærnøkkel = 1, ikke funnet, null returneres.
            Kunde kunde1 = db.Kunde.Find(1);

            // hent en kunde med navn Ole Olsen. Ikke funnet, en exeption kastes. Finner den første.
            Kunde kunde2 = db.Kunde.First(k => k.Navn == "Ole Olsen");

            // hent en kunde med navn Ole Olsen. Ikke funnet, null returneres. Finner den første.
            Kunde kunde3 = db.Kunde.FirstOrDefault(k => k.Navn == "Ole Olsen");

            // hent en kunde med navn Ole Olsen. Dersom det er flere enn en, eller ikke funnet, exeption kastes.
            Kunde kunde4 = db.Kunde.Single(k => k.Navn == "Ole Olsen");

            // hent en kunde med navn Ole Olsen. Dersom det er flere enn en, eller ikke funnet, null returneres.
            Kunde kunde5 = db.Kunde.SingleOrDefault(k => k.Navn == "Ole Olsen");

            // finn alle kundene med navn Ole Oslsen (dersom det er flere)

            // denne kan bare aksesseres via en foreach-løkke
            IEnumerable<Kunde> kunder1 = db.Kunde.Where(k => k.Navn == "Ole Olsen");

            // denne kan brukes dersom man ønsker å spørre på et utdrag av collection i etterkant av spørringen
            // denne skjer så i SQL isteden for i minne
            IQueryable<Kunde> kunder2 = db.Kunde.Where(k => k.Navn == "Ole Olsen");
            var kunder21 = db.Kunde.Where(k => k.Navn == "Ole Olsen"); // ved bruk av var blir det en IQueryable

            // må brukes dersom man ønsker å sette inn eller finne objekter via indexer etter innhenting
            List<Kunde> kunder3 = db.Kunde.Where(k => k.Navn == "Ole Olsen").ToList();

            // hent alle ordrelinjer som har varer med navnet "Skruer 3mm"
            IEnumerable<OrdreLinje> ordrelinjer1 = db.OrdreLinjer.Where(o => o.Vare.Navn == "Skruer 3mm");

            // hent alle ordre, med dato og antall, som har ordrelinjer som har varer med navnet "Skruer 3mm"

            IQueryable<Skurer3mm> OrdreSkruer3mm = db.Ordre.Join(db.OrdreLinjer,
                                                        o => o.Id,
                                                        ol => ol.Id,
                                                        (o, ol) => new Skurer3mm
                                                                    {OrdreDato = o.Dato,
                                                                     Antall = ol.Antall,
                                                                     VareNavn = ol.Vare.Navn })
                                                        .Where(ordreOrdreLinje => ordreOrdreLinje.VareNavn == "Skruer 3mm"); 
            return View();
        }

        public ActionResult LeggeTilEksempeler()
        {
            Kunde nyKunde = new Kunde();
            nyKunde.Navn = "Line Jensen";
            db.Kunde.Add(nyKunde);
            db.SaveChanges();

            // for mer komplek insert - se DBInit.cs 
            return View();
        }

        public ActionResult sletteTilEksempel()
        {
            // hent det ønskede elementet man vil slette
            Kunde sletteObjekt = db.Kunde.Find(1);
            // slett objektet
            db.Kunde.Remove(sletteObjekt);
            // lagre endringene
            db.SaveChanges();
            return View();
        }

        public ActionResult endreEksempel()
        {
            // hent det ønskede elementet man vil endre
            Kunde endreObjekt = db.Kunde.Find(1);
            // endre en attributt
            endreObjekt.Navn = "Per Hansen";
            // lagre endringene
            db.SaveChanges();
            return View();
        }
    }
}

  