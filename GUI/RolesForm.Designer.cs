namespace GUI
{
    partial class RolesForm
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
            this.splitContainer        = new System.Windows.Forms.SplitContainer();
            this.treeRoles             = new System.Windows.Forms.TreeView();
            this.splitDerecho          = new System.Windows.Forms.SplitContainer();
            this.grpPatentes           = new System.Windows.Forms.GroupBox();
            this.chkListPatentes       = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarPatentes    = new System.Windows.Forms.Button();
            this.grpSubFamilias        = new System.Windows.Forms.GroupBox();
            this.chkListSubFamilias    = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarSubFamilias = new System.Windows.Forms.Button();
            this.grpAltaPatente        = new System.Windows.Forms.GroupBox();
            this.lblNombrePatente      = new System.Windows.Forms.Label();
            this.txtNombrePatente      = new System.Windows.Forms.TextBox();
            this.lblDescripcionPatente = new System.Windows.Forms.Label();
            this.txtDescripcionPatente = new System.Windows.Forms.TextBox();
            this.lblPatentesDisp       = new System.Windows.Forms.Label();
            this.cboPatentesDisponibles = new System.Windows.Forms.ComboBox();
            this.btnAltaPatente        = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDerecho)).BeginInit();
            this.splitDerecho.Panel1.SuspendLayout();
            this.splitDerecho.Panel2.SuspendLayout();
            this.splitDerecho.SuspendLayout();
            this.grpPatentes.SuspendLayout();
            this.grpSubFamilias.SuspendLayout();
            this.grpAltaPatente.SuspendLayout();
            this.SuspendLayout();
            //
            // splitContainer — divide TreeView | panel derecho
            //
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.SplitterDistance = 280;
            this.splitContainer.Panel1.Controls.Add(this.treeRoles);
            this.splitContainer.Panel2.Controls.Add(this.splitDerecho);
            //
            // treeRoles
            //
            this.treeRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRoles.Name = "treeRoles";
            this.treeRoles.TabIndex = 0;
            this.treeRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeRoles_AfterSelect);
            //
            // splitDerecho — divide (Patentes + SubFamilias) | Alta Patente
            //
            this.splitDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDerecho.Name = "splitDerecho";
            this.splitDerecho.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitDerecho.SplitterDistance = 380;
            this.splitDerecho.Panel1.Controls.Add(this.grpSubFamilias);
            this.splitDerecho.Panel1.Controls.Add(this.grpPatentes);
            this.splitDerecho.Panel2.Controls.Add(this.grpAltaPatente);
            //
            // grpPatentes
            //
            this.grpPatentes.Controls.Add(this.chkListPatentes);
            this.grpPatentes.Controls.Add(this.btnGuardarPatentes);
            this.grpPatentes.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpPatentes.Enabled = false;
            this.grpPatentes.Name = "grpPatentes";
            this.grpPatentes.Padding = new System.Windows.Forms.Padding(8);
            this.grpPatentes.Size = new System.Drawing.Size(360, 380);
            this.grpPatentes.TabIndex = 0;
            this.grpPatentes.Text = "Patentes de la familia seleccionada";
            //
            // chkListPatentes
            //
            this.chkListPatentes.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.chkListPatentes.CheckOnClick = true;
            this.chkListPatentes.Location = new System.Drawing.Point(11, 22);
            this.chkListPatentes.Name = "chkListPatentes";
            this.chkListPatentes.Size = new System.Drawing.Size(330, 320);
            this.chkListPatentes.TabIndex = 0;
            //
            // btnGuardarPatentes
            //
            this.btnGuardarPatentes.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left));
            this.btnGuardarPatentes.Location = new System.Drawing.Point(11, 348);
            this.btnGuardarPatentes.Name = "btnGuardarPatentes";
            this.btnGuardarPatentes.Size = new System.Drawing.Size(140, 26);
            this.btnGuardarPatentes.TabIndex = 1;
            this.btnGuardarPatentes.Text = "Guardar patentes";
            this.btnGuardarPatentes.Click += new System.EventHandler(this.BtnGuardarPatentes_Click);
            //
            // grpSubFamilias
            //
            this.grpSubFamilias.Controls.Add(this.chkListSubFamilias);
            this.grpSubFamilias.Controls.Add(this.btnGuardarSubFamilias);
            this.grpSubFamilias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubFamilias.Enabled = false;
            this.grpSubFamilias.Name = "grpSubFamilias";
            this.grpSubFamilias.Padding = new System.Windows.Forms.Padding(8);
            this.grpSubFamilias.TabIndex = 1;
            this.grpSubFamilias.Text = "Sub-Familias de la familia seleccionada";
            //
            // chkListSubFamilias
            //
            this.chkListSubFamilias.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.chkListSubFamilias.CheckOnClick = true;
            this.chkListSubFamilias.Location = new System.Drawing.Point(11, 22);
            this.chkListSubFamilias.Name = "chkListSubFamilias";
            this.chkListSubFamilias.Size = new System.Drawing.Size(330, 320);
            this.chkListSubFamilias.TabIndex = 0;
            //
            // btnGuardarSubFamilias
            //
            this.btnGuardarSubFamilias.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left));
            this.btnGuardarSubFamilias.Location = new System.Drawing.Point(11, 348);
            this.btnGuardarSubFamilias.Name = "btnGuardarSubFamilias";
            this.btnGuardarSubFamilias.Size = new System.Drawing.Size(160, 26);
            this.btnGuardarSubFamilias.TabIndex = 1;
            this.btnGuardarSubFamilias.Text = "Guardar sub-familias";
            this.btnGuardarSubFamilias.Click += new System.EventHandler(this.BtnGuardarSubFamilias_Click);
            //
            // grpAltaPatente
            //
            this.grpAltaPatente.Controls.Add(this.lblNombrePatente);
            this.grpAltaPatente.Controls.Add(this.txtNombrePatente);
            this.grpAltaPatente.Controls.Add(this.lblDescripcionPatente);
            this.grpAltaPatente.Controls.Add(this.txtDescripcionPatente);
            this.grpAltaPatente.Controls.Add(this.lblPatentesDisp);
            this.grpAltaPatente.Controls.Add(this.cboPatentesDisponibles);
            this.grpAltaPatente.Controls.Add(this.btnAltaPatente);
            this.grpAltaPatente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAltaPatente.Name = "grpAltaPatente";
            this.grpAltaPatente.Padding = new System.Windows.Forms.Padding(8);
            this.grpAltaPatente.TabIndex = 0;
            this.grpAltaPatente.Text = "Nueva Patente";
            //
            // lblNombrePatente
            //
            this.lblNombrePatente.AutoSize = true;
            this.lblNombrePatente.Location = new System.Drawing.Point(11, 26);
            this.lblNombrePatente.Name = "lblNombrePatente";
            this.lblNombrePatente.Text = "Nombre:";
            //
            // txtNombrePatente
            //
            this.txtNombrePatente.Location = new System.Drawing.Point(90, 23);
            this.txtNombrePatente.MaxLength = 100;
            this.txtNombrePatente.Name = "txtNombrePatente";
            this.txtNombrePatente.Size = new System.Drawing.Size(250, 20);
            this.txtNombrePatente.TabIndex = 0;
            //
            // lblDescripcionPatente
            //
            this.lblDescripcionPatente.AutoSize = true;
            this.lblDescripcionPatente.Location = new System.Drawing.Point(11, 55);
            this.lblDescripcionPatente.Name = "lblDescripcionPatente";
            this.lblDescripcionPatente.Text = "Descripcion:";
            //
            // txtDescripcionPatente
            //
            this.txtDescripcionPatente.Location = new System.Drawing.Point(90, 52);
            this.txtDescripcionPatente.MaxLength = 200;
            this.txtDescripcionPatente.Name = "txtDescripcionPatente";
            this.txtDescripcionPatente.Size = new System.Drawing.Size(250, 20);
            this.txtDescripcionPatente.TabIndex = 1;
            //
            // lblPatentesDisp
            //
            this.lblPatentesDisp.AutoSize = true;
            this.lblPatentesDisp.Location = new System.Drawing.Point(11, 85);
            this.lblPatentesDisp.Name = "lblPatentesDisp";
            this.lblPatentesDisp.Text = "Patentes existentes:";
            //
            // cboPatentesDisponibles
            //
            this.cboPatentesDisponibles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPatentesDisponibles.Location = new System.Drawing.Point(130, 82);
            this.cboPatentesDisponibles.Name = "cboPatentesDisponibles";
            this.cboPatentesDisponibles.Size = new System.Drawing.Size(210, 21);
            this.cboPatentesDisponibles.TabIndex = 2;
            //
            // btnAltaPatente
            //
            this.btnAltaPatente.Location = new System.Drawing.Point(11, 114);
            this.btnAltaPatente.Name = "btnAltaPatente";
            this.btnAltaPatente.Size = new System.Drawing.Size(130, 28);
            this.btnAltaPatente.TabIndex = 3;
            this.btnAltaPatente.Text = "Crear Patente";
            this.btnAltaPatente.Click += new System.EventHandler(this.BtnAltaPatente_Click);
            //
            // RolesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.splitContainer);
            this.Name = "RolesForm";
            this.Text = "Gestion de Roles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RolesForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitDerecho.Panel1.ResumeLayout(false);
            this.splitDerecho.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDerecho)).EndInit();
            this.splitDerecho.ResumeLayout(false);
            this.grpPatentes.ResumeLayout(false);
            this.grpSubFamilias.ResumeLayout(false);
            this.grpAltaPatente.ResumeLayout(false);
            this.grpAltaPatente.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer     splitContainer;
        private System.Windows.Forms.TreeView            treeRoles;
        private System.Windows.Forms.SplitContainer     splitDerecho;
        private System.Windows.Forms.GroupBox            grpPatentes;
        private System.Windows.Forms.CheckedListBox      chkListPatentes;
        private System.Windows.Forms.Button              btnGuardarPatentes;
        private System.Windows.Forms.GroupBox            grpSubFamilias;
        private System.Windows.Forms.CheckedListBox      chkListSubFamilias;
        private System.Windows.Forms.Button              btnGuardarSubFamilias;
        private System.Windows.Forms.GroupBox            grpAltaPatente;
        private System.Windows.Forms.Label               lblNombrePatente;
        private System.Windows.Forms.TextBox             txtNombrePatente;
        private System.Windows.Forms.Label               lblDescripcionPatente;
        private System.Windows.Forms.TextBox             txtDescripcionPatente;
        private System.Windows.Forms.Label               lblPatentesDisp;
        private System.Windows.Forms.ComboBox            cboPatentesDisponibles;
        private System.Windows.Forms.Button              btnAltaPatente;
    }
}
