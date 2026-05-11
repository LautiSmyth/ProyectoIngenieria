using BE;
using BE.Enums;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class UsuariosForm : Form
    {
        private readonly UsuarioServicio _usuarioServicio = new UsuarioServicio();
        private readonly CompositeServicio _compositeServicio = new CompositeServicio();
        private List<Usuario> _usuarios;
        private List<Familia> _familias;
        private Usuario _usuarioSeleccionado;
        private bool _columnasConfiguradas = false;

        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            splitPrincipal.SplitterDistance = (int)(this.ClientSize.Height * 0.55);
            cboEstado.DataSource = Enum.GetValues(typeof(EstadoUsuario));
            CargarDatos();
        }

        private void CargarDatos()
        {
            _usuarios = _usuarioServicio.ObtenerTodos();
            _familias = _compositeServicio.ObtenerArbol();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = _usuarios;

            if (!_columnasConfiguradas && dgvUsuarios.Columns.Count > 0)
            {
                string[] columnasOcultas = { "PasswordHash", "DV", "IntentosFallidos", "CantidadBloqueos", "FechaBloqueo", "Accesos" };
                foreach (string col in columnasOcultas)
                    if (dgvUsuarios.Columns[col] != null)
                        dgvUsuarios.Columns[col].Visible = false;
                _columnasConfiguradas = true;
            }

            CargarComboFamilias();
        }

        private void CargarComboFamilias()
        {
            cboFamilias.BeginUpdate();
            cboFamilias.Items.Clear();
            foreach (Familia f in _familias)
                cboFamilias.Items.Add(new FamiliaItem(f.IdFamilia, f.Nombre));
            if (cboFamilias.Items.Count > 0)
                cboFamilias.SelectedIndex = 0;
            cboFamilias.EndUpdate();
        }

        private void CargarRolesActuales()
        {
            lstRolesActuales.Items.Clear();
            if (_usuarioSeleccionado == null) return;

            List<int> asignadas = _compositeServicio.ObtenerIdsFamiliasPorUsuario(_usuarioSeleccionado.IdUsuario);
            foreach (Familia f in _familias)
            {
                if (asignadas.Contains(f.IdFamilia))
                    lstRolesActuales.Items.Add(new FamiliaItem(f.IdFamilia, f.Nombre));
            }
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                _usuarioSeleccionado = null;
                lstRolesActuales.Items.Clear();
                return;
            }

            _usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (_usuarioSeleccionado == null) return;

            cboEstado.SelectedItem = _usuarioSeleccionado.Estado;
            CargarRolesActuales();
        }

        private void BtnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EstadoUsuario nuevoEstado = (EstadoUsuario)cboEstado.SelectedItem;

            if (nuevoEstado == _usuarioSeleccionado.Estado)
            {
                MessageBox.Show("El estado seleccionado es el mismo que el actual.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                _usuarioServicio.CambiarEstado(this.Text, _usuarioSeleccionado.IdUsuario, nuevoEstado);
                MessageBox.Show("Estado actualizado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cambiar estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAsignarRol_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboFamilias.SelectedItem == null) return;

            FamiliaItem item = cboFamilias.SelectedItem as FamiliaItem;
            if (item == null) return;

            try
            {
                _compositeServicio.AsignarFamiliaAUsuario(_usuarioSeleccionado.IdUsuario, item.IdFamilia);
                CargarRolesActuales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQuitarRol_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null || lstRolesActuales.SelectedItem == null) return;

            FamiliaItem item = lstRolesActuales.SelectedItem as FamiliaItem;
            if (item == null) return;

            try
            {
                _compositeServicio.QuitarFamiliaDeUsuario(_usuarioSeleccionado.IdUsuario, item.IdFamilia);
                CargarRolesActuales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNuevoUsername.Text) || string.IsNullOrEmpty(txtNuevaPassword.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _usuarioServicio.Alta(this.Text, txtNuevoUsername.Text.Trim(), txtNuevaPassword.Text);
                MessageBox.Show($"Usuario '{txtNuevoUsername.Text}' creado correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNuevoUsername.Text = "";
                txtNuevaPassword.Text = "";
                CargarDatos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class FamiliaItem
        {
            public int IdFamilia { get; }
            public string Nombre { get; }

            public FamiliaItem(int id, string nombre)
            { IdFamilia = id; Nombre = nombre; }

            public override string ToString()
            { return Nombre; }
        }
    }
}
