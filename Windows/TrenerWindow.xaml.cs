using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
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
    /// Interaction logic for TrenerWindow.xaml
    /// </summary>
    public partial class TrenerWindow : Window
    {
        private Korisnik korisnik;
        private Trener trener;
        private ITrenerService trenerService = new TrenerService();
        private ITerminService terminService = new TerminService();

        public TrenerWindow(Korisnik korisnik)
        {
            InitializeComponent();

            this.trener = trenerService.VratiTreneraPoId(korisnik);

            this.korisnik = korisnik;
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void miDodajTermin_Click(object sender, RoutedEventArgs e)
        {
            var addEditTerminWindow = new AddEditWindow(trener);

            var successeful = addEditTerminWindow.ShowDialog();

            if ((bool)successeful)
            {
                myDataGrid.ItemsSource = terminService.VratiSveTreneroveTermine(trener);
            }
        }

        private void miObrisiTermin_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = myDataGrid.SelectedItem as Termin;

            if (selectedUser != null && !selectedUser.rezervisan)
            {
                terminService.ObrisiTermin(selectedUser.id);
                myDataGrid.ItemsSource = terminService.VratiSveTreneroveTermine(trener);
            }
        }

        private void miTermini_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.ItemsSource = terminService.VratiSveTreneroveTermine(trener);
        }

        private void miIzmeniTermin_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = myDataGrid.SelectedItem as Termin;

            if (selectedItem != null && selectedItem is Termin && !selectedItem.rezervisan)
            {
                var addEditProfessorWindow = new AddEditWindow(selectedItem);

                var successeful = addEditProfessorWindow.ShowDialog();

                if ((bool)successeful)
                {
                    myDataGrid.ItemsSource = terminService.VratiSveTreneroveTermine(trener);
                }
            }
        }

        private void miOsmisliTrening_Click(object sender, RoutedEventArgs e)
        {
            
            
            var termin = myDataGrid.SelectedItem as Termin;

            if (termin is not null && termin.aktivan && termin.rezervisan && termin is Termin)
            {


                var osmisliTreningWindow = new OsmisliTrening(termin);

                var successeful = osmisliTreningWindow.ShowDialog();

                if ((bool)successeful)
                {
                    myDataGrid.ItemsSource = terminService.VratiSveTreneroveTermine(trener);
                }
            }
        }

        private void miTreningUzivo_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = myDataGrid.SelectedItem as Termin;

            if(selectedItem!= null && selectedItem is Termin && selectedItem.rezervisan && selectedItem.opisTermina != null)
            {
                TreningUzivoWindow tuw = new TreningUzivoWindow(selectedItem);
                
                var succesfull = tuw.ShowDialog();

                if((bool)succesfull)
                {
                    myDataGrid.ItemsSource = terminService.VratiSveTreneroveTermine(trener);
                }
            }
        }

        private void miMojiKlijenti_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Klijent> klijti = trenerService.VratiKlijentSaKojimaJeTrenerRadio(trener);
            myDataGrid.ItemsSource = klijti;
        }

        private void miOceniKlijenta_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = myDataGrid.SelectedItem as Klijent;

            if (selectedItem != null && selectedItem is Klijent)
            {
                OceniWindow tuw = new OceniWindow(selectedItem.korisnik);
                tuw.Show();
            }
        }
    }
}
