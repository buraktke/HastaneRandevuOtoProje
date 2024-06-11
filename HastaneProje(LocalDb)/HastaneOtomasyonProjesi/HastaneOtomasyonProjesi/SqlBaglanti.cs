using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyonProjesi
{
    internal class SqlBaglanti
    {

        private SqlBaglanti()
        {

        }

        private static SqlBaglanti YeniSinif;

        public static SqlBaglanti SinifiGetir()
        {
            if (YeniSinif == null)
            {
                YeniSinif = new SqlBaglanti();
            }
            return YeniSinif;
        }

        public SqlConnection baglanti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
