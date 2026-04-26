namespace GUI
{
    partial class MenuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblBaseDatos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSeparador = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnBitacora = new System.Windows.Forms.ToolStripButton();
            this.btnCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBaseDatos,
            this.lblSeparador2,
            this.lblSeparador,
            this.lblHora});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Padding = new System.Windows.Forms.Padding(1);
            this.lblBaseDatos.Size = new System.Drawing.Size(84, 17);
            this.lblBaseDatos.Text = "Base de datos:";
            // 
            // lblSeparador2
            // 
            this.lblSeparador2.Name = "lblSeparador2";
            this.lblSeparador2.Size = new System.Drawing.Size(10, 17);
            this.lblSeparador2.Text = "|";
            // 
            // lblSeparador
            // 
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(817, 17);
            this.lblSeparador.Spring = true;
            this.lblSeparador.Text = "|";
            this.lblSeparador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHora
            // 
            this.lblHora.Name = "lblHora";
            this.lblHora.Padding = new System.Windows.Forms.Padding(1);
            this.lblHora.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblHora.Size = new System.Drawing.Size(51, 17);
            this.lblHora.Text = "00:00:00";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 10);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(57, 6);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario,
            this.toolStripSeparator2,
            this.btnBitacora,
            this.btnCerrarSesion,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 30);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Padding = new System.Windows.Forms.Padding(4);
            this.lblUsuario.Size = new System.Drawing.Size(55, 27);
            this.lblUsuario.Text = "Usuario";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // btnBitacora
            // 
            this.btnBitacora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBitacora.Image = ((System.Drawing.Image)(resources.GetObject("btnBitacora.Image")));
            this.btnBitacora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Padding = new System.Windows.Forms.Padding(4);
            this.btnBitacora.Size = new System.Drawing.Size(62, 27);
            this.btnBitacora.Text = "Bitacora";
            this.btnBitacora.Click += new System.EventHandler(this.BtnBitacora_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(4);
            this.btnCerrarSesion.Size = new System.Drawing.Size(88, 27);
            this.btnCerrarSesion.Text = "Cerrar Sesion";
            this.btnCerrarSesion.Click += new System.EventHandler(this.BtnCerrarSesion_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 661);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblBaseDatos;
        private System.Windows.Forms.ToolStripStatusLabel lblHora;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel lblSeparador;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnBitacora;
        private System.Windows.Forms.ToolStripButton btnCerrarSesion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}