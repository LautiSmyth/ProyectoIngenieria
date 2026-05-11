using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Usuario> ObtenerTodos()
        {
            const string consulta = "SELECT * FROM Usuario";
            DataTable tabla = _acceso.Leer(consulta, null);
            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow fila in tabla.Rows)
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                    Username = fila["Username"].ToString(),
                    PasswordHash = fila["PasswordHash"].ToString(),
                    Estado = (EstadoUsuario)Convert.ToInt32(fila["Estado"]),
                    FechaAlta = Convert.ToDateTime(fila["FechaAlta"]),
                    IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]),
                    CantidadBloqueos = Convert.ToInt32(fila["CantidadBloqueos"]),
                    DV = Convert.ToInt32(fila["DV"])
                };

                if (fila["UltimoLogin"] != DBNull.Value)
                    usuario.UltimoLogin = Convert.ToDateTime(fila["UltimoLogin"]);

                if (fila["FechaBloqueo"] != DBNull.Value)
                    usuario.FechaBloqueo = Convert.ToDateTime(fila["FechaBloqueo"]);

                lista.Add(usuario);
            }
            return lista;
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            const string consulta = "SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            DataTable tabla = _acceso.Leer(consulta, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            DataRow fila = tabla.Rows[0];
            Usuario usuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                Username = fila["Username"].ToString(),
                PasswordHash = fila["PasswordHash"].ToString(),
                Estado = (EstadoUsuario)Convert.ToInt32(fila["Estado"]),
                FechaAlta = Convert.ToDateTime(fila["FechaAlta"]),
                IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]),
                CantidadBloqueos = Convert.ToInt32(fila["CantidadBloqueos"]),
                DV = Convert.ToInt32(fila["DV"])
            };
            if (fila["UltimoLogin"] != DBNull.Value)
                usuario.UltimoLogin = Convert.ToDateTime(fila["UltimoLogin"]);
            if (fila["FechaBloqueo"] != DBNull.Value)
                usuario.FechaBloqueo = Convert.ToDateTime(fila["FechaBloqueo"]);
            return usuario;
        }

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

            Usuario usuario = new Usuario
            {
                IdUsuario = Convert.ToInt32(fila["IdUsuario"]),
                Username = fila["Username"].ToString(),
                PasswordHash = fila["PasswordHash"].ToString(),
                Estado = (EstadoUsuario)Convert.ToInt32(fila["Estado"]),
                FechaAlta = Convert.ToDateTime(fila["FechaAlta"]),
                IntentosFallidos = Convert.ToInt32(fila["IntentosFallidos"]),
                CantidadBloqueos = Convert.ToInt32(fila["CantidadBloqueos"]),
                DV = Convert.ToInt32(fila["DV"])
            };

            if (fila["UltimoLogin"] != DBNull.Value)
                usuario.UltimoLogin = Convert.ToDateTime(fila["UltimoLogin"]);

            if (fila["FechaBloqueo"] != DBNull.Value)
                usuario.FechaBloqueo = Convert.ToDateTime(fila["FechaBloqueo"]);

            return usuario;
        }

        public void Insertar(Usuario usuario)
        {
            const string consulta =
                "INSERT INTO Usuario (Username, PasswordHash, Estado, FechaAlta, IntentosFallidos, CantidadBloqueos, DV) " +
                "VALUES (@Username, @PasswordHash, @Estado, @FechaAlta, @IntentosFallidos, @CantidadBloqueos, @DV)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Username", usuario.Username),
                new SqlParameter("@PasswordHash", usuario.PasswordHash),
                new SqlParameter("@Estado", (int)usuario.Estado),
                new SqlParameter("@FechaAlta", usuario.FechaAlta),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@CantidadBloqueos", usuario.CantidadBloqueos),
                new SqlParameter("@DV", usuario.DV)
            };

            _acceso.Escribir(consulta, parametros);
        }

        public void Actualizar(Usuario usuario)
        {
            const string consulta =
                "UPDATE Usuario SET Estado = @Estado, IntentosFallidos = @IntentosFallidos, " +
                "CantidadBloqueos = @CantidadBloqueos, FechaBloqueo = @FechaBloqueo, UltimoLogin = @UltimoLogin, DV = @DV " +
                "WHERE IdUsuario = @IdUsuario";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", usuario.IdUsuario),
                new SqlParameter("@Estado", (int)usuario.Estado),
                new SqlParameter("@IntentosFallidos", usuario.IntentosFallidos),
                new SqlParameter("@CantidadBloqueos", usuario.CantidadBloqueos),
                new SqlParameter("@FechaBloqueo", (object)usuario.FechaBloqueo ?? DBNull.Value),
                new SqlParameter("@UltimoLogin", (object)usuario.UltimoLogin ?? DBNull.Value),
                new SqlParameter("@DV", usuario.DV)
            };

            _acceso.Escribir(consulta, parametros);
        }
    }
}