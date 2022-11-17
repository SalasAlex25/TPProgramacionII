using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class ButacaFuncion
    {
        public int IdButacaFuncion { get; set; }
        public Butaca Butaca { get; set; }
        public Funcion Funcion { get; set; }
        public Reserva Reserva { get; set; }
    }
}
