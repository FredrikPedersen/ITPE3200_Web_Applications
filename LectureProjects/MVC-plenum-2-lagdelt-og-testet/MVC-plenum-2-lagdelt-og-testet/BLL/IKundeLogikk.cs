using MVC_plenum_2.Model;
using System;
using System.Collections.Generic;
namespace MVC_plenum_2.BLL
{
    public interface IKundeLogikk
    {
        bool endreKunde(int id, Kunde innKunde);
        List<Kunde> hentAlle();
        Kunde hentEnKunde(int id);
        bool settInnKunde(Kunde innKunde);
        bool slettKunde(int id);
    }
}
