using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineBackend.Dominio;
using CineBackend.Servicio;
using CineBackend.Datos;

namespace WinFormsTPPrueba.Presentacion
{
    public partial class FormCompras : Form
    {
        private IServicio helper;
        private Dictionary<int, Funcion> dicFunciones;
        private Dictionary<int, Pelicula> dicPeliculas;
        private Dictionary<int, ButacaFuncion> dicButacasFunciones;
        private Dictionary<int, Cliente> dicClientes;
        private Dictionary<int, Butaca> dicButacas;
        private List<Butaca>[,] asientos;
        private int cantSalas, filasPorSala, butacasPorFila; //2 //4 //5
        private bool canDeselectDgvButacasFunciones = false;
        private ButacaFuncion entrada = new ButacaFuncion();
        private string nombrePeliculaEstrenos;
        private int indiceLimiteButacasFuncionesPermanentes;

        //Variables desde comprobantes
        public ButacaFuncion RetornoAComprobantes { get; set; }
        private bool soloVista;
        private List<ButacaFuncion> butacasYaSeleccionadas;

        public FormCompras(bool soloVista)
        {
            InitializeComponent();
            this.soloVista = soloVista;
        }

        public FormCompras(bool soloVista, List<ButacaFuncion> butacasYaSeleccionadas)
        {
            InitializeComponent();
            this.soloVista = soloVista;
            this.butacasYaSeleccionadas = butacasYaSeleccionadas;
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            helper = new Service();
            dicFunciones = new Dictionary<int, Funcion>();
            dicPeliculas = new Dictionary<int, Pelicula>();
            CargarCombos();
            EstadoInicial();
        }
        private void SeleccionarRowSegunNombrePelicula()
        {
            foreach (Pelicula x in dicPeliculas.Values)
            {
                if (String.IsNullOrEmpty(nombrePeliculaEstrenos))
                    return;
                if (x.Nombre == nombrePeliculaEstrenos)
                {
                    dgvCartelera.Rows[x.IdPelicula-1].Selected = true;
                    //MessageBox.Show($"Nombre Pasado: {nombrePeliculaEstrenos}" +
                    //                $"Nombre Obtenido: {x.Nombre}");
                }
            }
        }
        private void btnPrueba_Click(object sender, EventArgs e)
        {
            SeleccionarRowSegunNombrePelicula();
        }

        private void EstadoInicial()
        {
            cboGeneroPelicula.SelectedValue = -1;
            cboCalificacionEtaria.SelectedValue = -1;
            cboIdioma.SelectedValue = -1;

            if (dicClientes == null) CargarClientes();
            if(dgvCartelera.DataSource == null) CargarPeliculas();
            if(dgvFunciones.DataSource == null) CargarFunciones();
            if(dicButacasFunciones == null) CargarSalas();
            ActualizarPeliculas();
            LimpiarAsientos();
            dgvFunciones.Enabled = false;
            dgvButacasFunciones.Enabled = false;
            if (soloVista)
            {
                btnElegirAsiento.Visible = true;
                btnReservar.Visible = false;
                btnComprar.Visible = false;
                indiceLimiteButacasFuncionesPermanentes = dicButacasFunciones.Count;
                if (butacasYaSeleccionadas != null && butacasYaSeleccionadas.Count > 0)
                {
                    foreach(ButacaFuncion x in butacasYaSeleccionadas)
                    {
                        if (dicButacasFunciones.ContainsKey(x.IdButacaFuncion))
                            continue;
                        if (x != null)
                        {
                            dicButacasFunciones.Add(x.IdButacaFuncion, x);
                        }
                    }
                }
            }
            else
            {

                btnElegirAsiento.Visible = false;
                btnReservar.Visible = true;
                btnComprar.Visible = true;
            }
        }

