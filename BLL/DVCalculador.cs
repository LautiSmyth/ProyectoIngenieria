using BE;
using System.Collections.Generic;

namespace BLL
{
    public static class DVCalculador
    {
        public static int CalcularHorizontal(Usuario usuario)
        {
            string[] campos = new string[]
            {
                usuario.IdUsuario.ToString(),
                usuario.Username,
                usuario.PasswordHash,
                ((int)usuario.Estado).ToString(),
                usuario.FechaAlta.ToString("yyyyMMddHHmmss"),
                usuario.UltimoLogin.HasValue ? usuario.UltimoLogin.Value.ToString("yyyyMMddHHmmss") : "0",
                usuario.IntentosFallidos.ToString(),
                usuario.CantidadBloqueos.ToString(),
                usuario.FechaBloqueo.HasValue ? usuario.FechaBloqueo.Value.ToString("yyyyMMddHHmmss") : "0"
            };

            int suma = 0;
            int posicion = 1;

            foreach (string campo in campos)
            {
                foreach (char caracter in campo)
                {
                    suma += caracter * posicion;
                    posicion++;
                }
            }

            return suma % 10;
        }

        public static int CalcularVertical(List<Usuario> usuarios)
        {
            int suma = 0;
            foreach (Usuario usuario in usuarios)
                suma += usuario.DV;

            return suma % 10;
        }
    }
}