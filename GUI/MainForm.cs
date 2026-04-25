using Servicios;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private readonly ConexionServicio _conexionServicio = new ConexionServicio();
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly Timer _timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
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
            BitacoraForm form = new BitacoraForm { MdiParent = this };
            form.Show();
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Esta seguro que desea cerrar la sesion?",
                "Cerrar sesion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                _usuarioServicio.Logout();

                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
