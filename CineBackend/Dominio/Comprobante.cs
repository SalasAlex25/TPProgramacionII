using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class Comprobante
    {
        public int IdComprobante { get; set; }
        //public Empleado Empleado { get; set; }
        public int Empleado { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        //public Tipo_compra Tipo { get; set; }
        public int Tipo { get; set; }
        public double Descuento { get; set; }

        public List<DetalleComprobante> Detalles { get; set; }

        public Comprobante()
        {
            Detalles = new List<DetalleComprobante>();
        }

        public void AgregarDetalle(DetalleComprobante detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice)
        {
            Detalles.RemoveAt(indice);
        }
        public float CalcularTotal()
        {
            float total = 0;
            foreach (DetalleComprobante item in Detalles)
                total += item.CalcularSubTotal();
            return total;
        }
        public int CantidadTotal()
        {
            int total = 1;
            foreach (DetalleComprobante item in Detalles)
                total += 1;
            return total;
        }
    }
}
