namespace DAL
{
    public class DVVerticalDAL
    {
        private readonly Acceso _acceso = Acceso.GetInstance();

        public DVVertical Obtener(string tabla)
        {
            const string consulta = "SELECT Tabla, Valor FROM DVVertical WHERE Tabla = @Tabla";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Tabla", tabla)
            };

            DataTable dt = _acceso.Leer(consulta, parametros);
            if (dt.Rows.Count == 0)
                return null;

            return new DVVertical
            {
                Tabla = dt.Rows[0]["Tabla"].ToString(),
                Valor = Convert.ToInt32(dt.Rows[0]["Valor"])
            };
        }

        public void Actualizar(string tabla, int valor)
        {
            const string consulta = "UPDATE DVVertical SET Valor = @Valor WHERE Tabla = @Tabla";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Tabla", tabla),
                new SqlParameter("@Valor", valor)
            };

            _acceso.Escribir(consulta, parametros);
        }
    }
}
