using CineApp.Cliente;
using CineBackend;
using CineBackend.Dominio;
using CineBackend.Servicio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTPPrueba.Presentacion;

namespace CineApp.Presentacion
{
    public partial class FormNuevosComprobantes : Form
    {
        private IServicio servicio;
        private List<ButacaFuncion> butacasSeleccionadas;
        private string tipoInt = "System.Int32";
        private string tipoString = "System.String";
        private string tipoDecimal = "System.Decimal";
        //private Type tipoInt = Type.GetType("System.Int32", true);
        //private Type tipoString = Type.GetType("System.String", true);
        //private Type tipoDecimal = Type.GetType("System.Decimal", true);
        //private Type tipoButacaFuncion = typeof(ButacaFuncion);
        private string tipoButacaFuncion = typeof(ButacaFuncion).ToString();

        public FormNuevosComprobantes()
        {
            InitializeComponent();
        }
        private void FormNuevosComprobantes_Load(object sender, EventArgs e)
        {
            servicio = new Service();
            butacasSeleccionadas = new List<ButacaFuncion>();
            InicializarDgvEntradas();
            EstadoInicial();
        }

        private void EstadoInicial()
        {
            CargarCombosAsync();
        }

        private void EstadoReset()
        {
            dgvEntradas.Rows.Clear();
            butacasSeleccionadas = new List<ButacaFuncion>();
        }

        private async void CargarCombosAsync()
        {
            //List<TipoDocumento> tiposDocumento = servicio.CargarComboTiposDocumento();
            string url = "https://localhost:7291/api/Comprobantes/GetTiposDocumento";
            var result = await ClienteSingleton.GetInstancia().GetAsync(url);

            List<TipoDocumento> tiposDocumento = new List<TipoDocumento>();
            List<TipoDocumento> tiposDocumento2 = new List<TipoDocumento>();
            List<Object> test = JsonConvert.DeserializeObject<List<Object>>(result);
            foreach(Object x in test)
            {
                TipoDocumento tempTipoDocumento = JsonConvert.DeserializeObject<TipoDocumento>(x.ToString());
                tiposDocumento.Add(tempTipoDocumento);
                tiposDocumento2.Add(tempTipoDocumento);
            }

            cboTipoDocumentoEmpleado.DataSource = tiposDocumento;
            cboTipoDocumentoEmpleado.DisplayMember = "ValorTipoDocumento";
            cboTipoDocumentoEmpleado.ValueMember = "IdTipoDocumento";
            cboTipoDocumentoCliente.DataSource = tiposDocumento2;
            cboTipoDocumentoCliente.DisplayMember = "ValorTipoDocumento";
            cboTipoDocumentoCliente.ValueMember = "IdTipoDocumento";
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            AgregarEntrada();
        }

        private void InicializarDgvEntradas()
        {
            DataGridViewCheckBoxColumn columnSelectedSeat = new DataGridViewCheckBoxColumn();
            columnSelectedSeat.HeaderText = "Asiento Seleccionado";
            columnSelectedSeat.Name = "colAsientoElegido";

            DataGridViewButtonColumn columnButton = new DataGridViewButtonColumn();
            columnButton.UseColumnTextForButtonValue = true;
            columnButton.HeaderText = "Funcion";
            columnButton.Text = "Elegir Butaca";
            columnButton.Name = "colElegirButaca";
            dgvEntradas.Columns.Insert(0, columnButton);

            dgvEntradas.Columns.Add("colPrecio", "Precio");
            dgvEntradas.Columns["colPrecio"].ValueType = Type.GetType("System.Double", true);

            //dgvEntradas.Columns.Add("colCantidad", "Cantidad");
            //dgvEntradas.Columns["colCantidad"].ValueType = Type.GetType("System.Int32", true);

            dgvEntradas.Columns.Add("colButacaFuncion", "Butaca Funcion");
            dgvEntradas.Columns["colButacaFuncion"].Visible = false;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.HeaderText = "Eliminar";
            deleteButton.Text = "Quitar";
            deleteButton.Name = "colBotonEliminar";
            dgvEntradas.Columns.Insert(dgvEntradas.Columns.Count-1, deleteButton);
            dgvEntradas.Columns.Insert(dgvEntradas.Columns.Count - 1, columnSelectedSeat);
        }

        private void AgregarEntrada()
        {
            int lastRow = dgvEntradas.Rows.Add();
        }

