using Servicios;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class LoginForm : Form
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                _usuarioServicio.Login(txtUsername.Text, txtPassword.Text);

                MessageBox.Show("Bienvenido!", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            catch (UnauthorizedAccessException ex)
            {
                // Credenciales incorrectas, bloqueado, inactivo
                MessageBox.Show(ex.Message, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error inesperado. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}