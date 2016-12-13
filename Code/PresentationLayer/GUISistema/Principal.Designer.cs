namespace MinLab.Code.PresentationLayer.GUISistema
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.Temporizador = new System.Windows.Forms.Timer(this.components);
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.BtnInicio = new System.Windows.Forms.Button();
            this.BtnExamen = new System.Windows.Forms.Button();
            this.BtnAcerca = new System.Windows.Forms.Button();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.BtnOrden = new System.Windows.Forms.Button();
            this.BtnPaciente = new System.Windows.Forms.Button();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.campUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaOrdenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionABaseDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelOpciones.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOpciones
            // 
            this.panelOpciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOpciones.BackColor = System.Drawing.Color.DimGray;
            this.panelOpciones.Controls.Add(this.BtnInicio);
            this.panelOpciones.Controls.Add(this.BtnExamen);
            this.panelOpciones.Controls.Add(this.BtnAcerca);
            this.panelOpciones.Controls.Add(this.BtnReporte);
            this.panelOpciones.Controls.Add(this.BtnOrden);
            this.panelOpciones.Controls.Add(this.BtnPaciente);
            this.panelOpciones.Location = new System.Drawing.Point(-1, 44);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(163, 617);
            this.panelOpciones.TabIndex = 0;
            // 
            // BtnInicio
            // 
            this.BtnInicio.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnInicio.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.BtnInicio.FlatAppearance.BorderSize = 0;
            this.BtnInicio.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Khaki;
            this.BtnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.BtnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInicio.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnInicio.Image = global::MinLab.Properties.Resources.home;
            this.BtnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInicio.Location = new System.Drawing.Point(1, 0);
            this.BtnInicio.Name = "BtnInicio";
            this.BtnInicio.Size = new System.Drawing.Size(162, 48);
            this.BtnInicio.TabIndex = 8;
            this.BtnInicio.Text = "Inicio";
            this.BtnInicio.UseVisualStyleBackColor = false;
            this.BtnInicio.Click += new System.EventHandler(this.BtnInicio_Click);
            // 
            // BtnExamen
            // 
            this.BtnExamen.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExamen.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnExamen.FlatAppearance.BorderSize = 0;
            this.BtnExamen.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnExamen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnExamen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExamen.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExamen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnExamen.Image = global::MinLab.Properties.Resources.test;
            this.BtnExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExamen.Location = new System.Drawing.Point(1, 147);
            this.BtnExamen.Name = "BtnExamen";
            this.BtnExamen.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BtnExamen.Size = new System.Drawing.Size(182, 48);
            this.BtnExamen.TabIndex = 7;
            this.BtnExamen.Text = "Examen";
            this.BtnExamen.UseMnemonic = false;
            this.BtnExamen.UseVisualStyleBackColor = false;
            this.BtnExamen.Click += new System.EventHandler(this.BtnExamen_Click);
            // 
            // BtnAcerca
            // 
            this.BtnAcerca.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAcerca.FlatAppearance.BorderSize = 0;
            this.BtnAcerca.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAcerca.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcerca.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAcerca.Image = global::MinLab.Properties.Resources.info;
            this.BtnAcerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAcerca.Location = new System.Drawing.Point(0, 569);
            this.BtnAcerca.Name = "BtnAcerca";
            this.BtnAcerca.Size = new System.Drawing.Size(183, 48);
            this.BtnAcerca.TabIndex = 6;
            this.BtnAcerca.Text = "Acerca";
            this.BtnAcerca.UseVisualStyleBackColor = false;
            this.BtnAcerca.Click += new System.EventHandler(this.BtnAcerca_Click);
            // 
            // BtnReporte
            // 
            this.BtnReporte.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnReporte.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnReporte.FlatAppearance.BorderSize = 0;
            this.BtnReporte.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporte.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnReporte.Image = global::MinLab.Properties.Resources.report;
            this.BtnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReporte.Location = new System.Drawing.Point(1, 196);
            this.BtnReporte.Name = "BtnReporte";
            this.BtnReporte.Size = new System.Drawing.Size(183, 48);
            this.BtnReporte.TabIndex = 0;
            this.BtnReporte.Text = "Reporte";
            this.BtnReporte.UseVisualStyleBackColor = false;
            this.BtnReporte.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // BtnOrden
            // 
            this.BtnOrden.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnOrden.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnOrden.FlatAppearance.BorderSize = 0;
            this.BtnOrden.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrden.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrden.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOrden.Image = global::MinLab.Properties.Resources.list;
            this.BtnOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrden.Location = new System.Drawing.Point(1, 98);
            this.BtnOrden.Name = "BtnOrden";
            this.BtnOrden.Size = new System.Drawing.Size(172, 48);
            this.BtnOrden.TabIndex = 1;
            this.BtnOrden.Text = "Orden";
            this.BtnOrden.UseVisualStyleBackColor = false;
            this.BtnOrden.Click += new System.EventHandler(this.BtnOrden_Click);
            // 
            // BtnPaciente
            // 
            this.BtnPaciente.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnPaciente.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnPaciente.FlatAppearance.BorderSize = 0;
            this.BtnPaciente.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnPaciente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnPaciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPaciente.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaciente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnPaciente.Image = global::MinLab.Properties.Resources.boy__1_;
            this.BtnPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPaciente.Location = new System.Drawing.Point(1, 49);
            this.BtnPaciente.Name = "BtnPaciente";
            this.BtnPaciente.Size = new System.Drawing.Size(182, 48);
            this.BtnPaciente.TabIndex = 3;
            this.BtnPaciente.Text = "Paciente";
            this.BtnPaciente.UseVisualStyleBackColor = false;
            this.BtnPaciente.Click += new System.EventHandler(this.BtnPaciente_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.AutoScroll = true;
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Location = new System.Drawing.Point(158, 44);
            this.panelPrincipal.MaximumSize = new System.Drawing.Size(1066, 617);
            this.panelPrincipal.MinimumSize = new System.Drawing.Size(1024, 700);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1066, 700);
            this.panelPrincipal.TabIndex = 4;
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelBar.Controls.Add(this.BtnLogout);
            this.panelBar.Controls.Add(this.campUser);
            this.panelBar.Controls.Add(this.label1);
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1224, 44);
            this.panelBar.TabIndex = 2;
            // 
            // BtnLogout
            // 
            this.BtnLogout.AutoSize = true;
            this.BtnLogout.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnLogout.FlatAppearance.BorderSize = 0;
            this.BtnLogout.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnLogout.Image = global::MinLab.Properties.Resources.exit;
            this.BtnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogout.Location = new System.Drawing.Point(1181, 9);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Size = new System.Drawing.Size(32, 30);
            this.BtnLogout.TabIndex = 26;
            this.BtnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLogout.UseVisualStyleBackColor = false;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // campUser
            // 
            this.campUser.AutoSize = true;
            this.campUser.BackColor = System.Drawing.Color.Transparent;
            this.campUser.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campUser.ForeColor = System.Drawing.SystemColors.Window;
            this.campUser.Location = new System.Drawing.Point(1024, 15);
            this.campUser.Name = "campUser";
            this.campUser.Size = new System.Drawing.Size(143, 18);
            this.campUser.TabIndex = 27;
            this.campUser.Text = "Alexis Gavidia Meza";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Sistema de Laboratorio";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.panelPrincipal);
            this.panel2.Controls.Add(this.panelBar);
            this.panel2.Controls.Add(this.panelOpciones);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1225, 661);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 24);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.cuentaToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaOrdenToolStripMenuItem,
            this.nuevaPruebaToolStripMenuItem,
            this.conexionABaseDatosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevaOrdenToolStripMenuItem
            // 
            this.nuevaOrdenToolStripMenuItem.Name = "nuevaOrdenToolStripMenuItem";
            this.nuevaOrdenToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nuevaOrdenToolStripMenuItem.Text = "Nueva Orden";
            // 
            // nuevaPruebaToolStripMenuItem
            // 
            this.nuevaPruebaToolStripMenuItem.Name = "nuevaPruebaToolStripMenuItem";
            this.nuevaPruebaToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.nuevaPruebaToolStripMenuItem.Text = "Nueva Prueba";
            // 
            // conexionABaseDatosToolStripMenuItem
            // 
            this.conexionABaseDatosToolStripMenuItem.Name = "conexionABaseDatosToolStripMenuItem";
            this.conexionABaseDatosToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.conexionABaseDatosToolStripMenuItem.Text = "Exportar Pruebas";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // cuentaToolStripMenuItem
            // 
            this.cuentaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCuentaToolStripMenuItem,
            this.nuevoUsuarioToolStripMenuItem});
            this.cuentaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            this.cuentaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // nuevaCuentaToolStripMenuItem
            // 
            this.nuevaCuentaToolStripMenuItem.Name = "nuevaCuentaToolStripMenuItem";
            this.nuevaCuentaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.nuevaCuentaToolStripMenuItem.Text = "Modificar Datos";
            // 
            // nuevoUsuarioToolStripMenuItem
            // 
            this.nuevoUsuarioToolStripMenuItem.Name = "nuevoUsuarioToolStripMenuItem";
            this.nuevoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.nuevoUsuarioToolStripMenuItem.Text = "Nuevo Usuario";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1225, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1241, 700);
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winchanzao";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.panelOpciones.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Temporizador;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.Button BtnInicio;
        private System.Windows.Forms.Button BtnExamen;
        private System.Windows.Forms.Button BtnAcerca;
        private System.Windows.Forms.Button BtnReporte;
        private System.Windows.Forms.Button BtnOrden;
        private System.Windows.Forms.Button BtnPaciente;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Label campUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaOrdenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPruebaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionABaseDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCuentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
    }
}