        //Clientes
        private void CargarClientes()
        {
            dicClientes = new Dictionary<int, Cliente>();
            dicClientes = helper.CargarClientes();
        }
        //Peliculas
        private void CargarPeliculas()
        {
            List<Pelicula> cartelera = new List<Pelicula>();

            int genero = ((GeneroPelicula)cboGeneroPelicula.SelectedItem).IdGeneroPelicula;
            int calificacion = ((CalificacionEtaria)cboCalificacionEtaria.SelectedItem).IdCalificacionEtaria;
            int idioma = ((Idioma)cboIdioma.SelectedItem).IdIdioma;

            if(dgvCartelera.DataSource == null)
            {
                cartelera = helper.CargarPeliculas();
                foreach (Pelicula x in cartelera)
                {
                    if (x != null) dicPeliculas.Add(x.IdPelicula, x);
                }
                dgvCartelera.DataSource = cartelera;
            }

            if (genero == -1 && calificacion == -1 && idioma == -1)
                grpPeliculasDisponibles.Text = "Peliculas Disponibles - Sin Filtros";
            else
                grpPeliculasDisponibles.Text = "Peliculas Disponibles - Filtros Activados";

            CorregirDgvCartelera();
        }
        private void CorregirDgvCartelera()
        {
            //Agregado de Columnas en DGV
            dgvCartelera.Columns["idPaisOrigen"].Visible = false;
            dgvCartelera.Columns["IdPelicula"].Visible = false;
            //dgvCartelera.Columns["imagen"].Visible = false;
            if (dgvCartelera.Columns["colValorGenero"] == null)
            {
                dgvCartelera.Columns["Genero"].Visible = false;
                dgvCartelera.Columns.Add("colValorGenero", "Genero");
                dgvCartelera.Columns["colValorGenero"].DisplayIndex = 2;
            }
            if (dgvCartelera.Columns["colCalificacionEtaria"] == null)
            {
                dgvCartelera.Columns["CalificacionEtaria"].Visible = false;
                dgvCartelera.Columns.Add("colCalificacionEtaria", "Calificación");
                dgvCartelera.Columns["colCalificacionEtaria"].DisplayIndex = 3;
            }
            if (dgvCartelera.Columns["colIdioma"] == null)
            {
                dgvCartelera.Columns["Idioma"].Visible = false;
                dgvCartelera.Columns.Add("colIdioma", "Idioma");
                dgvCartelera.Columns["colIdioma"].DisplayIndex = 4;
            }
            dgvCartelera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCartelera.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCartelera.RowHeadersWidth = 4;

            //Actualizacion de Columnas en DGV
            foreach (DataGridViewRow x in dgvCartelera.Rows)
            {
                x.Cells["colValorGenero"].Value = ((GeneroPelicula)x.Cells["Genero"].Value).ValorGeneroPelicula;
                x.Cells["colCalificacionEtaria"].Value = ((CalificacionEtaria)x.Cells["CalificacionEtaria"].Value).ValorCalificacionEtaria;
                x.Cells["colIdioma"].Value = ((Idioma)x.Cells["Idioma"].Value).ValorIdioma;
            }
            ActualizarPeliculas();
        }
        private void LimpiarSeleccionPeliculas()
        {
            dgvCartelera.CurrentCell = null;
            picImagenPelicula.Image = null;
        }
        private void ActualizarPeliculas()
        {
            LimpiarSeleccionPeliculas();
            string cleanFilterText = "-----";
            foreach (DataGridViewRow x in dgvCartelera.Rows)
            {
                string generoFila = x.Cells["colValorGenero"].Value.ToString();
                if (generoFila != cboGeneroPelicula.Text && cboGeneroPelicula.Text != cleanFilterText) //((Genero)cboGeneroPelicula.SelectedValue).NombreGenero
                {
                    x.Visible = false;
                    continue;
                }
                else
                {
                    x.Visible = true;
                }
                string calificacionFila = x.Cells["colCalificacionEtaria"].Value.ToString();
                if (calificacionFila != cboCalificacionEtaria.Text && cboCalificacionEtaria.Text != cleanFilterText)
                {
                    x.Visible = false;
                    continue;
                }
                else
                {
                    x.Visible = true;
                }
                string idiomaFila = x.Cells["colIdioma"].Value.ToString();
                if (idiomaFila != cboIdioma.Text && cboIdioma.Text != cleanFilterText)
                {
                    x.Visible = false;
                    continue;
                }
                else
                {
                    x.Visible = true;
                }
            }
            ActualizarFunciones(-1);
        }

