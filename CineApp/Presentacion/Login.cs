using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineApp.EmpleadoLogin;
using CineApp.Presentacion;
using WinFormsTPPrueba;

namespace CineApp.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtuser_Enter(object sender, EventArgs e)
        {
            if(txtuser.Text == "USUARIO")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
        }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if( txtuser.Text == "")
            {
                txtuser.Text = "USUARIO";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "CONTRASEÑA")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "CONTRASEÑA";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;


            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if(txtuser.Text != "USUARIO")
            {
                if (txtpass.Text != "CONTRASEÑA")
                {
                    EmpeladoLogin empleado = new EmpeladoLogin();
                    var validLogin = empleado.empleadologin(txtuser.Text, txtpass.Text);
                    if (validLogin == true)
                    {
                        TestForm altaclientes = new TestForm();
                        altaclientes.ShowDialog();
                        this.Hide();

                    }
                    else
                    {
                        msgError("Incorrecto usuario o contraseña");
                    }

                } else { msgError("Porfavor Ingrese la contraseña"); }
                
                

            }  else { msgError("Por Favor ingrese el Usuario"); }
        }
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "  " + msg;
            lblErrorMessage.Visible = true;
        }
    }
}
