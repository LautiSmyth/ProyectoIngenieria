using BE;
using BE.Enums;
using DAL;
using Seguridad;
using System;

namespace Servicios
{
    public class BitacoraServicios
    {
        private readonly BitacoraDAL _dal = new BitacoraDAL();

        // Registrar CON sesion activa — toma el usuario del SessionManager
        public void Registrar(string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            BE.Usuario usuario = SessionManager.GetInstance().Usuario;

            // Si no hay sesion activa, usar la sobrecarga sin sesion
            if (usuario == null)
            {
                Registrar("sin sesion", modulo, actividad, detalle, exitoso, error);
                return;
            }

            string detalleCompleto;
            if (exitoso)
                detalleCompleto = "El usuario '" + usuario.Username + "' realizo '" + actividad + "' en el modulo '" + modulo + "'. " + detalle;
            else
                detalleCompleto = "El usuario '" + usuario.Username + "' intento '" + actividad + "' en el modulo '" + modulo + "' pero ocurrio un error. " + detalle;

            NivelCriticidad criticidad = CriticidadMapper.Obtener(actividad);

            Bitacora registro = new Bitacora
            {
                Fecha = DateTime.Now,
                UsuarioId = usuario.Id,
                Username = usuario.Username,
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = criticidad,
                Detalle = detalleCompleto,
                Error = error,
                Exitoso = exitoso
            };

            _dal.Insertar(registro);
        }

        // Registrar SIN sesion activa (ej: intento de login fallido)
        public void Registrar(string usernameIngresado, string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            NivelCriticidad criticidad = CriticidadMapper.Obtener(actividad);

            Bitacora registro = new Bitacora
            {
                Fecha = DateTime.Now,
                UsuarioId = null,
                Username = usernameIngresado,
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = criticidad,
                Detalle = detalle,
                Error = error,
                Exitoso = exitoso
            };

            _dal.Insertar(registro);
        }
    }
}
