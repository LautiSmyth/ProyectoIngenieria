using BE;
using BE.Enums;
using DAL;
using Seguridad;
using System;

namespace Servicios
{
    public class Bitacora
    {
        private readonly BitacoraDAL _dal = new BitacoraDAL();

        public void Registrar(string modulo, string actividad, string error)
        {
            BE.Usuario usuario = SessionManager.GetInstance().Usuario;

            string detalleCompleto;
            if (string.IsNullOrEmpty(error))
            {
                detalleCompleto = $"El usuario '{usuario.Username}' realizo '{actividad}' en el modulo '{modulo}'. ";
            }
            else
            {
                detalleCompleto = $"El usuario {usuario.Username} intento {actividad} en el modulo {modulo} pero ocurrio un error.";
            }

            NivelCriticidad criticidad = CriticidadMapper.Obtener(actividad);

            BE.Bitacora registro = new BE.Bitacora() {
                Fecha = DateTime.Now,
                UsuarioId = usuario.Id,
                Username = usuario.Username,
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = criticidad,
                Detalle = detalleCompleto,
                Error = error
            };

            _dal.Insertar(registro);
        }

        public void Registrar(string usernameIngresado, string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            NivelCriticidad criticidad = CriticidadMapper.Obtener(actividad);

            BE.Bitacora registro = new BE.Bitacora() {
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
