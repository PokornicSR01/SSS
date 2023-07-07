using SSS_Projekat_Miju.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace SSS_Projekat_Miju.Modules
{
    public class Klijent
    {
        public Korisnik korisnik { get; set; }
        public int korisnikId { get; set; }
        public int id { get; set; }
        public int visina { get; set; }
        public int tezina { get; set; }
        public string bolesti { get; set; }
        public ObservableCollection<TipCiljeviEnum> ciljevi { get; set; }
        public ObservableCollection<TipRekvizitaEnum> rekviziti { get; set; }
        public double stanjeNaKartici { get; set; }
        public ObservableCollection<Termin> termini { get; set; }
        public ObservableCollection<Trener> treneri { get; set; }
        public Klijent() { }

        public object Clone()
        {
            return new Klijent()
            {
                korisnik = korisnik, 
                visina =visina,
                tezina = tezina,
                bolesti = bolesti,
                id = id,
                korisnikId = korisnikId,
                ciljevi = ciljevi,
                rekviziti = rekviziti
            };
        }
        public override string ToString()
        {
            return korisnik.ime + " " + korisnik.prezime;
        }
    }


}
