namespace BE
{
    public class Patente : ComponenteAcceso
    {
        public int IdPatente { get; set; }
        private readonly string _nombre;
        private readonly string _descripcion;

        public override string Nombre { get { return _nombre; } }
        public override string Descripcion { get { return _descripcion; } }

        public Patente(int idPatente, string nombre, string descripcion)
        {
            IdPatente    = idPatente;
            _nombre      = nombre;
            _descripcion = descripcion;
        }

        public override bool TienePermiso(string nombre)
        {
            return Nombre == nombre;
        }
    }
}
