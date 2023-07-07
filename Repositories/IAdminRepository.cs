using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Repositories
{
    interface IAdminRepository
    {
        void AktivacijaTrenera(Trener trener);
        void UkiniVerifikacijuTrenera(Trener trener);
        ObservableCollection<Trener> vratiAktivneSveTrenere();
    }
}
