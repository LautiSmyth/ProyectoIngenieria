using BE;
using Servicios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class BitacoraForm : Form
    {
        private readonly BitacoraServicios _bitacoraServicios = new BitacoraServicios();

        private List<Bitacora> _listaCompleta = new List<Bitacora>();

        public BitacoraForm()
        {
            InitializeComponent();
        }

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            CargarDesdeBD();

            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBitacora.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBitacora.Columns["Error"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarDesdeBD()
        {
            try
            {
                _listaCompleta = _bitacoraServicios.ObtenerTodos();
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
                if (!string.IsNullOrEmpty(txtBuscar.Text))
                {
                    string busqueda = txtBuscar.Text.ToLower();
                    bool encontrado = false;

                    if (chkUsername.Checked && bitacora.Username.ToLower().Contains(busqueda))
                        encontrado = true;
                    if (chkDetalle.Checked && bitacora.Detalle.ToLower().Contains(busqueda))
                        encontrado = true;
                    if (chkError.Checked && bitacora.Error.ToLower().Contains(busqueda))
                        encontrado = true;

                    if (!encontrado)
                        continue;
                }

                if (!string.IsNullOrEmpty(cboCriticidad.Text) && bitacora.Criticidad.ToString() != cboCriticidad.Text)
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

            dgvBitacora.Columns["Id"].Visible = false;
            dgvBitacora.Columns["UsuarioId"].Visible = false;

            lblContador.Text = "Mostrando " + lista.Count + " de " + _listaCompleta.Count + " registros";
        }

        private void LimpiarFiltros()
        {
            txtBuscar.Text = "";
            chkUsername.Checked = true;
            chkDetalle.Checked = true;
            chkError.Checked = false;
            cboCriticidad.Text = "";
            cboActividad.Text = "";
            chkExitoso.CheckState = CheckState.Indeterminate;
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            dtpHasta.MinDate = dtpDesde.Value;
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
            LimpiarFiltros();
            MostrarEnGrilla(_listaCompleta);
        }
    }
}