using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class TipoSala
    {
        public int IdTipoSala { get; set; }
        public string Tipo { get; set; }

        public TipoSala()
        {
            IdTipoSala = 0;
            Tipo = String.Empty;
        }
    }
}
