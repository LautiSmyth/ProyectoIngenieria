using BE;
using Seguridad;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;
using DAL;

namespace Servicios
{
    public class Bitacora
    {
        private readonly BitacoraDAL _dal = new BitacoraDAL();

        // ── Registra un evento del usuario con sesión activa ──────────────────
        public void Registrar(int? usuarioId, string username, string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            BE.Usuario usuario = Seguridad.SessionManager.GetInstance().Usuario;
            if (usuario == null) return;

            string detalle = string.IsNullOrEmpty(error)
                ? $"El usuario '{usuario.Username}' realizo '{actividad}' en el modulo '{modulo}' (criticidad: {nivel})."
                : $"El usuario '{usuario.Username}' intento '{actividad}' en el modulo '{modulo}' pero ocurrio un error: {error}";

            _bitacoraDAL.Registrar(new BE.Bitacora
            {
                Fecha = DateTime.Now,
                UsuarioId = usuario.Id,
                Username = usuario.Username,
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = ,
                Detalle = detalle,
                Error = error,
            });
        }
    }
}
