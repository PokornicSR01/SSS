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
    internal class KlijentService : IKlijentService
    {
        IKlijentRepository klijentRepository;
        IKorisnikRepository korisnikRepository;
        ITrenerRepository trenerRepository;

        public KlijentService()
        {
            klijentRepository = new KlijentRepository();
            korisnikRepository = new KorisnikRepository();
            trenerRepository = new TrenerRepository();
        }

        public void DodajKlijenta(Klijent klijent)
        {
            var korisnikId = korisnikRepository.DodajKorisnika(klijent.korisnik);
            klijent.korisnik.id = korisnikId;

            klijentRepository.DodajKlijenta(klijent);
        }

        public void IzmeniKlijenta(int id, Klijent klijent)
        {
            korisnikRepository.IzmeniKorisnika(klijent.korisnik.id, klijent.korisnik);
            klijentRepository.IzmeniKlijenta(id, klijent);

        }

        public void OcenjivanjeTrenera(Trener trener, int ocena)
        {
            throw new NotImplementedException();
        }

        public void PravljenjeTermina(Termin termin)
        {
            throw new NotImplementedException();
        }

        public void UplataNaKarticu(int uplata, Klijent klijent)
        {
            klijentRepository.UplataNaKarticu(uplata, klijent);
        }

        public Klijent vratiKlijent(Korisnik korisnik)
        {
            return klijentRepository.vratiKlijent(korisnik);
        }

        public Klijent vratiKlijentaPoId(int id)
        {
            return klijentRepository.vratiKlijentaPoId(id);
        }

        public List<Klijent> VratiSveAktivneKlijente()
        {
            return klijentRepository.VratiSveAktivneKlijente();
        }

        public ObservableCollection<Trener> VratiTrenereSaKojimaJeKlijentRadio(Klijent klijent)
        {
            List<int> trenerIds = klijentRepository.VratiListuIdTrenera(klijent);
            ObservableCollection<Trener> treners = new ObservableCollection<Trener>();
            foreach(int id in trenerIds)
            {
                treners.Add(trenerRepository.vratiTreneraPoId(id));
            }

            klijent.treneri = treners;

            return treners;
        }
    }
}
