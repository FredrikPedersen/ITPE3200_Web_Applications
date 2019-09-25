using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using MVC_Ajax.Models;

namespace MVC_Ajax
{
    public class KundeDB
    {
        KundeContext db = new KundeContext();

        public List<domeneKunde> hentAlleKunder()
        {
            List<domeneKunde> alleKunder = db.Kunder.Select(k => new domeneKunde()
            {
                id = k.id,
                fornavn = k.fornavn,
                etternavn = k.etternavn,
                adresse = k.adresse,
                postnr = k.postnr,
                poststed = k.poststed.poststed
            }).ToList();
            return alleKunder;
        }

        public domeneKunde hentEnKunde(int id)
        {
            Kunde enDBKunde = db.Kunder.Find(id);

            var enKunde = new domeneKunde()
            {
                id = enDBKunde.id,
                fornavn = enDBKunde.fornavn,
                etternavn = enDBKunde.etternavn,
                adresse = enDBKunde.adresse,
                postnr = enDBKunde.postnr,
                poststed = enDBKunde.poststed.poststed
            };
            return enKunde;
        }

        public bool lagreEnKunde(domeneKunde innDomeneKunde)
        {
            var nyKunde = new Kunde
            {
                fornavn = innDomeneKunde.fornavn,
                etternavn = innDomeneKunde.etternavn,
                adresse = innDomeneKunde.adresse,
                postnr = innDomeneKunde.postnr
            };

            Poststed funnetPoststed = db.Poststeder.Find(innDomeneKunde.postnr);
            if (funnetPoststed == null)
            {
                // lag poststedet
                var nyttPoststed = new Poststed
                {
                    postnr = innDomeneKunde.postnr,
                    poststed = innDomeneKunde.poststed
                };
                // legg det inn i den nye kunden
                nyKunde.poststed = nyttPoststed;

            }
            try
            {
                // lagre kunden
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
    }  
}