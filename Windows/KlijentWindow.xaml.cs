using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for KlijentWindow.xaml
    /// </summary>
    public partial class KlijentWindow : Window
    {
        private Korisnik korisnik;
        private ITrenerService trenerService = new TrenerService();
        private ITerminService terminService = new TerminService();
        private IKlijentService klijentService = new KlijentService();
        public Klijent klijent;

        public KlijentWindow(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.klijent = klijentService.vratiKlijent(korisnik);
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void miSviTreneri_Click(object sender, RoutedEventArgs e)
        {
            List<Trener> sviTreneri = trenerService.VratiSveAktivneTrenere();
            List<Trener> verifikovaniTreneri = new List<Trener>();
            foreach(Trener tr in sviTreneri)
            {
                if (tr.verifikovan)
                {
                    verifikovaniTreneri.Add(tr);
                }
            }
            myDataGrid.ItemsSource = verifikovaniTreneri;
        }

        private void miTreneroviTermini_Click(object sender, RoutedEventArgs e)
        {
            var trener = myDataGrid.SelectedItem as Trener;

            if (trener != null && trener is Trener)
            {
                List<Termin> sviTermini = terminService.VratiSveTreneroveTermine(trener);
                List<Termin> neRezervisaniTermini = new List<Termin>();
                foreach(Termin ter in sviTermini)
                {
                    if (!ter.rezervisan)
                    {
                        neRezervisaniTermini.Add(ter);
                    }
                }
                myDataGrid.ItemsSource = neRezervisaniTermini;
            } 
            
        }

        private void miRezervisiTermin_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = myDataGrid.SelectedItem as Termin;
           
            if(selectedItem != null && selectedItem is Termin)
            {
                if (!selectedItem.rezervisan && klijent.stanjeNaKartici > selectedItem.cena)
                {
                    terminService.NaplatiTermin(klijent, selectedItem.trener, selectedItem);
                    terminService.RezervisanjeTermina(selectedItem, klijent);

                    myDataGrid.ItemsSource = terminService.VratiSveKlijentoveRezervisaneTermine(klijent);
                }
                else if(selectedItem.rezervisan)
                {
                    DateTime dateTime = DateTime.Now;
                    if(!(selectedItem.datum.AddHours(-2) < dateTime))
                    {
                        terminService.VratiPare(klijent, selectedItem.trener, selectedItem);
                    }

                    terminService.OtkaziTermin(selectedItem, klijent);

                    myDataGrid.ItemsSource = terminService.VratiSveKlijentoveRezervisaneTermine(klijent);
                }
            } 
        }

        private void miMojiTermini_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = terminService.VratiSveKlijentoveRezervisaneTermine(klijent);
        }

        private void miUplatiNovac_Click(object sender, RoutedEventArgs e)
        {
            UplataNaKarticuWindow uNKW = new UplataNaKarticuWindow(this.klijent);

            var succesful = uNKW.ShowDialog();

            if ((bool)succesful)
            {
                this.klijent = klijentService.vratiKlijent(this.klijent.korisnik);
            }
        }

        private void miOceniTrenera_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = myDataGrid.SelectedItem as Trener;

            if (selectedItem != null && selectedItem is Trener)
            {
                OceniWindow oW = new OceniWindow(selectedItem.korisnik);
                oW.Show();
            }
        }

        private void miTreningUzivo_Click(object sender, RoutedEventArgs e)
        {
            TreningUzivoWindow tuw = new TreningUzivoWindow(klijent);
            tuw.Show();
        }

        private void miMojiTreneri_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Trener> treneri = klijentService.VratiTrenereSaKojimaJeKlijentRadio(klijent);
            myDataGrid.ItemsSource = treneri;
        }

        private void miMojiPodaci_Click(object sender, RoutedEventArgs e)
        {
            AddEditKlijent aek = new AddEditKlijent(klijent);

            var succesful = aek.ShowDialog();

            if ((bool)succesful)
            {
                KlijentWindow kw = new KlijentWindow(klijent.korisnik);
                kw.Show();
                this.Close();
            }
        }
    }
}
