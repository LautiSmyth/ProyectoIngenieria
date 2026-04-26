using BE;
using BE.Enums;
using DAL;
using System;

namespace BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL _dal = new UsuarioDAL();

        public Usuario ObtenerYValidar(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");

            Usuario usuario = _dal.ObtenerPorUsername(username) ?? throw new UnauthorizedAccessException("Usuario no encontrado.");
            if (usuario.Estado == EstadoUsuario.Bloqueado)
            {
                const int minutos = 15;
                bool pasaronLosMinutos = usuario.FechaBloqueo.HasValue &&
                                        (DateTime.Now - usuario.FechaBloqueo.Value).TotalMinutes >= minutos;

                if (pasaronLosMinutos)
                {
                    usuario.Estado = EstadoUsuario.Activo;
                    usuario.IntentosFallidos = 0;
                    usuario.FechaBloqueo = null;
                    _dal.Actualizar(usuario);
                }
                else
                {
                    throw new UnauthorizedAccessException("Usuario bloqueado. Intente nuevamente en " + minutos + " minutos.");
                }
            }

            if (usuario.Estado == EstadoUsuario.Inactivo)
                throw new UnauthorizedAccessException("Usuario inactivo. Contacte al administrador.");

            return usuario;
        }

        public void Alta(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Username))
                throw new ArgumentException("El nombre de usuario no puede estar vacio.");

            if (string.IsNullOrEmpty(usuario.PasswordHash))
                throw new ArgumentException("La contraseña no puede estar vacia.");

            Usuario existente = _dal.ObtenerPorUsername(usuario.Username);
            if (existente != null)
                throw new ArgumentException("El nombre de usuario ya existe.");

            _dal.Insertar(usuario);
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