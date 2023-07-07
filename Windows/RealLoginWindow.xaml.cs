using SSS_Projekat_Miju.Enums;
using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SSS_Projekat_Miju.Windows
{
    /// <summary>
    /// Interaction logic for RealLoginWindow.xaml
    /// </summary>
    public partial class RealLoginWindow : Window
    {
        IKorisnikService korisnikService = new KorisnikService();
        public RealLoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Korisnik registrovaniKorisnik = korisnikService.Login(txtEmail.Text, txtLozinka.Password.ToString());

            if (registrovaniKorisnik != null)
            {
                if (registrovaniKorisnik.tipKorisnika.Equals(TipKorisnikaEnum.VLASNIK))
                {
                    VlasnikWindow window = new VlasnikWindow(registrovaniKorisnik);
                    window.Show();
                    this.Close();
                }
                else if (registrovaniKorisnik.tipKorisnika.Equals(TipKorisnikaEnum.ADMIN))
                {
                    AdminWindow mw = new AdminWindow(registrovaniKorisnik);
                    mw.Show();
                    this.Close();
                }
                else if (registrovaniKorisnik.tipKorisnika.Equals(TipKorisnikaEnum.TRENER))
                {
                    TrenerWindow mw = new TrenerWindow(registrovaniKorisnik);
                    mw.Show();
                    this.Close();
                }
                else if (registrovaniKorisnik.tipKorisnika.Equals(TipKorisnikaEnum.KLIJENT))
                {
                    KlijentWindow mw = new KlijentWindow(registrovaniKorisnik);
                    mw.Show();
                    this.Close();
                }
            }

        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }
    }
}
