using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Repositories
{
    interface IKlijentRepository
    {
        int DodajKlijenta(Klijent klijent);
        void IzmeniKlijenta(int id,Klijent klijent);
        void ZakazivanjeTermina(Termin termin, Klijent klijent);
        void OtkazivanjeTermina(Termin termin, Klijent klijent);
        List<Klijent> VratiSveAktivneKlijente();
        void OcenjivanjeTrenera(Trener trener, int ocena);
        void UplataNaKarticu(int uplata, Klijent klijent);
        Klijent vratiKlijent(Korisnik korisnik);
        Klijent vratiKlijentaPoId(int id);
        void DodajKlijentuTrenera(Termin termin);

        List<int> VratiListuIdTrenera(Klijent klijent);

    }
}
