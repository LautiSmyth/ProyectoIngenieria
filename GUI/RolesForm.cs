using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class RolesForm : Form
    {
        private readonly CompositeServicio _compositeServicio = new CompositeServicio();
        private List<Familia> _familias;
        private List<Patente> _todasLasPatentes;
        private List<int> _idsTodasLasHijas;
        private Familia _familiaSeleccionada;

        public RolesForm()
        {
            InitializeComponent();
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            _familias = _compositeServicio.ObtenerArbol();
            _todasLasPatentes = _compositeServicio.ObtenerPatentes();
            _idsTodasLasHijas = _compositeServicio.ObtenerIdsTodasLasFamiliasHijas();
            CargarArbol();
            CargarComboPatenteNueva();
        }

        private void CargarArbol()
        {
            treeRoles.BeginUpdate();
            treeRoles.Nodes.Clear();

            foreach (Familia familia in _familias)
            {
                // Solo agrega familias raiz (las que no son hijas de ninguna otra)
                if (!EsHija(familia.IdFamilia))
                    treeRoles.Nodes.Add(CrearNodo(familia));
            }

            treeRoles.ExpandAll();
            treeRoles.EndUpdate();
        }

        // Verifica si una familia es hija de alguna otra usando la lista ya cargada en memoria.
        // Evita hacer N consultas a la BD — una sola consulta alcanza para todas las familias.
        private bool EsHija(int idFamilia)
        {
            return _idsTodasLasHijas.Contains(idFamilia);
        }

        // Crea un nodo del TreeView a partir de una Familia recorriendo sus hijos recursivamente.
        // Usa polimorfismo: llama TienePermiso y ObtenerHijos sin is/as/GetType.
        private TreeNode CrearNodo(Familia familia)
        {
            TreeNode nodo = new TreeNode($"[Familia] {familia.Nombre}");
            nodo.Tag = familia;

            foreach (ComponenteAcceso hijo in familia.ObtenerHijos())
            {
                // Patente — nodo hoja
                if (hijo is Patente patente)
                {
                    TreeNode nodoPatente = new TreeNode($"[Patente] {patente.Nombre}");
                    nodoPatente.Tag = patente;
                    nodo.Nodes.Add(nodoPatente);
                }
                // Sub-Familia — nodo contenedor recursivo
                else if (hijo is Familia subFamilia)
                {
                    nodo.Nodes.Add(CrearNodo(subFamilia));
                }
            }

            return nodo;
        }

        private void CargarComboPatenteNueva()
        {
            cboPatentesDisponibles.BeginUpdate();
            cboPatentesDisponibles.Items.Clear();
            foreach (Patente p in _todasLasPatentes)
                cboPatentesDisponibles.Items.Add(new PatenteItem(p.IdPatente, p.Nombre));
            cboPatentesDisponibles.EndUpdate();

            if (cboPatentesDisponibles.Items.Count > 0)
                cboPatentesDisponibles.SelectedIndex = 0;
        }

        private void TreeRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _familiaSeleccionada = e.Node.Tag as Familia;

            bool hayFamilia = _familiaSeleccionada != null;
            grpPatentes.Enabled = hayFamilia;
            grpSubFamilias.Enabled = hayFamilia;

            if (!hayFamilia) return;

            CargarPatentesDeFamilia();
            CargarSubFamiliasDeFamilia();
        }

        private void CargarPatentesDeFamilia()
        {
            List<int> asignadas = _compositeServicio.ObtenerIdsPatentesDeF amilia(_familiaSeleccionada.IdFamilia);

            chkListPatentes.BeginUpdate();
            chkListPatentes.Items.Clear();
            foreach (Patente p in _todasLasPatentes)
                chkListPatentes.Items.Add(new PatenteItem(p.IdPatente, p.Nombre), asignadas.Contains(p.IdPatente));
            chkListPatentes.EndUpdate();
        }

        private void CargarSubFamiliasDeFamilia()
        {
            List<int> asignadas = _compositeServicio.ObtenerIdsFamiliasHijasDeF amilia(_familiaSeleccionada.IdFamilia);

            chkListSubFamilias.BeginUpdate();
            chkListSubFamilias.Items.Clear();
            foreach (Familia f in _familias)
            {
                if (f.IdFamilia == _familiaSeleccionada.IdFamilia) continue;
                chkListSubFamilias.Items.Add(new FamiliaItem(f.IdFamilia, f.Nombre), asignadas.Contains(f.IdFamilia));
            }
            chkListSubFamilias.EndUpdate();
        }

        private void BtnGuardarPatentes_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionada == null) return;

            try
            {
                List<int> actuales = _compositeServicio.ObtenerIdsPatentesDeF amilia(_familiaSeleccionada.IdFamilia);

                for (int i = 0; i < chkListPatentes.Items.Count; i++)
                {
                    PatenteItem item = chkListPatentes.Items[i] as PatenteItem;
                    if (item == null) continue;

                    bool estaChecked = chkListPatentes.GetItemChecked(i);
                    bool yaAsignada = actuales.Contains(item.IdPatente);

                    if (estaChecked && !yaAsignada)
                        _compositeServicio.AgregarPatenteAFamilia(_familiaSeleccionada.IdFamilia, item.IdPatente);
                    else if (!estaChecked && yaAsignada)
                        _compositeServicio.EliminarPatenteDeFamilia(_familiaSeleccionada.IdFamilia, item.IdPatente);
                }

                MessageBox.Show("Patentes actualizadas correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar patentes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardarSubFamilias_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionada == null) return;

            try
            {
                List<int> actuales = _compositeServicio.ObtenerIdsFamiliasHijasDeF amilia(_familiaSeleccionada.IdFamilia);

                for (int i = 0; i < chkListSubFamilias.Items.Count; i++)
                {
                    FamiliaItem item = chkListSubFamilias.Items[i] as FamiliaItem;
                    if (item == null) continue;

                    bool estaChecked = chkListSubFamilias.GetItemChecked(i);
                    bool yaAsignada = actuales.Contains(item.IdFamilia);

                    if (estaChecked && !yaAsignada)
                        _compositeServicio.AgregarFamiliaAFamilia(_familiaSeleccionada.IdFamilia, item.IdFamilia);
                    else if (!estaChecked && yaAsignada)
                        _compositeServicio.EliminarFamiliaDeFamilia(_familiaSeleccionada.IdFamilia, item.IdFamilia);
                }

                MessageBox.Show("Sub-Familias actualizadas correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar sub-familias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAltaPatente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombrePatente.Text) || string.IsNullOrEmpty(txtDescripcionPatente.Text))
            {
                MessageBox.Show("Complete nombre y descripcion.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Patente nueva = new Patente(0, txtNombrePatente.Text.Trim(), txtDescripcionPatente.Text.Trim());
                _compositeServicio.AltaPatente(nueva);
                MessageBox.Show($"Patente '{nueva.Nombre}' creada correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombrePatente.Text = "";
                txtDescripcionPatente.Text = "";
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear patente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class PatenteItem
        {
            public int IdPatente { get; }
            public string Nombre { get; }
            public PatenteItem(int id, string nombre) { IdPatente = id; Nombre = nombre; }
            public override string ToString() { return Nombre; }
        }

        private class FamiliaItem
        {
            public int IdFamilia { get; }
            public string Nombre { get; }
            public FamiliaItem(int id, string nombre) { IdFamilia = id; Nombre = nombre; }
            public override string ToString() { return Nombre; }
        }
    }
}
