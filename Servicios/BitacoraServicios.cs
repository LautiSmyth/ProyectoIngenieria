using BE;
using BLL;
using DAL;
using Seguridad;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class BitacoraServicios
    {
        private readonly BitacoraDAL _dal = new BitacoraDAL();

        public List<Bitacora> ObtenerTodos()
        {
            List<Bitacora> lista = _dal.ObtenerTodos();
            foreach (Bitacora b in lista)
                b.Username = Encriptador.Descifrar(b.Username);
            return lista;
        }

        public void Registrar(string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;

            if (usuario == null)
            {
                RegistrarSinSesion("sin sesion", modulo, actividad, detalle, exitoso, error);
                return;
            }

            string detalleCompleto;
            if (exitoso)
                detalleCompleto = $"El usuario '{usuario.Username}' realizo '{actividad}' en el modulo '{modulo}'. {detalle}";
            else
                detalleCompleto = $"El usuario '{usuario.Username}' intento '{actividad}' en el modulo '{modulo}' pero ocurrio un error. {detalle}";

            Bitacora registro = new Bitacora
            {
                Fecha = DateTime.Now,
                IdUsuario = usuario.IdUsuario,
                Username = Encriptador.Cifrar(usuario.Username),
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = CriticidadMapper.Obtener(actividad),
                Detalle = detalleCompleto,
                Error = error,
                Exitoso = exitoso
            };

            _dal.Insertar(registro);
        }

        public void RegistrarSinSesion(string usernameIngresado, string modulo, string actividad, string detalle, bool exitoso, string error = "")
        {
            Bitacora registro = new Bitacora
            {
                Fecha = DateTime.Now,
                IdUsuario = null,
                Username = Encriptador.Cifrar(usernameIngresado),
                Modulo = modulo,
                Actividad = actividad,
                Criticidad = CriticidadMapper.Obtener(actividad),
                Detalle = detalle,
                Error = error,
                Exitoso = exitoso
            };

            _dal.Insertar(registro);
        }
    }
}