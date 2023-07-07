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
    /// Interaction logic for OsmisliTrening.xaml
    /// </summary>
    public partial class OsmisliTrening : Window
    {
        Termin termin;
        ITerminService terminService = new TerminService();
        public OsmisliTrening(Termin termin)
        {
            InitializeComponent();
            this.termin = termin.Clone() as Termin;
            txtRekviziti.ItemsSource = Enum.GetValues(typeof(TipRekvizitaEnum));
            txtCiljevi.ItemsSource = Enum.GetValues(typeof(TipCiljeviEnum));


            foreach (TipRekvizitaEnum a in termin.klijent.rekviziti)
            {
                txtRekviziti.SelectedItems.Add(a);
            }

            foreach (TipCiljeviEnum cilj in termin.klijent.ciljevi)
            {
                txtCiljevi.SelectedItems.Add(cilj);
            }
            DataContext = this.termin;

        }

        private void btnPonisti_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if(txtOsmisliTrening.Text != "")
            {
                terminService.OsmisliTermin(termin);
            }
            DialogResult = true;
        }
    }
}
