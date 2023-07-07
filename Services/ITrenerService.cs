using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    interface ITrenerService
    {
        void DodajTrenera(Trener trener);
        void IzmeniTrenera(int id, Trener trener);
        void PravljenjeTermina(Termin termin);
        Trener VratiTreneraPoId(Korisnik korisnik);
        void OcenjivanjeKlijenta(Klijent klijent, int ocena);
        List<Trener> VratiSveAktivneTrenere();
        Trener vratiTreneraPoId(int id);

        ObservableCollection<Klijent> VratiKlijentSaKojimaJeTrenerRadio(Trener trener);

    }
}
