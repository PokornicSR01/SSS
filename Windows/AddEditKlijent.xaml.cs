using SSS_Projekat_Miju.Enums;
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
    /// Interaction logic for AddEditKlijent.xaml
    /// </summary>
    public partial class AddEditKlijent : Window
    {
        private IKlijentService klijentService = new KlijentService();
        private Klijent klijent;
        private bool isAddMode;
        private bool isReg;

        public AddEditKlijent(Klijent klijent)
        {
            InitializeComponent();
            CenterWindowOnScreen();

            txtRekviziti.ItemsSource = Enum.GetValues(typeof(TipRekvizitaEnum));
            txtCiljevi.ItemsSource = Enum.GetValues(typeof(TipCiljeviEnum));
            

            this.klijent = klijent.Clone() as Klijent;


            foreach (TipRekvizitaEnum a in klijent.rekviziti)
            {
                txtRekviziti.SelectedItems.Add(a);
            }

            foreach(TipCiljeviEnum cilj in klijent.ciljevi)
            {
                txtCiljevi.SelectedItems.Add(cilj);
            }

            DataContext = this.klijent;


            isAddMode = false;
        }

        public AddEditKlijent()
        {
            InitializeComponent();
            CenterWindowOnScreen();

            txtRekviziti.ItemsSource = Enum.GetValues(typeof(TipRekvizitaEnum));
            txtCiljevi.ItemsSource = Enum.GetValues(typeof(TipCiljeviEnum));

            btnPonisti.Visibility= Visibility.Collapsed;

            var korisnik1 = new Korisnik
            {
                tipKorisnika = Enums.TipKorisnikaEnum.KLIJENT,
                aktivan = true,
            };

            klijent = new Klijent
            {
                korisnik = korisnik1,
            };

            isAddMode = true;
            DataContext = klijent;
        }
        public AddEditKlijent(bool reg)
        {
            InitializeComponent();
            CenterWindowOnScreen();

            txtRekviziti.ItemsSource = Enum.GetValues(typeof(TipRekvizitaEnum));
            txtCiljevi.ItemsSource = Enum.GetValues(typeof(TipCiljeviEnum));

            btnPonisti2.Visibility = Visibility.Collapsed;


            isReg = true;

            var korisnik1 = new Korisnik
            {
                tipKorisnika = Enums.TipKorisnikaEnum.KLIJENT,
                aktivan = true,
            };

            klijent = new Klijent
            {
                korisnik = korisnik1,
            };

            isAddMode = true;
            DataContext = klijent;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                klijent.rekviziti = vratiSelektovaneRekvizite();
                klijent.ciljevi = vratiSelektovaneCiljeve();
                klijentService.DodajKlijenta(klijent);
            }
            else
            {
                klijent.rekviziti = vratiSelektovaneRekvizite();
                klijent.ciljevi = vratiSelektovaneCiljeve();
                klijentService.IzmeniKlijenta(klijent.id, klijent);

            }

            
            if (isReg)
            {
                MainWindow mW = new MainWindow();
                mW.Show();

            }
            DialogResult = true;
            Close();
        }

        private void btnPonisti_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lW = new LoginWindow();
            lW.Show();
            this.Close();
        }

        private ObservableCollection<TipRekvizitaEnum> vratiSelektovaneRekvizite()
        {
            ObservableCollection<TipRekvizitaEnum> rekviziti = new ObservableCollection<TipRekvizitaEnum>();
            foreach(TipRekvizitaEnum rekvizit in txtRekviziti.SelectedItems)
            {
                rekviziti.Add(rekvizit);
            }
            return rekviziti;
        }

        private ObservableCollection<TipCiljeviEnum> vratiSelektovaneCiljeve()
        {
            ObservableCollection<TipCiljeviEnum> ciljevi = new ObservableCollection<TipCiljeviEnum>();
            foreach (TipCiljeviEnum cilj in txtCiljevi.SelectedItems)
            {
                ciljevi.Add(cilj);
            }
            return ciljevi;
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void btnPonisti2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
