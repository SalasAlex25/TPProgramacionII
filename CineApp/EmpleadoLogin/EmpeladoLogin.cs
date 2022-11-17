using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineBackend.Datos;

namespace CineApp.EmpleadoLogin
{
    internal class EmpeladoLogin
    {
        DaoLogin daoLogin = new DaoLogin();
        public bool empleadologin(string usuario,string contraseña)
        {
            return daoLogin.Login(usuario, contraseña);
        }
    }
}
