using CineBackend.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineBackend.Datos
{
    interface IDao
    {
        //PABLO
        DataTable ConsultaClientes();
        DataTable Consulta_Comprobantes_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente);
        //List<Comprobante> Consulta_Comprobantes_Con_Filtro(List<Parametro> values/*DateTime fecha1, DateTime fecha2, int cliente*/);
        //DataTable Consulta_Comprobantes(int cliente);
        List<Comprobante> Consulta_Comprobantes(List<Parametro> values/*int cliente*/);
        DataTable ConsultaDatos(int codigo);
        decimal Consulta_Total_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente);
        decimal Consulta_Total(int cliente);
        DataTable Sorteo();
        DataTable Consulta_Reporte();
        Cliente DevolverDatos(string documento);
        bool ModificarUsuario(Cliente usuario);
        bool EliminarUsuario(Cliente usuario);
        int IdUsuario(string documento, int tipoDocumento);

        //NACHO
        List<TipoDocumento> CargarComboTiposDocumento();
        List<Genero> CargarComboGenero();
        List<TipoCliente> CargarComboTiposCliente();
        List<Calle> CargarComboCalles();
        string NombreDeUsuario(string documento, int tipoDocumento);
        int UsuarioExistente(string documento, int tipoDocumento);
        int ProximoIdUsuario();
        bool InsertarUsuario(Cliente usuario);
        Dictionary<int, Cliente> CargarClientes();
        List<Pelicula> CargarPeliculas();
        Dictionary<int, Funcion> CargarFunciones();
        Dictionary<int, Sala> CargarSalas();
        Dictionary<int, Butaca> CargarButacas(Dictionary<int, Sala> dicSalas);
        Dictionary<int, ButacaFuncion> CargarButacasFunciones(Dictionary<int, Butaca> dicButacas,
                                                                     Dictionary<int, Funcion> dicFunciones,
                                                                     Dictionary<int, Cliente> dicClientes);
        List<GeneroPelicula> CargarComboGenerosPelicula();
        List<CalificacionEtaria> CargarComboCalificacionesEtarias();
        List<Idioma> CargarComboIdiomas();
        int ComprarButacaFuncion(int idCliente, int idButaca, int idFuncion, float precio, bool reserva);
        Calle InformacionDeCalle(Calle calle);

        bool AgregarComprobante(List<Parametro2> parametrosTipados);
    }
}
