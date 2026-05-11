using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class DVBLL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();
        private readonly DVVerticalDAL _dvVerticalDAL = new DVVerticalDAL();

        private const string TablaUsuario = "Usuario";

        public bool VerificarIntegridad()
        {
            List<Usuario> usuarios = _usuarioDAL.ObtenerTodos();

            foreach (Usuario usuario in usuarios)
            {
                int dvEsperado = DVCalculador.CalcularHorizontal(usuario);
                if (usuario.DV != dvEsperado)
                    return false;
            }

            DVVertical dvVertical = _dvVerticalDAL.Obtener(TablaUsuario);
            if (dvVertical == null)
                return false;

            int dvVerticalCalculado = DVCalculador.CalcularVertical(usuarios);
            if (dvVertical.Valor != dvVerticalCalculado)
                return false;

            return true;
        }

        public void RecalcularDVs(Usuario usuario)
        {
            usuario.DV = DVCalculador.CalcularHorizontal(usuario);
            _usuarioDAL.Actualizar(usuario);

            List<Usuario> todos = _usuarioDAL.ObtenerTodos();
            int dvVertical = DVCalculador.CalcularVertical(todos);
            _dvVerticalDAL.Actualizar(TablaUsuario, dvVertical);
        }

        public void AsignarDVAlta(Usuario usuario)
        {
            usuario.DV = DVCalculador.CalcularHorizontal(usuario);
        }

        public void RecalcularVertical()
        {
            List<Usuario> todos = _usuarioDAL.ObtenerTodos();
            int dvVertical = DVCalculador.CalcularVertical(todos);
            _dvVerticalDAL.Actualizar(TablaUsuario, dvVertical);
        }
    }
}
