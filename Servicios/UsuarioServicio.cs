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

        public void Alta(string modulo, string username, string password)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    Username = Encriptador.Cifrar(username),
                    PasswordHash = Encriptador.Hash(password),
                    Estado = EstadoUsuario.Activo,
                    FechaAlta = DateTime.Now,
                    IntentosFallidos = 0
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
                Usuario usuario = _bll.ObtenerPorUsername(Encriptador.Cifrar(username));
                if (usuario == null)
                {
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Credenciales invalidas.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                bool passwordCorrecta = Encriptador.Verificar(passwordIngresada, usuario.PasswordHash);

                if (!passwordCorrecta)
                {
                    _bll.RegistrarIntentoFallido(usuario);
                    _bitacora.RegistrarSinSesion(username, modulo, "IntentoFallido", "Credenciales invalidas.", false, "Credenciales invalidas.");
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }

                try
                {
                    _bll.ValidarEstado(usuario);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException("Usuario o contraseña incorrectos.");
                }
                _bll.RegistrarLoginExitoso(usuario);
                usuario.Username = Encriptador.Descifrar(usuario.Username);
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