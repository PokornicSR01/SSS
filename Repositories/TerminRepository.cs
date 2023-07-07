using SSS_Projekat_Miju.Enums;
using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SSS_Projekat_Miju.Repositories
{
    class TerminRepository : ITerminRepository
    {
        public int DodajTermin(Termin termin, Trener trener)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Termin (TrenerId, Datum, Cena, Rezervisan, Aktivan, Zavrsen)
                    output inserted.Id
                    values (@TrenerId, @Datum, @Cena, @Rezervisan, @Aktivan, @zavrsen)";

                command.Parameters.Add(new SqlParameter("TrenerId", trener.id));
                command.Parameters.Add(new SqlParameter("Datum", termin.datum));
                command.Parameters.Add(new SqlParameter("Cena", termin.cena));
                command.Parameters.Add(new SqlParameter("Rezervisan", termin.rezervisan));
                command.Parameters.Add(new SqlParameter("Aktivan", termin.aktivan));
                command.Parameters.Add(new SqlParameter("zavrsen", termin.zavrsen));

                return (int)command.ExecuteScalar();
            }
        }

        public void IzmeniTermin(int id, Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Termin set 
                        Datum = @Datum,
                        Cena = @Cena
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Datum", termin.datum));
                command.Parameters.Add(new SqlParameter("Cena", termin.cena));

                command.ExecuteScalar();
            }
        }

        public void NaplatiTerminKlijentu(Klijent klijent, Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Klijent set 
                        StanjeNaKartici = StanjeNaKartici - @StanjeNaKartici
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("StanjeNaKartici", termin.cena));
                command.Parameters.Add(new SqlParameter("id", klijent.id));

                command.ExecuteScalar();
            }
        }

        public void ObrisiTermin(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Termin set Aktivan=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }

        public void OsmisliTermin(Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Termin set 
                        OpisTermina = @OpisTermina
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", termin.id));
                command.Parameters.Add(new SqlParameter("OpisTermina", termin.opisTermina));
                

                command.ExecuteScalar();
            }
        }

        public void OtkaziTermin(Termin termin, Klijent klijent)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Termin set 
                        KlijentId = Null,
                        Rezervisan = 0
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", termin.id));

                command.ExecuteScalar();
            }
        }

        public void RezervisanjeTermina(Termin termin, Klijent klijent)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Termin set 
                        KlijentId = @KlijentId,
                        Rezervisan = 1
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", termin.id));
                command.Parameters.Add(new SqlParameter("KlijentId", klijent.id));

                command.ExecuteScalar();
            }
        }

        public void UplatiNovacTreneru(Trener trener, Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Trener set 
                        UkupnaZarada = UkupnaZarada + @StanjeNaKartici
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("StanjeNaKartici", termin.cena*0.9));
                command.Parameters.Add(new SqlParameter("id", trener.id));

                command.ExecuteScalar();
            }
        }

        public void UzmiPareTreneru(Trener trener, Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Trener set 
                        UkupnaZarada = UkupnaZarada - @StanjeNaKartici
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("StanjeNaKartici", termin.cena*0.9));
                command.Parameters.Add(new SqlParameter("id", trener.id));

                command.ExecuteScalar();
            }
        }

        public void UzmiProcenat(Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Vlasnik set 
                        Zarada = Zarada + @StanjeNaKartici
                        where Id=1";

                command.Parameters.Add(new SqlParameter("StanjeNaKartici", termin.cena * 0.1));
                

                command.ExecuteScalar();
            }
        }

        public void VratiPareKlijentu(Klijent klijent, Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Klijent set 
                        StanjeNaKartici = StanjeNaKartici + @StanjeNaKartici
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("StanjeNaKartici", termin.cena));
                command.Parameters.Add(new SqlParameter("id", klijent.id));

                command.ExecuteScalar();
            }
        }

        public void VratiProcenat(Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Vlasnik set 
                        Zarada = Zarada - @StanjeNaKartici
                        where Id=1";

                command.Parameters.Add(new SqlParameter("StanjeNaKartici", termin.cena * 0.1));


                command.ExecuteScalar();
            }
        }

        public List<Termin> VratiSveAktivneTermine()
        {
            List<Termin> termini = new List<Termin>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from termin t, trener tren, RegistrovaniKorisnici rK where t.TrenerId = tren.id and tren.KorisnikId = rK.Id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Termin");

                foreach (DataRow row in ds.Tables["Termin"].Rows)
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
                        id = (int)row["TrenerId"],
                        korisnik = user,
                        sertifikat = row["Sertifikat"] as string,
                        zvanje = row["Zvanje"] as string,
                        ukupnaZarada = (int)row["UkupnaZarada"],
                        verifikovan = (bool)row["Verifikovan"],

                    };

                    string opis1 = row["OpisTermina"] as string;

                    var termin = new Termin
                    {
                        datum = Convert.ToDateTime(row["Datum"]),
                        cena = (int)row["Cena"],
                        trener = trener,
                        aktivan = (bool)row["Aktivan"],
                        zavrsen = (bool)row["Zavrsen"],
                        rezervisan = (bool)row["Rezervisan"],
                        id = (int)row["Id"]
                    };

                    if(opis1 != null)
                    {
                        termin.opisTermina = opis1;
                    }

                    if (termin.aktivan == true)
                    {
                        termini.Add(termin);
                    }
                }
            }

            return termini;
        }

        public List<Termin> VratiSveKlijentoveRezervisaneTermine(Klijent klijent)
        {
            List<Termin> termini = new List<Termin>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from termin t, trener tr, registrovaniKorisnici reg where t.KlijentId = {klijent.id} and tr.id = t.TrenerId and tr.KorisnikId = reg.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Termin");

                foreach (DataRow row in ds.Tables["Termin"].Rows)
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
                        id = (int)row["TrenerId"],
                        korisnik = user,
                        sertifikat = row["Sertifikat"] as string,
                        zvanje = row["Zvanje"] as string,
                        ukupnaZarada = (int)row["UkupnaZarada"],
                        verifikovan = (bool)row["Verifikovan"],
                        

                    };

                    var termin = new Termin
                    {
                        datum = Convert.ToDateTime(row["Datum"]),
                        cena = (int)row["Cena"],
                        klijent = klijent,
                        trener = trener,    
                        aktivan = (bool)row["Aktivan"],
                        zavrsen = (bool)row["Zavrsen"],
                        rezervisan = (bool)row["Rezervisan"],
                        id = (int)row["Id"]
                    };

                    if (termin.aktivan == true)
                    {
                        termini.Add(termin);
                    }
                }
            }

            return termini;
        }
 
        public List<Termin> VratiSveTreneroveTermine(Trener trener)
        {
            List<Termin> termini = new List<Termin>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from (termin t left outer join Klijent k on k.id = t.KlijentId ) left outer join RegistrovaniKorisnici rk on k.KorisnikId = rk.id;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();


                dataAdapter.Fill(ds, "Termin");

                foreach (DataRow row in ds.Tables["Termin"].Rows)
                {
                    ObservableCollection<TipRekvizitaEnum> rekviziti =  new ObservableCollection<TipRekvizitaEnum>();
                    ObservableCollection<TipCiljeviEnum> ciljevi = new ObservableCollection<TipCiljeviEnum>();
                    string stringRekvizita = row["Rekviziti"] as string;
                    if(stringRekvizita != null)
                    {

                        String[] split = stringRekvizita.Split(",");
                        

                        foreach (string s in split)
                        {
                            TipRekvizitaEnum rekvizit = (TipRekvizitaEnum)Enum.Parse(typeof(TipRekvizitaEnum), s as string);
                            rekviziti.Add(rekvizit);
                        }

                        string stringCiljeva = row["Ciljevi"] as string;
                        String[] split1 = stringRekvizita.Split(",");
                        

                        foreach (string s in split1)
                        {
                            TipCiljeviEnum rekvizit = (TipCiljeviEnum)Enum.Parse(typeof(TipCiljeviEnum), s as string);
                            ciljevi.Add(rekvizit);
                        }
                    }
                    var termin = new Termin
                    {
                        datum = Convert.ToDateTime(row["Datum"]),
                        cena = (int)row["Cena"],
                        opisTermina = row["OpisTermina"] as string,
                        aktivan = (bool)row["Aktivan"],
                        zavrsen = (bool)row["Zavrsen"],
                        rezervisan = (bool)row["Rezervisan"],
                        id = (int)row["Id"]
                        
                    };

                    Klijent klijent1 = new Klijent();

                    if (row["KlijentId"] is int)
                    {
                        var klijent = new Klijent
                        {
                            korisnikId = (int)row["KorisnikId"],
                            id = (int)row["KlijentId"],
                            rekviziti= rekviziti,
                            ciljevi = ciljevi,
                            visina = (int)row["Visina"],
                            tezina = (int)row["Tezina"],
                            bolesti = row["Bolesti"] as string,

                        };
                        klijent1 = klijent;
                        termin.klijent = klijent;
                    }

                    if (row["KorisnikId"] is int)
                    {
                        var user = new Korisnik
                        {
                            aktivan = (bool)row["Aktivan"],
                            id = (int)row["KorisnikId"],
                            ime = row["Ime"] as string,
                            prezime = row["Prezime"] as string,
                            eMail = row["Email"] as string,
                            lozinka = row["Lozinka"] as string,
                            tipKorisnika = (TipKorisnikaEnum)Enum.Parse(typeof(TipKorisnikaEnum), row["TipKorisnika"] as string),
                            brojTelefona = row["BrojTelefona"] as string,
                            adresa = row["Adresa"] as string,
                            brojKreditneKartice = row["BrojKreditneKartice"] as string,
                            maternjiJezik = row["MaternjiJezik"] as string,
                            ostaliJezici = row["OstaliJezici"] as string,
                            brojOcena = (int)row["BrojOcena"],
                            zbirOcena = (int)row["ZbirOcena"]
                        };

                        klijent1.korisnik = user;
                        
                    };

                    if ((int)row["TrenerId"] == trener.id)
                    {
                        termin.trener = trener;
                    }

                        if (termin.aktivan == true && termin.trener != null)
                    {
                        termini.Add(termin);
                    }
                }
            }

            return termini;
        }

        public void ZavrsiTermin(Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Termin set 
                        Zavrsen = 1
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", termin.id));

                command.ExecuteScalar();
            }
        }
    }
}