        //Funciones
        private void CargarFunciones()
        {
            if(dgvFunciones.DataSource == null)
            {
                dicFunciones = helper.CargarFunciones();

                foreach (Funcion x in dicFunciones.Values)
                {
                    if (x != null && x.Pelicula != null)
                    {
                        x.Pelicula = dicPeliculas[x.Pelicula.IdPelicula];
                    }
                }
                dgvFunciones.DataSource = dicFunciones.Values.ToList<Funcion>();
            }
            CorregirDgvFunciones();
            ActualizarFunciones(-1);
        }
        private void CorregirDgvFunciones()
        {
            //ARREGLAR DGV FUNCIONES -- AJUSTES DE PRIMERA VUELTA
            if (dgvFunciones.Columns["Pelicula"].Visible == true ||
               dgvFunciones.Columns["Sala"].Visible == true)
            {
                dgvFunciones.Columns["Pelicula"].Visible = false;
                //dgvFunciones.Columns.Add("colPelicula", "Pelicula");
                //dgvFunciones.Columns["colPelicula"].DisplayIndex = 1;
                //}
                //if(dgvFunciones.Columns["Sala"].Visible == true)
                //{
                dgvFunciones.Columns["Sala"].Visible = false;
                dgvFunciones.Columns.Add("colIdSala", "Nro de Sala");
                dgvFunciones.Columns.Add("colTipoSala", "Tipo de Sala");
                dgvFunciones.Columns["colIdSala"].DisplayIndex = 1;
                dgvFunciones.Columns["colTipoSala"].DisplayIndex = 2;

                foreach (DataGridViewRow x in dgvFunciones.Rows)
                {
                    if (x != null)
                    {
                        x.Cells["colIdSala"].Value = ((Sala)x.Cells["Sala"].Value).IdSala;
                        x.Cells["colTipoSala"].Value = ((Sala)x.Cells["Sala"].Value).TipoSala.Tipo;
                    }
                }

                //Ancho de las columnas
                dgvFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvFunciones.RowHeadersWidth = 4;
            }
        }
        private void LimpiarSeleccionFunciones()
        {
            dgvFunciones.CurrentCell = null;
        }
        private void ActualizarFunciones(int idPelicula)
        {
            LimpiarSeleccionFunciones();
            foreach (DataGridViewRow x in dgvFunciones.Rows)
            {
                if (x != null)
                {
                    if (((Pelicula)x.Cells["Pelicula"].Value).IdPelicula == idPelicula)
                        x.Visible = true;
                    else
                        x.Visible = false;
                }
            }

            if (idPelicula != -1)
                grpFunciones.Text = $"Funciones - {dicPeliculas[idPelicula].Nombre}";
            else
                grpFunciones.Text = $"Funciones - (Seleccione una pelicula)";
        }

