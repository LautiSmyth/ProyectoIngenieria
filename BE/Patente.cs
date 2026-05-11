namespace BE
{
    // Hoja del Composite — permiso individual.
    // TienePermiso devuelve true solo si el nombre coincide exactamente.
    // No tiene hijos ni delega: es la unidad minima de permiso.
    public class Patente : ComponenteAcceso
    {
        public int IdPatente { get; set; }
        private readonly string _nombre;
        private readonly string _descripcion;

        public override string Nombre { get { return _nombre; } }
        public override string Descripcion { get { return _descripcion; } }

        public Patente(int idPatente, string nombre, string descripcion)
        {
            IdPatente = idPatente;
            _nombre = nombre;
            _descripcion = descripcion;
        }

        public override bool TienePermiso(string nombre)
        {
            return Nombre == nombre;
        }
    }
}
