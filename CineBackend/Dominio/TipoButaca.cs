using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class TipoButaca
    {
        public int IdTipoButaca { get; set; }
        public string ValorTipoButaca { get; set; }

        public TipoButaca()
        {
            IdTipoButaca = 0;
            ValorTipoButaca = String.Empty;
        }

        public TipoButaca(int idTipoButaca, string valorTipoButaca)
        {
            this.IdTipoButaca = IdTipoButaca;
            this.ValorTipoButaca = valorTipoButaca;
        }
    }
}
