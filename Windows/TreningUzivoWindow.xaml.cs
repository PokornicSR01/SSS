using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SSS_Projekat_Miju.Windows
{
    /// <summary>
    /// Interaction logic for TreningUzivoWindow.xaml
    /// </summary>
    public partial class TreningUzivoWindow : Window
    {
        Termin termin;
        ITerminService terminService = new TerminService();
        public TreningUzivoWindow(Termin termin)
        {
            InitializeComponent();
            this.termin = termin;
        }

        public TreningUzivoWindow(Klijent klijent)
        {
            InitializeComponent();
            button.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            terminService.ZavrsiTrening(termin);
            DialogResult = true;
            this.Close();
        }
    }
}
