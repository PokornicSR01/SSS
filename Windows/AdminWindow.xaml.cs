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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private ITrenerService trenerRepository = new TrenerService();
        private ITerminService terminRepository = new TerminService();
        private IKlijentService klijentRepository = new KlijentService();
        private IAdminService adminRepository = new AdminService();
        private KorisnikService korisnikService = new KorisnikService();
        private Korisnik korisnik;
        public AdminWindow(Korisnik korisnik)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            trenerMenu.Visibility = Visibility.Hidden;

        }
        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }
        private void miTreneri_Click(object sender, RoutedEventArgs e)
        {
            trenerMenu.Visibility = Visibility.Visible;
            miAddTrener.Visibility = Visibility.Visible;
            miUpdateTrener.Visibility = Visibility.Visible;
            miDeleteTrener.Visibility = Visibility.Visible;
            miVerifikujProfesora.Visibility = Visibility.Visible;
            miAddKlijent.Visibility = Visibility.Collapsed;
            miDeleteKlijent.Visibility = Visibility.Collapsed;
            miUpdateKlijent.Visibility = Visibility.Collapsed;
            myDataGrid.ItemsSource = trenerRepository.VratiSveAktivneTrenere();
        }
        private void miKlijenti_Click(object sender, RoutedEventArgs e)
        {

            trenerMenu.Visibility = Visibility.Visible;
            miAddKlijent.Visibility = Visibility.Visible;
            miDeleteKlijent.Visibility = Visibility.Visible;
            miUpdateKlijent.Visibility = Visibility.Visible;
            miAddTrener.Visibility = Visibility.Collapsed;
            miUpdateTrener.Visibility = Visibility.Collapsed;
            miDeleteTrener.Visibility = Visibility.Collapsed;
            miVerifikujProfesora.Visibility = Visibility.Collapsed;
            
            myDataGrid.ItemsSource = klijentRepository.VratiSveAktivneKlijente();
        }
        private void miVerifikujProfesora_Click(object sender, RoutedEventArgs e)
        {
            if(myDataGrid.SelectedItem is Trener && myDataGrid.SelectedItem != null)
            {
                Trener izabranTrener = myDataGrid.SelectedItem as Trener;
                if (!izabranTrener.verifikovan)
                {

                    adminRepository.AktivirajTrenera(izabranTrener);
                }
                else if (izabranTrener.verifikovan)
                {
                    adminRepository.UkiniVerifikacijuTrenera(izabranTrener);
                }
                myDataGrid.ItemsSource = trenerRepository.VratiSveAktivneTrenere();
            };
        }
        private void miAddTrener_Click(object sender, RoutedEventArgs e)
        {
            var addProfessorWindow = new AddEditTrener();

            var successeful = addProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {
                myDataGrid.ItemsSource = trenerRepository.VratiSveAktivneTrenere();
            }
        }
        private void miUpdateTrener_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = myDataGrid.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = trenerRepository.VratiSveAktivneTrenere();

                var addEditProfessorWindow = new AddEditTrener(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    myDataGrid.ItemsSource = trenerRepository.VratiSveAktivneTrenere();
                }
            }
        }
        private void miDeleteTrener_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as Trener;

            if (selectedUser != null)
            {
                korisnikService.ObrisiKorisnika(selectedUser.korisnik.id);
                myDataGrid.ItemsSource = trenerRepository.VratiSveAktivneTrenere();
            }
        }
        private void miAddKlijent_Click(object sender, RoutedEventArgs e)
        {
            var addProfessorWindow = new AddEditKlijent();

            var successeful = addProfessorWindow.ShowDialog();

            if ((bool)successeful)
            {
                myDataGrid.ItemsSource = klijentRepository.VratiSveAktivneKlijente();
            }
        }
        private void miUpdateKlijent_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = myDataGrid.SelectedIndex;

            if (selectedIndex >= 0)
            {
                var professors = klijentRepository.VratiSveAktivneKlijente();

                var addEditProfessorWindow = new AddEditKlijent(professors[selectedIndex]);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    myDataGrid.ItemsSource = klijentRepository.VratiSveAktivneKlijente();
                }
            }
        }
        private void miDeleteKlijent_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as Klijent;

            if (selectedUser != null)
            {
                korisnikService.ObrisiKorisnika(selectedUser.korisnik.id);
                myDataGrid.ItemsSource = klijentRepository.VratiSveAktivneKlijente();
            }
        }
        private void miTermini_Click(object sender, RoutedEventArgs e)
        {
            trenerMenu.Visibility = Visibility.Collapsed;
            miAddKlijent.Visibility = Visibility.Collapsed;
            miDeleteKlijent.Visibility = Visibility.Collapsed;
            miUpdateKlijent.Visibility = Visibility.Collapsed;
            miAddTrener.Visibility = Visibility.Collapsed;
            miUpdateTrener.Visibility = Visibility.Collapsed;
            miDeleteTrener.Visibility = Visibility.Collapsed;
            miVerifikujProfesora.Visibility = Visibility.Collapsed;

            myDataGrid.ItemsSource = terminRepository.VratiSveAktivneTermine();
        }
    }
}
