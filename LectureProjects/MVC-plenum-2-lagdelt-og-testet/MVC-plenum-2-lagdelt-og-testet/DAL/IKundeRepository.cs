using MVC_plenum_2.Model;
using System;
using System.Collections.Generic;
namespace MVC_plenum_2.DAL
{
    
    public interface IKundeRepository
    {
        bool endreKunde(int id, Kunde innKunde);
        List<Kunde> hentAlle();
        Kunde hentEnKunde(int id);
        bool settInn(Kunde innKunde);
        bool slettKunde(int id);
    }
}
