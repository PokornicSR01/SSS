using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Repositories
{
    interface ITerminRepository
    {
        public List<Termin> VratiSveAktivneTermine();
        int DodajTermin(Termin termin, Trener trener);
        void ObrisiTermin(int id);
        void IzmeniTermin(int id, Termin termin);
        List<Termin> VratiSveTreneroveTermine(Trener trener);
        void RezervisanjeTermina(Termin termin, Klijent klijent);
        void OtkaziTermin(Termin termin, Klijent klijent);
        void NaplatiTerminKlijentu(Klijent klijent, Termin termin);
        void UplatiNovacTreneru(Trener trener, Termin termin);
        void VratiPareKlijentu(Klijent klijent, Termin termin);
        void UzmiPareTreneru(Trener trener, Termin termin);
        void UzmiProcenat(Termin termin);
        void VratiProcenat(Termin termin);
        List<Termin> VratiSveKlijentoveRezervisaneTermine(Klijent klijent);
        void OsmisliTermin(Termin termin);
        void ZavrsiTermin(Termin termin);
    }
}
