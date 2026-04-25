using BE;
using System;
using System.Data.SqlClient;

namespace DAL
{
    public class BitacoraDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public void Insertar(Bitacora bitacora)
        {
            string consulta = @"INSERT INTO Bitacora (Fecha, UsuarioId, Username, Modulo, Actividad, Criticidad, Detalle, Error, Exitoso)
                                VALUES (@Fecha, @UsuarioId, @Username, @Modulo, @Actividad, @Criticidad, @Detalle, @Error, @Exitoso)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Fecha", bitacora.Fecha),
                new SqlParameter("@UsuarioId", (object)bitacora.UsuarioId ?? DBNull.Value),
                new SqlParameter("@Username", bitacora.Username),
                new SqlParameter("@Modulo", bitacora.Modulo),
                new SqlParameter("@Actividad", bitacora.Actividad),
                new SqlParameter("@Criticidad", (int)bitacora.Criticidad),
                new SqlParameter("@Detalle", bitacora.Detalle),
                new SqlParameter("@Error", bitacora.Error ?? ""),
                new SqlParameter("@Exitoso", bitacora.Exitoso)
            };

            _acceso.Escribir(consulta, parametros);
        }
    }
}
