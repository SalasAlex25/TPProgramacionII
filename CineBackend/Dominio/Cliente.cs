using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Cliente
    {
            private int idCliente;
            private string apellido;
            private string nombre;
            private TipoCliente tipoCliente;
            private DateTime fecha_nac;
            private TipoDocumento tipoDocumento;
            private string documento;
            private Calle calle;
            private int altura;
            private Genero genero;
            private string baja;
            public Cliente()
            {
                idCliente = 0;
                apellido = String.Empty;
                nombre = String.Empty;
                tipoCliente = null;
                fecha_nac = DateTime.Now;
                tipoDocumento = null;
                documento = String.Empty;
                calle = null;
                altura = 0;
                genero = null;
                baja = "N";
            }

            public Cliente(int idCliente, string apellido, string nombre, TipoCliente tipoCliente, DateTime fecha_nac,
                           TipoDocumento tipo_documento, string documento, Calle calle, int altura, Genero genero)
            {
                this.idCliente = idCliente;
                this.apellido = apellido;
                this.nombre = nombre;
                this.tipoCliente = tipoCliente;
                this.fecha_nac = fecha_nac;
                this.tipoDocumento = tipo_documento;
                this.documento = documento;
                this.calle = calle;
                this.altura = altura;
                this.genero = genero;
                this.baja = "N";
            }

            public int IdCliente
            {
                get { return idCliente; }
                set { idCliente = value; }
            }
            public string Apellido
            {
                get { return apellido; }
                set { apellido = value; }
            }
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public DateTime FechaNac
            {
                get { return fecha_nac; }
                set { fecha_nac = value; }
            }

            public TipoDocumento TipoDocumento
            {
                get { return tipoDocumento; }
                set { tipoDocumento = value; }
            }

            public string Documento
            {
                get { return documento; }
                set { documento = value; }
            }

            public Calle Calle
            {
                get { return calle; }
                set { calle = value; }
            }

            public int Altura
            {
                get { return altura; }
                set { altura = value; }
            }

            public Genero Genero
            {
                get { return genero; }
                set { genero = value; }
            }

            public TipoCliente TipoCliente
            {
                get { return tipoCliente; }
                set { tipoCliente = value; }
            }
            public string Baja
            {
                get { return baja; }
                set { baja = value; }
            }
    }
}
