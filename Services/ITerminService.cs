using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    internal interface ITerminService
    {
        public List<Termin> VratiSveAktivneTermine();
        void DodajTermin(Termin termin,Trener trener);
        void IzmeniTermin(int id, Termin termin);
        void ObrisiTermin(int id);
        List<Termin> VratiSveTreneroveTermine(Trener trener);
        List<Termin> VratiSveKlijentoveRezervisaneTermine(Klijent klijent);
        void RezervisanjeTermina(Termin termin, Klijent klijent);
        void OtkaziTermin(Termin termin, Klijent klijent);
        void NaplatiTermin(Klijent klijent, Trener trener, Termin termin);
        void VratiPare(Klijent klijent, Trener trener, Termin termin);
        void OsmisliTermin(Termin termin);
        void ZavrsiTrening(Termin termin);

        
    }
}
