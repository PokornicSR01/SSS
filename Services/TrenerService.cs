using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    class TrenerService : ITrenerService
    {
        ITrenerRepository trenerRepository;
        IKorisnikRepository korisnikRepository;
        IKlijentRepository klijentRepository;

        public TrenerService()
        {
            trenerRepository = new TrenerRepository();
            korisnikRepository = new KorisnikRepository();
            klijentRepository = new KlijentRepository();
        }

        public void DodajTrenera(Trener trener)
        {
            var korisnikId = korisnikRepository.DodajKorisnika(trener.korisnik);
            trener.korisnik.id = korisnikId;

            trenerRepository.DodajTrenera(trener);
        }

        public void IzmeniTrenera(int id,Trener trener)
        {
            korisnikRepository.IzmeniKorisnika(trener.korisnik.id, trener.korisnik);
            trenerRepository.IzmeniTrenera(id, trener);
        }

        public void OcenjivanjeKlijenta(Klijent klijent, int ocena)
        {
            throw new NotImplementedException();
        }

        public void PravljenjeTermina(Termin termin)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Klijent> VratiKlijentSaKojimaJeTrenerRadio(Trener trener)
        {
            List<int> klijentIds = trenerRepository.VratiListuIdKlijenata(trener);
            ObservableCollection<Klijent> klijents = new ObservableCollection<Klijent>();
            foreach (int id in klijentIds)
            {
                klijents.Add(klijentRepository.vratiKlijentaPoId(id));
            }

            trener.klijenti = klijents;

            return klijents;
        }

        public List<Trener> VratiSveAktivneTrenere()
        {
            return trenerRepository.VratiSveAktivneTrenere();
        }

        public Trener VratiTreneraPoId(Korisnik korisnik)
        {
            return trenerRepository.VratiTreneraPoId(korisnik);
        }

        public Trener vratiTreneraPoId(int id)
        {
            return trenerRepository.vratiTreneraPoId(id);
        }
    }
}
