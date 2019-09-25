using Kunde_app_1_core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kunde_app_1_core
{
    public class DBKunde
    {
        private readonly KundeContext _context;

        public DBKunde(KundeContext context)
        {
            _context = context;
        }
        public List<Kunde> alleKunder()
        {
           List<Kunde> alleKunder;
           try
           {
                alleKunder = _context.Kunder.Select(k => new Kunde
                {
                    id = k.Id,
                    fornavn = k.Fornavn,
                    etternavn = k.Etternavn,
                    adresse = k.Adresse,
                    postnr = k.Poststeder.Postnr,
                    poststed = k.Poststeder.Poststed
                }).ToList();
            }
            catch(Exception e)
            {
                alleKunder = null;
            }
            return alleKunder;
        }

        public bool lagreKunde(Kunde innKunde)
        {
            try
            {
                var nyKundeRad = new Kunder();
                nyKundeRad.Fornavn = innKunde.fornavn;
                nyKundeRad.Etternavn = innKunde.etternavn;
                nyKundeRad.Adresse = innKunde.adresse;

                var sjekkPostSted = _context.Poststeder.Find(innKunde.postnr);
                if (sjekkPostSted == null)
                {
                    var poststedsRad = new Poststeder();
                    poststedsRad.Postnr = innKunde.postnr;
                    poststedsRad.Poststed = innKunde.poststed;
                    nyKundeRad.Poststeder = poststedsRad;
                }
                else
                {
                    nyKundeRad.Poststeder = sjekkPostSted;
                }
                _context.Kunder.Add(nyKundeRad);
                _context.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public Kunde hentKunde(int id)
        {
            //Kunder enKunde = _context.Kunder.Find(id); Fungerer ikke da Core ikke støtter lazy - loading !!!
            Kunder enKunde = _context.Kunder.Include(p => p.Poststeder).FirstOrDefault(k => k.Id == id);
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

        public bool endreKunde(Kunde innKunde)
        {
            try
            {
                // var endreObjekt = _context.Kunder.Find(innKunde.id); Må nedres da Core ikke støtter lazy - loading !!!
                Kunder endreObjekt = _context.Kunder.Include(p => p.Poststeder).FirstOrDefault(k => k.Id == innKunde.id);
                if (endreObjekt.Poststeder.Postnr != innKunde.postnr)
                {
                    var sjekkPostnr = _context.Poststeder.Find(innKunde.postnr);
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
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }

        public bool slett(int id)
        {
            try
            {
                var slettObjekt = _context.Kunder.Find(id);
                _context.Kunder.Remove(slettObjekt);
                _context.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
    }
}
