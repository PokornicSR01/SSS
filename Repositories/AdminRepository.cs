using SSS_Projekat_Miju.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SSS_Projekat_Miju.Repositories
{
    class AdminRepository : IAdminRepository
    {
        public void UkiniVerifikacijuTrenera(Trener trener)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Trener set Verifikovan=0 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", trener.id));
                command.ExecuteNonQuery();
            }
        }

        void IAdminRepository.AktivacijaTrenera(Trener trener)
        {
            using (SqlConnection conn = new SqlConnection(Config.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = "update dbo.Trener set Verifikovan=1 where Id=@id";

                command.Parameters.Add(new SqlParameter("id", trener.id));
                command.ExecuteNonQuery();
            }
        }

        ObservableCollection<Trener> IAdminRepository.vratiAktivneSveTrenere()
        {
            throw new NotImplementedException();
        }
    }
}
