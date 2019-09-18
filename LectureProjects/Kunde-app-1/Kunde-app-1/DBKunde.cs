using Kunde_app_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kunde_app_1
{
    public class DBKunde
    {
        public List<Kunde> alleKunder()
        {
            using (var db = new KundeContext())
            {
                List<Kunde> alleKunder = db.Kunder.Select(k => new Kunde
                {
                    id = k.Id,
                    fornavn = k.Fornavn,
                    etternavn = k.Etternavn,
                    adresse = k.Adresse,
                    postnr = k.Poststeder.Postnr,
                    poststed = k.Poststeder.Poststed
                }).ToList();

                return alleKunder;
            }
        }

        public bool lagreKunde(Kunde innKunde)
        {
            using (var db = new KundeContext())
            {
                try
                {
                    var nyKundeRad = new Kunder();
                    nyKundeRad.Fornavn = innKunde.fornavn;
                    nyKundeRad.Etternavn = innKunde.etternavn;
                    nyKundeRad.Adresse = innKunde.adresse;

                    var sjekkPostnr = db.Poststeder.Find(innKunde.postnr);
                    if (sjekkPostnr == null)
                    {
                        var poststedsRad = new Poststeder();
                        poststedsRad.Postnr = innKunde.postnr;
                        poststedsRad.Poststed = innKunde.poststed;
                        nyKundeRad.Poststeder = poststedsRad;
                    }
                    else
                    {
                        nyKundeRad.Poststeder = sjekkPostnr;
                    }
                    db.Kunder.Add(nyKundeRad);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public Kunde hentKunde(int id)
        {
            using (var db = new KundeContext())
            {
                Kunder enKunde = db.Kunder.Find(id);
                var hentetKunde = new Kunde()
                {
                    id = enKunde.Id,
                    fornavn = enKunde.Fornavn,
                    etternavn = enKunde.Etternavn,
                    adresse = enKunde.Adresse,
                    postnr = enKunde.Poststeder.Postnr,
                    poststed = enKunde.Poststeder.Poststed
                };
                return hentetKunde;
            }
        } 

        public bool endreKunde(Kunde innKunde)
        {
            using (var db = new KundeContext())
            {
                try
                {
                    var endreObjekt = db.Kunder.Find(innKunde.id);
                    if(endreObjekt.Poststeder.Postnr!=innKunde.postnr)
                    {
                        var sjekkPostnr = db.Poststeder.Find(innKunde.postnr);
                        if (sjekkPostnr == null)
                        {
                            var poststedsRad = new Poststeder();
                            poststedsRad.Postnr = innKunde.postnr;
                            poststedsRad.Poststed = innKunde.poststed;
                            endreObjekt.Poststeder = poststedsRad;
                        }
                        else
                        {
                            endreObjekt.Poststeder.Postnr = innKunde.postnr;
                        }
                    }
                    endreObjekt.Fornavn = innKunde.fornavn;
                    endreObjekt.Etternavn = innKunde.etternavn;
                    endreObjekt.Adresse = innKunde.adresse;
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return false;
                }
                return true;
            }
        }

        public bool slett(int id)
        {
            using (var db = new KundeContext())
            {
                try
                {
                    var slettObjekt = db.Kunder.Find(id);
                    db.Kunder.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
    }
}