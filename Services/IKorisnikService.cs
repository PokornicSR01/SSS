using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    interface IKorisnikService
    {
        int DodajKorisnika(Korisnik korisnik);
        void IzmeniKorisnika(int id, Korisnik korisnik);
        void ObrisiKorisnika(int id);
        Korisnik Login(string eMail, string lozinka);
    }
}
