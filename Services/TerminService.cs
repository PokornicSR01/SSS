using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    internal class TerminService : ITerminService
    {
        private ITerminRepository repository;
        private IKlijentRepository klijentRepository;
        private ITrenerRepository trenerRepository;
        public TerminService()
        { 
            repository = new TerminRepository();
            klijentRepository= new KlijentRepository();
            trenerRepository= new TrenerRepository();
        }
        public void DodajTermin(Termin termin, Trener trener)
        {
            repository.DodajTermin(termin, trener);
        }

        public void IzmeniTermin(int id, Termin termin)
        {
            repository.IzmeniTermin(id, termin);
        }

        public void NaplatiTermin(Klijent klijent, Trener trener, Termin termin)
        {
            repository.NaplatiTerminKlijentu(klijent, termin);
            repository.UplatiNovacTreneru(trener, termin);
            repository.UzmiProcenat(termin);

        }

        public void ObrisiTermin(int id)
        {
            repository.ObrisiTermin(id);
        }

        public void OsmisliTermin(Termin termin)
        {
            repository.OsmisliTermin(termin);
        }

        public void OtkaziTermin(Termin termin, Klijent klijent)
        {
            repository.OtkaziTermin(termin, klijent);
        }

        public void RezervisanjeTermina(Termin termin, Klijent klijent)
        {
            repository.RezervisanjeTermina(termin, klijent);
        }

        public void VratiPare(Klijent klijent, Trener trener, Termin termin)
        {
            repository.UzmiPareTreneru(trener, termin);
            repository.VratiPareKlijentu(klijent, termin);
            repository.VratiProcenat(termin);
        }

        public List<Termin> VratiSveAktivneTermine()
        {
            return repository.VratiSveAktivneTermine();
        }

        public List<Termin> VratiSveKlijentoveRezervisaneTermine(Klijent klijent)
        {
            return repository.VratiSveKlijentoveRezervisaneTermine(klijent);
        }

        public List<Termin> VratiSveTreneroveTermine(Trener trener)
        {
            return repository.VratiSveTreneroveTermine(trener);
        }

        public void ZavrsiTrening(Termin termin)
        {
            klijentRepository.DodajKlijentuTrenera(termin);
            trenerRepository.DodajKlijentaTreneru(termin);
            repository.ZavrsiTermin(termin);
        }
    }
}
