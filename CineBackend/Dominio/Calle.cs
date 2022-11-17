using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Calle
    {
        private string nombreCalle;
        private int idCalle;
        private Barrio barrio;

        public Calle()
        {
            nombreCalle = String.Empty;
            idCalle = 0;
            barrio = null;
        }

        public Calle(string nombreCalle, int idCalle, Barrio barrio)
        {
            this.nombreCalle = nombreCalle;
            this.idCalle = idCalle;
            this.barrio = barrio;
        }

        public string NombreCalle
        {
            get { return nombreCalle; }
            set { nombreCalle = value; }
        }

        public int IdCalle
        {
            get { return idCalle; }
            set { idCalle = value; }
        }
        
        public Barrio Barrio
        {
            get { return barrio; }
            set { barrio = value; }
        }
    }
}
