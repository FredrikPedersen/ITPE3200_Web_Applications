using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_plenum_2.Model;

namespace MVC_plenum_2.DAL
{
    public class KundeRepositoryStub : DAL.IKundeRepository
    {
        public List<Kunde> hentAlle()
        {
            var kundeListe = new List<Kunde>();
            var kunde = new Kunde()
            {
                id = 1,
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo",
                
            };
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            return kundeListe;
        }

        public bool settInn(Kunde innKunde)
        {
           if(innKunde.fornavn == "")
           {
               return false;
           }
           else
           {
               return true;
           } 
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            if(id==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettKunde(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Kunde hentEnKunde(int id)
        {
            if(id==0)
            {
                var kunde = new Kunde();
                kunde.id = 0;
                return kunde;
            }
            else
            {
                var kunde = new Kunde()
                {
                    id = 1,
                    fornavn = "Per",
                    etternavn = "Olsen",
                    adresse = "Osloveien 82",
                    postnr = "1234",
                    poststed = "Oslo"
                };
                return kunde;
            }
        }
    }
}