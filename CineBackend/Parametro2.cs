using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend
{
    public class Parametro2
    {
        public string Clave { get; set; }
        public object Valor { get; set; }
        public string Tipo { get; set; }

        public Parametro2()
        {
            Clave = String.Empty;
            Valor = "";
            Tipo = "System.String";
        }

        public Parametro2(string clave, object valor, string tipo)
        {
            Clave = clave;
            Valor = valor;
            Tipo = tipo;
        }
    }
}
