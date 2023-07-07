using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    internal interface IKlijentService
    {
        void DodajKlijenta(Klijent klijent);
        void IzmeniKlijenta(int id,Klijent klijent);
        void PravljenjeTermina(Termin termin);
        List<Klijent> VratiSveAktivneKlijente();
        void OcenjivanjeTrenera(Trener trener, int ocena);
        Klijent vratiKlijentaPoId(int id);
        void UplataNaKarticu(int uplata, Klijent klijent);
        Klijent vratiKlijent(Korisnik korisnik);


        ObservableCollection<Trener> VratiTrenereSaKojimaJeKlijentRadio(Klijent klijent);
       
    }
}
