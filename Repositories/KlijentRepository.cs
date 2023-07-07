using SSS_Projekat_Miju.Enums;
using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Repositories
{
    class KlijentRepository : IKlijentRepository
    {
        public void DodajKlijentuTrenera(Termin termin)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                string string1 = termin.trener.id + ",";

                Boolean boolean = vratiNull(termin.klijent.id);

                if (boolean)
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"update dbo.Klijent set 
                        Treneri = @idTrenera + Treneri
                        where Id=@id";

                    command.Parameters.Add(new SqlParameter("id", termin.klijent.id));
                    command.Parameters.Add(new SqlParameter("idTrenera", string1));

                    command.ExecuteScalar();
                }
                else
                {
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"update dbo.Klijent set 
                        Treneri = @idTrenera
                        where Id=@id";

                    command.Parameters.Add(new SqlParameter("id", termin.klijent.id));
                    command.Parameters.Add(new SqlParameter("idTrenera", string1));

                    command.ExecuteScalar();
                }
                
            }
        }

        public void UplataNaKarticu(int uplata, Klijent klijent)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Klijent set 
                        StanjeNaKartici = StanjeNaKartici + @Uplata
                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", klijent.id));
                command.Parameters.Add(new SqlParameter("Uplata", uplata));

                command.ExecuteScalar();
            }
        }

        public Klijent vratiKlijent(Korisnik korisnik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Klijent p where p.KorisnikId = {korisnik.id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Klijent");

                foreach (DataRow row in ds.Tables["Klijent"].Rows)
                {
                    string stringRekvizita = row["Rekviziti"] as string;
                    String[] split = stringRekvizita.Split(",");
                    ObservableCollection<TipRekvizitaEnum> rekviziti = new ObservableCollection<TipRekvizitaEnum>();

                    foreach (string s in split)
                    {
                        TipRekvizitaEnum rekvizit = (TipRekvizitaEnum)Enum.Parse(typeof(TipRekvizitaEnum), s as string);
                        rekviziti.Add(rekvizit);
                    }

                    string stringCiljeva = row["Ciljevi"] as string;
                    String[] split1 = stringCiljeva.Split(",");
                    ObservableCollection<TipCiljeviEnum> ciljevi = new ObservableCollection<TipCiljeviEnum>();

                    foreach (string s in split1)
                    {
                        TipCiljeviEnum rekvizit = (TipCiljeviEnum)Enum.Parse(typeof(TipCiljeviEnum), s as string);
                        ciljevi.Add(rekvizit);
                    }

                    var klijent = new Klijent
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = korisnik,
                        rekviziti = rekviziti,
                        visina = (int)row["Visina"],
                        tezina = (int)row["Tezina"],
                        bolesti = row["Bolesti"] as string,
                        ciljevi = ciljevi,
                        stanjeNaKartici = (int)row["StanjeNaKartici"],

                    };

                    if (klijent.korisnik.aktivan == true)
                    {
                        return klijent;
                    }
                }
            }

            return null;
        }

        public Klijent vratiKlijentaPoId(int id)
        {

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Klijent p, dbo.RegistrovaniKorisnici u where p.KorisnikId=u.id and p.id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Klijent");

                foreach (DataRow row in ds.Tables["Klijent"].Rows)
                {
                    string stringRekvizita = row["Rekviziti"] as string;
                    String[] split = stringRekvizita.Split(",");
                    ObservableCollection<TipRekvizitaEnum> rekviziti = new ObservableCollection<TipRekvizitaEnum>();

                    foreach (string s in split)
                    {
                        TipRekvizitaEnum rekvizit = (TipRekvizitaEnum)Enum.Parse(typeof(TipRekvizitaEnum), s as string);
                        rekviziti.Add(rekvizit);
                    }

                    string stringCiljeva = row["Ciljevi"] as string;
                    String[] split1 = stringCiljeva.Split(",");
                    ObservableCollection<TipCiljeviEnum> ciljevi = new ObservableCollection<TipCiljeviEnum>();

                    foreach (string s in split1)
                    {
                        TipCiljeviEnum rekvizit = (TipCiljeviEnum)Enum.Parse(typeof(TipCiljeviEnum), s as string);
                        ciljevi.Add(rekvizit);
                    }

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

                    var klijent = new Klijent
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = user,
                        rekviziti = rekviziti,
                        visina = (int)row["Visina"],
                        tezina = (int)row["Tezina"],
                        bolesti = row["Bolesti"] as string,
                        ciljevi = ciljevi

                    };

                    if (klijent.korisnik.aktivan == true)
                    {
                        return klijent;
                    }
                }
            }

            return null;
        }

        public List<Klijent> VratiSveAktivneKlijente()
        {
            List<Klijent> treneri = new List<Klijent>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = "select * from dbo.Klijent p, dbo.RegistrovaniKorisnici u where p.KorisnikId=u.id";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Klijent");

                foreach (DataRow row in ds.Tables["Klijent"].Rows)
                {
                    string stringRekvizita = row["Rekviziti"] as string;
                    String[] split = stringRekvizita.Split(",");
                    ObservableCollection<TipRekvizitaEnum> rekviziti = new ObservableCollection<TipRekvizitaEnum>();

                    foreach(string s in split)
                    {
                        TipRekvizitaEnum rekvizit = (TipRekvizitaEnum)Enum.Parse(typeof(TipRekvizitaEnum), s as string);
                        rekviziti.Add(rekvizit);
                    }

                    string stringCiljeva = row["Ciljevi"] as string;
                    String[] split1 = stringCiljeva.Split(",");
                    ObservableCollection<TipCiljeviEnum> ciljevi = new ObservableCollection<TipCiljeviEnum>();

                    foreach (string s in split1)
                    {
                        TipCiljeviEnum rekvizit = (TipCiljeviEnum)Enum.Parse(typeof(TipCiljeviEnum), s as string);
                        ciljevi.Add(rekvizit);
                    }

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

                    var klijent = new Klijent
                    {
                        korisnikId = (int)row["KorisnikId"],
                        id = (int)row["Id"],
                        korisnik = user,
                        rekviziti = rekviziti,
                        visina = (int)row["Visina"],
                        tezina = (int)row["Tezina"],
                        bolesti = row["Bolesti"] as string,
                        ciljevi = ciljevi,
                        stanjeNaKartici = (int)row["StanjeNaKartici"],


                    };

                    if (klijent.korisnik.aktivan == true)
                    {
                        treneri.Add(klijent);
                    }
                }
            }

            return treneri;
        
    }

        int IKlijentRepository.DodajKlijenta(Klijent klijent)
        {

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                string rekviziti = "";

                foreach (TipRekvizitaEnum rekvizit in klijent.rekviziti)
                {
                    rekviziti += (int)rekvizit + ",";
                }

                rekviziti = rekviziti.Remove(rekviziti.Length-1);

                string ciljevi = "";

                foreach (TipCiljeviEnum cilj in klijent.ciljevi)
                {
                    ciljevi += (int)cilj+ ",";
                }

                ciljevi = ciljevi.Remove(ciljevi.Length - 1);

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.Klijent (KorisnikId, Visina, Tezina, Bolesti, Ciljevi, Rekviziti, StanjeNaKartici)
                    output inserted.Id
                    values (@KorisnikId, @Visina, @Tezina, @Bolesti, @Ciljevi, @Rekviziti, @StanjeNaKartici)";

                command.Parameters.Add(new SqlParameter("KorisnikId", klijent.korisnik.id));
                command.Parameters.Add(new SqlParameter("Visina", klijent.tezina));
                command.Parameters.Add(new SqlParameter("Tezina", klijent.visina));
                command.Parameters.Add(new SqlParameter("Bolesti", klijent.bolesti));
                
                command.Parameters.Add(new SqlParameter("Ciljevi", ciljevi));
                command.Parameters.Add(new SqlParameter("Rekviziti", rekviziti));
                command.Parameters.Add(new SqlParameter("StanjeNaKartici", klijent.stanjeNaKartici));

                return (int)command.ExecuteScalar();
            }
        }

        void IKlijentRepository.IzmeniKlijenta(int id,Klijent klijent)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                string rekviziti = "";

                foreach (TipRekvizitaEnum rekvizit in klijent.rekviziti)
                {
                    rekviziti += (int)rekvizit + ",";
                }

                rekviziti = rekviziti.Remove(rekviziti.Length - 1);

                string ciljevi = "";

                foreach (TipCiljeviEnum cilj in klijent.ciljevi)
                {
                    ciljevi += (int)cilj + ",";
                }

                ciljevi = ciljevi.Remove(ciljevi.Length - 1);

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Klijent set 
                        Visina = @Visina,
                        Tezina = @Tezina,
                        Bolesti = @Bolesti,
                        Ciljevi = @Ciljevi,
                        Rekviziti = @Rekviziti
                        
                        where Id=@id";
                        

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Visina", klijent.visina));
                command.Parameters.Add(new SqlParameter("Tezina", klijent.tezina));
                command.Parameters.Add(new SqlParameter("Bolesti", klijent.bolesti));
                command.Parameters.Add(new SqlParameter("Ciljevi", ciljevi));
                command.Parameters.Add(new SqlParameter("Rekviziti", rekviziti));


                command.ExecuteScalar();
            }
        }

        void IKlijentRepository.OcenjivanjeTrenera(Trener trener, int ocena)
        {
            throw new NotImplementedException();
        }

        void IKlijentRepository.OtkazivanjeTermina(Termin termin, Klijent klijent)
        {
            throw new NotImplementedException();
        }

        void IKlijentRepository.ZakazivanjeTermina(Termin termin, Klijent klijent)
        {
            throw new NotImplementedException();
        }
        Boolean vratiNull(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.klijent t where t.id = {id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Klijent");

                foreach (DataRow row in ds.Tables["Klijent"].Rows)
                {
                    string obj = row["Treneri"] as string;

                    string string1 = "";

                    if (obj is null)
                    {
                        string1 = "null";
                    }
                    

                    if (string1 == "null")
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

        public List<int> VratiListuIdTrenera(Klijent klijent)
        {
            List<int> treneri = new List<int>();

            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.Klijent p  where p.Id={klijent.id}";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "Klijent");
                foreach (DataRow row in ds.Tables["Klijent"].Rows)
                {
                    string ids = row["Treneri"] as string;

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
    }
}
