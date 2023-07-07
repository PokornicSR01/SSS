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
    /// Interaction logic for UplataNaKarticuWindow.xaml
    /// </summary>
    public partial class UplataNaKarticuWindow : Window
    {
        Klijent klijent;
        IKlijentService klijentService = new KlijentService();
        public UplataNaKarticuWindow(Klijent klijent)
        {
            InitializeComponent();
            this.klijent = klijent;
        }

        private void btnPonisti_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            klijentService.UplataNaKarticu(Int32.Parse(txtUplata.Text), klijent);

            DialogResult = true;
        }
    }
}
