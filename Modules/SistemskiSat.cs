using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Modules
{
    public class SistemskiSat
    {
        public ObservableCollection<Trener> treneri { get; set; }
        public SistemskiSat() { }
    }
}
