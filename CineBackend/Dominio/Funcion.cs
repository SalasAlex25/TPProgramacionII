using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Funcion
    {
        public int IdFuncion { get; set; }
        public Pelicula Pelicula { get; set; }
        public Sala Sala { get; set; }
        public DateTime Fecha { get; set; }
        public double Precio { get; set; }

        public Funcion()
        {
            IdFuncion = 0;
            Pelicula = null;
            Sala = null;
            Fecha = DateTime.Now;
            Precio = 0;
        }

        public Funcion(int idFuncion, Pelicula pelicula, Sala sala, DateTime dia, double precio)
        {
            this.IdFuncion = idFuncion;
            this.Pelicula = pelicula;
            this.Sala = sala;
            this.Fecha = dia;
            this.Precio = precio;
        }

    }
}
