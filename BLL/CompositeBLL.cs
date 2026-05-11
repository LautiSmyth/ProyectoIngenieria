using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CompositeBLL
    {
        private readonly FamiliaDAL _familiaDAL = new FamiliaDAL();
        private readonly PatenteDAL _patenteDAL = new PatenteDAL();

        public List<ComponenteAcceso> CargarAccesosUsuario(int idUsuario)
        {
            return _familiaDAL.ObtenerAccesosPorUsuario(idUsuario);
        }

        public List<Familia> ObtenerArbol()
        {
            return _familiaDAL.ObtenerArbolCompleto();
        }

        public List<Patente> ObtenerPatentes()
        {
            return _patenteDAL.ObtenerTodos();
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int idUsuario)
        {
            return _familiaDAL.ObtenerIdsFamiliasPorUsuario(idUsuario);
        }

        public List<int> ObtenerIdsPatentesDeF amilia(int idFamilia)
        {
            return _familiaDAL.ObtenerIdsPatentesDeF amilia(idFamilia);
        }

        public List<int> ObtenerIdsFamiliasHijasDeF amilia(int idFamilia)
        {
            return _familiaDAL.ObtenerIdsFamiliasHijasDeF amilia(idFamilia);
        }

        public List<int> ObtenerIdsTodasLasFamiliasHijas()
        {
            return _familiaDAL.ObtenerIdsTodasLasFamiliasHijas();
        }

        public void AgregarPatenteAFamilia(int idFamilia, int idPatente)
        {
            _familiaDAL.AgregarPatenteAFamilia(idFamilia, idPatente);
        }

        public void EliminarPatenteDeFamilia(int idFamilia, int idPatente)
        {
            _familiaDAL.EliminarPatenteDeFamilia(idFamilia, idPatente);
        }

        public void AgregarFamiliaAFamilia(int idFamilia, int idFamiliaHijo)
        {
            _familiaDAL.AgregarFamiliaAFamilia(idFamilia, idFamiliaHijo);
        }

        public void EliminarFamiliaDeFamilia(int idFamilia, int idFamiliaHijo)
        {
            _familiaDAL.EliminarFamiliaDeFamilia(idFamilia, idFamiliaHijo);
        }

        public void AsignarFamiliaAUsuario(int idUsuario, int idFamilia)
        {
            _familiaDAL.AsignarFamiliaAUsuario(idUsuario, idFamilia);
        }

        public void QuitarFamiliaDeUsuario(int idUsuario, int idFamilia)
        {
            _familiaDAL.QuitarFamiliaDeUsuario(idUsuario, idFamilia);
        }

        public void AltaPatente(Patente patente)
        {
            _patenteDAL.Insertar(patente);
        }

        public void ModificarPatente(Patente patente)
        {
            _patenteDAL.Actualizar(patente);
        }
    }
}