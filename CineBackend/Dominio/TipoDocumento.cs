using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string ValorTipoDocumento { get; set; }

        public TipoDocumento()
        {
            IdTipoDocumento = 0;
            ValorTipoDocumento = String.Empty;
        }

        public TipoDocumento(int idTipoDocumento, string tipoDocumento)
        {
            this.IdTipoDocumento = idTipoDocumento;
            this.ValorTipoDocumento = tipoDocumento;
        }
    }
}
