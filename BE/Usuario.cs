using System;

namespace BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Enums.EstadoUsuario Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? UltimoLogin { get; set; }
        public int IntentosFallidos { get; set; }
        public DateTime? FechaBloqueo { get; set; }
    }
}