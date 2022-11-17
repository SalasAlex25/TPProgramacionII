using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CineBackend.Datos
{
    public class DaoLogin : HelperLogin
    {
        public bool Login(string usuario, string contraseña) { 
            using(var connetion = GetSqlConnection())
            {
                connetion.Open(); 
                using(var command=new SqlCommand())
                {
                    command.Connection = connetion;
                    command.CommandText = "SP_VALIDAR_INCIO_SESION";
                    command.Parameters.AddWithValue("@USUARIO", usuario);
                    command.Parameters.AddWithValue("@CONTRASEÑA", contraseña);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }else 
                        return false;
                }
            }
        }

    }
}
