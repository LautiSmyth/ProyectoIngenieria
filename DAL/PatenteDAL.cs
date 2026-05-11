using BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PatenteDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Patente> ObtenerTodos()
        {
            const string consulta = "SELECT IdPatente, Nombre, Descripcion FROM Patente ORDER BY Nombre";
            DataTable tabla = _acceso.Leer(consulta, null);
            List<Patente> lista = new List<Patente>();

            foreach (DataRow fila in tabla.Rows)
                lista.Add(Mapear(fila));

            return lista;
        }

        public Patente ObtenerPorId(int idPatente)
        {
            const string consulta = "SELECT IdPatente, Nombre, Descripcion FROM Patente WHERE IdPatente = @IdPatente";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdPatente", idPatente)
            };
            DataTable tabla = _acceso.Leer(consulta, parametros);

            if (tabla.Rows.Count == 0)
                return null;

            return Mapear(tabla.Rows[0]);
        }

        public void Insertar(Patente patente)
        {
            const string consulta =
                "INSERT INTO Patente (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", patente.Nombre),
                new SqlParameter("@Descripcion", patente.Descripcion)
            };

            _acceso.Escribir(consulta, parametros);
        }

        public void Actualizar(Patente patente)
        {
            const string consulta =
                "UPDATE Patente SET Nombre = @Nombre, Descripcion = @Descripcion WHERE IdPatente = @IdPatente";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdPatente", patente.IdPatente),
                new SqlParameter("@Nombre", patente.Nombre),
                new SqlParameter("@Descripcion", patente.Descripcion)
            };

            _acceso.Escribir(consulta, parametros);
        }

        public void Eliminar(int idPatente)
        {
            const string consulta = "DELETE FROM Patente WHERE IdPatente = @IdPatente";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdPatente", idPatente)
            };
            _acceso.Escribir(consulta, parametros);
        }

        private Patente Mapear(DataRow fila)
        {
            return new Patente(
                (int)fila["IdPatente"],
                fila["Nombre"].ToString(),
                fila["Descripcion"].ToString()
            );
        }
    }
}