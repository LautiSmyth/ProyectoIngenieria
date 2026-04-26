using BE;
using BE.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BitacoraDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Bitacora> ObtenerTodos()
        {
            const string consulta = "SELECT * FROM Bitacora ORDER BY Fecha DESC";
            DataTable tabla = _acceso.Leer(consulta, null);

            List<Bitacora> lista = new List<Bitacora>();

            foreach (DataRow fila in tabla.Rows)
            {
                Bitacora b = new Bitacora
                {
                    Id = Convert.ToInt32(fila["Id"]),
                    Fecha = Convert.ToDateTime(fila["Fecha"]),
                    Username = fila["Username"].ToString(),
                    Modulo = fila["Modulo"].ToString(),
                    Actividad = fila["Actividad"].ToString(),
                    Criticidad = (NivelCriticidad)Convert.ToInt32(fila["Criticidad"]),
                    Detalle = fila["Detalle"].ToString(),
                    Error = fila["Error"].ToString(),
                    Exitoso = Convert.ToBoolean(fila["Exitoso"])
                };

                if (fila["UsuarioId"] != DBNull.Value)
                    b.UsuarioId = Convert.ToInt32(fila["UsuarioId"]);

                lista.Add(b);
            }

            return lista;
        }

        public void Insertar(Bitacora bitacora)
        {
            const string consulta = @"INSERT INTO Bitacora (Fecha, UsuarioId, Username, Modulo, Actividad, Criticidad, Detalle, Error, Exitoso)
                                VALUES (@Fecha, @UsuarioId, @Username, @Modulo, @Actividad, @Criticidad, @Detalle, @Error, @Exitoso)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha",      bitacora.Fecha),
                new SqlParameter("@UsuarioId",  (object)bitacora.UsuarioId ?? DBNull.Value),
                new SqlParameter("@Username",   bitacora.Username),
                new SqlParameter("@Modulo",     bitacora.Modulo),
                new SqlParameter("@Actividad",  bitacora.Actividad),
                new SqlParameter("@Criticidad", (int)bitacora.Criticidad),
                new SqlParameter("@Detalle",    bitacora.Detalle),
                new SqlParameter("@Error",      bitacora.Error ?? ""),
                new SqlParameter("@Exitoso",    bitacora.Exitoso)
            };

            _acceso.Escribir(consulta, parametros);
        }
    }
}