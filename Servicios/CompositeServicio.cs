using BE;
using BLL;
using System.Collections.Generic;

namespace Servicios
{
    public class CompositeServicio
    {
        private readonly CompositeBLL _bll = new CompositeBLL();

        public List<Familia> ObtenerArbol()
        {
            return _bll.ObtenerArbol();
        }

        public List<Patente> ObtenerPatentes()
        {
            return _bll.ObtenerPatentes();
        }

        public List<int> ObtenerIdsFamiliasPorUsuario(int idUsuario)
        {
            return _bll.ObtenerIdsFamiliasPorUsuario(idUsuario);
        }

        public List<int> ObtenerIdsPatentesDeFamilia(int idFamilia)
        {
            return _bll.ObtenerIdsPatentesDeFamilia(idFamilia);
        }

        public List<int> ObtenerIdsFamiliasHijasDeFamilia(int idFamilia)
        {
            return _bll.ObtenerIdsFamiliasHijasDeFamilia(idFamilia);
        }

        public List<int> ObtenerIdsTodasLasFamiliasHijas()
        {
            return _bll.ObtenerIdsTodasLasFamiliasHijas();
        }

        public void AgregarPatenteAFamilia(int idFamilia, int idPatente)
        {
            _bll.AgregarPatenteAFamilia(idFamilia, idPatente);
        }

        public void EliminarPatenteDeFamilia(int idFamilia, int idPatente)
        {
            _bll.EliminarPatenteDeFamilia(idFamilia, idPatente);
        }

        public void AgregarFamiliaAFamilia(int idFamilia, int idFamiliaHijo)
        {
            _bll.AgregarFamiliaAFamilia(idFamilia, idFamiliaHijo);
        }

        public void EliminarFamiliaDeFamilia(int idFamilia, int idFamiliaHijo)
        {
            _bll.EliminarFamiliaDeFamilia(idFamilia, idFamiliaHijo);
        }

        public void AsignarFamiliaAUsuario(int idUsuario, int idFamilia)
        {
            _bll.AsignarFamiliaAUsuario(idUsuario, idFamilia);
        }

        public void QuitarFamiliaDeUsuario(int idUsuario, int idFamilia)
        {
            _bll.QuitarFamiliaDeUsuario(idUsuario, idFamilia);
        }

        public void AltaFamilia(Familia familia)
        {
            _bll.AltaFamilia(familia);
        }

        public void AltaPatente(Patente patente)
        {
            _bll.AltaPatente(patente);
        }

        public void ModificarPatente(Patente patente)
        {
            _bll.ModificarPatente(patente);
        }
    }
}