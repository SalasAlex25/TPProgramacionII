using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public Cliente Ciente { get; set; }
        public DateTime FechaReserva { get; set; }

    }
}
