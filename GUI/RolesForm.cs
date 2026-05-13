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
        private Familia _familiaSeleccionadaPermisos;
        private Familia _familiaSeleccionadaEstructura;

        public RolesForm()
        {
            InitializeComponent();
        }

        private void RolesForm_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void RolesForm_Shown(object sender, EventArgs e)
        {
            splitPermisos.SplitterDistance = (int)(splitPermisos.Width * 0.25);
            splitEstructura.SplitterDistance = (int)(splitEstructura.Width * 0.25);
            CentrarBotones(pnlBotonesPermisos, btnAgregarPermiso, btnQuitarPermiso);
            CentrarBotones(pnlBotonesEstructura, btnAgregarEstructura, btnQuitarEstructura);
        }

        private void CentrarBotones(Panel panel, Button btn1, Button btn2)
        {
            int centro = panel.Height / 2;
            btn1.Location = new System.Drawing.Point((panel.Width - btn1.Width) / 2, centro - btn1.Height - 4);
            btn2.Location = new System.Drawing.Point((panel.Width - btn2.Width) / 2, centro + 4);
        }

        private void CargarDatos()
        {
            _familias = _compositeServicio.ObtenerArbol();
            _todasLasPatentes = _compositeServicio.ObtenerPatentes();
            _idsTodasLasHijas = _compositeServicio.ObtenerIdsTodasLasFamiliasHijas();
            CargarArbol(treePermisos);
            CargarArbol(treeEstructura);
        }

        private void CargarArbol(TreeView tree)
        {
            tree.BeginUpdate();
            tree.Nodes.Clear();

            foreach (Familia familia in _familias)
            {
                if (!EsHija(familia.IdFamilia))
                    tree.Nodes.Add(CrearNodo(familia));
            }

            tree.ExpandAll();
            tree.EndUpdate();
        }

        private bool EsHija(int idFamilia)
        {
            return _idsTodasLasHijas.Contains(idFamilia);
        }

        private TreeNode CrearNodo(Familia familia)
        {
            TreeNode nodo = new TreeNode(familia.Nombre);
            nodo.Tag = familia;

            foreach (ComponenteAcceso hijo in familia.ObtenerHijos())
            {
                if (hijo is Patente patente)
                {
                    TreeNode nodoPatente = new TreeNode(patente.Nombre);
                    nodoPatente.Tag = patente;
                    nodo.Nodes.Add(nodoPatente);
                }
                else if (hijo is Familia subFamilia)
                {
                    nodo.Nodes.Add(CrearNodo(subFamilia));
                }
            }

            return nodo;
        }

        private void ActualizarFamiliaSeleccionada(ref Familia familiaSeleccionada)
        {
            if (familiaSeleccionada == null) return;
            int id = familiaSeleccionada.IdFamilia;
            familiaSeleccionada = null;
            foreach (Familia f in _familias)
            {
                if (f.IdFamilia == id)
                {
                    familiaSeleccionada = f;
                    break;
                }
            }
        }

        // ===================== PESTAÑA PERMISOS =====================

        private void TreePermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _familiaSeleccionadaPermisos = e.Node?.Tag as Familia;

            bool hayFamilia = _familiaSeleccionadaPermisos != null;
            pnlConfiguradorPermisos.Enabled = hayFamilia;
            lblFamiliaPermisos.Text = hayFamilia
                ? $"Familia: {_familiaSeleccionadaPermisos.Nombre}"
                : "Seleccione una familia del arbol";

            if (!hayFamilia)
            {
                lstMiembrosPermisos.Items.Clear();
                lstDisponiblesPermisos.Items.Clear();
                return;
            }

            CargarConfiguradorPermisos();
        }

        private void CargarConfiguradorPermisos()
        {
            List<int> asignadas = _compositeServicio.ObtenerIdsPatentesDeFamilia(_familiaSeleccionadaPermisos.IdFamilia);

            lstMiembrosPermisos.BeginUpdate();
            lstMiembrosPermisos.Items.Clear();
            lstDisponiblesPermisos.BeginUpdate();
            lstDisponiblesPermisos.Items.Clear();

            foreach (Patente p in _todasLasPatentes)
            {
                PatenteItem item = new PatenteItem(p.IdPatente, p.Nombre);
                if (asignadas.Contains(p.IdPatente))
                    lstMiembrosPermisos.Items.Add(item);
                else
                    lstDisponiblesPermisos.Items.Add(item);
            }

            lstMiembrosPermisos.EndUpdate();
            lstDisponiblesPermisos.EndUpdate();
        }

        private void BtnAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionadaPermisos == null || lstDisponiblesPermisos.SelectedItem == null) return;

            PatenteItem item = lstDisponiblesPermisos.SelectedItem as PatenteItem;
            if (item == null) return;

            try
            {
                _compositeServicio.AgregarPatenteAFamilia(_familiaSeleccionadaPermisos.IdFamilia, item.IdPatente);
                CargarDatos();
                ActualizarFamiliaSeleccionada(ref _familiaSeleccionadaPermisos);
                CargarConfiguradorPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarPermiso_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionadaPermisos == null || lstMiembrosPermisos.SelectedItem == null) return;

            PatenteItem item = lstMiembrosPermisos.SelectedItem as PatenteItem;
            if (item == null) return;

            try
            {
                _compositeServicio.EliminarPatenteDeFamilia(_familiaSeleccionadaPermisos.IdFamilia, item.IdPatente);
                CargarDatos();
                ActualizarFamiliaSeleccionada(ref _familiaSeleccionadaPermisos);
                CargarConfiguradorPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevaPatente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePatente.Text.Trim();
            string descripcion = txtDescripcionPatente.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Complete nombre y descripcion.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _compositeServicio.AltaPatente(new Patente(0, nombre, descripcion));
                MessageBox.Show($"Patente '{nombre}' creada.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombrePatente.Text = "";
                txtDescripcionPatente.Text = "";
                CargarDatos();
                if (_familiaSeleccionadaPermisos != null)
                {
                    ActualizarFamiliaSeleccionada(ref _familiaSeleccionadaPermisos);
                    CargarConfiguradorPermisos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== PESTAÑA ESTRUCTURA =====================

        private void TreeEstructura_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _familiaSeleccionadaEstructura = e.Node?.Tag as Familia;

            bool hayFamilia = _familiaSeleccionadaEstructura != null;
            pnlConfiguradorEstructura.Enabled = hayFamilia;
            lblFamiliaEstructura.Text = hayFamilia
                ? $"Familia: {_familiaSeleccionadaEstructura.Nombre}"
                : "Seleccione una familia del arbol";

            if (!hayFamilia)
            {
                lstMiembrosEstructura.Items.Clear();
                lstDisponiblesEstructura.Items.Clear();
                return;
            }

            CargarConfiguradorEstructura();
        }

        private void CargarConfiguradorEstructura()
        {
            List<int> asignadas = _compositeServicio.ObtenerIdsFamiliasHijasDeFamilia(_familiaSeleccionadaEstructura.IdFamilia);

            lstMiembrosEstructura.BeginUpdate();
            lstMiembrosEstructura.Items.Clear();
            lstDisponiblesEstructura.BeginUpdate();
            lstDisponiblesEstructura.Items.Clear();

            foreach (Familia f in _familias)
            {
                if (f.IdFamilia == _familiaSeleccionadaEstructura.IdFamilia) continue;
                FamiliaItem item = new FamiliaItem(f.IdFamilia, f.Nombre);
                if (asignadas.Contains(f.IdFamilia))
                    lstMiembrosEstructura.Items.Add(item);
                else
                    lstDisponiblesEstructura.Items.Add(item);
            }

            lstMiembrosEstructura.EndUpdate();
            lstDisponiblesEstructura.EndUpdate();
        }

        private void BtnAgregarEstructura_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionadaEstructura == null || lstDisponiblesEstructura.SelectedItem == null) return;

            FamiliaItem item = lstDisponiblesEstructura.SelectedItem as FamiliaItem;
            if (item == null) return;

            try
            {
                _compositeServicio.AgregarFamiliaAFamilia(_familiaSeleccionadaEstructura.IdFamilia, item.IdFamilia);
                CargarDatos();
                ActualizarFamiliaSeleccionada(ref _familiaSeleccionadaEstructura);
                CargarConfiguradorEstructura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarEstructura_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionadaEstructura == null || lstMiembrosEstructura.SelectedItem == null) return;

            FamiliaItem item = lstMiembrosEstructura.SelectedItem as FamiliaItem;
            if (item == null) return;

            try
            {
                _compositeServicio.EliminarFamiliaDeFamilia(_familiaSeleccionadaEstructura.IdFamilia, item.IdFamilia);
                CargarDatos();
                ActualizarFamiliaSeleccionada(ref _familiaSeleccionadaEstructura);
                CargarConfiguradorEstructura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevaFamilia_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreFamilia.Text.Trim();
            string descripcion = txtDescripcionFamilia.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Complete nombre y descripcion.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _compositeServicio.AltaFamilia(new Familia(0, nombre, descripcion));
                MessageBox.Show($"Familia '{nombre}' creada.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreFamilia.Text = "";
                txtDescripcionFamilia.Text = "";
                CargarDatos();
                if (_familiaSeleccionadaEstructura != null)
                {
                    ActualizarFamiliaSeleccionada(ref _familiaSeleccionadaEstructura);
                    CargarConfiguradorEstructura();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
