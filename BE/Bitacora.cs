using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int? UsuarioId { get; set; }
        public string Username { get; set; }
        public string Modulo { get; set; }
        public string Actividad { get; set; }
        public Enums.NivelCriticidad Criticidad { get; set; }
        public string Detalle { get; set; }
        public string Error { get; set; }
        public bool Exitoso { get; set; }
    }
}
