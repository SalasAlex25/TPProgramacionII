using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class TipoCliente
    {
        public int IdTipoCliente { get; set; }
        public string ValorTipoCliente { get; set; }

        public TipoCliente()
        {
            IdTipoCliente = 0;
            ValorTipoCliente = String.Empty;
        }

        public TipoCliente(int idGenero, string valorGenero)
        {
            this.IdTipoCliente = idGenero;
            this.ValorTipoCliente = valorGenero;
        }
    }
}
