using BE;
using BE.Enums;
using BLL;
using Seguridad;
using System;

namespace Servicios
{
    public class UsuarioServicio
    {
        private readonly UsuarioBLL _bll = new UsuarioBLL();
        private readonly BitacoraServicios _bitacora = new BitacoraServicios();

        public void Alta(string username, string password)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    Username = username,
                    PasswordHash = Encriptador.Hash(password),
                    Estado = EstadoUsuario.Activo,
                    FechaAlta = DateTime.Now,
                    IntentosFallidos = 0
                };

                _bll.Alta(usuario);
                _bitacora.Registrar("Usuarios", "Alta", "Alta de usuario '" + username + "'.", true);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _bitacora.Registrar("Usuarios", "Alta", "Error al dar de alta usuario '" + username + "'.", false, ex.Message);
                throw;
            }
        }

        public void Login(string username, string passwordIngresada)
        {
            Usuario usuario = null;

            try
            {
                usuario = _bll.ObtenerYValidar(username);

                bool passwordCorrecta = Encriptador.Verificar(passwordIngresada, usuario.PasswordHash);

                if (!passwordCorrecta)
                {
                    _bll.RegistrarIntentoFallido(usuario);
                    _bitacora.Registrar(username, "Seguridad", "IntentoFallido", "Contraseña incorrecta.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Contraseña incorrecta.");
                }

                _bll.RegistrarLoginExitoso(usuario);
                SessionManager.GetInstance().Login(usuario);
                _bitacora.Registrar("Seguridad", "Login", "Login exitoso.", true);
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                string usernameLog = usuario != null ? usuario.Username : username;
                _bitacora.Registrar(usernameLog, "Seguridad", "IntentoFallido", "Error inesperado en login.", false, ex.Message);
                throw;
            }
        }

        public void Logout()
        {
            _bitacora.Registrar("Seguridad", "Logout", "Cierre de sesion.", true);
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
