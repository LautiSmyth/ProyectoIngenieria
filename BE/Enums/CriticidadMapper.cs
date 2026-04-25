using System.Collections.Generic;

namespace BE.Enums
{
    public static class CriticidadMapper
    {
        private static readonly Dictionary<string, NivelCriticidad> _diccionario = new Dictionary<string, NivelCriticidad>
        {
            { "Login",              NivelCriticidad.Informativo },
            { "Logout",             NivelCriticidad.Informativo },
            { "Consulta",           NivelCriticidad.Informativo },
            { "Alta",               NivelCriticidad.Bajo },
            { "Modificacion",       NivelCriticidad.Medio },
            { "Eliminacion",        NivelCriticidad.Alto },
            { "CambioPassword",     NivelCriticidad.Critico },
            { "IntentoFallido",     NivelCriticidad.Alto },
            { "UsuarioBloqueado",   NivelCriticidad.Critico },
            { "CambioEstado",       NivelCriticidad.Alto },
        };

        public static NivelCriticidad Obtener(string actividad)
        {
            NivelCriticidad nivel;
            bool encontrado = _diccionario.TryGetValue(actividad, out nivel);

            if (encontrado)
                return nivel;
            else
                return NivelCriticidad.Informativo; // valor por defecto
        }
    }
}