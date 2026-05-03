using BE;
using BE.Enums;
using System.Collections.Generic;

namespace Servicios
{
    public class CriticidadServicio
    {
        public CriticidadConfig ObtenerConfig(NivelCriticidad criticidad)
        {
            return BLL.CriticidadMapper.ObtenerConfig(criticidad);
        }

        public List<CriticidadConfig> ObtenerTodos()
        {
            return BLL.CriticidadMapper.ObtenerTodos();
        }

        public void Recargar()
        {
            BLL.CriticidadMapper.Recargar();
        }
    }
}