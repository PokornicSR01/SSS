using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Modules
{
    public class Termin
    {
        public int id { get; set; }
        public Boolean rezervisan { get; set; }
        public Boolean zavrsen{ get; set; }
        public DateTime datum { get; set; }
        public double cena { get; set; }
        public Boolean aktivan { get; set; }
        public Klijent klijent { get; set; }
        public Trener trener { get; set; }

        public string opisTermina { get; set; }
        public Termin() { }

        public object Clone()
        {
            return new Termin()
            {
                rezervisan = rezervisan,
                cena = cena,
                datum = datum,
                aktivan = aktivan,
                klijent = klijent, 
                trener = trener,
                opisTermina = opisTermina,
                zavrsen= zavrsen,
                id = id
            };
        }
    }
}
