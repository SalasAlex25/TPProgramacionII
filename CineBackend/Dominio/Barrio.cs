using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Barrio
    {
        private string nombreBarrio;
        private int idBarrio;
        private Localidad localidad;

        public Barrio()
        {
            nombreBarrio = String.Empty;
            idBarrio = 0;
            localidad = null;
        }

        public Barrio(string nombreBarrio, int idBarrio, Localidad localidad)
        {
            this.nombreBarrio = nombreBarrio;
            this.idBarrio = idBarrio;
            this.localidad = localidad;
        }

        public string NombreBarrio
        {
            get { return nombreBarrio; }
            set { nombreBarrio = value; }
        }

        public int IdBarrio {
            get { return idBarrio; }
            set { idBarrio = value; }
        }

        public Localidad Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }
    }
}
