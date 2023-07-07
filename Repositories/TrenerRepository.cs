using SSS_Projekat_Miju.Enums;
using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SSS_Projekat_Miju.Repositories
{
    class TrenerRepository : ITrenerRepository
    {
        public void DodajKlijentaTreneru(Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                string string1 = termin.klijent.id + ",";

                bool boolean = vratiNull(termin.trener.id);

                if (boolean)
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"update dbo.Trener set 
                            Klijenti = @idKlijenta + Klijenti
                            where Id=@id";

                    command.Parameters.Add(new SqlParameter("id", termin.trener.id));
                    command.Parameters.Add(new SqlParameter("idKlijenta", string1));

                    command.ExecuteScalar();
                }
                else
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"update dbo.Trener set 
                            Klijenti = @idKlijenta
                            where Id=@id";

                    command.Parameters.Add(new SqlParameter("id", termin.trener.id));
                    command.Parameters.Add(new SqlParameter("idKlijenta", string1));

                    command.ExecuteScalar();
                }
            }
        }

        public List<Trener> NajboljeRangiraniTreneri()
        {
            List<Trener> treneri = new List<Trener>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Trener p, dbo.RegistrovaniKorisnici u where p.KorisnikId=u.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Trener");

                foreach (DataRow row in ds.Tables["Trener"].Rows)
                {
                    var user = new Korisnik
                    {
                        id = (int)row["KorisnikId"],
                        ime = row["Ime"] as string,
                        prezime = row["Prezime"] as string,
                        eMail = row["Email"] as string,
                        lozinka = row["Lozinka"] as string,
                        tipKorisnika = (TipKorisnikaEnum)Enum.Parse(typeof(TipKorisnikaEnum), row["TipKorisnika"] as string),
                        brojTelefona = row["BrojTelefona"] as string,
                        aktivan = (bool)row["Aktivan"],
                        adresa = row["Adresa"] as string,
                        brojKreditneKartice = row["BrojKreditneKartice"] as string,
                        maternjiJezik = row["MaternjiJezik"] as string,
                        ostaliJezici = row["OstaliJezici"] as string,
                        brojOcena = (int)row["BrojOcena"],
                        zbirOcena = (int)row["ZbirOcena"]
                    };

                    var trener = new Trener
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = user,
                        sertifikat = row["Sertifikat"] as string,
                        zvanje = row["Zvanje"] as string,
                        ukupnaZarada = (int)row["UkupnaZarada"],
                        verifikovan = (bool)row["Verifikovan"],
                        diploma = row["Diploma"] as string

                    };

                    double prosek = (double)trener.korisnik.zbirOcena / (double)trener.korisnik.brojOcena; 
                    
                    if (trener.korisnik.aktivan == true && prosek >= 4)
                    {
                        treneri.Add(trener);
                    }
                }
            }

            return treneri;
        }

        public List<int> VratiListuIdKlijenata(Trener trener)
        {
            List<int> treneri = new List<int>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                
                string commandText = $"select * from dbo.Trener p  where p.Id={trener.id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Trener");
                foreach (DataRow row in ds.Tables["Trener"].Rows)
                {
                    string ids = row["Klijenti"] as string;

                    if(ids != null)
                    {
                        ids = ids.Remove(ids.Length - 1);
                        if (ids != null)
                        {
                            String[] split = ids.Split(",");

                            foreach (string a in split)
                            {
                                if (!treneri.Contains(Int32.Parse(a)))
                                {

                                    treneri.Add(Int32.Parse(a));
                                }
                            }
                        }
                    }
                    
                }
            }
            return treneri;
        }
    

        public List<Trener> VratiSveAktivneTrenere()
        {
            List<Trener> treneri = new List<Trener>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Trener p, dbo.RegistrovaniKorisnici u where p.KorisnikId=u.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Trener");

                foreach (DataRow row in ds.Tables["Trener"].Rows)
                {
                    var user = new Korisnik
                    {
                        id = (int)row["KorisnikId"],
                        ime = row["Ime"] as string,
                        prezime = row["Prezime"] as string,
                        eMail = row["Email"] as string,
                        lozinka = row["Lozinka"] as string,
                        tipKorisnika = (TipKorisnikaEnum)Enum.Parse(typeof(TipKorisnikaEnum), row["TipKorisnika"] as string),
                        brojTelefona = row["BrojTelefona"] as string,
                        aktivan = (bool)row["Aktivan"],
                        adresa = row["Adresa"] as string,
                        brojKreditneKartice = row["BrojKreditneKartice"] as string,
                        maternjiJezik = row["MaternjiJezik"] as string,
                        ostaliJezici = row["OstaliJezici"] as string,
                        brojOcena = (int)row["BrojOcena"],
                        zbirOcena = (int)row["ZbirOcena"]
                    };

                    var trener = new Trener
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = user,
                        sertifikat = row["Sertifikat"] as string,
                        zvanje = row["Zvanje"] as string,
                        ukupnaZarada = (int)row["UkupnaZarada"],
                        verifikovan = (bool)row["Verifikovan"],
                        diploma = row["Diploma"] as string

                    };

                    if (trener.korisnik.aktivan == true)
                    {
                        treneri.Add(trener);
                    }
                }
            }

            return treneri;
        }

        public Trener VratiTreneraPoId(Korisnik korisnik)
        {

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Trener p where p.KorisnikId = {korisnik.id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Trener");

                foreach (DataRow row in ds.Tables["Trener"].Rows)
                {

                    var trener = new Trener
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = korisnik,
                        sertifikat = row["Sertifikat"] as string,
                        zvanje = row["Zvanje"] as string,
                        ukupnaZarada = (int)row["UkupnaZarada"],
                        verifikovan = (bool)row["Verifikovan"],
                        diploma = row["Diploma"] as string,

                    };

                    return trener;
                }
            }

            return null;
        }

        public Trener vratiTreneraPoId(int id)
        {

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Trener p, dbo.RegistrovaniKorisnici u where p.KorisnikId=u.id and p.id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Trener");

                foreach (DataRow row in ds.Tables["Trener"].Rows)
                {
                    var user = new Korisnik
                    {
                        id = (int)row["KorisnikId"],
                        ime = row["Ime"] as string,
                        prezime = row["Prezime"] as string,
                        eMail = row["Email"] as string,
                        lozinka = row["Lozinka"] as string,
                        tipKorisnika = (TipKorisnikaEnum)Enum.Parse(typeof(TipKorisnikaEnum), row["TipKorisnika"] as string),
                        brojTelefona = row["BrojTelefona"] as string,
                        aktivan = (bool)row["Aktivan"],
                        adresa = row["Adresa"] as string,
                        brojKreditneKartice = row["BrojKreditneKartice"] as string,
                        maternjiJezik = row["MaternjiJezik"] as string,
                        ostaliJezici = row["OstaliJezici"] as string,
                        brojOcena = (int)row["BrojOcena"],
                        zbirOcena = (int)row["ZbirOcena"]
                    };

                    var trener = new Trener
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = user,
                        sertifikat = row["Sertifikat"] as string,
                        zvanje = row["Zvanje"] as string,
                        ukupnaZarada = (int)row["UkupnaZarada"],
                        verifikovan = (bool)row["Verifikovan"],
                        diploma = row["Diploma"] as string

                    };

                    if (trener.korisnik.aktivan == true)
                    {
                        return trener;
                    }
                }
            }

            return null;
        }

        int ITrenerRepository.DodajTrenera(Trener trener)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Trener (KorisnikId, Zvanje, Sertifikat, UkupnaZarada, verifikovan,diploma)
                    output inserted.Id
                    values (@KorisnikId, @Zvanje, @Sertifikat, @UkupnaZarada, @verifikovan,@diploma)";

                command.Parameters.Add(new SqlParameter("KorisnikId", trener.korisnik.id));
                command.Parameters.Add(new SqlParameter("Sertifikat", trener.sertifikat));
                command.Parameters.Add(new SqlParameter("Zvanje", trener.zvanje));
                command.Parameters.Add(new SqlParameter("UkupnaZarada", trener.ukupnaZarada));
                command.Parameters.Add(new SqlParameter("verifikovan", trener.verifikovan));
                command.Parameters.Add(new SqlParameter("diploma", trener.diploma));

                return (int)command.ExecuteScalar();
            }
        }

        void ITrenerRepository.IzmeniTrenera(int id,Trener trener)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Trener set 
                        Zvanje = @Zvanje,
                        Sertifikat = @Sertifikat,
                        Diploma = @Diploma
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Zvanje", trener.zvanje));
                command.Parameters.Add(new SqlParameter("Sertifikat", trener.sertifikat));
                command.Parameters.Add(new SqlParameter("Diploma", trener.diploma));

                command.ExecuteScalar();
            }
        }

        void ITrenerRepository.OcenjivanjeKlijenta(Klijent klijent, int ocena)
        {
            throw new NotImplementedException();
        }

        void ITrenerRepository.PravljenjeTermina(Termin termin)
        {
            throw new NotImplementedException();
        }

        Boolean vratiNull(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Trener t where t.id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Trener");

                foreach (DataRow row in ds.Tables["Trener"].Rows)
                {
                    string obj = row["Klijenti"] as string;

                    string string1 = "";

                    if(obj is null)
                    {
                        string1 = "null";
                    }
                    else
                    {
                        string1 = "1";
                    }

                    if(string1 == "null")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    
                }
            }

            return false;
        }
    }
}
