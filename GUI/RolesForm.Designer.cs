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
            this.tabControl                 = new System.Windows.Forms.TabControl();
            this.tabPermisos                = new System.Windows.Forms.TabPage();
            this.splitPermisos              = new System.Windows.Forms.SplitContainer();
            this.grpArbolPermisos           = new System.Windows.Forms.GroupBox();
            this.treePermisos               = new System.Windows.Forms.TreeView();
            this.splitDerechoPermisos       = new System.Windows.Forms.SplitContainer();
            this.grpConfiguradorPermisos    = new System.Windows.Forms.GroupBox();
            this.lblFamiliaPermisos         = new System.Windows.Forms.Label();
            this.pnlConfiguradorPermisos    = new System.Windows.Forms.TableLayoutPanel();
            this.grpMiembrosPermisos        = new System.Windows.Forms.GroupBox();
            this.lstMiembrosPermisos        = new System.Windows.Forms.ListBox();
            this.pnlBotonesPermisos         = new System.Windows.Forms.Panel();
            this.btnAgregarPermiso          = new System.Windows.Forms.Button();
            this.btnQuitarPermiso           = new System.Windows.Forms.Button();
            this.grpDisponiblesPermisos     = new System.Windows.Forms.GroupBox();
            this.lstDisponiblesPermisos     = new System.Windows.Forms.ListBox();
            this.grpNuevaPatente            = new System.Windows.Forms.GroupBox();
            this.lblNombrePatente           = new System.Windows.Forms.Label();
            this.txtNombrePatente           = new System.Windows.Forms.TextBox();
            this.lblDescripcionPatente      = new System.Windows.Forms.Label();
            this.txtDescripcionPatente      = new System.Windows.Forms.TextBox();
            this.btnNuevaPatente            = new System.Windows.Forms.Button();
            this.tabEstructura              = new System.Windows.Forms.TabPage();
            this.splitEstructura            = new System.Windows.Forms.SplitContainer();
            this.grpArbolEstructura         = new System.Windows.Forms.GroupBox();
            this.treeEstructura             = new System.Windows.Forms.TreeView();
            this.splitDerechoEstructura     = new System.Windows.Forms.SplitContainer();
            this.grpConfiguradorEstructura  = new System.Windows.Forms.GroupBox();
            this.lblFamiliaEstructura       = new System.Windows.Forms.Label();
            this.pnlConfiguradorEstructura  = new System.Windows.Forms.TableLayoutPanel();
            this.grpMiembrosEstructura      = new System.Windows.Forms.GroupBox();
            this.lstMiembrosEstructura      = new System.Windows.Forms.ListBox();
            this.pnlBotonesEstructura       = new System.Windows.Forms.Panel();
            this.btnAgregarEstructura       = new System.Windows.Forms.Button();
            this.btnQuitarEstructura        = new System.Windows.Forms.Button();
            this.grpDisponiblesEstructura   = new System.Windows.Forms.GroupBox();
            this.lstDisponiblesEstructura   = new System.Windows.Forms.ListBox();
            this.grpNuevaFamilia            = new System.Windows.Forms.GroupBox();
            this.lblNombreFamilia           = new System.Windows.Forms.Label();
            this.txtNombreFamilia           = new System.Windows.Forms.TextBox();
            this.lblDescripcionFamilia      = new System.Windows.Forms.Label();
            this.txtDescripcionFamilia      = new System.Windows.Forms.TextBox();
            this.btnNuevaFamilia            = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPermisos)).BeginInit();
            this.splitPermisos.Panel1.SuspendLayout();
            this.splitPermisos.Panel2.SuspendLayout();
            this.splitPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDerechoPermisos)).BeginInit();
            this.splitDerechoPermisos.Panel1.SuspendLayout();
            this.splitDerechoPermisos.Panel2.SuspendLayout();
            this.splitDerechoPermisos.SuspendLayout();
            this.grpArbolPermisos.SuspendLayout();
            this.grpConfiguradorPermisos.SuspendLayout();
            this.pnlConfiguradorPermisos.SuspendLayout();
            this.grpMiembrosPermisos.SuspendLayout();
            this.grpDisponiblesPermisos.SuspendLayout();
            this.grpNuevaPatente.SuspendLayout();
            this.tabEstructura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEstructura)).BeginInit();
            this.splitEstructura.Panel1.SuspendLayout();
            this.splitEstructura.Panel2.SuspendLayout();
            this.splitEstructura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitDerechoEstructura)).BeginInit();
            this.splitDerechoEstructura.Panel1.SuspendLayout();
            this.splitDerechoEstructura.Panel2.SuspendLayout();
            this.splitDerechoEstructura.SuspendLayout();
            this.grpArbolEstructura.SuspendLayout();
            this.grpConfiguradorEstructura.SuspendLayout();
            this.pnlConfiguradorEstructura.SuspendLayout();
            this.grpMiembrosEstructura.SuspendLayout();
            this.grpDisponiblesEstructura.SuspendLayout();
            this.grpNuevaFamilia.SuspendLayout();
            this.SuspendLayout();
            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabPermisos);
            this.tabControl.Controls.Add(this.tabEstructura);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            //
            // ======================== TAB PERMISOS ========================
            //
            this.tabPermisos.Controls.Add(this.splitPermisos);
            this.tabPermisos.Name = "tabPermisos";
            this.tabPermisos.Padding = new System.Windows.Forms.Padding(4);
            this.tabPermisos.Text = "Permisos de Familia";
            //
            // splitPermisos
            //
            this.splitPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPermisos.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitPermisos.Name = "splitPermisos";
            this.splitPermisos.Panel1.Controls.Add(this.grpArbolPermisos);
            this.splitPermisos.Panel2.Controls.Add(this.splitDerechoPermisos);
            //
            // grpArbolPermisos
            //
            this.grpArbolPermisos.Controls.Add(this.treePermisos);
            this.grpArbolPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpArbolPermisos.Name = "grpArbolPermisos";
            this.grpArbolPermisos.Padding = new System.Windows.Forms.Padding(4);
            this.grpArbolPermisos.Text = "Estructura de Roles";
            //
            // treePermisos
            //
            this.treePermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreePermisos_AfterSelect);
            //
            // splitDerechoPermisos
            //
            this.splitDerechoPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDerechoPermisos.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitDerechoPermisos.Name = "splitDerechoPermisos";
            this.splitDerechoPermisos.Panel1.Controls.Add(this.grpConfiguradorPermisos);
            this.splitDerechoPermisos.Panel2.Controls.Add(this.grpNuevaPatente);
            //
            // grpConfiguradorPermisos
            //
            this.grpConfiguradorPermisos.Controls.Add(this.lblFamiliaPermisos);
            this.grpConfiguradorPermisos.Controls.Add(this.pnlConfiguradorPermisos);
            this.grpConfiguradorPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfiguradorPermisos.Name = "grpConfiguradorPermisos";
            this.grpConfiguradorPermisos.Padding = new System.Windows.Forms.Padding(4);
            this.grpConfiguradorPermisos.Text = "Configurador de Permisos";
            //
            // lblFamiliaPermisos
            //
            this.lblFamiliaPermisos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFamiliaPermisos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFamiliaPermisos.Name = "lblFamiliaPermisos";
            this.lblFamiliaPermisos.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.lblFamiliaPermisos.Size = new System.Drawing.Size(100, 24);
            this.lblFamiliaPermisos.Text = "Seleccione una familia del arbol";
            //
            // pnlConfiguradorPermisos — 3 columnas: Miembros | Botones | Disponibles
            //
            this.pnlConfiguradorPermisos.ColumnCount = 3;
            this.pnlConfiguradorPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlConfiguradorPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlConfiguradorPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.pnlConfiguradorPermisos.Controls.Add(this.grpMiembrosPermisos, 0, 0);
            this.pnlConfiguradorPermisos.Controls.Add(this.pnlBotonesPermisos, 1, 0);
            this.pnlConfiguradorPermisos.Controls.Add(this.grpDisponiblesPermisos, 2, 0);
            this.pnlConfiguradorPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfiguradorPermisos.Enabled = false;
            this.pnlConfiguradorPermisos.Name = "pnlConfiguradorPermisos";
            this.pnlConfiguradorPermisos.RowCount = 1;
            this.pnlConfiguradorPermisos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // grpMiembrosPermisos
            //
            this.grpMiembrosPermisos.Controls.Add(this.lstMiembrosPermisos);
            this.grpMiembrosPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMiembrosPermisos.Name = "grpMiembrosPermisos";
            this.grpMiembrosPermisos.Padding = new System.Windows.Forms.Padding(4);
            this.grpMiembrosPermisos.Text = "Permisos asignados";
            //
            // lstMiembrosPermisos
            //
            this.lstMiembrosPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMiembrosPermisos.Name = "lstMiembrosPermisos";
            //
            // pnlBotonesPermisos
            //
            this.pnlBotonesPermisos.Controls.Add(this.btnAgregarPermiso);
            this.pnlBotonesPermisos.Controls.Add(this.btnQuitarPermiso);
            this.pnlBotonesPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotonesPermisos.Name = "pnlBotonesPermisos";
            //
            // btnAgregarPermiso
            //
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(90, 30);
            this.btnAgregarPermiso.Text = "<< Agregar";
            this.btnAgregarPermiso.Click += new System.EventHandler(this.BtnAgregarPermiso_Click);
            //
            // btnQuitarPermiso
            //
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(90, 30);
            this.btnQuitarPermiso.Text = "Quitar >>";
            this.btnQuitarPermiso.Click += new System.EventHandler(this.BtnQuitarPermiso_Click);
            //
            // grpDisponiblesPermisos
            //
            this.grpDisponiblesPermisos.Controls.Add(this.lstDisponiblesPermisos);
            this.grpDisponiblesPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDisponiblesPermisos.Name = "grpDisponiblesPermisos";
            this.grpDisponiblesPermisos.Padding = new System.Windows.Forms.Padding(4);
            this.grpDisponiblesPermisos.Text = "Permisos disponibles";
            //
            // lstDisponiblesPermisos
            //
            this.lstDisponiblesPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisponiblesPermisos.Name = "lstDisponiblesPermisos";
            //
            // grpNuevaPatente
            //
            this.grpNuevaPatente.Controls.Add(this.lblNombrePatente);
            this.grpNuevaPatente.Controls.Add(this.txtNombrePatente);
            this.grpNuevaPatente.Controls.Add(this.lblDescripcionPatente);
            this.grpNuevaPatente.Controls.Add(this.txtDescripcionPatente);
            this.grpNuevaPatente.Controls.Add(this.btnNuevaPatente);
            this.grpNuevaPatente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNuevaPatente.Name = "grpNuevaPatente";
            this.grpNuevaPatente.Padding = new System.Windows.Forms.Padding(8);
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
            this.txtNombrePatente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNombrePatente.Location = new System.Drawing.Point(82, 25);
            this.txtNombrePatente.MaxLength = 100;
            this.txtNombrePatente.Name = "txtNombrePatente";
            this.txtNombrePatente.Size = new System.Drawing.Size(150, 20);
            //
            // lblDescripcionPatente
            //
            this.lblDescripcionPatente.AutoSize = true;
            this.lblDescripcionPatente.Location = new System.Drawing.Point(8, 56);
            this.lblDescripcionPatente.Name = "lblDescripcionPatente";
            this.lblDescripcionPatente.Text = "Descripcion:";
            //
            // txtDescripcionPatente
            //
            this.txtDescripcionPatente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtDescripcionPatente.Location = new System.Drawing.Point(82, 53);
            this.txtDescripcionPatente.MaxLength = 200;
            this.txtDescripcionPatente.Name = "txtDescripcionPatente";
            this.txtDescripcionPatente.Size = new System.Drawing.Size(150, 20);
            //
            // btnNuevaPatente
            //
            this.btnNuevaPatente.Location = new System.Drawing.Point(8, 86);
            this.btnNuevaPatente.Name = "btnNuevaPatente";
            this.btnNuevaPatente.Size = new System.Drawing.Size(110, 28);
            this.btnNuevaPatente.Text = "Crear Patente";
            this.btnNuevaPatente.Click += new System.EventHandler(this.BtnNuevaPatente_Click);
            //
            // ======================== TAB ESTRUCTURA ========================
            //
            this.tabEstructura.Controls.Add(this.splitEstructura);
            this.tabEstructura.Name = "tabEstructura";
            this.tabEstructura.Padding = new System.Windows.Forms.Padding(4);
            this.tabEstructura.Text = "Estructura de Familias";
            //
            // splitEstructura
            //
            this.splitEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEstructura.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitEstructura.Name = "splitEstructura";
            this.splitEstructura.Panel1.Controls.Add(this.grpArbolEstructura);
            this.splitEstructura.Panel2.Controls.Add(this.splitDerechoEstructura);
            //
            // grpArbolEstructura
            //
            this.grpArbolEstructura.Controls.Add(this.treeEstructura);
            this.grpArbolEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpArbolEstructura.Name = "grpArbolEstructura";
            this.grpArbolEstructura.Padding = new System.Windows.Forms.Padding(4);
            this.grpArbolEstructura.Text = "Estructura de Roles";
            //
            // treeEstructura
            //
            this.treeEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeEstructura.Name = "treeEstructura";
            this.treeEstructura.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeEstructura_AfterSelect);
            //
            // splitDerechoEstructura
            //
            this.splitDerechoEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDerechoEstructura.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitDerechoEstructura.Name = "splitDerechoEstructura";
            this.splitDerechoEstructura.Panel1.Controls.Add(this.grpConfiguradorEstructura);
            this.splitDerechoEstructura.Panel2.Controls.Add(this.grpNuevaFamilia);
            //
            // grpConfiguradorEstructura
            //
            this.grpConfiguradorEstructura.Controls.Add(this.lblFamiliaEstructura);
            this.grpConfiguradorEstructura.Controls.Add(this.pnlConfiguradorEstructura);
            this.grpConfiguradorEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfiguradorEstructura.Name = "grpConfiguradorEstructura";
            this.grpConfiguradorEstructura.Padding = new System.Windows.Forms.Padding(4);
            this.grpConfiguradorEstructura.Text = "Configurador de Estructura";
            //
            // lblFamiliaEstructura
            //
            this.lblFamiliaEstructura.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFamiliaEstructura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFamiliaEstructura.Name = "lblFamiliaEstructura";
            this.lblFamiliaEstructura.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.lblFamiliaEstructura.Size = new System.Drawing.Size(100, 24);
            this.lblFamiliaEstructura.Text = "Seleccione una familia del arbol";
            //
            // pnlConfiguradorEstructura — 3 columnas: Miembros | Botones | Disponibles
            //
            this.pnlConfiguradorEstructura.ColumnCount = 3;
            this.pnlConfiguradorEstructura.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.pnlConfiguradorEstructura.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.pnlConfiguradorEstructura.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.pnlConfiguradorEstructura.Controls.Add(this.grpMiembrosEstructura, 0, 0);
            this.pnlConfiguradorEstructura.Controls.Add(this.pnlBotonesEstructura, 1, 0);
            this.pnlConfiguradorEstructura.Controls.Add(this.grpDisponiblesEstructura, 2, 0);
            this.pnlConfiguradorEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConfiguradorEstructura.Enabled = false;
            this.pnlConfiguradorEstructura.Name = "pnlConfiguradorEstructura";
            this.pnlConfiguradorEstructura.RowCount = 1;
            this.pnlConfiguradorEstructura.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // grpMiembrosEstructura
            //
            this.grpMiembrosEstructura.Controls.Add(this.lstMiembrosEstructura);
            this.grpMiembrosEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMiembrosEstructura.Name = "grpMiembrosEstructura";
            this.grpMiembrosEstructura.Padding = new System.Windows.Forms.Padding(4);
            this.grpMiembrosEstructura.Text = "Sub-Familias asignadas";
            //
            // lstMiembrosEstructura
            //
            this.lstMiembrosEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMiembrosEstructura.Name = "lstMiembrosEstructura";
            //
            // pnlBotonesEstructura
            //
            this.pnlBotonesEstructura.Controls.Add(this.btnAgregarEstructura);
            this.pnlBotonesEstructura.Controls.Add(this.btnQuitarEstructura);
            this.pnlBotonesEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotonesEstructura.Name = "pnlBotonesEstructura";
            //
            // btnAgregarEstructura
            //
            this.btnAgregarEstructura.Name = "btnAgregarEstructura";
            this.btnAgregarEstructura.Size = new System.Drawing.Size(90, 30);
            this.btnAgregarEstructura.Text = "<< Agregar";
            this.btnAgregarEstructura.Click += new System.EventHandler(this.BtnAgregarEstructura_Click);
            //
            // btnQuitarEstructura
            //
            this.btnQuitarEstructura.Name = "btnQuitarEstructura";
            this.btnQuitarEstructura.Size = new System.Drawing.Size(90, 30);
            this.btnQuitarEstructura.Text = "Quitar >>";
            this.btnQuitarEstructura.Click += new System.EventHandler(this.BtnQuitarEstructura_Click);
            //
            // grpDisponiblesEstructura
            //
            this.grpDisponiblesEstructura.Controls.Add(this.lstDisponiblesEstructura);
            this.grpDisponiblesEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDisponiblesEstructura.Name = "grpDisponiblesEstructura";
            this.grpDisponiblesEstructura.Padding = new System.Windows.Forms.Padding(4);
            this.grpDisponiblesEstructura.Text = "Familias disponibles";
            //
            // lstDisponiblesEstructura
            //
            this.lstDisponiblesEstructura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDisponiblesEstructura.Name = "lstDisponiblesEstructura";
            //
            // grpNuevaFamilia
            //
            this.grpNuevaFamilia.Controls.Add(this.lblNombreFamilia);
            this.grpNuevaFamilia.Controls.Add(this.txtNombreFamilia);
            this.grpNuevaFamilia.Controls.Add(this.lblDescripcionFamilia);
            this.grpNuevaFamilia.Controls.Add(this.txtDescripcionFamilia);
            this.grpNuevaFamilia.Controls.Add(this.btnNuevaFamilia);
            this.grpNuevaFamilia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNuevaFamilia.Name = "grpNuevaFamilia";
            this.grpNuevaFamilia.Padding = new System.Windows.Forms.Padding(8);
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
            this.txtNombreFamilia.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtNombreFamilia.Location = new System.Drawing.Point(82, 25);
            this.txtNombreFamilia.MaxLength = 100;
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(150, 20);
            //
            // lblDescripcionFamilia
            //
            this.lblDescripcionFamilia.AutoSize = true;
            this.lblDescripcionFamilia.Location = new System.Drawing.Point(8, 56);
            this.lblDescripcionFamilia.Name = "lblDescripcionFamilia";
            this.lblDescripcionFamilia.Text = "Descripcion:";
            //
            // txtDescripcionFamilia
            //
            this.txtDescripcionFamilia.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtDescripcionFamilia.Location = new System.Drawing.Point(82, 53);
            this.txtDescripcionFamilia.MaxLength = 200;
            this.txtDescripcionFamilia.Name = "txtDescripcionFamilia";
            this.txtDescripcionFamilia.Size = new System.Drawing.Size(150, 20);
            //
            // btnNuevaFamilia
            //
            this.btnNuevaFamilia.Location = new System.Drawing.Point(8, 86);
            this.btnNuevaFamilia.Name = "btnNuevaFamilia";
            this.btnNuevaFamilia.Size = new System.Drawing.Size(110, 28);
            this.btnNuevaFamilia.Text = "Crear Familia";
            this.btnNuevaFamilia.Click += new System.EventHandler(this.BtnNuevaFamilia_Click);
            //
            // RolesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.tabControl);
            this.Name = "RolesForm";
            this.Text = "Gestion de Roles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RolesForm_Load);
            this.Shown += new System.EventHandler(this.RolesForm_Shown);
            this.tabControl.ResumeLayout(false);
            this.tabPermisos.ResumeLayout(false);
            this.splitPermisos.Panel1.ResumeLayout(false);
            this.splitPermisos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPermisos)).EndInit();
            this.splitPermisos.ResumeLayout(false);
            this.splitDerechoPermisos.Panel1.ResumeLayout(false);
            this.splitDerechoPermisos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDerechoPermisos)).EndInit();
            this.splitDerechoPermisos.ResumeLayout(false);
            this.grpArbolPermisos.ResumeLayout(false);
            this.grpConfiguradorPermisos.ResumeLayout(false);
            this.pnlConfiguradorPermisos.ResumeLayout(false);
            this.grpMiembrosPermisos.ResumeLayout(false);
            this.grpDisponiblesPermisos.ResumeLayout(false);
            this.grpNuevaPatente.ResumeLayout(false);
            this.grpNuevaPatente.PerformLayout();
            this.tabEstructura.ResumeLayout(false);
            this.splitEstructura.Panel1.ResumeLayout(false);
            this.splitEstructura.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEstructura)).EndInit();
            this.splitEstructura.ResumeLayout(false);
            this.splitDerechoEstructura.Panel1.ResumeLayout(false);
            this.splitDerechoEstructura.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitDerechoEstructura)).EndInit();
            this.splitDerechoEstructura.ResumeLayout(false);
            this.grpArbolEstructura.ResumeLayout(false);
            this.grpConfiguradorEstructura.ResumeLayout(false);
            this.pnlConfiguradorEstructura.ResumeLayout(false);
            this.grpMiembrosEstructura.ResumeLayout(false);
            this.grpDisponiblesEstructura.ResumeLayout(false);
            this.grpNuevaFamilia.ResumeLayout(false);
            this.grpNuevaFamilia.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl            tabControl;
        private System.Windows.Forms.TabPage               tabPermisos;
        private System.Windows.Forms.SplitContainer        splitPermisos;
        private System.Windows.Forms.GroupBox              grpArbolPermisos;
        private System.Windows.Forms.TreeView              treePermisos;
        private System.Windows.Forms.SplitContainer        splitDerechoPermisos;
        private System.Windows.Forms.GroupBox              grpConfiguradorPermisos;
        private System.Windows.Forms.Label                 lblFamiliaPermisos;
        private System.Windows.Forms.TableLayoutPanel      pnlConfiguradorPermisos;
        private System.Windows.Forms.GroupBox              grpMiembrosPermisos;
        private System.Windows.Forms.ListBox               lstMiembrosPermisos;
        private System.Windows.Forms.Panel                 pnlBotonesPermisos;
        private System.Windows.Forms.Button                btnAgregarPermiso;
        private System.Windows.Forms.Button                btnQuitarPermiso;
        private System.Windows.Forms.GroupBox              grpDisponiblesPermisos;
        private System.Windows.Forms.ListBox               lstDisponiblesPermisos;
        private System.Windows.Forms.GroupBox              grpNuevaPatente;
        private System.Windows.Forms.Label                 lblNombrePatente;
        private System.Windows.Forms.TextBox               txtNombrePatente;
        private System.Windows.Forms.Label                 lblDescripcionPatente;
        private System.Windows.Forms.TextBox               txtDescripcionPatente;
        private System.Windows.Forms.Button                btnNuevaPatente;
        private System.Windows.Forms.TabPage               tabEstructura;
        private System.Windows.Forms.SplitContainer        splitEstructura;
        private System.Windows.Forms.GroupBox              grpArbolEstructura;
        private System.Windows.Forms.TreeView              treeEstructura;
        private System.Windows.Forms.SplitContainer        splitDerechoEstructura;
        private System.Windows.Forms.GroupBox              grpConfiguradorEstructura;
        private System.Windows.Forms.Label                 lblFamiliaEstructura;
        private System.Windows.Forms.TableLayoutPanel      pnlConfiguradorEstructura;
        private System.Windows.Forms.GroupBox              grpMiembrosEstructura;
        private System.Windows.Forms.ListBox               lstMiembrosEstructura;
        private System.Windows.Forms.Panel                 pnlBotonesEstructura;
        private System.Windows.Forms.Button                btnAgregarEstructura;
        private System.Windows.Forms.Button                btnQuitarEstructura;
        private System.Windows.Forms.GroupBox              grpDisponiblesEstructura;
        private System.Windows.Forms.ListBox               lstDisponiblesEstructura;
        private System.Windows.Forms.GroupBox              grpNuevaFamilia;
        private System.Windows.Forms.Label                 lblNombreFamilia;
        private System.Windows.Forms.TextBox               txtNombreFamilia;
        private System.Windows.Forms.Label                 lblDescripcionFamilia;
        private System.Windows.Forms.TextBox               txtDescripcionFamilia;
        private System.Windows.Forms.Button                btnNuevaFamilia;
    }
}
