using System.Collections.Generic;

namespace BE
{
    public class Familia : ComponenteAcceso
    {
        public int IdFamilia { get; set; }
        private readonly string _nombre;
        private readonly string _descripcion;
        private readonly List<ComponenteAcceso> _hijos;

        public override string Nombre { get { return _nombre; } }
        public override string Descripcion { get { return _descripcion; } }

        public Familia(int idFamilia, string nombre, string descripcion)
        {
            IdFamilia = idFamilia;
            _nombre = nombre;
            _descripcion = descripcion;
            _hijos = new List<ComponenteAcceso>();
        }

        public void Agregar(ComponenteAcceso componente)
        {
            _hijos.Add(componente);
        }

        public void Eliminar(ComponenteAcceso componente)
        {
            _hijos.Remove(componente);
        }

        public List<ComponenteAcceso> ObtenerHijos()
        {
            return new List<ComponenteAcceso>(_hijos);
        }

        public override bool TienePermiso(string nombre)
        {
            foreach (ComponenteAcceso hijo in _hijos)
            {
                if (hijo.TienePermiso(nombre))
                    return true;
            }
            return false;
        }
    }
}
