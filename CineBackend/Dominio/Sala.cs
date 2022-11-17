using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Sala
    {
        public int IdSala { get; set; }
        public int Capacidad { get; set; }
        public TipoSala TipoSala { get; set; }

        public Sala()
        {
            IdSala = 0;
            Capacidad = 0;
            TipoSala = null;
        }
    }
}
