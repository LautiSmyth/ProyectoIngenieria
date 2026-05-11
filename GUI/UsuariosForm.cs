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

            CargarFamiliasEnLista();
        }

        private void CargarFamiliasEnLista()
        {
            chkListFamilias.Items.Clear();
            foreach (Familia f in _familias)
                chkListFamilias.Items.Add(new FamiliaItem(f.IdFamilia, f.Nombre), false);
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                _usuarioSeleccionado = null;
                LimpiarPanelDerecho();
                return;
            }

            _usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
            if (_usuarioSeleccionado == null) return;

            cboEstado.SelectedItem = _usuarioSeleccionado.Estado;

            List<int> asignadas = _compositeServicio.ObtenerIdsFamiliasPorUsuario(_usuarioSeleccionado.IdUsuario);
            for (int i = 0; i < chkListFamilias.Items.Count; i++)
            {
                FamiliaItem item = chkListFamilias.Items[i] as FamiliaItem;
                if (item != null)
                    chkListFamilias.SetItemChecked(i, asignadas.Contains(item.IdFamilia));
            }
        }

        private void LimpiarPanelDerecho()
        {
            for (int i = 0; i < chkListFamilias.Items.Count; i++)
                chkListFamilias.SetItemChecked(i, false);
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

        private void BtnGuardarRoles_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<int> actuales = _compositeServicio.ObtenerIdsFamiliasPorUsuario(_usuarioSeleccionado.IdUsuario);

                for (int i = 0; i < chkListFamilias.Items.Count; i++)
                {
                    FamiliaItem item = chkListFamilias.Items[i] as FamiliaItem;
                    if (item == null) continue;

                    bool estaChecked = chkListFamilias.GetItemChecked(i);
                    bool yaAsignada = actuales.Contains(item.IdFamilia);

                    if (estaChecked && !yaAsignada)
                        _compositeServicio.AsignarFamiliaAUsuario(_usuarioSeleccionado.IdUsuario, item.IdFamilia);
                    else if (!estaChecked && yaAsignada)
                        _compositeServicio.QuitarFamiliaDeUsuario(_usuarioSeleccionado.IdUsuario, item.IdFamilia);
                }

                MessageBox.Show("Roles actualizados correctamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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