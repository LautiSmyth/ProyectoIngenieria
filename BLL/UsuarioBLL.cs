using System;
using DAL;
using BE;
using BE.Enums;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();

        public Usuario ObtenerYValidar(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");

            Usuario usuario = _dal.ObtenerPorUsername(username);

            if (usuario == null)
                throw new UnauthorizedAccessException("Usuario no encontrado.");

            if (usuario.Estado == EstadoUsuario.Bloqueado)
            {
                int minutos = 15;
                if(usuario.FechaBloqueo.HasValue && (DateTime.Now - usuario.FechaBloqueo.Value).TotalMinutes >= minutos)
                {
                    usuario.Estado = EstadoUsuario.Activo;
                    usuario.IntentosFallidos = 0;
                    usuario.FechaBloqueo = null;
                    _dal.Actualizar(usuario);
                }
                else
                {
                    throw new UnauthorizedAccessException($"Usuario bloqueado. Intente nuevamente en {minutos} minutos.");
                }
            }

            if (usuario.Estado == EstadoUsuario.Inactivo)
                throw new UnauthorizedAccessException("Usuario inactivo. Contacte al administrador.");

            return usuario;
        }

        public void RegistrarIntentoFallido(Usuario usuario)
        {
            usuario.IntentosFallidos++;

            if (usuario.IntentosFallidos >= 3)
            {
                usuario.Estado = EstadoUsuario.Bloqueado;
                usuario.FechaBloqueo = DateTime.Now;
            }

            _dal.Actualizar(usuario);
        }

        public void RegistrarLoginExitoso(Usuario usuario)
        {
            usuario.IntentosFallidos = 0;
            usuario.UltimoLogin = DateTime.Now;
            _dal.Actualizar(usuario);
        }
    }
}
