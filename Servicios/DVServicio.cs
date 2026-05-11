using BLL;

namespace Servicios
{
    public class DVServicio
    {
        private readonly DVBLL _bll = new DVBLL();

        public bool VerificarIntegridad()
        {
            return _bll.VerificarIntegridad();
        }
    }
}