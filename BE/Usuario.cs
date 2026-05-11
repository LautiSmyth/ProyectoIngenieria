using System;
using System.Collections.Generic;

namespace BE
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Enums.EstadoUsuario Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public int IntentosFallidos { get; set; }
        public int CantidadBloqueos { get; set; }
        public int DV { get; set; }
        public DateTime? FechaBloqueo { get; set; }

        // Accesos cargados en memoria al hacer login — no se persisten en esta lista
        public List<ComponenteAcceso> Accesos { get; set; } = new List<ComponenteAcceso>();

        // Verifica si el usuario tiene un permiso recorriendo sus accesos
        // usando polimorfismo puro — sin is, as ni GetType()
        public bool TienePermiso(string nombre)
        {
            foreach (ComponenteAcceso acceso in Accesos)
            {
                if (acceso.TienePermiso(nombre))
                    return true;
            }
            return false;
        }
    }
}
