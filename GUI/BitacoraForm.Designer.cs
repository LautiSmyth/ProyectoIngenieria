namespace GUI
{
    partial class BitacoraForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.chkUsername = new System.Windows.Forms.CheckBox();
            this.cboCriticidad = new System.Windows.Forms.ComboBox();
            this.chkDetalle = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.cboActividad = new System.Windows.Forms.ComboBox();
            this.chkExitoso = new System.Windows.Forms.CheckBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 90);
            this.panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.txtBuscar);
            this.flowLayoutPanel1.Controls.Add(this.chkUsername);
            this.flowLayoutPanel1.Controls.Add(this.chkDetalle);
            this.flowLayoutPanel1.Controls.Add(this.chkError);
            this.flowLayoutPanel1.Controls.Add(this.cboCriticidad);
            this.flowLayoutPanel1.Controls.Add(this.cboActividad);
            this.flowLayoutPanel1.Controls.Add(this.chkExitoso);
            this.flowLayoutPanel1.Controls.Add(this.dtpDesde);
            this.flowLayoutPanel1.Controls.Add(this.dtpHasta);
            this.flowLayoutPanel1.Controls.Add(this.btnLimpiar);
            this.flowLayoutPanel1.Controls.Add(this.btnBuscar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 90);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBitacora.Location = new System.Drawing.Point(0, 0);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.Size = new System.Drawing.Size(800, 450);
            this.dgvBitacora.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(6, 9);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // chkUsername
            // 
            this.chkUsername.AutoSize = true;
            this.chkUsername.Location = new System.Drawing.Point(160, 11);
            this.chkUsername.Margin = new System.Windows.Forms.Padding(0, 5, 4, 0);
            this.chkUsername.Name = "chkUsername";
            this.chkUsername.Size = new System.Drawing.Size(80, 17);
            this.chkUsername.TabIndex = 1;
            this.chkUsername.Text = "checkBox1";
            this.chkUsername.UseVisualStyleBackColor = true;
            // 
            // cboCriticidad
            // 
            this.cboCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriticidad.FormattingEnabled = true;
            this.cboCriticidad.Location = new System.Drawing.Point(412, 9);
            this.cboCriticidad.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.cboCriticidad.Name = "cboCriticidad";
            this.cboCriticidad.Size = new System.Drawing.Size(121, 21);
            this.cboCriticidad.TabIndex = 2;
            // 
            // chkDetalle
            // 
            this.chkDetalle.AutoSize = true;
            this.chkDetalle.Location = new System.Drawing.Point(244, 11);
            this.chkDetalle.Margin = new System.Windows.Forms.Padding(0, 5, 4, 0);
            this.chkDetalle.Name = "chkDetalle";
            this.chkDetalle.Size = new System.Drawing.Size(80, 17);
            this.chkDetalle.TabIndex = 3;
            this.chkDetalle.Text = "checkBox2";
            this.chkDetalle.UseVisualStyleBackColor = true;
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.Location = new System.Drawing.Point(328, 11);
            this.chkError.Margin = new System.Windows.Forms.Padding(0, 5, 4, 0);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(80, 17);
            this.chkError.TabIndex = 4;
            this.chkError.Text = "checkBox3";
            this.chkError.UseVisualStyleBackColor = true;
            // 
            // cboActividad
            // 
            this.cboActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividad.FormattingEnabled = true;
            this.cboActividad.Location = new System.Drawing.Point(537, 9);
            this.cboActividad.Margin = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.cboActividad.Name = "cboActividad";
            this.cboActividad.Size = new System.Drawing.Size(121, 21);
            this.cboActividad.TabIndex = 5;
            // 
            // chkExitoso
            // 
            this.chkExitoso.AutoSize = true;
            this.chkExitoso.Location = new System.Drawing.Point(662, 11);
            this.chkExitoso.Margin = new System.Windows.Forms.Padding(0, 5, 4, 0);
            this.chkExitoso.Name = "chkExitoso";
            this.chkExitoso.Size = new System.Drawing.Size(80, 17);
            this.chkExitoso.TabIndex = 6;
            this.chkExitoso.Text = "checkBox4";
            this.chkExitoso.UseVisualStyleBackColor = true;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(6, 34);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(100, 20);
            this.dtpDesde.TabIndex = 7;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(109, 34);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(100, 20);
            this.dtpHasta.TabIndex = 8;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(212, 34);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "button1";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(290, 34);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "button2";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // BitacoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBitacora);
            this.Name = "BitacoraForm";
            this.Text = "Bitacora";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.CheckBox chkUsername;
        private System.Windows.Forms.ComboBox cboCriticidad;
        private System.Windows.Forms.CheckBox chkDetalle;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.ComboBox cboActividad;
        private System.Windows.Forms.CheckBox chkExitoso;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnBuscar;
    }
}