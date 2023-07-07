using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
using SSS_Projekat_Miju.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for VlasnikWindow.xaml
    /// </summary>
    public partial class VlasnikWindow : Window
    {
        private Korisnik korisnik;
        ITrenerRepository trenerRepository = new TrenerRepository();
        public VlasnikWindow(Korisnik korisnik)
        {
            InitializeComponent();

            this.korisnik = korisnik;
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void miTreneriRangiraniPoZaradi_Click(object sender, RoutedEventArgs e)
        {

            List<Trener> treneriLissta = trenerRepository.NajboljeRangiraniTreneri();

            ObservableCollection<Trener> treneri = new ObservableCollection<Trener>(treneriLissta);


            ICollectionView view = CollectionViewSource.GetDefaultView(treneri);
            view.SortDescriptions.Add(new SortDescription("ukupnaZarada", ListSortDirection.Descending));

            myDataGrid.ItemsSource = view;


        }

        private void miTreneriRangiraniPoOcenama_Click(object sender, RoutedEventArgs e)
        {
            double plata = vratiProsecnuPlatu();

            List<Trener> treneriLissta = trenerRepository.VratiSveAktivneTrenere();
            ObservableCollection<Trener> treneri = new ObservableCollection<Trener>(treneriLissta);
            ObservableCollection<Trener> nadprosecniTreneri = new ObservableCollection<Trener>();

            foreach (Trener tr in treneri)
            {
                if (tr.ukupnaZarada > plata)
                {
                    nadprosecniTreneri.Add(tr);
                }
            }

            ICollectionView view = CollectionViewSource.GetDefaultView(nadprosecniTreneri);
            view.SortDescriptions.Add(new SortDescription("ukupnaZarada", ListSortDirection.Descending));

            myDataGrid.ItemsSource = view;

        }

        private double vratiProsecnuPlatu()
        {
            double ukupnaZarada = 0;

            List<Trener> sviTreneri = trenerRepository.VratiSveAktivneTrenere();
            List<Trener> verifikovaniTreneri = new List<Trener>();
            foreach (Trener tr in sviTreneri)
            {
                if (tr.verifikovan)
                {
                    ukupnaZarada += tr.ukupnaZarada;
                    verifikovaniTreneri.Add(tr);
                }
            }

            return ukupnaZarada / sviTreneri.Count();
        }
    }
}
