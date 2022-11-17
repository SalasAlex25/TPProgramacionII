using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Provincia
    {
        private string nombreProvincia;
        private int idProvincia;

        public Provincia()
        {
            nombreProvincia = String.Empty;
            idProvincia = 0;
        }

        public Provincia(string nombreProvincia, int idProvincia)
        {
            this.nombreProvincia = nombreProvincia;
            this.idProvincia = idProvincia;
        }

        public string NombreProvincia
        {
            get { return nombreProvincia; }
            set { nombreProvincia = value; }
        }
        public int IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
    }
}
