using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Localidad
    {
        private string nombreLocalidad;
        private int idLocalidad;
        private Provincia provincia;

        public Localidad()
        {
            nombreLocalidad = String.Empty;
            idLocalidad = 0;
            provincia = null;
        }

        public Localidad(string nombreLocalidad, int idLocalidad, Provincia provincia)
        {
            this.nombreLocalidad = nombreLocalidad;
            this.idLocalidad = idLocalidad;
            this.provincia = provincia;
        }

        public string NombreLocalidad
        {
            get { return nombreLocalidad; }
            set { nombreLocalidad = value; }
        }
        public int IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }
        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
    }
}
