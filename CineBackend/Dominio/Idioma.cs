using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Idioma
    {
        public int IdIdioma { get; set; }
        public string ValorIdioma { get; set; }

        public Idioma()
        {
            IdIdioma = 0;
            ValorIdioma = String.Empty;
        }

        public Idioma(int idIdioma, string valorIdioma)
        {
            this.IdIdioma = idIdioma;
            this.ValorIdioma = valorIdioma;
        }
    }
}
