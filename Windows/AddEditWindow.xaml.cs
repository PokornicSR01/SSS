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
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        private ITerminService terminService = new TerminService();
        private Termin termin;
        private Trener trener;
        private Boolean isAddMode;
        public AddEditWindow(Termin termin)
        {
            InitializeComponent();

            this.termin = termin.Clone() as Termin;

            DataContext = this.termin;

            isAddMode = false;
        }

        public AddEditWindow(Trener trener)
        {
            InitializeComponent();

            InitializeComponent();

            this.trener = trener;

            termin = new Termin
            {
                aktivan = true,
                rezervisan = false,
                klijent = null,
                zavrsen = false,
            };

            isAddMode = true;
            DataContext = termin;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (isAddMode)
            {
                string datum = txtDatum.Text;
                termin.datum = Convert.ToDateTime(datum);
                DateTime dateTime = DateTime.Now.AddDays(30);
                if(termin.datum > DateTime.Now && termin.datum < dateTime)
                {
                    terminService.DodajTermin(termin, trener);
                }
            }
            else
            {
                string datum = txtDatum.Text;
                termin.datum = Convert.ToDateTime(datum);
                terminService.IzmeniTermin(termin.id,termin);
            }

            DialogResult = true;
            this.Close();
        }

        private void btnPonisti_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