        //Salas
        private void CargarSalas()
        {
            Dictionary<int, Sala> dicSalas = new Dictionary<int, Sala>();
            dicSalas = helper.CargarSalas();
            CargarButacas(dicSalas);
        }
        //Butacas
        private void CargarButacas(Dictionary<int,Sala> dicSalas)
        {
            dicButacas = new Dictionary<int, Butaca>();
            dicButacas = helper.CargarButacas(dicSalas);
            CargarButacasFunciones(dicButacas, dicFunciones);
        }
        //ButacasFunciones
        private void CargarButacasFunciones(Dictionary<int, Butaca> dicButacas, 
                                            Dictionary<int,Funcion> dicFunciones_)
        {
            if (dicButacasFunciones == null)
            {
                dicButacasFunciones = new Dictionary<int, ButacaFuncion>();
                dicButacasFunciones = helper.CargarButacasFunciones(dicButacas, dicFunciones_, dicClientes);
                //dgvButacasFunciones.DataSource = dicButacasFunciones.Values.ToList<ButacaFuncion>();
            }
            AsientificarButacasFunciones(dicButacasFunciones);
        }
        private void AsientificarButacasFunciones(/*Dictionary<int, Butaca> dicButacas, */
                                                  Dictionary<int, ButacaFuncion> dicButacaFuncion)
        {
            //Encontrar Nro de Salas
            int nroSalas = -1;
            int nroFilas = -1;
            int nroButacas = -1;
            foreach (ButacaFuncion x in dicButacaFuncion.Values)
            {
                if (x.Butaca.Sala.IdSala > nroSalas) nroSalas = x.Butaca.Sala.IdSala;
                if (x.Butaca.IdFila > nroFilas) nroFilas = x.Butaca.IdFila;
                if (x.Butaca.IdButaca > nroButacas && 
                    x.Butaca.Sala.IdSala == 1 &&
                    x.Butaca.IdFila == 1) nroButacas = x.Butaca.IdButaca;
            }
            cantSalas = nroSalas;
            filasPorSala = nroFilas;
            butacasPorFila = nroButacas;

            asientos = new List<Butaca>[nroSalas, nroFilas];
            int counter = 0;
            foreach (ButacaFuncion x in dicButacaFuncion.Values)
            {
                int idSala = x.Butaca.Sala.IdSala-1;
                int idFila = x.Butaca.IdFila-1;
                if(asientos[idSala, idFila] == null)
                {
                    asientos[idSala, idFila] = new List<Butaca>();
                }
                asientos[idSala, idFila].Add(x.Butaca);
                counter++;
            }
            AsientificarDgvButacasFunciones();
        }
        private void AsientificarDgvButacasFunciones()
        {
            if (dgvButacasFunciones.Columns.Count > 0 && dgvButacasFunciones.Rows.Count > 0)
                return;
            dgvButacasFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvButacasFunciones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvButacasFunciones.RowHeadersWidth = 4;
            int rowHeight = dgvButacasFunciones.Height / filasPorSala;
            for (int i = 0; i < butacasPorFila; i++)
            {
                dgvButacasFunciones.Columns.Add("colButaca" + i.ToString(), "ButacaNro" + i.ToString());
            }
            for (int i = 0; i < filasPorSala; i++)
            {
                dgvButacasFunciones.Rows.Add(1);
                dgvButacasFunciones.Rows[i].Height = rowHeight;
            }
            dgvButacasFunciones.ScrollBars = ScrollBars.None;
            LimpiarAsientos();
            canDeselectDgvButacasFunciones = true;
        }
        private void LimpiarAsientos()
        {
            grpButacas.Text = "Butacas - (Seleccione una funcion)";
            foreach (DataGridViewRow x in dgvButacasFunciones.Rows)
            {
                foreach (DataGridViewCell y in x.Cells)
                {
                    y.Style.BackColor = Color.Gray;
                    y.Style.SelectionBackColor = Color.Green;
                    y.Style.ForeColor = y.Style.BackColor;
                    y.Style.SelectionForeColor = y.Style.SelectionBackColor;
                    y.Value = null;
                }
            }
            dgvButacasFunciones.CurrentCell = null;
        }
        private void ActualizarAsientosDgvButacasFunciones(int idFuncion)
        {
            LimpiarAsientos();
            grpButacas.Text = $"{grpFunciones.Text} - {dicFunciones[idFuncion].Fecha}";
            Dictionary<int, ButacaFuncion> butacasDeFuncion = new Dictionary<int, ButacaFuncion>();
            foreach(ButacaFuncion x in dicButacasFunciones.Values.ToList<ButacaFuncion>())
            {
                if (x.Funcion.IdFuncion == null)
                    continue;
                if(x.Funcion.IdFuncion == idFuncion)
                {
                    butacasDeFuncion.Add(x.IdButacaFuncion, x);
                }
            }
            int butacaFuncionIndex;
            foreach(ButacaFuncion y in butacasDeFuncion.Values)
            {
                butacaFuncionIndex = (y.Butaca.IdButaca - 1) % 5;
                dgvButacasFunciones[butacaFuncionIndex, y.Butaca.IdFila - 1].Style.BackColor = 
                    y.IdButacaFuncion <= indiceLimiteButacasFuncionesPermanentes ? Color.Red : Color.Orange;
                dgvButacasFunciones[butacaFuncionIndex, y.Butaca.IdFila - 1].Style.ForeColor = 
                    y.IdButacaFuncion <= indiceLimiteButacasFuncionesPermanentes ? Color.Red : Color.Orange;

                dgvButacasFunciones[butacaFuncionIndex, y.Butaca.IdFila - 1].ReadOnly = true;
            }
            foreach (Butaca x in dicButacas.Values)
            {
                if(x.Sala.IdSala == dicFunciones[idFuncion].Sala.IdSala)
                {
                    butacaFuncionIndex = (x.IdButaca - 1) % 5;
                    dgvButacasFunciones[butacaFuncionIndex, x.IdFila - 1].Value = x;
                }
            }
        }

