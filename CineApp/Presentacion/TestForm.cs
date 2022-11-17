using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineBackend.Dominio;
using CineBackend.Servicio;
using CineBackend.Datos;
using CineApp.Cliente;
using Newtonsoft.Json;
using CineApp;
using WinFormsTPPrueba.Presentacion;
using CineApp.Presentacion;
using ReportesCineApp.Presentacion;
using ReportesCineApp;
using ReportesCineApp.Reportes;

namespace WinFormsTPPrueba
{
    public partial class TestForm : Form
    {
        private IServicio helper;

        public TestForm()
        {
            InitializeComponent();
            helper = new Service();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            txtDocumento.Select();
            EstadoInicial();
            CargarCombos();
            LimpiarCampos(true);
        }

        //Hacer muchas funciones o una sola generica, para cargar combo
        private void CargarCombos()
        {
            //TipoDocumento
            List<TipoDocumento> tiposDocumento = new List<TipoDocumento>();
            tiposDocumento = helper.CargarComboTiposDocumento();
            cboTiposDocumento.DataSource = tiposDocumento;
            cboTiposDocumento.ValueMember = "IdTipoDocumento";
            cboTiposDocumento.DisplayMember = "ValorTipoDocumento";

            //Genero
            List<Genero> generos = new List<Genero>();
            generos = helper.CargarComboGenero();
            cboGeneros.DataSource = generos;
            cboGeneros.DisplayMember = "NombreGenero";
            cboGeneros.ValueMember = "IdGenero";

            //TiposClientes
            List<TipoCliente> tiposCliente = new List<TipoCliente>();
            tiposCliente = helper.CargarComboTiposCliente();
            cboCategorias.DataSource = tiposCliente;
            cboCategorias.DisplayMember = "ValorTipoCliente";
            cboCategorias.ValueMember = "IdTipoCliente";

            //Calles
            List<Calle> calles = new List<Calle>();
            calles = helper.CargarComboCalles();
            cboCalles.DataSource = calles;
            cboCalles.DisplayMember = "NombreCalle";
            cboCalles.ValueMember = "IdCalle";
        }

        private void LimpiarCampos(bool limpiarTodo)
        {
            if (limpiarTodo)
            {
                txtDocumento.Text = String.Empty;
                cboTiposDocumento.SelectedIndex = -1;
            }
            cboCategorias.SelectedIndex = -1;
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            cboGeneros.SelectedIndex = -1;
            dtpFechaNacimiento.Value = DateTime.Now;
            cboCalles.SelectedIndex = -1;
            nudAltura.Value = 1;
        }

        private void EstadoInicial()
        {
            EstadoUsuario(false, false);
            //grpRegistrarse.Visible = false;
            //btnRegistrarse.Visible = false;
            //grpRegistrarse.Enabled = false;
            //btnRegistrarse.Enabled = false;
            //btnAceptar.Visible = false;
            //btnAceptar.Enabled = false;
            //btnModificar.Visible = false;
            //btnEliminar.Visible = false;
            //menuApartados.BackColor = SystemColors.Control;
            //itemAcercaDe.Visible = false;
        }

