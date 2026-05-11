namespace GUI
{
    partial class UsuariosForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitPrincipal    = new System.Windows.Forms.SplitContainer();
            this.dgvUsuarios       = new System.Windows.Forms.DataGridView();
            this.pnlInferior       = new System.Windows.Forms.TableLayoutPanel();
            this.grpAlta           = new System.Windows.Forms.GroupBox();
            this.lblNuevoUsername  = new System.Windows.Forms.Label();
            this.txtNuevoUsername  = new System.Windows.Forms.TextBox();
            this.lblNuevaPassword  = new System.Windows.Forms.Label();
            this.txtNuevaPassword  = new System.Windows.Forms.TextBox();
            this.btnCrearUsuario   = new System.Windows.Forms.Button();
            this.grpEstado         = new System.Windows.Forms.GroupBox();
            this.lblEstado         = new System.Windows.Forms.Label();
            this.cboEstado         = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstado  = new System.Windows.Forms.Button();
            this.grpRoles          = new System.Windows.Forms.GroupBox();
            this.lblRolAsignar     = new System.Windows.Forms.Label();
            this.cboFamilias       = new System.Windows.Forms.ComboBox();
            this.btnAsignarRol     = new System.Windows.Forms.Button();
            this.lstRolesActuales  = new System.Windows.Forms.ListBox();
            this.btnQuitarRol      = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).BeginInit();
            this.splitPrincipal.Panel1.SuspendLayout();
            this.splitPrincipal.Panel2.SuspendLayout();
            this.splitPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.pnlInferior.SuspendLayout();
            this.grpAlta.SuspendLayout();
            this.grpEstado.SuspendLayout();
            this.grpRoles.SuspendLayout();
            this.SuspendLayout();
            //
            // splitPrincipal
            //
            this.splitPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitPrincipal.Panel1MinSize = 150;
            this.splitPrincipal.Panel2MinSize = 200;
            this.splitPrincipal.Name = "splitPrincipal";
            this.splitPrincipal.Panel1.Controls.Add(this.dgvUsuarios);
            this.splitPrincipal.Panel2.Controls.Add(this.pnlInferior);
            //
            // dgvUsuarios
            //
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.DgvUsuarios_SelectionChanged);
            //
            // pnlInferior — 3 columnas iguales
            //
            this.pnlInferior.ColumnCount = 3;
            this.pnlInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnlInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlInferior.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlInferior.Controls.Add(this.grpAlta, 0, 0);
            this.pnlInferior.Controls.Add(this.grpEstado, 1, 0);
            this.pnlInferior.Controls.Add(this.grpRoles, 2, 0);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(4);
            this.pnlInferior.RowCount = 1;
            this.pnlInferior.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // grpAlta
            //
            this.grpAlta.Controls.Add(this.lblNuevoUsername);
            this.grpAlta.Controls.Add(this.txtNuevoUsername);
            this.grpAlta.Controls.Add(this.lblNuevaPassword);
            this.grpAlta.Controls.Add(this.txtNuevaPassword);
            this.grpAlta.Controls.Add(this.btnCrearUsuario);
            this.grpAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlta.Name = "grpAlta";
            this.grpAlta.Padding = new System.Windows.Forms.Padding(8);
            this.grpAlta.Text = "Alta de usuario";
            //
            // lblNuevoUsername
            //
            this.lblNuevoUsername.AutoSize = true;
            this.lblNuevoUsername.Location = new System.Drawing.Point(8, 28);
            this.lblNuevoUsername.Name = "lblNuevoUsername";
            this.lblNuevoUsername.Text = "Username:";
            //
            // txtNuevoUsername
            //
            this.txtNuevoUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNuevoUsername.Location = new System.Drawing.Point(82, 25);
            this.txtNuevoUsername.MaxLength = 200;
            this.txtNuevoUsername.Name = "txtNuevoUsername";
            this.txtNuevoUsername.Size = new System.Drawing.Size(200, 20);
            this.txtNuevoUsername.TabIndex = 0;
            //
            // lblNuevaPassword
            //
            this.lblNuevaPassword.AutoSize = true;
            this.lblNuevaPassword.Location = new System.Drawing.Point(8, 56);
            this.lblNuevaPassword.Name = "lblNuevaPassword";
            this.lblNuevaPassword.Text = "Password:";
            //
            // txtNuevaPassword
            //
            this.txtNuevaPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNuevaPassword.Location = new System.Drawing.Point(82, 53);
            this.txtNuevaPassword.MaxLength = 200;
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(200, 20);
            this.txtNuevaPassword.TabIndex = 1;
            this.txtNuevaPassword.UseSystemPasswordChar = true;
            //
            // btnCrearUsuario
            //
            this.btnCrearUsuario.Location = new System.Drawing.Point(8, 86);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(120, 28);
            this.btnCrearUsuario.TabIndex = 2;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            //
            // grpEstado
            //
            this.grpEstado.Controls.Add(this.lblEstado);
            this.grpEstado.Controls.Add(this.cboEstado);
            this.grpEstado.Controls.Add(this.btnCambiarEstado);
            this.grpEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Padding = new System.Windows.Forms.Padding(8);
            this.grpEstado.Text = "Estado del usuario";
            //
            // lblEstado
            //
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(8, 28);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado:";
            //
            // cboEstado
            //
            this.cboEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new System.Drawing.Point(62, 25);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(180, 21);
            this.cboEstado.TabIndex = 0;
            //
            // btnCambiarEstado
            //
            this.btnCambiarEstado.Location = new System.Drawing.Point(8, 58);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(130, 28);
            this.btnCambiarEstado.TabIndex = 1;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.BtnCambiarEstado_Click);
            //
            // grpRoles
            //
            this.grpRoles.Controls.Add(this.lblRolAsignar);
            this.grpRoles.Controls.Add(this.cboFamilias);
            this.grpRoles.Controls.Add(this.btnAsignarRol);
            this.grpRoles.Controls.Add(this.lstRolesActuales);
            this.grpRoles.Controls.Add(this.btnQuitarRol);
            this.grpRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Padding = new System.Windows.Forms.Padding(8);
            this.grpRoles.Text = "Roles del usuario seleccionado";
            //
            // lblRolAsignar
            //
            this.lblRolAsignar.AutoSize = true;
            this.lblRolAsignar.Location = new System.Drawing.Point(8, 28);
            this.lblRolAsignar.Name = "lblRolAsignar";
            this.lblRolAsignar.Text = "Asignar rol:";
            //
            // cboFamilias
            //
            this.cboFamilias.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cboFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilias.Location = new System.Drawing.Point(80, 25);
            this.cboFamilias.Name = "cboFamilias";
            this.cboFamilias.Size = new System.Drawing.Size(200, 21);
            this.cboFamilias.TabIndex = 0;
            //
            // btnAsignarRol
            //
            this.btnAsignarRol.Location = new System.Drawing.Point(8, 55);
            this.btnAsignarRol.Name = "btnAsignarRol";
            this.btnAsignarRol.Size = new System.Drawing.Size(110, 26);
            this.btnAsignarRol.TabIndex = 1;
            this.btnAsignarRol.Text = "Asignar Rol";
            this.btnAsignarRol.Click += new System.EventHandler(this.BtnAsignarRol_Click);
            //
            // lstRolesActuales
            //
            this.lstRolesActuales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lstRolesActuales.Location = new System.Drawing.Point(8, 90);
            this.lstRolesActuales.Name = "lstRolesActuales";
            this.lstRolesActuales.Size = new System.Drawing.Size(350, 80);
            this.lstRolesActuales.TabIndex = 2;
            //
            // btnQuitarRol
            //
            this.btnQuitarRol.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.btnQuitarRol.Location = new System.Drawing.Point(8, 178);
            this.btnQuitarRol.Name = "btnQuitarRol";
            this.btnQuitarRol.Size = new System.Drawing.Size(110, 26);
            this.btnQuitarRol.TabIndex = 3;
            this.btnQuitarRol.Text = "Quitar Rol";
            this.btnQuitarRol.Click += new System.EventHandler(this.BtnQuitarRol_Click);
            //
            // UsuariosForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.splitPrincipal);
            this.Name = "UsuariosForm";
            this.Text = "Gestion de Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            this.splitPrincipal.Panel1.ResumeLayout(false);
            this.splitPrincipal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPrincipal)).EndInit();
            this.splitPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            this.grpAlta.ResumeLayout(false);
            this.grpAlta.PerformLayout();
            this.grpEstado.ResumeLayout(false);
            this.grpEstado.PerformLayout();
            this.grpRoles.ResumeLayout(false);
            this.grpRoles.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer    splitPrincipal;
        private System.Windows.Forms.DataGridView       dgvUsuarios;
        private System.Windows.Forms.TableLayoutPanel   pnlInferior;
        private System.Windows.Forms.GroupBox           grpAlta;
        private System.Windows.Forms.Label              lblNuevoUsername;
        private System.Windows.Forms.TextBox            txtNuevoUsername;
        private System.Windows.Forms.Label              lblNuevaPassword;
        private System.Windows.Forms.TextBox            txtNuevaPassword;
        private System.Windows.Forms.Button             btnCrearUsuario;
        private System.Windows.Forms.GroupBox           grpEstado;
        private System.Windows.Forms.Label              lblEstado;
        private System.Windows.Forms.ComboBox           cboEstado;
        private System.Windows.Forms.Button             btnCambiarEstado;
        private System.Windows.Forms.GroupBox           grpRoles;
        private System.Windows.Forms.Label              lblRolAsignar;
        private System.Windows.Forms.ComboBox           cboFamilias;
        private System.Windows.Forms.Button             btnAsignarRol;
        private System.Windows.Forms.ListBox            lstRolesActuales;
        private System.Windows.Forms.Button             btnQuitarRol;
    }
}
