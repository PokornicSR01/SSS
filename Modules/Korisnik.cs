using SSS_Projekat_Miju.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Modules
{
    public class Korisnik
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brojTelefona { get; set; }
        public string lozinka { get; set; }
        public string eMail { get; set; }
        public string adresa { get; set; }
        public string brojKreditneKartice { get; set; }
        public string maternjiJezik { get; set; }
        public string ostaliJezici { get; set; }
        public double zbirOcena { get; set; }
        public int brojOcena { get; set; }
        public Boolean aktivan { get; set; }
        public TipKorisnikaEnum tipKorisnika { get; set; }
        public Korisnik() { }

        public double VratiProsecnuOcenu()
        {
            return this.zbirOcena / this.brojOcena;
        }

        public object Clone()
        {
            return new Korisnik()
            {
                id = this.id,
                ime = this.ime,
                prezime = this.prezime,
                brojTelefona = this.brojTelefona,
                lozinka = this.lozinka,
                adresa = this.adresa,
                brojKreditneKartice = this.brojKreditneKartice,
                maternjiJezik = this.maternjiJezik,
                ostaliJezici = this.ostaliJezici,
                zbirOcena = this.zbirOcena,
                brojOcena = this.brojOcena,
                eMail = this.eMail,
                aktivan = this.aktivan,
            };
        }

        public override string ToString()
        {
            return ime + " " + prezime;
        }
    }
}