        private void dgvEntradas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            switch (e.ColumnIndex)
            {
                case 0: //Elegir Butaca
                    if (dgvEntradas.Rows[e.RowIndex].Cells["colAsientoElegido"].Value != null)
                    {
                        MessageBox.Show("Si quiere reemplazar esta butaca, eliminela y seleccione otra", "Butaca ya seleccionada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    SettearEntrada(e.RowIndex);

                    break;

                case 1: //Precio
                    break;

                case 2: //Quitar
                    butacasSeleccionadas.Remove((ButacaFuncion)dgvEntradas["colButacaFuncion", e.RowIndex].Value);
                    dgvEntradas.Rows.RemoveAt(e.RowIndex);
                    break;

                default:
                    //Completar
                    break;
            }
        }

        private void SettearEntrada(int rowIndex)
        {
            //FormCompras formEleccionButaca = new FormCompras(true);
            using (FormCompras formEleccionButaca = new FormCompras(true, butacasSeleccionadas))
            {
                DialogResult result = formEleccionButaca.ShowDialog();
                if(result == DialogResult.OK)
                {
                    dgvEntradas.Rows[rowIndex].Cells["colButacaFuncion"].Value = 
                        formEleccionButaca.RetornoAComprobantes;
                    dgvEntradas.Rows[rowIndex].Cells["colAsientoElegido"].Value = true;
                    
                    //dgvEntradas.Rows[rowIndex].Cells["colElegirButaca"].
                    MessageBox.Show("Butaca Seleccionada Correctamente!", "Proceso Exitoso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //dgvEntradas.Rows[rowIndex].Cells["colElegirButaca"].ReadOnly = false;
                    dgvEntradas.Rows[rowIndex].Cells["colAsientoElegido"].Value = false;
                    dgvEntradas.Rows[rowIndex].Cells["colAsientoElegido"].Value = null;
                    MessageBox.Show("Hubo un error en la seleccion, intente nuevamente", "Proceso Fallido",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Seguro que desea salir?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
                this.Dispose();
        }
        private bool ValidarDatos()
        {
            bool validados = true;
            if (cboTipoDocumentoEmpleado.SelectedIndex == -1 ||
               cboTipoDocumentoCliente.SelectedIndex == -1 ||
               String.IsNullOrEmpty(txtDocumentoEmpleado.Text) ||
               String.IsNullOrEmpty(txtDocumentoCliente.Text) ||
               dgvEntradas.Rows.Count <= 0)
            {
                validados = false;
            }
            foreach (DataGridViewRow x in dgvEntradas.Rows)
            {
                if (x.Cells["colButacaFuncion"].Value == null)
                {
                    validados = false;
                    break;
                }
                else if (x.Cells["colPrecio"].Value == null)
                {
                    validados = false;
                    break;
                }
            }
            if(servicio.UsuarioExistente(txtDocumentoEmpleado.Text, 
                (int)cboTipoDocumentoEmpleado.SelectedValue) != 2)
            {
                MessageBox.Show("Los datos del empleado son erroneos", "Inserte un empleado valido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(servicio.UsuarioExistente(txtDocumentoCliente.Text,
                (int)cboTipoDocumentoCliente.SelectedValue) != 1)
            {
                MessageBox.Show("Los datos del cliente son erroneos", "Inserte un cliente valido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else if(!validados)
            {
                MessageBox.Show("Complete los campos de las entradas", "Proceso Fallido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return validados;
        }


        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            //inTipoDocEmpleado, inDocEmpleado, inTipoDocumentoCliente, inDocumentoCliente, ButacaFuncion
            //precio
            if (ValidarDatos())
            {
                List<ButacaFuncion> listaButacasFunciones = new List<ButacaFuncion>();
                List<decimal> listaPrecios = new List<decimal>();

                foreach(DataGridViewRow x in dgvEntradas.Rows)
                {
                    listaButacasFunciones.Add((ButacaFuncion)x.Cells["colButacaFuncion"].Value);
                    listaPrecios.Add(Convert.ToDecimal(x.Cells["colPrecio"].Value));
                }

                List<Parametro2> httpParams = new List<Parametro2>();
                httpParams.Add(new Parametro2("tipoDocEmp", (int)cboTipoDocumentoEmpleado.SelectedValue, tipoInt));
                httpParams.Add(new Parametro2("docEmp", txtDocumentoEmpleado.Text, tipoString));
                httpParams.Add(new Parametro2("tipoDocClie", (int)cboTipoDocumentoEmpleado.SelectedValue, tipoInt));
                httpParams.Add(new Parametro2("docClie", txtDocumentoCliente.Text, tipoString));
                for(int i = 0; i < listaButacasFunciones.Count; i++)
                {
                    httpParams.Add(new Parametro2("Butaca", listaButacasFunciones[i], tipoButacaFuncion));
                    httpParams.Add(new Parametro2("Precio", listaPrecios[i], tipoDecimal));
                }

                string url = "https://localhost:7291/api/Comprobantes/AgregarComprobante";
                string JsonString = JsonConvert.SerializeObject(httpParams);
                var resultado = await ClienteSingleton.GetInstancia().PostAsync(url, JsonString);
                bool aux = JsonConvert.DeserializeObject<bool>(resultado);
                //bool aux = servicio.AgregarComprobante(
                //    (int)cboTipoDocumentoEmpleado.SelectedValue,
                //    txtDocumentoEmpleado.Text,
                //    (int)cboTipoDocumentoCliente.SelectedValue,
                //    txtDocumentoCliente.Text,
                //    listaButacasFunciones,
                //    listaPrecios
                //    );
                if(aux) {
                    MessageBox.Show("Comprobante cargado correctamente", "Proceso Completado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoReset();
                }
                else
                {
                    MessageBox.Show("Hubo un error en la carga del comprobante", "Proceso Fallido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
