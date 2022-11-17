using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineBackend.Datos;
using CineBackend.Dominio;

namespace CineBackend.Servicio
{
    public class Service : IServicio
    {
        //PABLO
        private IDao ayudante;

        public Service()
        {
            ayudante = new HelperDB();
        }

        public DataTable ConsultaClientes()
        {
            return ayudante.ConsultaClientes();
        }

        public DataTable ConsultaDatos(int codigo)
        {
            return ayudante.ConsultaDatos(codigo);
        }

        //public DataTable Consulta_Comprobantes(int cliente)
        //{
        //    return ayudante.Consulta_Comprobantes(cliente);
        //}

        public List<Comprobante> Consulta_Comprobantes(List<Parametro> values/*int cliente*/)
        {
            return ayudante.Consulta_Comprobantes(values/*cliente*/);
        }

        public DataTable Consulta_Comprobantes_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente)
        {
            return ayudante.Consulta_Comprobantes_Con_Filtro(fecha1, fecha2, cliente);
        }

        //public List<Comprobante> Consulta_Comprobantes_Con_Filtro(List<Parametro> values/*DateTime fecha1, DateTime fecha2, int cliente*/)
        //{
        //    return ayudante.Consulta_Comprobantes_Con_Filtro(values/*fecha1, fecha2, cliente*/);
        //}
        public DataTable Consulta_Reporte()
        {
            return ayudante.Consulta_Reporte();
        }

        public decimal Consulta_Total(int cliente)
        {
            return ayudante.Consulta_Total(cliente);
        }

        public decimal Consulta_Total_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente)
        {
            return ayudante.Consulta_Total_Con_Filtro(fecha1, fecha2, cliente);
        }

        public DataTable Sorteo()
        {
            return ayudante.Sorteo();
        }

        public Cliente DevolverDatos(string documento)
        {
            return ayudante.DevolverDatos(documento);
        }
        public bool ModificarUsuario(Cliente usuario)
        {
            return ayudante.ModificarUsuario(usuario);
        }
        public bool EliminarUsuario(Cliente usuario)
        {
            return ayudante.EliminarUsuario(usuario);
        }
        public int IdUsuario(string documento, int tipoDocumento)
        {
            return ayudante.IdUsuario(documento, tipoDocumento);
        }

        //NACHO
        public List<TipoDocumento> CargarComboTiposDocumento()
        {
            return ayudante.CargarComboTiposDocumento();
        }
        public List<Genero> CargarComboGenero()
        {
            return ayudante.CargarComboGenero();
        }
        public List<TipoCliente> CargarComboTiposCliente()
        {
            return ayudante.CargarComboTiposCliente();
        }
        public List<Calle> CargarComboCalles()
        {
            return ayudante.CargarComboCalles();
        }
        public string NombreDeUsuario(string documento, int tipoDocumento)
        {
            return ayudante.NombreDeUsuario(documento,tipoDocumento);
        }
        public int UsuarioExistente(string documento, int tipoDocumento)
        {
            return ayudante.UsuarioExistente(documento,tipoDocumento);
        }
        public int ProximoIdUsuario()
        {
            return ayudante.ProximoIdUsuario();
        }
        public bool InsertarUsuario(Cliente usuario)
        {
            return ayudante.InsertarUsuario(usuario);
        }
        public Dictionary<int, Cliente> CargarClientes()
        {
            return ayudante.CargarClientes();
        }
        public List<Pelicula> CargarPeliculas()
        {
            return ayudante.CargarPeliculas();
        }
        public Dictionary<int, Funcion> CargarFunciones()
        {
            return ayudante.CargarFunciones();
        }
        public Dictionary<int, Sala> CargarSalas()
        {
            return ayudante.CargarSalas();
        }
        public Dictionary<int, Butaca> CargarButacas(Dictionary<int, Sala> dicSalas)
        {
            return ayudante.CargarButacas(dicSalas);
        }
        public Dictionary<int, ButacaFuncion> CargarButacasFunciones(Dictionary<int, Butaca> dicButacas,
                                                                     Dictionary<int, Funcion> dicFunciones,
                                                                     Dictionary<int, Cliente> dicClientes)
        {
            return ayudante.CargarButacasFunciones(dicButacas,dicFunciones,dicClientes);
        }
        public List<GeneroPelicula> CargarComboGenerosPelicula()
        {
            return ayudante.CargarComboGenerosPelicula();
        }
        public List<CalificacionEtaria> CargarComboCalificacionesEtarias()
        {
            return ayudante.CargarComboCalificacionesEtarias();
        }
        public List<Idioma> CargarComboIdiomas()
        {
            return ayudante.CargarComboIdiomas();
        }
        public int ComprarButacaFuncion(int idCliente, int idButaca, int idFuncion, float precio, bool reserva)
        {
            return ayudante.ComprarButacaFuncion(idCliente,idButaca,idFuncion,precio,reserva);
        }

        public Calle InformacionDeCalle(Calle calle)
        {
            return ayudante.InformacionDeCalle(calle);
        }
        public bool AgregarComprobante(List<Parametro2> parametrosTipados)
        {
            return ayudante.AgregarComprobante(parametrosTipados);
        }
    }
}
