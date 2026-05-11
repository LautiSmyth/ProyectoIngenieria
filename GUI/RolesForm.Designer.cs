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
            this.splitMain              = new System.Windows.Forms.SplitContainer();
            this.grpArbol               = new System.Windows.Forms.GroupBox();
            this.treeRoles              = new System.Windows.Forms.TreeView();
            this.splitDerecho           = new System.Windows.Forms.SplitContainer();
            this.grpConfigurador        = new System.Windows.Forms.GroupBox();
            this.lblFamiliaSeleccionada = new System.Windows.Forms.Label();
            this.flpConfigurador        = new System.Windows.Forms.TableLayoutPanel();
            this.grpDisponibles         = new System.Windows.Forms.GroupBox();
            this.lstDisponibles         = new System.Windows.Forms.ListBox();
            this.pnlBotones             = new System.Windows.Forms.Panel();
            this.btnAgregar             = new System.Windows.Forms.Button();
            this.btnQuitar              = new System.Windows.Forms.Button();
            this.grpMiembros            = new System.Windows.Forms.GroupBox();
            this.lstMiembros            = new System.Windows.Forms.ListBox();
            this.grpAlta                = new System.Windows.Forms.GroupBox();
            this.grpNuevaFamilia        = new System.Windows.Forms.GroupBox();
            this.lblNombreFamilia       = new System.Windows.Forms.Label();
            this.txtNombreFamilia       = new System.Windows.Forms.TextBox();
            this.lblDescripcionFamilia  = new System.Windows.Forms.Label();
            this.txtDescripcionFamilia  = new System.Windows.Forms.TextBox();
            this.btnNuevaFamilia        = new System.Windows.Forms.Button();
            this.grpNuevaPatente        = new System.Windows.Forms.GroupBox();
            this.lblNombrePatente       = new System.Windows.Forms.Label();
            this.txtNombrePatente       = new System.Windows.Forms.TextBox();
            this.lblDescripcionPatente  = new System.Windows.Forms.Label();
            this.txtDescripcionPatente  = new System.Windows.Forms.TextBox();
            this.btnNuevaPatente        = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDerecho)).BeginInit();
            this.splitDerecho.Panel1.SuspendLayout();
            this.splitDerecho.Panel2.SuspendLayout();
            this.splitDerecho.SuspendLayout();
            this.grpArbol.SuspendLayout();
            this.grpConfigurador.SuspendLayout();
            this.flpConfigurador.SuspendLayout();
            this.grpDisponibles.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.grpMiembros.SuspendLayout();
            this.grpAlta.SuspendLayout();
            this.grpNuevaFamilia.SuspendLayout();
            this.grpNuevaPatente.SuspendLayout();
            this.SuspendLayout();
            //
            // splitMain — TreeView | derecho, proporcion 30/70
            //
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Name = "splitMain";
            this.splitMain.Panel1MinSize = 220;
            this.splitMain.Panel2MinSize = 400;
            this.splitMain.Panel1.Controls.Add(this.grpArbol);
            this.splitMain.Panel2.Controls.Add(this.splitDerecho);
            //
            // grpArbol
            //
            this.grpArbol.Controls.Add(this.treeRoles);
            this.grpArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpArbol.Name = "grpArbol";
            this.grpArbol.Padding = new System.Windows.Forms.Padding(6);
            this.grpArbol.Text = "Estructura de Roles";
            //
            // treeRoles
            //
            this.treeRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRoles.Name = "treeRoles";
            this.treeRoles.TabIndex = 0;
            this.treeRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeRoles_AfterSelect);
            //
            // splitDerecho — Configurador | Alta, proporcion 65/35
            //
            this.splitDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDerecho.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitDerecho.Name = "splitDerecho";
            this.splitDerecho.Panel1MinSize = 350;
            this.splitDerecho.Panel2MinSize = 240;
            this.splitDerecho.Panel1.Controls.Add(this.grpConfigurador);
            this.splitDerecho.Panel2.Controls.Add(this.grpAlta);
            //
            // grpConfigurador
            //
            this.grpConfigurador.Controls.Add(this.lblFamiliaSeleccionada);
            this.grpConfigurador.Controls.Add(this.flpConfigurador);
            this.grpConfigurador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfigurador.Name = "grpConfigurador";
            this.grpConfigurador.Padding = new System.Windows.Forms.Padding(6);
            this.grpConfigurador.Text = "Configurador de Relaciones";
            //
            // lblFamiliaSeleccionada
            //
            this.lblFamiliaSeleccionada.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFamiliaSeleccionada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFamiliaSeleccionada.Name = "lblFamiliaSeleccionada";
            this.lblFamiliaSeleccionada.Padding = new System.Windows.Forms.Padding(4, 4, 0, 4);
            this.lblFamiliaSeleccionada.Size = new System.Drawing.Size(100, 24);
            this.lblFamiliaSeleccionada.Text = "Seleccione una familia del arbol";
            //
            // flpConfigurador — tabla 3 columnas: Disponibles | Botones | Miembros
            //
            this.flpConfigurador.ColumnCount = 3;
            this.flpConfigurador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.flpConfigurador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.flpConfigurador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.flpConfigurador.Controls.Add(this.grpDisponibles, 0, 0);
            this.flpConfigurador.Controls.Add(this.pnlBotones, 1, 0);
            this.flpConfigurador.Controls.Add(this.grpMiembros, 2, 0);
            this.flpConfigurador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpConfigurador.Enabled = false;
            this.flpConfigurador.Name = "flpConfigurador";
            this.flpConfigurador.RowCount = 1;
            this.flpConfigurador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // grpDisponibles
            //
            this.grpDisponibles.Controls.Add(this.lstDisponibles);
            this.grpDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDisponibles.Name = "grpDisponibles";
            this.grpDisponibles.Padding = new System.Windows.Forms.Padding(4);
            this.grpDisponibles.Text = "Disponibles";
            //
            // lstDisponibles
            //
            this.lstDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisponibles.Name = "lstDisponibles";
            this.lstDisponibles.TabIndex = 0;
            //
            // pnlBotones
            //
            this.pnlBotones.Controls.Add(this.btnAgregar);
            this.pnlBotones.Controls.Add(this.btnQuitar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.Name = "pnlBotones";
            //
            // btnAgregar
            //
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregar.Location = new System.Drawing.Point(4, 180);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 30);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar >>";
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            //
            // btnQuitar
            //
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuitar.Location = new System.Drawing.Point(4, 220);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(90, 30);
            this.btnQuitar.TabIndex = 1;
            this.btnQuitar.Text = "<< Quitar";
            this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            //
            // grpMiembros
            //
            this.grpMiembros.Controls.Add(this.lstMiembros);
            this.grpMiembros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMiembros.Name = "grpMiembros";
            this.grpMiembros.Padding = new System.Windows.Forms.Padding(4);
            this.grpMiembros.Text = "Miembros actuales";
            //
            // lstMiembros
            //
            this.lstMiembros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMiembros.Name = "lstMiembros";
            this.lstMiembros.TabIndex = 0;
            //
            // grpAlta
            //
            this.grpAlta.Controls.Add(this.grpNuevaPatente);
            this.grpAlta.Controls.Add(this.grpNuevaFamilia);
            this.grpAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAlta.Name = "grpAlta";
            this.grpAlta.Padding = new System.Windows.Forms.Padding(6);
            this.grpAlta.Text = "Nuevo elemento";
            //
            // grpNuevaFamilia
            //
            this.grpNuevaFamilia.Controls.Add(this.lblNombreFamilia);
            this.grpNuevaFamilia.Controls.Add(this.txtNombreFamilia);
            this.grpNuevaFamilia.Controls.Add(this.lblDescripcionFamilia);
            this.grpNuevaFamilia.Controls.Add(this.txtDescripcionFamilia);
            this.grpNuevaFamilia.Controls.Add(this.btnNuevaFamilia);
            this.grpNuevaFamilia.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNuevaFamilia.Name = "grpNuevaFamilia";
            this.grpNuevaFamilia.Padding = new System.Windows.Forms.Padding(8);
            this.grpNuevaFamilia.Size = new System.Drawing.Size(240, 140);
            this.grpNuevaFamilia.Text = "Nueva Familia";
            //
            // lblNombreFamilia
            //
            this.lblNombreFamilia.AutoSize = true;
            this.lblNombreFamilia.Location = new System.Drawing.Point(8, 28);
            this.lblNombreFamilia.Name = "lblNombreFamilia";
            this.lblNombreFamilia.Text = "Nombre:";
            //
            // txtNombreFamilia
            //
            this.txtNombreFamilia.Location = new System.Drawing.Point(78, 25);
            this.txtNombreFamilia.MaxLength = 100;
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(148, 20);
            this.txtNombreFamilia.TabIndex = 0;
            //
            // lblDescripcionFamilia
            //
            this.lblDescripcionFamilia.AutoSize = true;
            this.lblDescripcionFamilia.Location = new System.Drawing.Point(8, 58);
            this.lblDescripcionFamilia.Name = "lblDescripcionFamilia";
            this.lblDescripcionFamilia.Text = "Descripcion:";
            //
            // txtDescripcionFamilia
            //
            this.txtDescripcionFamilia.Location = new System.Drawing.Point(78, 55);
            this.txtDescripcionFamilia.MaxLength = 200;
            this.txtDescripcionFamilia.Name = "txtDescripcionFamilia";
            this.txtDescripcionFamilia.Size = new System.Drawing.Size(148, 20);
            this.txtDescripcionFamilia.TabIndex = 1;
            //
            // btnNuevaFamilia
            //
            this.btnNuevaFamilia.Location = new System.Drawing.Point(8, 88);
            this.btnNuevaFamilia.Name = "btnNuevaFamilia";
            this.btnNuevaFamilia.Size = new System.Drawing.Size(110, 28);
            this.btnNuevaFamilia.TabIndex = 2;
            this.btnNuevaFamilia.Text = "Crear Familia";
            this.btnNuevaFamilia.Click += new System.EventHandler(this.BtnNuevaFamilia_Click);
            //
            // grpNuevaPatente
            //
            this.grpNuevaPatente.Controls.Add(this.lblNombrePatente);
            this.grpNuevaPatente.Controls.Add(this.txtNombrePatente);
            this.grpNuevaPatente.Controls.Add(this.lblDescripcionPatente);
            this.grpNuevaPatente.Controls.Add(this.txtDescripcionPatente);
            this.grpNuevaPatente.Controls.Add(this.btnNuevaPatente);
            this.grpNuevaPatente.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNuevaPatente.Location = new System.Drawing.Point(6, 156);
            this.grpNuevaPatente.Name = "grpNuevaPatente";
            this.grpNuevaPatente.Padding = new System.Windows.Forms.Padding(8);
            this.grpNuevaPatente.Size = new System.Drawing.Size(240, 140);
            this.grpNuevaPatente.Text = "Nueva Patente";
            //
            // lblNombrePatente
            //
            this.lblNombrePatente.AutoSize = true;
            this.lblNombrePatente.Location = new System.Drawing.Point(8, 28);
            this.lblNombrePatente.Name = "lblNombrePatente";
            this.lblNombrePatente.Text = "Nombre:";
            //
            // txtNombrePatente
            //
            this.txtNombrePatente.Location = new System.Drawing.Point(78, 25);
            this.txtNombrePatente.MaxLength = 100;
            this.txtNombrePatente.Name = "txtNombrePatente";
            this.txtNombrePatente.Size = new System.Drawing.Size(148, 20);
            this.txtNombrePatente.TabIndex = 0;
            //
            // lblDescripcionPatente
            //
            this.lblDescripcionPatente.AutoSize = true;
            this.lblDescripcionPatente.Location = new System.Drawing.Point(8, 58);
            this.lblDescripcionPatente.Name = "lblDescripcionPatente";
            this.lblDescripcionPatente.Text = "Descripcion:";
            //
            // txtDescripcionPatente
            //
            this.txtDescripcionPatente.Location = new System.Drawing.Point(78, 55);
            this.txtDescripcionPatente.MaxLength = 200;
            this.txtDescripcionPatente.Name = "txtDescripcionPatente";
            this.txtDescripcionPatente.Size = new System.Drawing.Size(148, 20);
            this.txtDescripcionPatente.TabIndex = 1;
            //
            // btnNuevaPatente
            //
            this.btnNuevaPatente.Location = new System.Drawing.Point(8, 88);
            this.btnNuevaPatente.Name = "btnNuevaPatente";
            this.btnNuevaPatente.Size = new System.Drawing.Size(110, 28);
            this.btnNuevaPatente.TabIndex = 2;
            this.btnNuevaPatente.Text = "Crear Patente";
            this.btnNuevaPatente.Click += new System.EventHandler(this.BtnNuevaPatente_Click);
            //
            // RolesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.splitMain);
            this.Name = "RolesForm";
            this.Text = "Gestion de Roles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RolesForm_Load);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitDerecho.Panel1.ResumeLayout(false);
            this.splitDerecho.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDerecho)).EndInit();
            this.splitDerecho.ResumeLayout(false);
            this.grpArbol.ResumeLayout(false);
            this.grpConfigurador.ResumeLayout(false);
            this.flpConfigurador.ResumeLayout(false);
            this.grpDisponibles.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.grpMiembros.ResumeLayout(false);
            this.grpAlta.ResumeLayout(false);
            this.grpNuevaFamilia.ResumeLayout(false);
            this.grpNuevaFamilia.PerformLayout();
            this.grpNuevaPatente.ResumeLayout(false);
            this.grpNuevaPatente.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer    splitMain;
        private System.Windows.Forms.SplitContainer    splitDerecho;
        private System.Windows.Forms.GroupBox          grpArbol;
        private System.Windows.Forms.TreeView          treeRoles;
        private System.Windows.Forms.GroupBox          grpConfigurador;
        private System.Windows.Forms.Label             lblFamiliaSeleccionada;
        private System.Windows.Forms.TableLayoutPanel  flpConfigurador;
        private System.Windows.Forms.GroupBox          grpDisponibles;
        private System.Windows.Forms.ListBox           lstDisponibles;
        private System.Windows.Forms.Panel             pnlBotones;
        private System.Windows.Forms.Button            btnAgregar;
        private System.Windows.Forms.Button            btnQuitar;
        private System.Windows.Forms.GroupBox          grpMiembros;
        private System.Windows.Forms.ListBox           lstMiembros;
        private System.Windows.Forms.GroupBox          grpAlta;
        private System.Windows.Forms.GroupBox          grpNuevaFamilia;
        private System.Windows.Forms.Label             lblNombreFamilia;
        private System.Windows.Forms.TextBox           txtNombreFamilia;
        private System.Windows.Forms.Label             lblDescripcionFamilia;
        private System.Windows.Forms.TextBox           txtDescripcionFamilia;
        private System.Windows.Forms.Button            btnNuevaFamilia;
        private System.Windows.Forms.GroupBox          grpNuevaPatente;
        private System.Windows.Forms.Label             lblNombrePatente;
        private System.Windows.Forms.TextBox           txtNombrePatente;
        private System.Windows.Forms.Label             lblDescripcionPatente;
        private System.Windows.Forms.TextBox           txtDescripcionPatente;
        private System.Windows.Forms.Button            btnNuevaPatente;
    }
}
