using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CineBackend.Dominio
{
    public class CalificacionEtaria
    {
        public int IdCalificacionEtaria { get; set; }
        public string ValorCalificacionEtaria { get; set; }

        public CalificacionEtaria()
        {
            IdCalificacionEtaria = 0;
            ValorCalificacionEtaria = String.Empty;
        }

        public CalificacionEtaria(int idCaliEtaria, string valorCaliEtaria)
        {
            this.IdCalificacionEtaria = idCaliEtaria;
            this.ValorCalificacionEtaria = valorCaliEtaria;
        }
    }
}
