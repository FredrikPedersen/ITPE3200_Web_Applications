using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_plenum_2.Model;
using MVC_plenum_2.DAL;


namespace MVC_plenum_2.BLL
{
    public class KundeLogikk : BLL.IKundeLogikk
    {

        private IKundeRepository _repository;
 
        public KundeLogikk()
        {
            _repository = new KundeRepository();
        }

        public KundeLogikk(IKundeRepository stub)
        {
            _repository = stub;
        }
        public List<Kunde> hentAlle()
        {
            List<Kunde> allePersoner =  _repository.hentAlle();
            return allePersoner;
        }

        public bool settInnKunde(Kunde innKunde)
        {
            return _repository.settInn(innKunde);
        }

        public bool endreKunde(int id,Kunde innKunde)
        {
            return _repository.endreKunde(id, innKunde);
        }

        public Kunde hentEnKunde(int id)
        {
            return _repository.hentEnKunde(id);
        }

        public bool slettKunde(int id)
        {
            return _repository.slettKunde(id);
        }
    }
}
