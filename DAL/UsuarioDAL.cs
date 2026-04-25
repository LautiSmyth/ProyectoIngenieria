using BE;
using BE.Enums;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public BE.Usuario ObtenerPorUsername(string username)
        {
            const string consulta = "SELECT * FROM Usuario WHERE Username = @Username";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };

            DataTable tabla = _acceso.Leer(consulta, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];

            BE.Usuario usuario = new BE.Usuario
            {
                Id = Convert.ToInt32(fila["Id"]),
                Username = fila["Username"].ToString(),
                PasswordHash = fila["PasswordHash"].ToString(),
                Estado = (EstadoUsuario)Convert.ToInt32(fila["Estado"]),
                FechaAlta = Convert.ToDateTime(fila["FechaAlta"]),
                IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"])
            };

            if (fila["UltimoLogin"] != DBNull.Value)
                usuario.UltimoLogin = Convert.ToDateTime(fila["UltimoLogin"]);

            if (fila["FechaBloqueo"] != DBNull.Value)
                usuario.FechaBloqueo = Convert.ToDateTime(fila["FechaBloqueo"]);

            return usuario;
        }

        public void Insertar(BE.Usuario usuario)
        {
            const string consulta = @"INSERT INTO Usuario (Username, PasswordHash, Estado, FechaAlta, IntentosFallidos)
                                      VALUES (@Username, @PasswordHash, @Estado, @FechaAlta, @IntentosFallidos)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Username", usuario.Username),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Estado", (int)usuario.Estado),
                new SqlParameter("@FechaAlta", usuario.FechaAlta),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos)
            };

            _acceso.Escribir(consulta, parametros);
        }

        public void Actualizar(BE.Usuario usuario)
        {
            const string consulta = @"UPDATE Usuario SET
                                          Estado = @Estado,
                                          IntentosFallidos = @IntentosFallidos,
                                          FechaBloqueo = @FechaBloqueo,
                                          UltimoLogin = @UltimoLogin
                                      WHERE Id = @Id";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id", usuario.Id),
                new SqlParameter("@Estado", (int)usuario.Estado),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@FechaBloqueo", (object)usuario.FechaBloqueo ?? DBNull.Value),
                new SqlParameter("@UltimoLogin", (object)usuario.UltimoLogin ?? DBNull.Value)
            };

            _acceso.Escribir(consulta, parametros);
        }
    }
}
