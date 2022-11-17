using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CineBackend.Datos;
using CineBackend.Dominio;
using Newtonsoft.Json;

namespace CineBackend.Datos
{
    class HelperDB : IDao
    {
        private SqlConnection cnn;

        public HelperDB()
        {
            cnn = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=COMPLEJO_CINE_v4;Integrated Security=True");
        }

      

        //PABLO

        public DataTable ConsultaClientes()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("Consultar_Clientes", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public DataTable Consulta_Comprobantes_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente)
        {

            DataTable tabla = new DataTable();
            cnn.Open();
            string sp = "SP_CONSULTAR_COMPRAS_CON_FILTROS";
            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fecha1", fecha1);
            cmd.Parameters.AddWithValue("@fecha2", fecha2);
            cmd.Parameters.AddWithValue("@codigo", cliente);
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;

        }

        //public List<Comprobante> Consulta_Comprobantes_Con_Filtro(/*List<Parametro> values*/DateTime fecha1, DateTime fecha2, int cliente)
        //{
        //    cnn.Open();
        //    List<Comprobante> comprobantes = new List<Comprobante>();
        //    SqlCommand cmd = new SqlCommand("SP_CONSULTAR_COMPRAS_CON_FILTROS", cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@fecha1", fecha1);
        //    cmd.Parameters.AddWithValue("@fecha2", fecha2);
        //    cmd.Parameters.AddWithValue("@codigo", cliente);

        //    //if (values != null)
        //    //{
        //    //    foreach (Parametro oParametro in values)
        //    //    {

        //    //        if (oParametro.Valor == null)
        //    //            cmd.Parameters.AddWithValue(oParametro.Clave, DBNull.Value);
        //    //        else
        //    //            cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);

        //    //    }
        //    //}

        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    cnn.Close();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Comprobante comprobante = new Comprobante();
        //        comprobante.IdComprobante = Convert.ToInt32(row["Nro. Comprobante"].ToString());
        //        comprobante.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
        //        comprobante.Hora = Convert.ToDateTime(row["Hora"].ToString());               
        //        comprobantes.Add(comprobante);
        //    }

        //    return comprobantes;
            
        //}

        //public DataTable Consulta_Comprobantes(int cliente)
        //{

        //    DataTable tabla = new DataTable();
        //    cnn.Open();
        //    string sp = "SP_CONSULTAR_COMPRAS";
        //    SqlCommand cmd = new SqlCommand(sp, cnn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@codigo", cliente);
        //    tabla.Load(cmd.ExecuteReader());
        //    cnn.Close();

        //    return tabla;

        //}

