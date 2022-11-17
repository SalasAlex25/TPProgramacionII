using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CineBackend.Datos
{
     public class HelperLogin
    {
        private readonly string connectionstring;

        public HelperLogin()
        {
            connectionstring = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=COMPLEJO_CINE_v4;Integrated Security=True";
        }
        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionstring);
        }
    }
}
