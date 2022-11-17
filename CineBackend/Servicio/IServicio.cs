using CineBackend.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Servicio
{
    public interface IServicio
    {
        //PABLO
        public DataTable ConsultaClientes();
        public DataTable Consulta_Comprobantes_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente);
        //public List<Comprobante> Consulta_Comprobantes_Con_Filtro(List<Parametro> values/*DateTime fecha1, DateTime fecha2, int cliente*/);

        //public DataTable Consulta_Comprobantes(int cliente);
        public List<Comprobante> Consulta_Comprobantes(List<Parametro> values/*int cliente*/);
        public DataTable ConsultaDatos(int codigo);
        public decimal Consulta_Total_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente);
        public decimal Consulta_Total(int cliente);
        public DataTable Sorteo();
        public DataTable Consulta_Reporte();
        public Cliente DevolverDatos(string documento);
        public bool ModificarUsuario(Cliente usuario);
        public bool EliminarUsuario(Cliente usuario);
        public int IdUsuario(string documento, int tipoDocumento);

        //NACHO
        public List<TipoDocumento> CargarComboTiposDocumento();
        public List<Genero> CargarComboGenero();
        public List<TipoCliente> CargarComboTiposCliente();
        public List<Calle> CargarComboCalles();
        public string NombreDeUsuario(string documento, int tipoDocumento);
        public int UsuarioExistente(string documento, int tipoDocumento);
        public int ProximoIdUsuario();
        public bool InsertarUsuario(Cliente usuario);
        public Dictionary<int, Cliente> CargarClientes();
        public List<Pelicula> CargarPeliculas();
        public Dictionary<int, Funcion> CargarFunciones();
        public Dictionary<int, Sala> CargarSalas();
        public Dictionary<int, Butaca> CargarButacas(Dictionary<int, Sala> dicSalas);
        public Dictionary<int, ButacaFuncion> CargarButacasFunciones(Dictionary<int, Butaca> dicButacas,
                                                                     Dictionary<int, Funcion> dicFunciones,
                                                                     Dictionary<int, Cliente> dicClientes);
        public List<GeneroPelicula> CargarComboGenerosPelicula();
        public List<CalificacionEtaria> CargarComboCalificacionesEtarias();
        public List<Idioma> CargarComboIdiomas();
        public int ComprarButacaFuncion(int idCliente, int idButaca, int idFuncion, float precio, bool reserva);
        Calle InformacionDeCalle(Calle calle);

        bool AgregarComprobante(List<Parametro2> parametrosTipados);
    }
}