        private void EstadoUsuario(bool state, bool empleado)
        {
            //Control de Campos
            //menuApartados.Enabled = state;
            itemAcercaDe.Enabled = !state;
            archivoToolStripMenuItem.Enabled = !state;
            itemAdquirirEntradas.Enabled = state;
            itemComprar.Enabled = state;
            itemMisEntradas.Enabled = state;
            reportesToolStripMenuItem.Enabled = state;
            grpRegistrarse.Visible = state;
            btnRegistrarse.Visible = state;
            //pablo
            btnModificar.Visible = state;
            btnEliminar.Visible = state;
            btnAceptar.Visible = state;
            //Limpiar Campos
            if (state) LimpiarCampos(false);
            //Color Apartados
            if(state) menuApartados.BackColor = Color.Bisque;
            else menuApartados.BackColor = SystemColors.Control;
            itemAcercaDe.Visible = true;
            //Control Label Instruccion
            if (state)
            {
                string nombre = helper.NombreDeUsuario(txtDocumento.Text, (int)cboTiposDocumento.SelectedValue);
                lblInstruccion.Text = $"Bienvenido {nombre}!";

                if (empleado) //Empleado
                {
                    itemAcercaDe.Visible = true;
                }
                else //Cliente
                {
                }
            }
            else lblInstruccion.Text = "Ingrese sus datos";
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtDocumento.Text) || cboTiposDocumento.SelectedIndex == -1)
            {
                MessageBox.Show("Ingrese su numero y tipo de documento.", "Rellene los campos necesarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            if( helper.UsuarioExistente(txtDocumento.Text, (int)cboTiposDocumento.SelectedValue) == 2)
            {
                MessageBox.Show("Empleado Validado", "Inicio de Sesion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                EstadoUsuario(true, true);
            }
            else if (helper.UsuarioExistente(txtDocumento.Text, (int)cboTiposDocumento.SelectedValue) == 1)
            {
                MessageBox.Show("Usuario Validado", "Inicio de Sesion", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                EstadoUsuario(true, false);
                DevolverDatosAsync(txtDocumento.Text);
                btnRegistrarse.Visible = false;
                btnAceptar.Enabled = false;
                menuApartados.Enabled = true;
                itemAcercaDe.Enabled = true;
                archivoToolStripMenuItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Usuario no encontrado, registrese para continuar", "Inicio de Sesion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                EstadoUsuario(true, false);
                btnAceptar.Visible = false;
                btnEliminar.Visible = false;
                btnModificar.Visible = false;
                menuApartados.Enabled = true;
                itemAcercaDe.Enabled = true;
                archivoToolStripMenuItem.Enabled = true;
            }
        }

        private async Task DevolverDatosAsync(string documento)
        {                       
            Cliente cliente = new Cliente();
            //cliente = helper.DevolverDatos(documento);
            string url = "https://localhost:7291/api/Comprobantes/" + documento.ToString();
            var resultado = await ClienteSingleton.GetInstancia().GetAsync(url);
            cliente = JsonConvert.DeserializeObject<Cliente>(resultado);

            //cboCategorias.SelectedIndex = (int)cliente.TipoCliente.IdTipoCliente - 1;
            cboCategorias.SelectedIndex = 2;
            txtApellido.Text = cliente.Apellido.ToString();
            txtNombre.Text = cliente.Nombre.ToString();
            cboGeneros.SelectedIndex = (int)cliente.Genero.IdGenero - 1;
            dtpFechaNacimiento.Value = cliente.FechaNac;
            cboCalles.SelectedIndex = (int)cliente.Calle.IdCalle - 1;
            nudAltura.Value = (int)cliente.Altura;

        }
        private bool ValidarCampos()
        {
            bool validados = true;

            if (String.IsNullOrEmpty(txtDocumento.Text) ||
                cboTiposDocumento.SelectedIndex == -1 ||
                cboCategorias.SelectedIndex == -1 ||
                String.IsNullOrEmpty(txtNombre.Text) ||
                String.IsNullOrEmpty(txtApellido.Text) ||
                cboGeneros.SelectedIndex == -1 ||
                DateTime.Compare(dtpFechaNacimiento.Value, DateTime.Today) > -1 ||
                cboCalles.SelectedIndex == -1
                )
            {
                validados = false;
            }

            return validados;
        }
        private async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Cliente tempCliente = new Cliente(helper.ProximoIdUsuario(),
                                                  txtApellido.Text,
                                                  txtNombre.Text,
                                                 (TipoCliente)cboCategorias.SelectedItem,
                                                 dtpFechaNacimiento.Value,
                                                 (TipoDocumento)cboTiposDocumento.SelectedItem,
                                                 txtDocumento.Text,
                                                 (Calle)cboCalles.SelectedItem,
                                                 (int)nudAltura.Value,
                                                 (Genero)cboGeneros.SelectedItem);
                tempCliente.Calle = helper.InformacionDeCalle(tempCliente.Calle);
                tempCliente.Baja = "N";

                //modif pablo
                var ok = await GrabarClienteAsync(tempCliente);


                if (ok/*helper.InsertarUsuario(tempCliente)*/)
                {
                    MessageBox.Show("Usuario registrado correctamente, ahora inicie sesion", "Operacion Completada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoInicial();
                    LimpiarCampos(false);

                }
                else
                {
                    MessageBox.Show("Se produjo un error durante el registro, intente mas tarde",
                        "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                string msg = String.Empty;
                if (DateTime.Compare(dtpFechaNacimiento.Value, DateTime.Today) > -1)
                    msg = "La fecha de nacimiento debe ser anterior al dia de hoy";
                else 
                    msg = "Por favor complete todos los campos para registrarse";
                MessageBox.Show(msg, "Complete los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNuevosComprobantes formCompras = new FormNuevosComprobantes();
            formCompras.Show();
        }

        private void btnRellenar_Click(object sender, EventArgs e)
        {
            txtDocumento.Text = "M5739619";
            cboTiposDocumento.SelectedValue = 4;
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {

            txtDocumento.Text = "35786985";
            cboTiposDocumento.SelectedValue = 0;
        }

        private async Task<bool> GrabarClienteAsync(Cliente cliente)
        {
            string url = "https://localhost:7291/api/Comprobantes/GrabarCliente";
            string clienteJSON = JsonConvert.SerializeObject(cliente);

            var result = await ClienteSingleton.GetInstancia().PostAsync(url, clienteJSON);
            return result.Equals("true");
        }

        
        private void itemMisEntradas_Click(object sender, EventArgs e)
        {
            ConsultarEntrada consulta = new ConsultarEntrada();
            consulta.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAcercaDe info = new FrmAcercaDe();
            info.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            grpRegistrarse.Enabled = true;
            btnModificar.Enabled = false;
            btnAceptar.Enabled = true;

        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                Cliente tempCliente = new Cliente();

                tempCliente.IdCliente = helper.IdUsuario(txtDocumento.Text,(int)cboTiposDocumento.SelectedIndex);
                tempCliente.Apellido = txtApellido.Text;
                tempCliente.Nombre = txtNombre.Text;
                tempCliente.TipoCliente = (TipoCliente)cboCategorias.SelectedItem;
                tempCliente.FechaNac = dtpFechaNacimiento.Value;
                tempCliente.TipoDocumento = (TipoDocumento)cboTiposDocumento.SelectedItem;
                tempCliente.Documento = txtDocumento.Text;
                tempCliente.Calle = (Calle)cboCalles.SelectedItem;
                tempCliente.Altura = (int)nudAltura.Value;
                tempCliente.Genero = (Genero)cboGeneros.SelectedItem;
                tempCliente.Calle = helper.InformacionDeCalle(tempCliente.Calle);
                tempCliente.Baja = "N";

                var ok = await ModificarClienteAsync(tempCliente);


                if (ok/*helper.ModificarUsuario(tempCliente)*/)
                {
                    MessageBox.Show("Usuario modificado correctamente", "Operacion Completada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EstadoInicial();
                    LimpiarCampos(false);

                }
                else
                {
                    MessageBox.Show("Se produjo un error durante la modificación, intente mas tarde",
                        "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                string msg = String.Empty;
                if (DateTime.Compare(dtpFechaNacimiento.Value, DateTime.Today) > -1)
                    msg = "La fecha de nacimiento debe ser anterior al dia de hoy";
                else
                    msg = "Por favor complete todos los campos para modificar";
                MessageBox.Show(msg, "Complete los campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task<bool> ModificarClienteAsync(Cliente cliente)
        {
            string url = "https://localhost:7291/api/Comprobantes/ModificarCliente";
            string clienteJSON = JsonConvert.SerializeObject(cliente);

            var result = await ClienteSingleton.GetInstancia().PutAsync(url, clienteJSON);
            return result.Equals("true");
        }

        private async void btnEliminar_ClickAsync(object sender, EventArgs e)
        {
            Cliente tempCliente = new Cliente();

            tempCliente.IdCliente = helper.IdUsuario(txtDocumento.Text, (int)cboTiposDocumento.SelectedIndex);
            tempCliente.Apellido = txtApellido.Text;
            tempCliente.Nombre = txtNombre.Text;
            tempCliente.TipoCliente = (TipoCliente)cboCategorias.SelectedItem;
            tempCliente.FechaNac = dtpFechaNacimiento.Value;
            tempCliente.TipoDocumento = (TipoDocumento)cboTiposDocumento.SelectedItem;
            tempCliente.Documento = txtDocumento.Text;
            tempCliente.Calle = (Calle)cboCalles.SelectedItem;
            tempCliente.Altura = (int)nudAltura.Value;
            tempCliente.Genero = (Genero)cboGeneros.SelectedItem;
            tempCliente.Calle = helper.InformacionDeCalle(tempCliente.Calle);
            tempCliente.Baja = "S";
            
            var ok = await EliminarClienteAsync(tempCliente);

            if (ok/*helper.EliminarUsuario(documento)*/)
            {
                MessageBox.Show("Usuario eliminado", "Operacion Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EstadoInicial();
            }
            else
                MessageBox.Show("Se produjo un error durante la eliminación, intente mas tarde","Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private async Task<bool> EliminarClienteAsync(Cliente cliente)
        {
            string url = "https://localhost:7291/api/Comprobantes/EliminarCliente";
            string clienteJSON = JsonConvert.SerializeObject(cliente);

            var result = await ClienteSingleton.GetInstancia().PutAsync(url, clienteJSON);
            return result.Equals("true");
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuReporte reportes = new MenuReporte();
            reportes.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea salir?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Dispose();
        }
    }
}
