using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class GeneroPelicula
    {
        public int IdGeneroPelicula { get; set; }
        public string ValorGeneroPelicula { get; set; }

        public GeneroPelicula()
        {
            IdGeneroPelicula = 0;
            ValorGeneroPelicula = String.Empty;
        }

        public GeneroPelicula(int idGeneroPelicula, string valorGeneroPelicula)
        {
            this.IdGeneroPelicula = idGeneroPelicula;
            this.ValorGeneroPelicula = valorGeneroPelicula;
        }
    }
}
