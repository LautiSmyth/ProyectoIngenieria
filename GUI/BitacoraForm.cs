using BE;
using BE.Enums;
using Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class BitacoraForm : Form
    {
        private readonly BitacoraServicios _bitacoraServicios = new BitacoraServicios();
        private readonly CriticidadServicio _criticidadServicio = new CriticidadServicio();
        private List<Bitacora> _listaCompleta = new List<Bitacora>();

        public BitacoraForm()
        {
            InitializeComponent();
        }

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DesuscribirFiltros();
            CargarComboCriticidad();
            LimpiarFiltros();
            SuscribirFiltros();
        }

        private void BitacoraForm_Shown(object sender, EventArgs e)
        {
            CargarDesdeBD();
        }

        private void SuscribirFiltros()
        {
            txtBuscar.TextChanged += Filtro_Changed;
            txtUsername.TextChanged += Filtro_Changed;
            cboCriticidad.TextChanged += Filtro_Changed;
            cboActividad.TextChanged += Filtro_Changed;
            chkDetalle.CheckedChanged += Filtro_Changed;
            chkError.CheckedChanged += Filtro_Changed;
            chkExitoso.CheckStateChanged += Filtro_Changed;
            dtpDesde.ValueChanged += Filtro_Changed;
            dtpHasta.ValueChanged += Filtro_Changed;
        }

        private void DesuscribirFiltros()
        {
            txtBuscar.TextChanged -= Filtro_Changed;
            txtUsername.TextChanged -= Filtro_Changed;
            cboCriticidad.TextChanged -= Filtro_Changed;
            cboActividad.TextChanged -= Filtro_Changed;
            chkDetalle.CheckedChanged -= Filtro_Changed;
            chkError.CheckedChanged -= Filtro_Changed;
            chkExitoso.CheckStateChanged -= Filtro_Changed;
            dtpDesde.ValueChanged -= Filtro_Changed;
            dtpHasta.ValueChanged -= Filtro_Changed;
        }

        private void CargarComboCriticidad()
        {
            cboCriticidad.Items.Clear();
            cboCriticidad.Items.Add(new CriticidadItem(null, ""));
            foreach (CriticidadConfig config in _criticidadServicio.ObtenerTodos())
                cboCriticidad.Items.Add(new CriticidadItem(config.Nivel, config.Nombre));

            cboCriticidad.DisplayMember = "Nombre";
            cboCriticidad.SelectedIndex = 0;
        }

        private void CargarComboActividad()
        {
            string seleccionActual = cboActividad.Text;
            cboActividad.Items.Clear();
            cboActividad.Items.Add("");

            List<string> actividades = new List<string>();
            foreach (Bitacora b in _listaCompleta)
            {
                if (!actividades.Contains(b.Actividad))
                    actividades.Add(b.Actividad);
            }
            actividades.Sort();

            foreach (string actividad in actividades)
                cboActividad.Items.Add(actividad);

            cboActividad.Text = seleccionActual;
        }

        private void CargarDesdeBD()
        {
            try
            {
                _listaCompleta = _bitacoraServicios.ObtenerTodos();
                CargarComboActividad();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la bitacora: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            List<Bitacora> resultado = new List<Bitacora>();

            foreach (Bitacora bitacora in _listaCompleta)
            {
                if (!string.IsNullOrEmpty(txtUsername.Text)
                    && !bitacora.Username.ToLower().Contains(txtUsername.Text.ToLower()))
                    continue;

                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    string busqueda = txtBuscar.Text.ToLower();
                    bool encontrado = false;

                    if (chkDetalle.Checked && bitacora.Detalle.ToLower().Contains(busqueda))
                        encontrado = true;
                    if (chkError.Checked && bitacora.Error.ToLower().Contains(busqueda))
                        encontrado = true;

                    if (!encontrado)
                        continue;
                }

                if (cboCriticidad.SelectedItem is CriticidadItem item && item.Nivel.HasValue
                    && bitacora.Criticidad != item.Nivel.Value)
                    continue;

                if (!string.IsNullOrEmpty(cboActividad.Text) && bitacora.Actividad != cboActividad.Text)
                    continue;
                if (chkExitoso.CheckState == CheckState.Checked && !bitacora.Exitoso)
                    continue;
                if (chkExitoso.CheckState == CheckState.Unchecked && bitacora.Exitoso)
                    continue;
                if (bitacora.Fecha.Date < dtpDesde.Value.Date)
                    continue;
                if (bitacora.Fecha.Date > dtpHasta.Value.Date)
                    continue;

                resultado.Add(bitacora);
            }

            MostrarEnGrilla(resultado);
        }

        private void MostrarEnGrilla(List<Bitacora> lista)
        {
            dgvBitacora.DataSource = lista;
            dgvBitacora.Columns["IdBitacora"].Visible = false;
            dgvBitacora.Columns["IdUsuario"].Visible = false;
            dgvBitacora.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBitacora.Columns["Error"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lblContador.Text = $"Mostrando {lista.Count} de {_listaCompleta.Count} registros";

            foreach (DataGridViewRow fila in dgvBitacora.Rows)
            {
                if (fila.DataBoundItem == null) continue;

                NivelCriticidad criticidad = ((Bitacora)fila.DataBoundItem).Criticidad;
                CriticidadConfig config = _criticidadServicio.ObtenerConfig(criticidad);
                if (config == null) continue;

                Color colorFondo;
                try { colorFondo = ColorTranslator.FromHtml(config.ColorHex); }
                catch { continue; }

                fila.DefaultCellStyle.BackColor = colorFondo;
                fila.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(colorFondo, 0.1f);
            }
        }

        private void LimpiarFiltros()
        {
            txtBuscar.Text = "";
            txtUsername.Text = "";
            chkDetalle.Checked = true;
            chkError.Checked = false;
            if (cboCriticidad.Items.Count > 0) cboCriticidad.SelectedIndex = 0;
            cboActividad.Text = "";
            chkExitoso.CheckState = CheckState.Indeterminate;
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            dtpHasta.MinDate = DateTime.Today.AddMonths(-1);
        }

        private void Filtro_Changed(object sender, EventArgs e)
        {
            if (sender == dtpDesde)
            {
                dtpHasta.MinDate = dtpDesde.Value;
                if (dtpHasta.Value < dtpDesde.Value)
                    dtpHasta.Value = dtpDesde.Value;
            }
            AplicarFiltros();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            CargarDesdeBD();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            DesuscribirFiltros();
            LimpiarFiltros();
            SuscribirFiltros();
            AplicarFiltros();
        }
    }

    internal class CriticidadItem
    {
        public NivelCriticidad? Nivel { get; }
        public string Nombre { get; }

        public CriticidadItem(NivelCriticidad? nivel, string nombre)
        {
            Nivel = nivel;
            Nombre = nombre;
        }

        public override string ToString() { return Nombre; }
    }
}
