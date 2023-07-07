using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Repositories
{
    interface ITrenerRepository
    {
        int DodajTrenera(Trener trener);
        void IzmeniTrenera(int id,Trener trener);
        void PravljenjeTermina(Termin termin);
        List<Trener> VratiSveAktivneTrenere();
        void OcenjivanjeKlijenta(Klijent klijent, int ocena);
        Trener VratiTreneraPoId(Korisnik korisnik);
        Trener vratiTreneraPoId(int id);
        void DodajKlijentaTreneru(Termin termin);

        List<int> VratiListuIdKlijenata(Trener trener);

        List<Trener> NajboljeRangiraniTreneri();
    }
}
