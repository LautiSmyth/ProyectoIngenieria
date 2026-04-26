using Servicios;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly ConexionServicio _conexionServicio = new ConexionServicio();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (!_conexionServicio.VerificarConexion())
            {
                MessageBox.Show("No hay conexion a la base de datos. Contacte al administrador.",
                                "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _usuarioServicio.Login(this.Text, txtUsername.Text, txtPassword.Text);

                MenuForm menu = new MenuForm();
                menu.Show();
                this.Hide();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error inesperado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Salir();
            }
        }

        private void Salir()
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Esta seguro que desea salir?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
                Application.Exit();
        }

        private void ChkHidePass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = chkHidePass.Checked;
        }
    }
}