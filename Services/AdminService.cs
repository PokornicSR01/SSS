using SSS_Projekat_Miju.Modules;
using SSS_Projekat_Miju.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSS_Projekat_Miju.Services
{
    internal class AdminService : IAdminService
    {
        public IAdminRepository adminRepository;
        public AdminService() 
        {
            adminRepository = new AdminRepository();
        }

        public void AktivirajTrenera(Trener trener)
        {
            adminRepository.AktivacijaTrenera(trener);
        }

        public void UkiniVerifikacijuTrenera(Trener trener)
        {
            adminRepository.UkiniVerifikacijuTrenera(trener);
        }
    }
}
