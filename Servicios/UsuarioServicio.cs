using System;
using BLL;
using BE;
using Seguridad;

namespace Servicios
{
    public class UsuarioServicio
    {
        private readonly UsuarioBLL        _bll      = new UsuarioBLL();
        private readonly BitacoraServicios _bitacora = new BitacoraServicios();

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
    }
}
