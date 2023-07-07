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
    /// Interaction logic for AddEditTrener.xaml
    /// </summary>
    public partial class AddEditTrener : Window
    {
        private Trener trener;
        private ITrenerService trenerService = new TrenerService();
        private bool isAddMode;
        private bool isReg;

        public AddEditTrener(Trener trener)
        {
            InitializeComponent();

            this.trener = trener.Clone() as Trener;

            

            DataContext = this.trener;

            isAddMode = false;
        }

        public AddEditTrener()
        {
            InitializeComponent();

            var korisnik1 = new Korisnik
            {
                tipKorisnika = Enums.TipKorisnikaEnum.TRENER,
                aktivan = true,

            };

            trener = new Trener
            {
                korisnik = korisnik1,
                verifikovan = false
            };

            isAddMode = true;
            DataContext = trener;
        }

        public AddEditTrener(bool reg)
        {
            InitializeComponent();
            isReg = true;

            var korisnik1 = new Korisnik
            {
                tipKorisnika = Enums.TipKorisnikaEnum.TRENER,
                aktivan = true,

            };

            trener = new Trener
            {
                korisnik = korisnik1,
                verifikovan = false
            };

            isAddMode = true;
            DataContext = trener;
        }

        private void btnPonisti_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lW = new LoginWindow();
            lW.Show();
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                trenerService.DodajTrenera(trener);
            }
            else
            {
                trenerService.IzmeniTrenera(trener.id, trener);
            }
            if (isReg)
            {
                MainWindow mW = new MainWindow();
                mW.Show();

            }
            DialogResult = true;
            Close();
        }
    }
}
