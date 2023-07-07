using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    internal interface IAdminService
    {
        public void AktivirajTrenera(Trener trener);
        public void UkiniVerifikacijuTrenera(Trener trener);
    }
}
