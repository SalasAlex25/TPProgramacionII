using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Genero
    {
        private string nombreGenero;
        private int idGenero;
        
        public Genero()
        {
            nombreGenero = String.Empty;
            IdGenero = 0;
        }

        public Genero(string nombreGenero, int idGenero)
        {
            this.nombreGenero = nombreGenero;
            this.IdGenero = idGenero;
        }

        public string NombreGenero
        {
            get { return nombreGenero; }
            set { nombreGenero = value; }
        }

        public int IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }
    }
}
