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
            this.splitContainer    = new System.Windows.Forms.SplitContainer();
            this.dgvUsuarios       = new System.Windows.Forms.DataGridView();
            this.grpEstado         = new System.Windows.Forms.GroupBox();
            this.cboEstado         = new System.Windows.Forms.ComboBox();
            this.btnCambiarEstado  = new System.Windows.Forms.Button();
            this.grpRoles          = new System.Windows.Forms.GroupBox();
            this.chkListFamilias   = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarRoles   = new System.Windows.Forms.Button();
            this.grpAlta           = new System.Windows.Forms.GroupBox();
            this.lblNuevoUsername  = new System.Windows.Forms.Label();
            this.txtNuevoUsername  = new System.Windows.Forms.TextBox();
            this.lblNuevaPassword  = new System.Windows.Forms.Label();
            this.txtNuevaPassword  = new System.Windows.Forms.TextBox();
            this.btnCrearUsuario   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpEstado.SuspendLayout();
            this.grpRoles.SuspendLayout();
            this.grpAlta.SuspendLayout();
            this.SuspendLayout();
            //
            // splitContainer
            //
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.SplitterDistance = 620;
            this.splitContainer.Panel1.Controls.Add(this.dgvUsuarios);
            this.splitContainer.Panel2.Controls.Add(this.grpRoles);
            this.splitContainer.Panel2.Controls.Add(this.grpEstado);
            this.splitContainer.Panel2.Controls.Add(this.grpAlta);
            //
            // dgvUsuarios
            //
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.DgvUsuarios_SelectionChanged);
            //
            // grpEstado
            //
            this.grpEstado.Controls.Add(this.cboEstado);
            this.grpEstado.Controls.Add(this.btnCambiarEstado);
            this.grpEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEstado.Name = "grpEstado";
            this.grpEstado.Padding = new System.Windows.Forms.Padding(8);
            this.grpEstado.Size = new System.Drawing.Size(380, 64);
            this.grpEstado.TabIndex = 0;
            this.grpEstado.Text = "Estado del usuario";
            //
            // cboEstado
            //
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Location = new System.Drawing.Point(11, 30);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(160, 21);
            this.cboEstado.TabIndex = 0;
            //
            // btnCambiarEstado
            //
            this.btnCambiarEstado.Location = new System.Drawing.Point(180, 28);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(120, 26);
            this.btnCambiarEstado.TabIndex = 1;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.BtnCambiarEstado_Click);
            //
            // grpAlta
            //
            this.grpAlta.Controls.Add(this.lblNuevoUsername);
            this.grpAlta.Controls.Add(this.txtNuevoUsername);
            this.grpAlta.Controls.Add(this.lblNuevaPassword);
            this.grpAlta.Controls.Add(this.txtNuevaPassword);
            this.grpAlta.Controls.Add(this.btnCrearUsuario);
            this.grpAlta.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAlta.Name = "grpAlta";
            this.grpAlta.Padding = new System.Windows.Forms.Padding(8);
            this.grpAlta.Size = new System.Drawing.Size(380, 130);
            this.grpAlta.TabIndex = 2;
            this.grpAlta.Text = "Alta de usuario";
            //
            // lblNuevoUsername
            //
            this.lblNuevoUsername.AutoSize = true;
            this.lblNuevoUsername.Location = new System.Drawing.Point(11, 26);
            this.lblNuevoUsername.Name = "lblNuevoUsername";
            this.lblNuevoUsername.Text = "Username:";
            //
            // txtNuevoUsername
            //
            this.txtNuevoUsername.Location = new System.Drawing.Point(80, 23);
            this.txtNuevoUsername.MaxLength = 200;
            this.txtNuevoUsername.Name = "txtNuevoUsername";
            this.txtNuevoUsername.Size = new System.Drawing.Size(220, 20);
            this.txtNuevoUsername.TabIndex = 0;
            //
            // lblNuevaPassword
            //
            this.lblNuevaPassword.AutoSize = true;
            this.lblNuevaPassword.Location = new System.Drawing.Point(11, 56);
            this.lblNuevaPassword.Name = "lblNuevaPassword";
            this.lblNuevaPassword.Text = "Password:";
            //
            // txtNuevaPassword
            //
            this.txtNuevaPassword.Location = new System.Drawing.Point(80, 53);
            this.txtNuevaPassword.MaxLength = 200;
            this.txtNuevaPassword.Name = "txtNuevaPassword";
            this.txtNuevaPassword.Size = new System.Drawing.Size(220, 20);
            this.txtNuevaPassword.TabIndex = 1;
            this.txtNuevaPassword.UseSystemPasswordChar = true;
            //
            // btnCrearUsuario
            //
            this.btnCrearUsuario.Location = new System.Drawing.Point(11, 88);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(120, 28);
            this.btnCrearUsuario.TabIndex = 2;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.Click += new System.EventHandler(this.BtnCrearUsuario_Click);
            //
            // grpRoles
            //
            this.grpRoles.Controls.Add(this.chkListFamilias);
            this.grpRoles.Controls.Add(this.btnGuardarRoles);
            this.grpRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRoles.Name = "grpRoles";
            this.grpRoles.Padding = new System.Windows.Forms.Padding(8);
            this.grpRoles.TabIndex = 1;
            this.grpRoles.Text = "Roles asignados al usuario";
            //
            // chkListFamilias
            //
            this.chkListFamilias.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.chkListFamilias.CheckOnClick = true;
            this.chkListFamilias.Location = new System.Drawing.Point(11, 22);
            this.chkListFamilias.Name = "chkListFamilias";
            this.chkListFamilias.Size = new System.Drawing.Size(350, 220);
            this.chkListFamilias.TabIndex = 0;
            //
            // btnGuardarRoles
            //
            this.btnGuardarRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left));
            this.btnGuardarRoles.Location = new System.Drawing.Point(11, 250);
            this.btnGuardarRoles.Name = "btnGuardarRoles";
            this.btnGuardarRoles.Size = new System.Drawing.Size(140, 28);
            this.btnGuardarRoles.TabIndex = 1;
            this.btnGuardarRoles.Text = "Guardar asignacion";
            this.btnGuardarRoles.Click += new System.EventHandler(this.BtnGuardarRoles_Click);
            //
            // UsuariosForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.splitContainer);
            this.Name = "UsuariosForm";
            this.Text = "Gestion de Usuarios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UsuariosForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpEstado.ResumeLayout(false);
            this.grpEstado.PerformLayout();
            this.grpRoles.ResumeLayout(false);
            this.grpAlta.ResumeLayout(false);
            this.grpAlta.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer   splitContainer;
        private System.Windows.Forms.DataGridView      dgvUsuarios;
        private System.Windows.Forms.GroupBox          grpEstado;
        private System.Windows.Forms.ComboBox          cboEstado;
        private System.Windows.Forms.Button            btnCambiarEstado;
        private System.Windows.Forms.GroupBox          grpRoles;
        private System.Windows.Forms.CheckedListBox    chkListFamilias;
        private System.Windows.Forms.Button            btnGuardarRoles;
        private System.Windows.Forms.GroupBox          grpAlta;
        private System.Windows.Forms.Label             lblNuevoUsername;
        private System.Windows.Forms.TextBox           txtNuevoUsername;
        private System.Windows.Forms.Label             lblNuevaPassword;
        private System.Windows.Forms.TextBox           txtNuevaPassword;
        private System.Windows.Forms.Button            btnCrearUsuario;
    }
}
