using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
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
    /// Interaction logic for OceniWindow.xaml
    /// </summary>
    public partial class OceniWindow : Window
    {
        Korisnik korisnik;
        IKorisnikService korisnikService = new KorisnikService();
        public OceniWindow(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
        }

        private void btnPonisti_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(txtKomentar.Text != "" && txtUplata.Text != "")
            {
                korisnik.brojOcena += 1;
                korisnik.zbirOcena += Int32.Parse(txtUplata.Text);
                korisnikService.IzmeniKorisnika(korisnik.id,korisnik);
                this.Close();
            }
        }
    }
}
