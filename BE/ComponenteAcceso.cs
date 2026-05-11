namespace BE
{
    public abstract class ComponenteAcceso
    {
        public abstract string Nombre { get; }
        public abstract string Descripcion { get; }

        public abstract bool TienePermiso(string nombre);
    }
}