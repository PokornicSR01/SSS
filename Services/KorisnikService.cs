using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    class KorisnikService : IKorisnikService
    {
        IKorisnikRepository korisnikRepository;

        public KorisnikService()
        {
            korisnikRepository = new KorisnikRepository(); 
        }

        public int DodajKorisnika(Korisnik korisnik)
        {
            return korisnikRepository.DodajKorisnika(korisnik);
        }

        public void IzmeniKorisnika(int id, Korisnik korisnik)
        {
            korisnikRepository.IzmeniKorisnika(id, korisnik);
        }

        public Korisnik Login(string eMail, string lozinka)
        {
            return korisnikRepository.Login(eMail, lozinka);
        }

        public void ObrisiKorisnika(int id)
        {
            korisnikRepository.ObrisiKorisnika(id);
        }

        
    }
}
