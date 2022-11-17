using CineBackend.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineApp
{
    public partial class Sorteo : Form
    {
        private IServicio servicio;
        public Sorteo()
        {
            InitializeComponent();
            servicio = new Service();
        }

        private void Sorteo_Load(object sender, EventArgs e)
        {
            lblSorteo.Text = "Sorteo Año: " + DateTime.Now.ToString("yyyy");
            lblListado.Text = "Listado de los que mas compraron al " + DateTime.Now.ToString("dd/MM/yyyy");
            dgvSorteo.DataSource = CargarListado();
        }

        private DataTable CargarListado()
        {
            DataTable tabla = servicio.Sorteo();
            return tabla;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Puede ser sorteo entre los 5 que más compraron o un premio al que más compro
    }
}