        //private bool ButacaVendida(Funcion funcion, Butaca butaca)
        //{
        //    bool vendida = false;
        //    foreach (ButacaFuncion x in dicButacasFunciones.Values)
        //    {
        //        if(butaca == null)
        //        {
        //            MessageBox.Show("Esta butaca no esta disponible por el momento", "Seleccione otra butaca",
        //                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            vendida = true;
        //            break;
        //        }
        //        if (x.Funcion.IdFuncion == funcion.IdFuncion &&
        //            x.Butaca.IdButaca == butaca.IdButaca)
        //        { 
        //            vendida = true;
        //            break;
        //        }
        //    }
        //    return vendida;
        //}
        private bool ButacaVendida(Butaca butaca)
        {
            bool vendida = false;
            if (dgvFunciones.CurrentCell != null)
            {
                int idFuncion = (int)dgvFunciones.Rows[dgvFunciones.CurrentCell.RowIndex].Cells["idFuncion"].Value;
                Funcion funcion = dicFunciones[idFuncion];
                foreach (ButacaFuncion x in dicButacasFunciones.Values)
                {
                    if (x.Funcion.IdFuncion == funcion.IdFuncion &&
                        x.Butaca.IdButaca == butaca.IdButaca ||
                        butaca == null)
                    {
                        vendida = true;
                        break;
                    }
                }
            }
            else vendida = true;
            return vendida;
        }
        private void CargarCombos()
        {
            cboGeneroPelicula.DataSource = helper.CargarComboGenerosPelicula();
            cboGeneroPelicula.DisplayMember = "ValorGeneroPelicula";
            cboGeneroPelicula.ValueMember = "IdGeneroPelicula";

            cboCalificacionEtaria.DataSource = helper.CargarComboCalificacionesEtarias();
            cboCalificacionEtaria.DisplayMember = "ValorCalificacionEtaria";
            cboCalificacionEtaria.ValueMember = "IdCalificacionEtaria";

            cboIdioma.DataSource = helper.CargarComboIdiomas();
            cboIdioma.DisplayMember = "ValorIdioma";
            cboIdioma.ValueMember = "IdIdioma";
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            //Mostrar todas las peliculas sin filtros
        }

        private void SearchTabComboBoxChange(object sender, EventArgs e)
        {
            if (cboGeneroPelicula.SelectedItem != null &&
               cboCalificacionEtaria.SelectedItem != null &&
               cboIdioma.SelectedItem != null)
                    ActualizarPeliculas();
        }


