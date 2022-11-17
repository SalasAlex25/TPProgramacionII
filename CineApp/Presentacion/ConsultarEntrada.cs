using CineApp.Cliente;
using CineBackend;
using CineBackend.Dominio;
using CineBackend.Servicio;
using Newtonsoft.Json;
using System.Data;

namespace CineApp
{
    public partial class ConsultarEntrada : Form
    {
        IServicio servicio;
        public ConsultarEntrada()
        {
            InitializeComponent();
            servicio = new Service();
        }

        private async void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboxTodos.Checked)
            {
                //DataTable tabla = servicio.Consulta_Comprobantes((int)cboClientes.SelectedValue);
                //dgvEntradas.DataSource = tabla;
                dgvEntradas.Rows.Clear();

                List<Parametro> filtros = new List<Parametro>();
                filtros.Add(new Parametro("@codigo", (int)cboClientes.SelectedValue));

                List<Comprobante> lst = servicio.Consulta_Comprobantes(filtros/*(int)cboClientes.SelectedValue*/);
                foreach (Comprobante comprobante in lst)
                {
                    dgvEntradas.Rows.Add(new object[] {
                    comprobante.IdComprobante,
                    comprobante.Fecha.ToString("dd/MM/yyyy"),
                    comprobante.Hora.ToString("HH:ss")
                    });
                }
            }
            else
            {
                List<Parametro> filtros = new List<Parametro>();
                filtros.Add(new Parametro("@fecha1", dtpFecha1.Value.ToShortDateString()));
                filtros.Add(new Parametro("@fecha2", dtpFecha2.Value.ToShortDateString()));
                filtros.Add(new Parametro("@codigo", (int)cboClientes.SelectedValue));
                
                DataTable tabla = servicio.Consulta_Comprobantes_Con_Filtro(dtpFecha1.Value, dtpFecha2.Value, (int)cboClientes.SelectedValue);
                dgvEntradas.DataSource = tabla;
                dgvEntradas.Rows.Clear();
                //List<Comprobante> lst = servicio.Consulta_Comprobantes_Con_Filtro(dtpFecha1.Value, dtpFecha2.Value, (int)cboClientes.SelectedValue);
                //List<Comprobante> lst = null;         

                //string filtrosJSON = JsonConvert.SerializeObject(filtros);
                //string url = "https://localhost:7291/api/Comprobantes/consultar";

                //var resultado = await ClienteSingleton.GetInstancia().PostAsync(url,filtrosJSON);

                //lst = JsonConvert.DeserializeObject<List<Comprobante>>(resultado);

                foreach (Comprobante comprobante in tabla.Rows)
                {
                    dgvEntradas.Rows.Add(new object[] {
                    comprobante.IdComprobante,
                    comprobante.Fecha.ToString("dd/MM/yyyy"),
                    comprobante.Hora.ToString("HH:ss")
                    });
                }
            }

            lblCompras.Text = "Total de compras: " + (dgvEntradas.Rows.Count - 1);

            if (cboxTodos.Checked)
                lblTotal.Text = "Total: $ " + servicio.Consulta_Total((int)cboClientes.SelectedValue);
            else
                lblTotal.Text = "Total: $ " + servicio.Consulta_Total_Con_Filtro(dtpFecha1.Value, dtpFecha2.Value, (int)cboClientes.SelectedValue);

        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatosClientes();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }

        private void ConsultarEntrada_Load(object sender, EventArgs e)
        {
            dtpFecha1.Value = DateTime.Now;
            dtpFecha2.Value = DateTime.Now.AddDays(7);

            ComboClientes();
            DatosClientes();
        }
        private void ComboClientes()
        {
            DataTable tabla = new DataTable();
            tabla = servicio.ConsultaClientes();
            cboClientes.DataSource = tabla;
            cboClientes.ValueMember = "Id_Cliente";
            cboClientes.DisplayMember = "Cliente";
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DatosClientes()
        {
            DataRowView cliente = (DataRowView)cboClientes.SelectedItem;

            DateTime fechaNac = Convert.ToDateTime(cliente.Row.ItemArray[4].ToString());
            int codigo = Convert.ToInt32(cliente.Row.ItemArray[0].ToString());

            DataTable tabla = servicio.ConsultaDatos(codigo);

            txtCorreo.Text = "";
            txtTelefono.Text = "";

            foreach (DataRow fila in tabla.Rows)
            {
                if (fila[1].Equals("Email"))
                {
                    txtCorreo.Text = fila[2].ToString();
                }
                else
                {
                    txtTelefono.Text = fila[2].ToString();
                }
            }

            txtFechaNac.Text = fechaNac.ToString("dd/MM/yyyy");

        }

        private void cboxTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxTodos.Checked)
            {
                dtpFecha1.Enabled = false;
                dtpFecha2.Enabled = false;
            }
            else
            {
                dtpFecha1.Enabled = true;
                dtpFecha2.Enabled = true;
            }
        }
    }
}