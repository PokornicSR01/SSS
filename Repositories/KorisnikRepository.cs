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
    class KorisnikRepository : IKorisnikRepository
    {
        
        int IKorisnikRepository.DodajKorisnika(Korisnik korisnik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"
                    insert into dbo.RegistrovaniKorisnici (Ime, Prezime, BrojTelefona, Lozinka, TipKorisnika, Aktivan, Adresa
                    ,Email, BrojKreditneKartice, MaternjiJezik, OstaliJezici, ZbirOcena, BrojOcena)
                    output inserted.Id
                    values (@Ime, @Prezime, @BrojTelefona, @Lozinka, @TipKorisnika, @Aktivan, @Adresa
                    ,@Email , @BrojKreditneKartice, @MaternjiJezik, @OstaliJezici, @ZbirOcena, @BrojOcena)";


                command.Parameters.Add(new SqlParameter("Email", korisnik.eMail));
                command.Parameters.Add(new SqlParameter("Lozinka", korisnik.lozinka));
                command.Parameters.Add(new SqlParameter("Ime", korisnik.ime));
                command.Parameters.Add(new SqlParameter("Prezime", korisnik.prezime));
                command.Parameters.Add(new SqlParameter("TipKorisnika", korisnik.tipKorisnika));
                command.Parameters.Add(new SqlParameter("Adresa", korisnik.adresa));
                command.Parameters.Add(new SqlParameter("Aktivan", korisnik.aktivan));
                command.Parameters.Add(new SqlParameter("BrojKreditneKartice", korisnik.brojKreditneKartice));
                command.Parameters.Add(new SqlParameter("BrojTelefona", korisnik.brojTelefona));
                command.Parameters.Add(new SqlParameter("MaternjiJezik", korisnik.maternjiJezik));
                command.Parameters.Add(new SqlParameter("OstaliJezici", korisnik.ostaliJezici));
                command.Parameters.Add(new SqlParameter("ZbirOcena", korisnik.zbirOcena));
                command.Parameters.Add(new SqlParameter("BrojOcena", korisnik.brojOcena));

                return (int)command.ExecuteScalar();
            }
        }

        void IKorisnikRepository.IzmeniKorisnika(int id, Korisnik korisnik)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.RegistrovaniKorisnici set 
                        Ime = @Ime,
                        Prezime = @Prezime,
                        BrojTelefona = @BrojTelefona,
                        Lozinka = @Lozinka,
                        Email = @Email,
                        Adresa = @Adresa,
                        BrojKreditneKartice = @BrojKreditneKartice,
                        MaternjiJezik = @MaternjiJezik,
                        OstaliJezici = @OstaliJezici,
                        ZbirOcena = @ZbirOcena,
                        BrojOcena = @BrojOcena

                        where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("Ime", korisnik.ime));
                command.Parameters.Add(new SqlParameter("Prezime", korisnik.prezime));
                command.Parameters.Add(new SqlParameter("Lozinka", korisnik.lozinka));
                command.Parameters.Add(new SqlParameter("BrojTelefona", korisnik.brojTelefona));
                command.Parameters.Add(new SqlParameter("Email", korisnik.eMail));
                command.Parameters.Add(new SqlParameter("Adresa", korisnik.adresa));
                command.Parameters.Add(new SqlParameter("BrojKreditneKartice", korisnik.brojKreditneKartice));
                command.Parameters.Add(new SqlParameter("ZbirOcena", korisnik.zbirOcena));
                command.Parameters.Add(new SqlParameter("BrojOcena", korisnik.brojOcena));
                command.Parameters.Add(new SqlParameter("OstaliJezici", korisnik.ostaliJezici));
                command.Parameters.Add(new SqlParameter("MaternjiJezik", korisnik.maternjiJezik));

                command.ExecuteScalar();
            }
        }

        Korisnik IKorisnikRepository.Login(string eMail, string lozinka)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                string commandText = $"select * from dbo.RegistrovaniKorisnici u where u.Email like '{eMail}' and u.Lozinka like'{lozinka}'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, conn);

                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, "RegistrovaniKorisnici");

                if (ds.Tables["RegistrovaniKorisnici"].Rows.Count > 0)
                {
                    var row = ds.Tables["RegistrovaniKorisnici"].Rows[0];

                    var user = new Korisnik
                    {
                        id = (int)row["Id"],
                        ime = row["Ime"] as string,
                        prezime = row["Prezime"] as string,
                        eMail = row["Email"] as string,
                        lozinka = row["Lozinka"] as string,
                        brojTelefona = row["BrojTelefona"] as string,
                        brojKreditneKartice = row["BrojKreditneKartice"] as string,
                        maternjiJezik = row["MaternjiJezik"] as string,
                        ostaliJezici = row["OstaliJezici"] as string,
                        zbirOcena = (int)row["ZbirOcena"] ,
                        brojOcena = (int)row["BrojOcena"] ,
                        tipKorisnika = (TipKorisnikaEnum)Enum.Parse(typeof(TipKorisnikaEnum), row["TipKorisnika"] as string),
                        aktivan = (bool)row["Aktivan"],
                        adresa = row["Adresa"] as string
                    };

                    if (user.aktivan)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        void IKorisnikRepository.ObrisiKorisnika(int id)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.RegistrovaniKorisnici set Aktivan=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", id));
                command.ExecuteNonQuery();
            }
        }
    }
}