        private void dgvCartelera_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvCartelera.Rows[e.RowIndex].Cells["IdPelicula"].Value != null)
            {
                LimpiarAsientos();
                //picImagenPelicula.Image = (Image)dgvCartelera.Rows[e.RowIndex].Cells["Imagen"].Value;
                ActualizarFunciones((int)dgvCartelera.Rows[e.RowIndex].Cells["IdPelicula"].Value);
                dgvFunciones.Enabled = true;
            }
        }

        private void dgvFunciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 &&
                dgvFunciones.Rows[e.RowIndex].Cells["idFuncion"].Value != null &&
                dicButacasFunciones != null)
            {
                LimpiarAsientos();
                ActualizarAsientosDgvButacasFunciones((int)dgvFunciones.Rows[e.RowIndex].Cells["idFuncion"].Value);
                dgvButacasFunciones.Enabled = true;
            }
        }

        private void dgvButacasFunciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvButacasFunciones.Columns.Count == butacasPorFila &&
                dgvButacasFunciones.Rows.Count == filasPorSala)
            {
                if (canDeselectDgvButacasFunciones)
                {
                    if (dgvFunciones.CurrentCell == null || dgvFunciones.Rows[dgvFunciones.CurrentCell.RowIndex].Cells["idFuncion"].Value == null)
                        return;

                    int idFuncion = (int)dgvFunciones.Rows[dgvFunciones.CurrentCell.RowIndex].Cells["idFuncion"].Value;
                    if (ButacaVendida((Butaca)dgvButacasFunciones[e.ColumnIndex, e.RowIndex].Value)) //XXX
                    {
                        dgvButacasFunciones.ClearSelection();
                        entrada = null;
                    }
                    else
                    {
                        entrada = new ButacaFuncion();
                        Funcion entradaFuncion = dicFunciones[idFuncion];
                        Butaca entradaButaca = (Butaca)dgvButacasFunciones.CurrentCell.Value;

                        entrada.IdButacaFuncion = dicButacasFunciones.Count + 1;
                        entrada.Funcion = entradaFuncion;
                        entrada.Butaca = entradaButaca;
                        entrada.Reserva = null;
                    }
                }
            }
        }

        private void ComprarButacaFuncion()
        {
            //id_comprobante(SP), id_empleado(1), id_cliente, fecha(hoy), hora(ahora),
            //id_tipo_compra(0), descuento(null)
            //id_detalle_comprobante(SP), id_comprobante(SP), id_butaca_funcion,
            //precio_historico, cantidad(1), id_forma_pago(2)

            //id_cliente, id_butaca_funcion, precio_historico
            if (entrada != null)
            {
                if (helper.ComprarButacaFuncion(
                        1, entrada.Butaca.IdButaca, entrada.Funcion.IdFuncion,
                        (float)entrada.Funcion.Precio, true
                    ) == 2)
                {
                    MessageBox.Show("Se registro la compra correctamente", "Operacion Exitosa!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                    MessageBox.Show("Ocurrio un error en la compra", "Operacion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("La butaca selecciona no es valida", "Seleccione otra butaca",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void ReservarButacaFuncion()
        {
            //id_comprobante(SP), id_empleado(1), id_cliente, fecha(hoy), hora(ahora),
            //id_tipo_compra(0), descuento(null)
            //id_detalle_comprobante(SP), id_comprobante(SP), id_butaca_funcion,
            //precio_historico, cantidad(1), id_forma_pago(2)

            //id_cliente, id_butaca_funcion, precio_historico
            if (entrada != null)
            {
                if (helper.ComprarButacaFuncion(
                        1, entrada.Butaca.IdButaca, entrada.Funcion.IdFuncion,
                        (float)entrada.Funcion.Precio, false
                    ) == 3)
                {
                    MessageBox.Show("Se registro la reserva correctamente", "Operacion Exitosa!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                    MessageBox.Show("Ocurrio un error en la reserva", "Operacion Cancelada",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("La butaca selecciona no es valida", "Seleccione otra butaca",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void DevolverAsientoAComprobantes()
        {
            if (entrada != null && dgvButacasFunciones.CurrentCell != null)
            {
                RetornoAComprobantes = entrada;
                butacasYaSeleccionadas.Add(entrada);
                foreach (ButacaFuncion x in butacasYaSeleccionadas)
                {
                    if (x != null )
                    {
                        dicButacasFunciones.Remove(x.IdButacaFuncion);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                RetornoAComprobantes = null;
                MessageBox.Show("Seleccione otra butaca", "Seleccion Invalida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if(dgvButacasFunciones.CurrentCell != null && entrada != null)
            {
                ComprarButacaFuncion();
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {

            if (dgvButacasFunciones.CurrentCell != null && entrada != null)
            {
                ReservarButacaFuncion();
            }
        }

        private void dgvCartelera_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LimpiarSeleccionPeliculas();
            SeleccionarRowSegunNombrePelicula();
        }
        private void dgvFunciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LimpiarSeleccionFunciones();
        }

        private void btnElegirAsiento_Click(object sender, EventArgs e)
        {
            DevolverAsientoAComprobantes();
        }

        private void dgvButacasFunciones_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            canDeselectDgvButacasFunciones = true;
        }
        private void FormCompras_MouseUp(object sender, EventArgs e)
        {
            if (dgvButacasFunciones.CurrentCell == null)
                return;
            if (canDeselectDgvButacasFunciones)
            {
                if (ButacaVendida((Butaca)dgvButacasFunciones.CurrentCell.Value)) //XXX
                {
                    dgvButacasFunciones.ClearSelection();
                }
            }
        }
    }
}
