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

        public Usuario ObtenerPorUsername(string username)
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

            Usuario _usuario = new Usuario
            {
                Id = Convert.ToInt32(fila["Id"]),
                NombreUsuario    = fila["NombreUsuario"].ToString(),
                Username = fila["Username"].ToString(),
                PasswordHash = fila["PasswordHash"].ToString(),
                Estado = (EstadoUsuario)Convert.ToInt32(fila["Estado"]),
                FechaAlta = Convert.ToDateTime(fila["FechaAlta"]),
                IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"])
            };

            if (fila["UltimoLogin"] != DBNull.Value)
                _usuario.UltimoLogin = Convert.ToDateTime(fila["UltimoLogin"]);

            if (fila["FechaBloqueo"] != DBNull.Value)
                _usuario.FechaBloqueo = Convert.ToDateTime(fila["FechaBloqueo"]);

            return _usuario;
        }

        public void Insertar(Usuario _usuario)
        {
            const string consulta = @"INSERT INTO Usuario (NombreUsuario, Username, PasswordHash, Estado, FechaAlta, IntentosFallidos)
                                VALUES (@NombreUsuario, @Username, @PasswordHash, @Estado, @FechaAlta, @IntentosFallidos)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", _usuario.NombreUsuario),
                new SqlParameter("@Username", _usuario.Username),
                new SqlParameter("@PasswordHash", _usuario.PasswordHash),
                new SqlParameter("@Estado", (int)_usuario.Estado),
                new SqlParameter("@FechaAlta", _usuario.FechaAlta),
                new SqlParameter("@IntentosFallidos", _usuario.IntentosFallidos)
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
                new SqlParameter("@UltimoLogin", (object)usuario.UltimoLogin  ?? DBNull.Value)
            };

            _acceso.Escribir(consulta, parametros);
        }
    }
}
