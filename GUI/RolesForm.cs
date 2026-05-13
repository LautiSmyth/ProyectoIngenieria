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

        private void RolesForm_Shown(object sender, EventArgs e)
        {
            splitMain.SplitterDistance = (int)(this.ClientSize.Width * 0.25);
            splitDerecho.SplitterDistance = (int)((this.ClientSize.Width - splitMain.SplitterDistance) * 0.65);
            CentrarBotones();
        }

        private void CentrarBotones()
        {
            int centro = pnlBotones.Height / 2;
            btnAgregar.Location = new System.Drawing.Point((pnlBotones.Width - btnAgregar.Width) / 2, centro - btnAgregar.Height - 4);
            btnQuitar.Location = new System.Drawing.Point((pnlBotones.Width - btnQuitar.Width) / 2, centro + 4);
        }

        private void CargarDatos()
        {
            _familias = _compositeServicio.ObtenerArbol();
            _todasLasPatentes = _compositeServicio.ObtenerPatentes();
            _idsTodasLasHijas = _compositeServicio.ObtenerIdsTodasLasFamiliasHijas();
            CargarArbol();
        }

        private void CargarArbol()
        {
            treeRoles.BeginUpdate();
            treeRoles.Nodes.Clear();

            foreach (Familia familia in _familias)
            {
                if (!EsHija(familia.IdFamilia))
                    treeRoles.Nodes.Add(CrearNodo(familia));
            }

            treeRoles.ExpandAll();
            treeRoles.EndUpdate();
        }

        private bool EsHija(int idFamilia)
        {
            return _idsTodasLasHijas.Contains(idFamilia);
        }

        private TreeNode CrearNodo(Familia familia)
        {
            TreeNode nodo = new TreeNode(familia.Nombre);
            nodo.Tag = familia;
            nodo.ImageIndex = 0;
            nodo.SelectedImageIndex = 0;

            foreach (ComponenteAcceso hijo in familia.ObtenerHijos())
            {
                if (hijo is Patente patente)
                {
                    TreeNode nodoPatente = new TreeNode(patente.Nombre);
                    nodoPatente.Tag = patente;
                    nodoPatente.ImageIndex = 1;
                    nodoPatente.SelectedImageIndex = 1;
                    nodo.Nodes.Add(nodoPatente);
                }
                else if (hijo is Familia subFamilia)
                {
                    nodo.Nodes.Add(CrearNodo(subFamilia));
                }
            }

            return nodo;
        }

        private void TreeRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _familiaSeleccionada = e.Node?.Tag as Familia;

            bool hayFamilia = _familiaSeleccionada != null;
            flpConfigurador.Enabled = hayFamilia;
            lblFamiliaSeleccionada.Text = hayFamilia ? $"Familia: {_familiaSeleccionada.Nombre}" : "Seleccione una familia";

            if (!hayFamilia)
            {
                lstDisponibles.Items.Clear();
                lstMiembros.Items.Clear();
                return;
            }

            CargarConfigurador();
        }

        private void CargarConfigurador()
        {
            List<int> patentesMiembros = _compositeServicio.ObtenerIdsPatentesDeFamilia(_familiaSeleccionada.IdFamilia);
            List<int> familiasMiembros = _compositeServicio.ObtenerIdsFamiliasHijasDeFamilia(_familiaSeleccionada.IdFamilia);

            lstDisponibles.BeginUpdate();
            lstDisponibles.Items.Clear();
            lstMiembros.BeginUpdate();
            lstMiembros.Items.Clear();

            foreach (Patente p in _todasLasPatentes)
            {
                PatenteItem item = new PatenteItem(p.IdPatente, p.Nombre);
                if (patentesMiembros.Contains(p.IdPatente))
                    lstMiembros.Items.Add(item);
                else
                    lstDisponibles.Items.Add(item);
            }

            foreach (Familia f in _familias)
            {
                if (f.IdFamilia == _familiaSeleccionada.IdFamilia) continue;
                FamiliaItem item = new FamiliaItem(f.IdFamilia, f.Nombre);
                if (familiasMiembros.Contains(f.IdFamilia))
                    lstMiembros.Items.Add(item);
                else
                    lstDisponibles.Items.Add(item);
            }

            lstDisponibles.EndUpdate();
            lstMiembros.EndUpdate();
        }

        private void ActualizarFamiliaSeleccionada()
        {
            if (_familiaSeleccionada == null) return;
            int id = _familiaSeleccionada.IdFamilia;
            _familiaSeleccionada = null;
            foreach (Familia f in _familias)
            {
                if (f.IdFamilia == id)
                {
                    _familiaSeleccionada = f;
                    break;
                }
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionada == null || lstDisponibles.SelectedItem == null) return;

            try
            {
                object seleccionado = lstDisponibles.SelectedItem;

                if (seleccionado is PatenteItem patenteItem)
                    _compositeServicio.AgregarPatenteAFamilia(_familiaSeleccionada.IdFamilia, patenteItem.IdPatente);
                else if (seleccionado is FamiliaItem familiaItem)
                    _compositeServicio.AgregarFamiliaAFamilia(_familiaSeleccionada.IdFamilia, familiaItem.IdFamilia);

                CargarDatos();
                ActualizarFamiliaSeleccionada();
                CargarConfigurador();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (_familiaSeleccionada == null || lstMiembros.SelectedItem == null) return;

            try
            {
                object seleccionado = lstMiembros.SelectedItem;

                if (seleccionado is PatenteItem patenteItem)
                    _compositeServicio.EliminarPatenteDeFamilia(_familiaSeleccionada.IdFamilia, patenteItem.IdPatente);
                else if (seleccionado is FamiliaItem familiaItem)
                    _compositeServicio.EliminarFamiliaDeFamilia(_familiaSeleccionada.IdFamilia, familiaItem.IdFamilia);

                CargarDatos();
                ActualizarFamiliaSeleccionada();
                CargarConfigurador();
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
                MessageBox.Show("Complete nombre y descripcion de la familia.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _compositeServicio.AltaFamilia(new Familia(0, nombre, descripcion));
                MessageBox.Show($"Familia '{nombre}' creada.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreFamilia.Text = "";
                txtDescripcionFamilia.Text = "";
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNuevaPatente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePatente.Text.Trim();
            string descripcion = txtDescripcionPatente.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion))
            {
                MessageBox.Show("Complete nombre y descripcion de la patente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _compositeServicio.AltaPatente(new Patente(0, nombre, descripcion));
                MessageBox.Show($"Patente '{nombre}' creada.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombrePatente.Text = "";
                txtDescripcionPatente.Text = "";
                CargarDatos();
                if (_familiaSeleccionada != null)
                    CargarConfigurador();
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

            public PatenteItem(int id, string nombre)
            { IdPatente = id; Nombre = nombre; }

            public override string ToString()
            { return $"[Patente] {Nombre}"; }
        }

        private class FamiliaItem
        {
            public int IdFamilia { get; }
            public string Nombre { get; }

            public FamiliaItem(int id, string nombre)
            { IdFamilia = id; Nombre = nombre; }

            public override string ToString()
            { return $"[Familia] {Nombre}"; }
        }
    }
}
