using BE;
using BE.Enums;
using BLL;
using Seguridad;
using System;
using System.Collections.Generic;

namespace Servicios
{
    public class UsuarioServicio
    {
        private readonly UsuarioBLL _bll = new UsuarioBLL();
        private readonly BitacoraServicios _bitacora = new BitacoraServicios();
        private readonly CompositeBLL _compositeBLL = new CompositeBLL();

        public void Alta(string modulo, string username, string password)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    Username = username,
                    PasswordHash = Encriptador.Hash(password),
                    Estado = EstadoUsuario.Activo,
                    FechaAlta = DateTime.Now,
                    IntentosFallidos = 0,
                    CantidadBloqueos = 0
                };

                _bll.Alta(usuario);
                _bitacora.Registrar(modulo, "Alta", $"Alta de usuario '{username}'.", true);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.Registrar(modulo, "Alta", $"Error al dar de alta usuario '{username}'.", false, ex.Message);
                throw;
            }
        }

        public void Login(string modulo, string username, string passwordIngresada)
        {
            try
            {
                Usuario usuario = _bll.ObtenerPorUsername(username);
                if (usuario == null)
                {
                    ContadorSesion.GetInstance().RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Credenciales invalidas.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                bool passwordCorrecta = Encriptador.Verificar(passwordIngresada, usuario.PasswordHash);

                if (!passwordCorrecta)
                {
                    _bll.RegistrarIntentoFallido(usuario);
                    ContadorSesion.GetInstance().RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Credenciales invalidas.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                try
                {
                    _bll.ValidarEstado(usuario);
                }
                catch (UnauthorizedAccessException)
                {
                    ContadorSesion.GetInstance().RegistrarIntento();
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Cuenta bloqueada.", false, "Cuenta bloqueada.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                _bll.RegistrarLoginExitoso(usuario);
                ContadorSesion.GetInstance().Resetear();
                usuario.Accesos = _compositeBLL.CargarAccesosUsuario(usuario.IdUsuario);
                SessionManager.GetInstance().Login(usuario);
                _bitacora.Registrar(modulo, "Login", "Login exitoso.", true);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Error inesperado en login.", false, ex.Message);
                throw;
            }
        }

        public List<BE.Usuario> ObtenerTodos()
        {
            return _bll.ObtenerTodos();
        }

        public void CambiarEstado(string modulo, int idUsuario, BE.Enums.EstadoUsuario nuevoEstado)
        {
            BE.Usuario usuario = _bll.ObtenerPorId(idUsuario);
            _bll.CambiarEstado(usuario, nuevoEstado);
            _bitacora.Registrar(modulo, "CambioEstado", $"Estado cambiado a {nuevoEstado} para usuario '{usuario.Username}'.", true);
        }

        public bool LimiteAlcanzadoEnSesion()
        {
            return ContadorSesion.GetInstance().LimiteAlcanzado;
        }

        public bool TienePermiso(string nombre)
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;
            if (usuario == null)
                return false;

            return usuario.TienePermiso(nombre);
        }

        public void Logout(string modulo)
        {
            _bitacora.Registrar(modulo, "Logout", "Cierre de sesion.", true);
            SessionManager.GetInstance().Logout();
        }

        public string ObtenerUsernameEnSesion()
        {
            Usuario usuario = SessionManager.GetInstance().Usuario;

            if (usuario == null)
                return string.Empty;

            return usuario.Username;
        }
    }
}