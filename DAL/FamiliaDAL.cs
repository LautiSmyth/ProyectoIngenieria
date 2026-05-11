using BE;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class FamiliaDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public List<Familia> ObtenerArbolCompleto()
        {
            Dictionary<int, Familia> familias = new Dictionary<int, Familia>();
            DataTable tablaFamilias = _acceso.Leer(
                "SELECT IdFamilia, Nombre, Descripcion FROM Familia ORDER BY Nombre", null);

            foreach (DataRow fila in tablaFamilias.Rows)
            {
                Familia f = new Familia((int)fila["IdFamilia"], fila["Nombre"].ToString(), fila["Descripcion"].ToString());
                familias[f.IdFamilia] = f;
            }

            Dictionary<int, Patente> patentes = new Dictionary<int, Patente>();
            DataTable tablaPatentes = _acceso.Leer(
                "SELECT IdPatente, Nombre, Descripcion FROM Patente", null);

            foreach (DataRow fila in tablaPatentes.Rows)
            {
                Patente p = new Patente((int)fila["IdPatente"], fila["Nombre"].ToString(), fila["Descripcion"].ToString());
                patentes[p.IdPatente] = p;
            }

            DataTable tablaFamiliaPatente = _acceso.Leer(
                "SELECT IdFamilia, IdPatente FROM FamiliaPatente", null);

            foreach (DataRow fila in tablaFamiliaPatente.Rows)
            {
                int idFamilia = (int)fila["IdFamilia"];
                int idPatente = (int)fila["IdPatente"];
                if (familias.ContainsKey(idFamilia) && patentes.ContainsKey(idPatente))
                    familias[idFamilia].Agregar(patentes[idPatente]);
            }

            DataTable tablaFamiliaFamilia = _acceso.Leer(
                "SELECT IdFamilia, IdFamiliaHijo FROM FamiliaFamilia", null);

            foreach (DataRow fila in tablaFamiliaFamilia.Rows)
            {
                int idPadre = (int)fila["IdFamilia"];
                int idHijo = (int)fila["IdFamiliaHijo"];
                if (familias.ContainsKey(idPadre) && familias.ContainsKey(idHijo))
                    familias[idPadre].Agregar(familias[idHijo]);
            }

            return new List<Familia>(familias.Values);
        }

        public List<ComponenteAcceso> ObtenerAccesosPorUsuario(int idUsuario)
        {
            List<ComponenteAcceso> accesos = new List<ComponenteAcceso>();
            Dictionary<int, Familia> todasLasFamilias = new Dictionary<int, Familia>();

            foreach (Familia f in ObtenerArbolCompleto())
                todasLasFamilias[f.IdFamilia] = f;

            DataTable tablaFamilias = _acceso.Leer(
                "SELECT IdFamilia FROM UsuarioFamilia WHERE IdUsuario = @IdUsuario",
                new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) });

            foreach (DataRow fila in tablaFamilias.Rows)
            {
                int idFamilia = (int)fila["IdFamilia"];
                if (todasLasFamilias.ContainsKey(idFamilia))
                    accesos.Add(todasLasFamilias[idFamilia]);
            }

            DataTable tablaPatentes = _acceso.Leer(
                "SELECT p.IdPatente, p.Nombre, p.Descripcion FROM Patente p " +
                "INNER JOIN UsuarioPatente up ON p.IdPatente = up.IdPatente " +
                "WHERE up.IdUsuario = @IdUsuario",
                new SqlParameter[] { new SqlParameter("@IdUsuario", idUsuario) });

            foreach (DataRow fila in tablaPatentes.Rows)
            {
                accesos.Add(new Patente(
                    (int)fila["IdPatente"],
                    fila["Nombre"].ToString(),
                    fila["Descripcion"].ToString()
                ));
            }

            return accesos;
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int idUsuario)
        {
            List<int> ids = new List<int>();
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            DataTable tabla = _acceso.Leer(
                "SELECT IdFamilia FROM UsuarioFamilia WHERE IdUsuario = @IdUsuario", parametros);

            foreach (DataRow fila in tabla.Rows)
                ids.Add((int)fila["IdFamilia"]);

            return ids;
        }

        public List<int> ObtenerIdsPatentesDeFamilia(int idFamilia)
        {
            List<int> ids = new List<int>();
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", idFamilia)
            };
            DataTable tabla = _acceso.Leer(
                "SELECT IdPatente FROM FamiliaPatente WHERE IdFamilia = @IdFamilia", parametros);

            foreach (DataRow fila in tabla.Rows)
                ids.Add((int)fila["IdPatente"]);

            return ids;
        }

        public List<int> ObtenerIdsFamiliasHijasDeFamilia(int idFamilia)
        {
            List<int> ids = new List<int>();
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", idFamilia)
            };
            DataTable tabla = _acceso.Leer(
                "SELECT IdFamiliaHijo FROM FamiliaFamilia WHERE IdFamilia = @IdFamilia", parametros);

            foreach (DataRow fila in tabla.Rows)
                ids.Add((int)fila["IdFamiliaHijo"]);

            return ids;
        }

        public List<int> ObtenerIdsTodasLasFamiliasHijas()
        {
            List<int> ids = new List<int>();
            DataTable tabla = _acceso.Leer("SELECT IdFamiliaHijo FROM FamiliaFamilia", null);

            foreach (DataRow fila in tabla.Rows)
                ids.Add((int)fila["IdFamiliaHijo"]);

            return ids;
        }

        public void AgregarPatenteAFamilia(int idFamilia, int idPatente)
        {
            const string consulta =
                "IF NOT EXISTS (SELECT 1 FROM FamiliaPatente WHERE IdFamilia = @IdFamilia AND IdPatente = @IdPatente) " +
                "INSERT INTO FamiliaPatente (IdFamilia, IdPatente) VALUES (@IdFamilia, @IdPatente)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", idFamilia),
                new SqlParameter("@IdPatente", idPatente)
            };
            _acceso.Escribir(consulta, parametros);
        }

        public void EliminarPatenteDeFamilia(int idFamilia, int idPatente)
        {
            const string consulta =
                "DELETE FROM FamiliaPatente WHERE IdFamilia = @IdFamilia AND IdPatente = @IdPatente";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", idFamilia),
                new SqlParameter("@IdPatente", idPatente)
            };
            _acceso.Escribir(consulta, parametros);
        }

        public void AgregarFamiliaAFamilia(int idFamilia, int idFamiliaHijo)
        {
            const string consulta =
                "IF NOT EXISTS (SELECT 1 FROM FamiliaFamilia WHERE IdFamilia = @IdFamilia AND IdFamiliaHijo = @IdFamiliaHijo) " +
                "INSERT INTO FamiliaFamilia (IdFamilia, IdFamiliaHijo) VALUES (@IdFamilia, @IdFamiliaHijo)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", idFamilia),
                new SqlParameter("@IdFamiliaHijo", idFamiliaHijo)
            };
            _acceso.Escribir(consulta, parametros);
        }

        public void EliminarFamiliaDeFamilia(int idFamilia, int idFamiliaHijo)
        {
            const string consulta =
                "DELETE FROM FamiliaFamilia WHERE IdFamilia = @IdFamilia AND IdFamiliaHijo = @IdFamiliaHijo";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdFamilia", idFamilia),
                new SqlParameter("@IdFamiliaHijo", idFamiliaHijo)
            };
            _acceso.Escribir(consulta, parametros);
        }

        public void AsignarFamiliaAUsuario(int idUsuario, int idFamilia)
        {
            const string consulta =
                "IF NOT EXISTS (SELECT 1 FROM UsuarioFamilia WHERE IdUsuario = @IdUsuario AND IdFamilia = @IdFamilia) " +
                "INSERT INTO UsuarioFamilia (IdUsuario, IdFamilia) VALUES (@IdUsuario, @IdFamilia)";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@IdFamilia", idFamilia)
            };
            _acceso.Escribir(consulta, parametros);
        }

        public void QuitarFamiliaDeUsuario(int idUsuario, int idFamilia)
        {
            const string consulta =
                "DELETE FROM UsuarioFamilia WHERE IdUsuario = @IdUsuario AND IdFamilia = @IdFamilia";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario),
                new SqlParameter("@IdFamilia", idFamilia)
            };
            _acceso.Escribir(consulta, parametros);
        }
    }
}
