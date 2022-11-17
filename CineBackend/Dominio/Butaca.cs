using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Butaca
    {
        public int IdButaca { get; set; }
        public int IdFila { get; set; }
        public int NroButaca { get; set; }
        public TipoButaca TipoButaca { get; set; }
        public Sala Sala { get; set; }


    }
}
