using Servicios;
using System;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConexionServicio conexionServicio = new ConexionServicio();

            if (!conexionServicio.VerificarConexion())
            {
                MessageBox.Show("No se puede conectar a la base de datos. Contacte al administrador.", "Error de conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DVServicio dvServicio = new DVServicio();

            if (!dvServicio.VerificarIntegridad())
            {
                MessageBox.Show(
                    "Se detectaron inconsistencias en la base de datos.\n" +
                    "Es posible que los datos hayan sido modificados por fuera del sistema.\n\n" +
                    "Contacte al administrador de inmediato.",
                    "Error de integridad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            Application.Run(new LoginForm());
        }
    }
}