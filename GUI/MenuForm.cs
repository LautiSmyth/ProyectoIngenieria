using Servicios;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MenuForm : Form
    {
        private readonly LoginForm _loginForm;

        private readonly ConexionServicio _conexionServicio = new ConexionServicio();
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly Timer _timer = new Timer();

        private bool _cierreConfirmado = false;

        public MenuForm(LoginForm loginForm)
        {
            _loginForm = loginForm;
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + _usuarioServicio.ObtenerUsernameEnSesion();
            lblBaseDatos.Text = "Base de datos: " + _conexionServicio.ObtenerNombreBaseDatos();

            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            _timer.Start();
            ActualizarHora();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ActualizarHora();
        }

        private void ActualizarHora()
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void BtnBitacora_Click(object sender, EventArgs e)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form is BitacoraForm)
                {
                    form.Activate();
                    return;
                }
            }

            BitacoraForm bitacora = new BitacoraForm();
            bitacora.MdiParent = this;
            bitacora.Show();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cierreConfirmado)
                return;

            e.Cancel = true;
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Esta seguro que desea cerrar la sesion?",
                "Cerrar sesion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                _cierreConfirmado = true;
                _usuarioServicio.Logout(this.Text);
                this.Close();
            }
        }

        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
            _loginForm.Show();
        }
    }
}