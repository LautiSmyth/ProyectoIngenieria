using DAL;

namespace Servicios
{
    public class ConexionServicio
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public bool VerificarConexion()
        {
            return _acceso.VerificarConexion();
        }
    }
}
