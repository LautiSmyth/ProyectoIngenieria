using BE;
using BE.Enums;
using System;
using System.Collections.Generic;

namespace BLL
{
    public static class CriticidadMapper
    {
        private static readonly Dictionary<string, NivelCriticidad> _diccionario = new Dictionary<string, NivelCriticidad>
        {
            { "Login",            NivelCriticidad.Informativo },
            { "Logout",           NivelCriticidad.Informativo },
            { "Consulta",         NivelCriticidad.Informativo },
            { "Alta",             NivelCriticidad.Bajo        },
            { "Modificacion",     NivelCriticidad.Medio       },
            { "Eliminacion",      NivelCriticidad.Alto        },
            { "CambioPassword",   NivelCriticidad.Critico     },
            { "IntentoFallido",   NivelCriticidad.Alto        },
            { "UsuarioBloqueado", NivelCriticidad.Critico     },
            { "CambioEstado",     NivelCriticidad.Alto        },
        };

        private static Dictionary<NivelCriticidad, CriticidadConfig> _configBD = new Dictionary<NivelCriticidad, CriticidadConfig>();

        static CriticidadMapper()
        {
            Recargar();
        }

        public static void Recargar()
        {
            try
            {
                DAL.CriticidadDAL dal = new DAL.CriticidadDAL();
                List<CriticidadConfig> lista = dal.ObtenerTodos();
                Dictionary<NivelCriticidad, CriticidadConfig> nuevo = new Dictionary<NivelCriticidad, CriticidadConfig>();

                foreach (CriticidadConfig config in lista)
                    nuevo[config.Nivel] = config;

                _configBD = nuevo;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[CriticidadMapper] Error al cargar desde BD: {ex.Message}");
            }
        }

        public static NivelCriticidad Obtener(string actividad)
        {
            NivelCriticidad nivel;
            bool encontrado = _diccionario.TryGetValue(actividad, out nivel);

            if (encontrado)
                return nivel;
            else
                return NivelCriticidad.Informativo;
        }

        public static CriticidadConfig ObtenerConfig(NivelCriticidad criticidad)
        {
            CriticidadConfig config;
            if (_configBD.TryGetValue(criticidad, out config))
                return config;

            return null;
        }

        public static List<CriticidadConfig> ObtenerTodos()
        {
            List<CriticidadConfig> lista = new List<CriticidadConfig>(_configBD.Values);
            lista.Sort((a, b) => a.Orden.CompareTo(b.Orden));
            return lista;
        }
    }
}