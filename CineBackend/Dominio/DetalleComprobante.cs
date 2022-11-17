using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Dominio
{
    public class DetalleComprobante
    {
        //Butaca Funcion
        public float PrecioHistorico { get; set; }
        public int Cantidad { get; set; }
        public DetalleComprobante(/*Butaca Funcion,*/ float precioHistorico, int cant)
        {
            //ButacaFuncion = p;
            PrecioHistorico = precioHistorico;
            Cantidad = cant;
        }
        public DetalleComprobante()
        {

        }
        public float CalcularSubTotal()
        {
            return PrecioHistorico * Cantidad;
        }
    }
}