        public List<Comprobante> Consulta_Comprobantes(List<Parametro> values/*int cliente*/)
        {
            cnn.Open();
            List<Comprobante> comprobantes = new List<Comprobante>();
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_COMPRAS", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@codigo", cliente);
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
                }
            }
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cnn.Close();

            foreach (DataRow row in dt.Rows)
            {
                Comprobante comprobante = new Comprobante();
                comprobante.IdComprobante = Convert.ToInt32(row["Nro. Comprobante"].ToString());
                comprobante.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                comprobante.Hora = Convert.ToDateTime(row["Hora"].ToString());
                comprobantes.Add(comprobante);
            }

            return comprobantes;

        }

        public DataTable ConsultaDatos(int codigo)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            string sp = "SP_CONTACTOS_CLIENTES";
            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo",codigo);
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            return tabla;
        }

        public decimal Consulta_Total_Con_Filtro(DateTime fecha1, DateTime fecha2, int cliente)
        {

            decimal aux=0;
            //cnn.Open();
            //string sp = "SP_TOTAL_COMPRAS_CON_FILTRO";
            //SqlCommand cmd = new SqlCommand(sp, cnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@fecha1", fecha1);
            //cmd.Parameters.AddWithValue("@fecha2", fecha2);
            //cmd.Parameters.AddWithValue("@codigo", cliente);
            //SqlParameter pOut = new SqlParameter("@total",SqlDbType.Decimal);
            //pOut.Direction = ParameterDirection.Output;
            //cmd.Parameters.Add(pOut);
            //cmd.ExecuteNonQuery();
            //cnn.Close();

            //aux = Convert.ToDecimal(pOut.Value);
            return aux;

        }

        public decimal Consulta_Total( int cliente)
        {

            decimal aux = 0;
            cnn.Open();
            string sp = "SP_TOTAL_COMPRAS";
            SqlCommand cmd = new SqlCommand(sp, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", cliente);
            SqlParameter pOut = new SqlParameter("@total", SqlDbType.Decimal);
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cnn.Close();

            aux = Convert.ToDecimal(pOut.Value);
            return aux;

        }

        public DataTable Sorteo()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SP_SORTEO", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public DataTable Consulta_Reporte()
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SP_CONSULTA_REPORTE", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public Cliente DevolverDatos(string documento)
        {
            DataTable tabla = new DataTable();
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SP_DATOS_CLIENTES", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@documento", documento);
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();

            //List<Cliente> lst = new List<Cliente>();            

            List<TipoCliente> tiposCliente = CargarComboTiposCliente();
            List<TipoDocumento> tiposDocumento = CargarComboTiposDocumento();
            List<Calle> calles = CargarComboCalles();
            List<Genero> generos = CargarComboGenero();
            Dictionary<int, TipoCliente> dicTiposCliente = tiposCliente.ToDictionary(x => x.IdTipoCliente);
            Dictionary<int, TipoDocumento> dicTiposDocumento = tiposDocumento.ToDictionary(x => x.IdTipoDocumento);
            Dictionary<int, Calle> dicCalles = calles.ToDictionary(x => x.IdCalle);
            Dictionary<int, Genero> dicGenero = generos.ToDictionary(x => x.IdGenero);

            Cliente cliente = new Cliente();

            foreach (DataRow x in tabla.Rows)
            {
                
                cliente.IdCliente = (int)x["id_cliente"];
                cliente.Apellido = x["apellido_cliente"].ToString();
                cliente.Nombre = x["nombre_cliente"].ToString();
                cliente.FechaNac = (DateTime)x["fecha_nac"];
                cliente.TipoDocumento = dicTiposDocumento[(int)x["id_tipo_doc"]];
                cliente.Documento = x["nro_doc"].ToString();
                cliente.Calle = dicCalles[(int)x["id_calle"]];
                cliente.Altura = (int)x["altura"];
                cliente.Genero = dicGenero[(int)x["id_genero"]];

            }

            return cliente;
        }

        public bool ModificarUsuario(Cliente usuario)
        {
            bool ok = false;            
            SqlCommand command = new SqlCommand("SP_MODIFICAR_USUARIO", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            command.Parameters.AddWithValue("@apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@tipo_Cliente", usuario.TipoCliente.IdTipoCliente);
            command.Parameters.AddWithValue("@fec_nac", usuario.FechaNac);
            command.Parameters.AddWithValue("@tipo_doc", usuario.TipoDocumento.IdTipoDocumento);
            command.Parameters.AddWithValue("@nro_doc", usuario.Documento);
            command.Parameters.AddWithValue("@id_calle", usuario.Calle.IdCalle);
            command.Parameters.AddWithValue("@altura", usuario.Altura);
            command.Parameters.AddWithValue("@id_genero", usuario.Genero.IdGenero);

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                ok = command.ExecuteNonQuery() == 1;
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public bool EliminarUsuario(Cliente usuario)
        {
            bool ok = false;
            SqlCommand command = new SqlCommand("SP_BAJA_CLIENTES", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            command.Parameters.AddWithValue("@apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@tipo_Cliente", usuario.TipoCliente.IdTipoCliente);
            command.Parameters.AddWithValue("@fec_nac", usuario.FechaNac);
            command.Parameters.AddWithValue("@tipo_doc", usuario.TipoDocumento.IdTipoDocumento);
            command.Parameters.AddWithValue("@nro_doc", usuario.Documento);
            command.Parameters.AddWithValue("@id_calle", usuario.Calle.IdCalle);
            command.Parameters.AddWithValue("@altura", usuario.Altura);
            command.Parameters.AddWithValue("@id_genero", usuario.Genero.IdGenero);
            command.Parameters.AddWithValue("@baja", usuario.Baja);

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                ok = command.ExecuteNonQuery() == 1;
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }
        //retorna el id del cliente
        public int IdUsuario(string documento, int tipoDocumento)
        {
            int aux = 0;
            SqlTransaction t = null;
            SqlCommand command = new SqlCommand("SP_ID_USUARIO", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@documento", documento);
            command.Parameters.AddWithValue("@tipoDoc", tipoDocumento);
            SqlParameter outParameter = new SqlParameter("@resultado", SqlDbType.Int);
            outParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(outParameter);
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                command.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            if (outParameter.Value != null) aux = (int)outParameter.Value;
            return aux;
        }

        //NACHO

        //Clientes
        public Dictionary<int, Cliente> CargarClientes()
        {
            Dictionary<int, Cliente> dicClientes = new Dictionary<int, Cliente>();
            DataTable tablaClientes = new DataTable();

            SqlCommand command = new SqlCommand("SP_CARGA_CLIENTES", cnn);
            SqlTransaction t = null;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                tablaClientes.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            /*List<TipoCliente> tiposCliente = new List<TipoCliente>();
              List<TipoDocumento> tiposDocumento = new List<TipoDocumento>();
              List<Calle> calles = new List<Calle>();
              List<Genero> generos = new List<Genero>();
              tiposCliente = CargarComboTiposCliente();
              tiposDocumento = CargarComboTiposDocumento();
              calles = CargarComboCalles();
              generos = CargarComboGenero();
              Dictionary<int, TipoCliente> dicTiposCliente = new Dictionary<int, TipoCliente>();
              Dictionary<int, TipoDocumento> dicTiposDocumento = new Dictionary<int, TipoDocumento>();
              Dictionary<int, Calle> dicCalles = new Dictionary<int, Calle>();
              Dictionary<int, Genero> dicGenero = new Dictionary<int, Genero>();
              dicTiposCliente = tiposCliente.ToDictionary(x => x.IdTipoCliente);
              dicTiposDocumento = tiposDocumento.ToDictionary(x => x.IdTipoDocumento);
              dicCalles = calles.ToDictionary(x => x.IdCalle);
              dicGenero = generos.ToDictionary(x => x.IdGenero);*/

            List<TipoCliente> tiposCliente = CargarComboTiposCliente();
            List<TipoDocumento> tiposDocumento = CargarComboTiposDocumento();
            List<Calle> calles = CargarComboCalles();
            List<Genero> generos = CargarComboGenero();
            Dictionary<int, TipoCliente> dicTiposCliente = tiposCliente.ToDictionary(x => x.IdTipoCliente);
            Dictionary<int, TipoDocumento> dicTiposDocumento = tiposDocumento.ToDictionary(x => x.IdTipoDocumento);
            Dictionary<int, Calle> dicCalles = calles.ToDictionary(x => x.IdCalle);
            Dictionary<int, Genero> dicGenero = generos.ToDictionary(x => x.IdGenero);

            foreach (DataRow x in tablaClientes.Rows)
            {
                Cliente tempCliente = new Cliente();
                if (x != null)
                {
                    tempCliente.IdCliente = (int)x["id_cliente"];
                    tempCliente.Apellido = x["apellido_cliente"].ToString();
                    tempCliente.Nombre = x["nombre_cliente"].ToString();
                    tempCliente.FechaNac = (DateTime)x["fecha_nac"];
                    tempCliente.TipoDocumento = dicTiposDocumento[(int)x["id_tipo_doc"]];
                    tempCliente.Documento = x["nro_doc"].ToString();
                    tempCliente.Calle = dicCalles[(int)x["id_calle"]];
                    tempCliente.Altura = (int)x["altura"];
                    tempCliente.Genero = dicGenero[(int)x["id_genero"]];

                    dicClientes[(int)x["id_cliente"]] = tempCliente;
                }
            }

            return dicClientes;
        }

        ////PELICULAS
        public List<Pelicula> CargarPeliculas()
        {
            List<Pelicula> cartelera = new List<Pelicula>();
            DataTable tabla = new DataTable();
            SqlCommand command = new SqlCommand("SP_PELICULAS_DETALLES", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                tabla.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            foreach (DataRow x in tabla.Rows)
            {
                Pelicula tempPelicula = new Pelicula();
                if (x != null)
                {
                    GeneroPelicula tempGenero = new GeneroPelicula();
                    CalificacionEtaria tempCali = new CalificacionEtaria();
                    Idioma tempIdioma = new Idioma();

                    tempGenero.IdGeneroPelicula = (int)x["id_tipo_genero_pelicula"];
                    tempGenero.ValorGeneroPelicula = x["tipo_genero_pelicula"].ToString();

                    tempCali.IdCalificacionEtaria = (int)x["id_calificacion_etaria"];
                    tempCali.ValorCalificacionEtaria = x["calificacion_etarias"].ToString();

                    tempIdioma.IdIdioma = (int)x["id_idioma"];
                    tempIdioma.ValorIdioma = x["idioma"].ToString();

                    tempPelicula.Genero = tempGenero;
                    tempPelicula.CalificacionEtaria = tempCali;
                    tempPelicula.Idioma = tempIdioma;
                    tempPelicula.IdPelicula = (int)x["id_pelicula"];
                    tempPelicula.Nombre = x["nombre"].ToString();
                    tempPelicula.IdPaisOrigen = (int)x["id_pais_origen"];
                    tempPelicula.Duracion = (int)x["duracion"];
                    tempPelicula.Subtitulada = (bool)x["subtitulada"];
                    //tempPelicula.Imagen = x["Imagen"] == DBNull.Value ?
                    //    null : ConvertToImage(new Binary((byte[])x["imagen"]));
                }
                cartelera.Add(tempPelicula);
            }
            return cartelera;
        }
        #region Actualizar Peliculas Viejo
        /*public List<Pelicula> ActualizarPeliculas(int idGenero, int idCalEtaria, int idIdioma)
        {
            List<Pelicula> cartelera = new List<Pelicula>();
            DataTable tabla = new DataTable();
            SqlCommand command = new SqlCommand("SP_PELICULAS_FILTRADAS", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idGenero", idGenero);
            command.Parameters.AddWithValue("@idCalEtaria", idCalEtaria);
            command.Parameters.AddWithValue("@idIdioma", idIdioma);
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                tabla.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            foreach (DataRow x in tabla.Rows)
            {
                Pelicula tempPelicula = new Pelicula();
                if (x != null)
                {
                    GeneroPelicula tempGenero = new GeneroPelicula();
                    CalificacionEtaria tempCali = new CalificacionEtaria();
                    Idioma tempIdioma = new Idioma();

                    tempGenero.IdGeneroPelicula = (int)x["id_tipo_genero_pelicula"];
                    tempGenero.ValorGeneroPelicula = x["tipo_genero_pelicula"].ToString();

                    tempCali.IdCalificacionEtaria = (int)x["id_calificacion_etaria"];
                    tempCali.ValorCalificacionEtaria = x["calificacion_etarias"].ToString();

                    tempIdioma.IdIdioma = (int)x["id_idioma"];
                    tempIdioma.ValorIdioma = x["idioma"].ToString();

                    tempPelicula.Genero = tempGenero;
                    tempPelicula.CalificacionEtaria = tempCali;
                    tempPelicula.Idioma = tempIdioma;
                    tempPelicula.Nombre = x["nombre"].ToString();
                    tempPelicula.IdPaisOrigen = (int)x["id_pais_origen"];
                    tempPelicula.Duracion = (int)x["duracion"];
                    tempPelicula.Subtitulada = (bool)x["subtitulada"];
                }

                cartelera.Add(tempPelicula);
            }

            return cartelera;
        }*/
        #endregion
        public Dictionary<int, Funcion> CargarFunciones()
        {
            DataTable tabla = new DataTable();
            Dictionary<int, Funcion> dicFunciones = new Dictionary<int, Funcion>();

            SqlCommand command = new SqlCommand("SP_FUNCIONES_DETALLES", cnn);
            SqlTransaction t = null;
            command.CommandType = CommandType.StoredProcedure;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                tabla.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            foreach (DataRow x in tabla.Rows)
            {
                Funcion tempFuncion = new Funcion();
                Pelicula semiPelicula = new Pelicula();
                Sala tempSala = new Sala();
                TipoSala tempTipoSala = new TipoSala();
                if (x != null)
                {
                    semiPelicula.IdPelicula = (int)x["id_pelicula"]; // Lo completo en FormCompras

                    tempSala.IdSala = (int)x["id_sala"];
                    tempSala.Capacidad = (int)x["capacidad"];

                    tempTipoSala.IdTipoSala = tempSala.IdSala;
                    tempTipoSala.Tipo = x["tipo_sala"].ToString();

                    tempSala.TipoSala = tempTipoSala;

                    tempFuncion.IdFuncion = (int)x["id_funcion"];
                    tempFuncion.Fecha = (DateTime)x["fecha_hora"];
                    tempFuncion.Sala = tempSala;
                    tempFuncion.Pelicula = semiPelicula;
                    tempFuncion.Precio = (double)x["precio_actual"];

                    dicFunciones[(int)x["id_funcion"]] = tempFuncion;
                }
            }

            return dicFunciones;
        }
        public Dictionary<int, Sala> CargarSalas()
        {
            DataTable tablaSalas = new DataTable();
            Dictionary<int, Sala> dicSalas = new Dictionary<int, Sala>();

            DataTable tablaTipoSalas = new DataTable();
            Dictionary<int, TipoSala> dicTipoSala = new Dictionary<int, TipoSala>();

            SqlCommand commandSalas = new SqlCommand("SP_CARGA_SALAS", cnn);
            commandSalas.CommandType = CommandType.StoredProcedure;
            SqlCommand commandTipoSalas = new SqlCommand("SP_CARGA_TIPOSSALA", cnn);
            commandTipoSalas.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                commandSalas.Transaction = t;
                commandTipoSalas.Transaction = t;
                tablaSalas.Load(commandSalas.ExecuteReader());
                tablaTipoSalas.Load(commandTipoSalas.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            foreach (DataRow x in tablaTipoSalas.Rows)
            {
                TipoSala tempTipoSala = new TipoSala();
                if (x != null)
                {
                    tempTipoSala.IdTipoSala = (int)x["id_tipo_sala"];
                    tempTipoSala.Tipo = x["tipo_sala"].ToString();
                    dicTipoSala[tempTipoSala.IdTipoSala] = tempTipoSala;
                }
            }

            foreach (DataRow x in tablaSalas.Rows)
            {
                Sala tempSala = new Sala();
                if (x != null)
                {
                    tempSala.IdSala = (int)x["id_sala"];
                    tempSala.Capacidad = (int)x["capacidad"];
                    tempSala.TipoSala = dicTipoSala[(int)x["id_tipo_sala"]];
                    dicSalas[(int)x["id_sala"]] = tempSala;
                }
            }

            return dicSalas;
        }
        public Dictionary<int, Butaca> CargarButacas(Dictionary<int, Sala> dicSalas)
        {
            DataTable butacasTable = new DataTable();
            Dictionary<int, Butaca> dicButacas = new Dictionary<int, Butaca>();

            DataTable tipoButacasTable = new DataTable();
            Dictionary<int, TipoButaca> dicTipoButaca = new Dictionary<int, TipoButaca>();

            SqlCommand commandButaca = new SqlCommand("SP_CARGA_BUTACAS", cnn);
            commandButaca.CommandType = CommandType.StoredProcedure;
            SqlCommand commandTipoButaca = new SqlCommand("SP_CARGA_TIPO_BUTACA", cnn);
            commandTipoButaca.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                commandButaca.Transaction = t;
                commandTipoButaca.Transaction = t;
                butacasTable.Load(commandButaca.ExecuteReader());
                tipoButacasTable.Load(commandTipoButaca.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            foreach (DataRow x in tipoButacasTable.Rows)
            {
                TipoButaca tempTipoButaca = new TipoButaca();
                if (x != null)
                {
                    tempTipoButaca.IdTipoButaca = (int)x["id_tipo_butaca"];
                    tempTipoButaca.ValorTipoButaca = x["tipo_butaca"].ToString();
                    dicTipoButaca[(int)x["id_tipo_butaca"]] = tempTipoButaca;
                }
            }

            foreach (DataRow x in butacasTable.Rows)
            {
                Butaca tempButaca = new Butaca();
                if (x != null)
                {
                    tempButaca.IdButaca = (int)x["id_butaca"];
                    tempButaca.IdFila = (int)x["id_fila"];
                    tempButaca.NroButaca = (int)x["nro_butaca"];
                    tempButaca.TipoButaca = dicTipoButaca[(int)x["id_tipo_butaca"]];
                    tempButaca.Sala = dicSalas[(int)x["id_sala"]];
                    dicButacas[(int)x["id_butaca"]] = tempButaca;
                }
            }

            return dicButacas;
        }
        public Dictionary<int, ButacaFuncion> CargarButacasFunciones(Dictionary<int, Butaca> dicButacas,
                                                                     Dictionary<int, Funcion> dicFunciones,
                                                                     Dictionary<int, Cliente> dicClientes)
        {
            Dictionary<int, ButacaFuncion> dicButacasFunciones = new Dictionary<int, ButacaFuncion>();
            DataTable funcionTabla = new DataTable();

            SqlCommand command = new SqlCommand("SP_CARGA_BUTACAS_FUNCIONES", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                funcionTabla.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            foreach (DataRow x in funcionTabla.Rows)
            {
                ButacaFuncion tempButacaFuncion = new ButacaFuncion();
                Reserva tempReserva = new Reserva();
                if (x != null)
                {
                    tempButacaFuncion.Reserva = null;
                    Type type = x["id_reserva"].GetType();
                    if (x["id_reserva"] != DBNull.Value)
                    {
                        tempReserva.IdReserva = (int)x["id_reserva"];
                        tempReserva.Ciente = dicClientes[(int)x["id_cliente"]];
                        tempReserva.FechaReserva = (DateTime)x["fecha_reserva"];
                        tempButacaFuncion.Reserva = tempReserva;
                    }

                    tempButacaFuncion.IdButacaFuncion = (int)x["id_butaca_funcion"];
                    tempButacaFuncion.Butaca = dicButacas[(int)x["id_butaca"]];
                    tempButacaFuncion.Funcion = dicFunciones[(int)x["id_funcion"]];

                    dicButacasFunciones[(int)x["id_butaca_funcion"]] = tempButacaFuncion;
                }
            }

            return dicButacasFunciones;
        }

        ////COMPRAR
        //Compra entrada
        public int ComprarButacaFuncion(int idCliente, int idButaca, int idFuncion, float precio, bool reserva)
        {
            int filasAfectadas = 0;
            SqlCommand command = new SqlCommand("SP_ALTA_COMPRA", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            command.Parameters.AddWithValue("@inIdCliente", idCliente);
            command.Parameters.AddWithValue("@inIdButaca", idButaca);
            command.Parameters.AddWithValue("@inIdFuncion", idFuncion);
            command.Parameters.AddWithValue("@inPrecio", precio);
            command.Parameters.AddWithValue("@inReserva", reserva);
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                filasAfectadas = command.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return filasAfectadas;
        }

        ////USUARIO
        //Se fija si existe el usuario
        public int UsuarioExistente(string documento, int tipoDocumento)
        {
            int aux = 0;
            SqlTransaction t = null;
            SqlCommand command = new SqlCommand("SP_USUARIO_EXISTENTE", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@documento", documento);
            command.Parameters.AddWithValue("@tipoDoc", tipoDocumento);
            SqlParameter outParameter = new SqlParameter("@resultado", SqlDbType.Int);
            outParameter.Direction = ParameterDirection.Output;
            command.Parameters.Add(outParameter);
            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                command.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            if (outParameter.Value != null) aux = (int)outParameter.Value;
            return aux;
        }
        //Devuelve el ultimo id_cliente + 1
        public int ProximoIdUsuario()
        {
            SqlCommand command = new SqlCommand("SP_PROXIMO_ID_USUARIO", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            SqlParameter outParam = new SqlParameter("@proximoId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(outParam);

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                command.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return outParam.Value != null ? (int)outParam.Value : -1;
        }

        //Registra un usuario en la base
        public bool InsertarUsuario(Cliente usuario)
        {
            bool ok = false;
            int proximoId = ProximoIdUsuario();
            SqlCommand command = new SqlCommand("SP_INSERTAR_USUARIO", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            command.Parameters.AddWithValue("@id", proximoId);
            command.Parameters.AddWithValue("@apellido", usuario.Apellido);
            command.Parameters.AddWithValue("@nombre", usuario.Nombre);
            command.Parameters.AddWithValue("@idTipoCliente", usuario.TipoCliente.IdTipoCliente);
            command.Parameters.AddWithValue("@fechaNac", usuario.FechaNac);
            command.Parameters.AddWithValue("@idTipoDoc", usuario.TipoDocumento.IdTipoDocumento);
            command.Parameters.AddWithValue("@nroDoc", usuario.Documento);
            command.Parameters.AddWithValue("@idCalle", usuario.Calle.IdCalle);
            command.Parameters.AddWithValue("@altura", usuario.Altura);
            command.Parameters.AddWithValue("@idGenero", usuario.Genero.IdGenero);
            command.Parameters.AddWithValue("@baja", usuario.Baja);

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                ok = command.ExecuteNonQuery() == 1;
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }
        //Devuelve un nombre a partir de un dni y su tipo
        public string NombreDeUsuario(string documento, int tipoDocumento)
        {
            string nombre = String.Empty;
            SqlCommand command = new SqlCommand("SP_NOMBRE_DE_USUARIO", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            command.Parameters.AddWithValue("@documento", documento);
            command.Parameters.AddWithValue("@tipoDocumento", tipoDocumento);
            SqlParameter outParam = new SqlParameter("@nombreSalida", SqlDbType.VarChar, 50);
            outParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(outParam);

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                command.ExecuteNonQuery();
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            if (outParam != null && outParam.Value != null)
            {
                nombre = outParam.Value.ToString();
            }
            return nombre;
        }

        #region Cargar Combos
        ////COMBOS
        private DataTable SP_CARGAR_COMBO(string nombreTabla)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SP_CARGAR_COMBO", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;
            command.Parameters.AddWithValue("@nombreTabla", nombreTabla);

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                table.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return table;
        }
        //Cargar Combo Genero
        public List<Genero> CargarComboGenero()
        {
            List<Genero> generos = new List<Genero>();
            DataTable table = new DataTable();
            table = SP_CARGAR_COMBO("Generos");

            foreach (DataRow x in table.Rows)
            {
                if (x != null)
                {
                    Genero tempGenero = new Genero();
                    tempGenero.IdGenero = (int)x["id_genero"];
                    tempGenero.NombreGenero = x["genero"].ToString();
                    generos.Add(tempGenero);
                }
            }
            return generos;
        }
        //Cargar Combo Tipos Documento
        public List<TipoDocumento> CargarComboTiposDocumento()
        {
            List<TipoDocumento> tiposDocumento = new List<TipoDocumento>();
            DataTable table = new DataTable();
            table = SP_CARGAR_COMBO("Tipos_documento");

            foreach (DataRow x in table.Rows)
            {
                TipoDocumento tempTipo = new TipoDocumento();
                if (x != null)
                {
                    tempTipo.IdTipoDocumento = (int)x["id_tipo_doc"];
                    tempTipo.ValorTipoDocumento = x["tipo_doc"].ToString();
                    tiposDocumento.Add(tempTipo);
                }
            }
            return tiposDocumento;
        }
        //Cargar Combo Tipos Cliente
        public List<TipoCliente> CargarComboTiposCliente()
        {
            List<TipoCliente> tiposCliente = new List<TipoCliente>();
            DataTable table = new DataTable();
            table = SP_CARGAR_COMBO("Tipos_clientes");

            foreach (DataRow x in table.Rows)
            {
                TipoCliente tempTipo = new TipoCliente();
                if (x != null)
                {
                    tempTipo.IdTipoCliente = (int)x["id_tipo_clientes"];
                    tempTipo.ValorTipoCliente = x["tipo_cliente"].ToString();
                    tiposCliente.Add(tempTipo);
                }
            }
            return tiposCliente;
        }
        //Cargar Combo Calles
        public List<Calle> CargarComboCalles()
        {
            List<Calle> calles = new List<Calle>();
            DataTable table = new DataTable();
            table = SP_CARGAR_COMBO("Calles");

            foreach (DataRow x in table.Rows)
            {
                Calle tempCalle = new Calle();
                if (x != null)
                {
                    tempCalle.IdCalle = (int)x["id_calle"];
                    tempCalle.NombreCalle = x["calle"].ToString();
                    calles.Add(tempCalle);
                }
            }
            return calles;
        }
        //Cargar Combos Peliculas
        public List<GeneroPelicula> CargarComboGenerosPelicula()
        {
            List<GeneroPelicula> generosPelicula = new List<GeneroPelicula>();
            DataTable tabla = new DataTable();
            tabla = SP_CARGAR_COMBO("TIPOS_GENERO_PELICULA");
            DataRow defaultRow = tabla.NewRow();
            defaultRow[0] = -1;
            defaultRow[1] = "-----";
            tabla.Rows.Add(defaultRow);
            foreach (DataRow x in tabla.Rows)
            {
                GeneroPelicula tempGeneroPelicula = new GeneroPelicula();
                if (x != null)
                {
                    tempGeneroPelicula.IdGeneroPelicula = (int)x["id_tipo_genero_pelicula"];
                    tempGeneroPelicula.ValorGeneroPelicula = x["tipo_genero_pelicula"].ToString();
                }
                generosPelicula.Add(tempGeneroPelicula);
            }
            return generosPelicula;
        }
        public List<CalificacionEtaria> CargarComboCalificacionesEtarias()
        {
            List<CalificacionEtaria> calificacionesEtarias = new List<CalificacionEtaria>();
            DataTable tabla = new DataTable();
            tabla = SP_CARGAR_COMBO("CALIFICACIONES_ETARIAS");
            DataRow defaultRow = tabla.NewRow();
            defaultRow[0] = -1;
            defaultRow[1] = "-----";
            tabla.Rows.Add(defaultRow);
            foreach (DataRow x in tabla.Rows)
            {
                CalificacionEtaria tempCalificacionEtaria = new CalificacionEtaria();
                if (x != null)
                {
                    tempCalificacionEtaria.IdCalificacionEtaria = (int)x["id_calificacion_etaria"];
                    tempCalificacionEtaria.ValorCalificacionEtaria = x["calificacion_etarias"].ToString();
                }
                calificacionesEtarias.Add(tempCalificacionEtaria);
            }
            return calificacionesEtarias;
        }
        public List<Idioma> CargarComboIdiomas()
        {
            List<Idioma> idiomas = new List<Idioma>();
            DataTable tabla = new DataTable();
            tabla = SP_CARGAR_COMBO("IDIOMAS");
            DataRow defaultRow = tabla.NewRow();
            defaultRow[0] = -1;
            defaultRow[1] = "-----";
            tabla.Rows.Add(defaultRow);

            foreach (DataRow x in tabla.Rows)
            {
                Idioma tempIdioma = new Idioma();
                if (x != null)
                {
                    tempIdioma.IdIdioma = (int)x["id_idioma"];
                    tempIdioma.ValorIdioma = x["Idioma"].ToString();
                }
                idiomas.Add(tempIdioma);
            }
            return idiomas;
        }


        #endregion

        public Calle InformacionDeCalle(Calle calle)
        {
            DataTable tempTable = new DataTable();
            SqlCommand command = new SqlCommand("SP_INFO_CALLE", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@inIdCalle", calle.IdCalle);
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                command.Transaction = t;
                tempTable.Load(command.ExecuteReader());
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            DataRow dataRow = tempTable.Rows[0];

            Provincia tempProvincia = new Provincia(
                dataRow["provincia"].ToString(), 
                (int)dataRow["id_provincia"]);

            Localidad tempLocalidad = new Localidad(
                dataRow["localidad"].ToString(), 
                (int)dataRow["id_localidad"], 
                tempProvincia);

            Barrio tempBarrio = new Barrio(
                dataRow["barrio"].ToString(), 
                (int)dataRow["id_barrio"], 
                tempLocalidad);

            Calle tempCalle = new Calle(dataRow["calle"].ToString(), 
                (int)dataRow["id_calle"], 
                tempBarrio);


            return tempCalle;
        }
        public bool AgregarComprobante(List<Parametro2> parametrosTipados)
        {
            bool aux = true;
            SqlCommand commandComprobante = new SqlCommand("SP_AGREGAR_COMPROBANTE", cnn);
            commandComprobante.CommandType = CommandType.StoredProcedure;
            commandComprobante.Parameters.AddWithValue("@inTipoDocEmp", JsonConvert.DeserializeObject<int>(parametrosTipados[0].Valor.ToString()));
            commandComprobante.Parameters.AddWithValue("@inDocEmp", JsonConvert.DeserializeObject<string>(parametrosTipados[1].Valor.ToString()));
            commandComprobante.Parameters.AddWithValue("@inTipoDocClie", JsonConvert.DeserializeObject<int>(parametrosTipados[2].Valor.ToString()));
            commandComprobante.Parameters.AddWithValue("@inDocClie", JsonConvert.DeserializeObject<string>(parametrosTipados[3].Valor.ToString()));
            SqlParameter outNroComprobante = new SqlParameter("@outNroComprobante", SqlDbType.Int);
            outNroComprobante.Direction = ParameterDirection.Output;
            commandComprobante.Parameters.Add(outNroComprobante);
            //commandComprobante.Parameters.AddWithValue("@inTipoDocEmp", );
            //@inTipoDocEmp int, @inDocEmp varchar(50), @inTipoDocClie int, @inDocClie varchar(50),
            //@outNroComprobante int OUTPUT

            //@inIdComprobante int, @inIdButacaFuncion int, @inPrecio DECIMAL(10, 2)

            List<ButacaFuncion> listaButacaFunciones = new List<ButacaFuncion>();
            List<Decimal> listaPrecios = new List<decimal>();
            foreach (Parametro2 x in parametrosTipados)
            {
                if (x != null)
                {
                    if (x.Tipo == typeof(ButacaFuncion).ToString())
                    {
                        ButacaFuncion tempButacaFuncion = JsonConvert.DeserializeObject<ButacaFuncion>(x.Valor.ToString());
                        listaButacaFunciones.Add(tempButacaFuncion);
                    }
                    if (x.Tipo == typeof(Decimal).ToString())
                    {
                        Decimal tempPrecio = JsonConvert.DeserializeObject<Decimal>(x.Valor.ToString());
                        listaPrecios.Add(tempPrecio);
                    }
                }
            }

            SqlCommand commandDetalles = new SqlCommand("SP_AGREGAR_DETALLES", cnn);

            SqlParameter paramIdButaca = new SqlParameter("@inIdButaca", SqlDbType.Int);
            SqlParameter paramIdFuncion = new SqlParameter("@inIdFuncion", SqlDbType.Int);
            SqlParameter paramPrecio = new SqlParameter("@inPrecio", SqlDbType.Decimal);

            commandDetalles.Parameters.Add(paramIdButaca);
            commandDetalles.Parameters.Add(paramIdFuncion);
            commandDetalles.Parameters.Add(paramPrecio);

            commandDetalles.CommandType = CommandType.StoredProcedure;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                commandComprobante.Transaction = t;
                commandDetalles.Transaction = t;
                commandComprobante.ExecuteNonQuery();

                commandDetalles.Parameters.AddWithValue("@inIdComprobante", outNroComprobante.Value);
                for (int i = 0; i < listaButacaFunciones.Count; i++)
                {
                    paramIdButaca.Value = listaButacaFunciones[i].Butaca.IdButaca;
                    paramIdFuncion.Value = listaButacaFunciones[i].Funcion.IdFuncion;
                    paramPrecio.Value = listaPrecios[i];

                    commandDetalles.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch
            {
                aux = false;
                if (t != null)
                    t.Rollback();
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return aux;
        }


        //NON DB RELATED
        //public static Image ConvertToImage(Binary iBinary)
        //{
        //    var arrayBinary = iBinary.ToArray(); //PARA EL TIPO BINARY TUVE QUE INSTALAR Mindbox.Data.Linq
        //    Image rImage = null;

        //    using (MemoryStream ms = new MemoryStream(arrayBinary))
        //    {
        //        rImage = Image.FromStream(ms);
        //    }
        //    return rImage;
        //}

    }
}
