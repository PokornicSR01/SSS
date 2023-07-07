using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Modules
{
    public class Trener
    {
        public Korisnik korisnik { get; set; }
        public int korisnikId { get; set; }
        public int id { get; set; } 
        public string diploma { get; set; }
        public string zvanje { get; set; }
        public string sertifikat { get; set; }
        public double ukupnaZarada { get; set; }
        public ObservableCollection<Klijent> klijenti { get; set; }
        public ObservableCollection<Termin> termini { get; set; }
        public Boolean verifikovan { get; set; }
        public Trener() { }

        public object Clone()
        {
            return new Trener()
            {
                korisnik = korisnik,
                zvanje = zvanje,
                sertifikat = sertifikat,
                ukupnaZarada = ukupnaZarada,
                korisnikId = korisnikId,
                diploma = diploma,
                id = id
            };
        }

        public override string ToString()
        {
            return korisnik.ime + " " + korisnik.prezime;
        }

    }
}
