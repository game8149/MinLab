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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SplitCont = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnMedico = new System.Windows.Forms.Button();
            this.BtnInicio = new System.Windows.Forms.Button();
            this.BtnExamen = new System.Windows.Forms.Button();
            this.BtnAcerca = new System.Windows.Forms.Button();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.BtnOrden = new System.Windows.Forms.Button();
            this.BtnPaciente = new System.Windows.Forms.Button();
            this.CheckBoxMenu = new System.Windows.Forms.CheckBox();
            this.panelOpciones.SuspendLayout();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCont)).BeginInit();
            this.SplitCont.Panel1.SuspendLayout();
            this.SplitCont.Panel2.SuspendLayout();
            this.SplitCont.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOpciones
            // 
            this.panelOpciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelOpciones.BackColor = System.Drawing.Color.DimGray;
            this.panelOpciones.Controls.Add(this.BtnAcerca);
            this.panelOpciones.Controls.Add(this.button1);
            this.panelOpciones.Controls.Add(this.BtnMedico);
            this.panelOpciones.Controls.Add(this.BtnInicio);
            this.panelOpciones.Controls.Add(this.BtnExamen);
            this.panelOpciones.Controls.Add(this.BtnReporte);
            this.panelOpciones.Controls.Add(this.BtnOrden);
            this.panelOpciones.Controls.Add(this.BtnPaciente);
            this.panelOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpciones.Location = new System.Drawing.Point(0, 0);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(38, 623);
            this.panelOpciones.TabIndex = 0;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FloralWhite;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1072, 623);
            this.panelPrincipal.TabIndex = 4;
            this.panelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPrincipal_Paint);
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelBar.Controls.Add(this.CheckBoxMenu);
            this.panelBar.Controls.Add(this.label1);
            this.panelBar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1118, 36);
            this.panelBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(46, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Sistema de Laboratorio Clinico";
            // 
            // SplitCont
            // 
            this.SplitCont.BackColor = System.Drawing.SystemColors.GrayText;
            this.SplitCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitCont.Location = new System.Drawing.Point(0, 36);
            this.SplitCont.Name = "SplitCont";
            // 
            // SplitCont.Panel1
            // 
            this.SplitCont.Panel1.Controls.Add(this.panelOpciones);
            // 
            // SplitCont.Panel2
            // 
            this.SplitCont.Panel2.Controls.Add(this.panelPrincipal);
            this.SplitCont.Size = new System.Drawing.Size(1118, 625);
            this.SplitCont.SplitterDistance = 40;
            this.SplitCont.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SlateGray;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Image = global::MinLab.Properties.Resources.exit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(-3, 570);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 42);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnMedico
            // 
            this.BtnMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(150)))));
            this.BtnMedico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnMedico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMedico.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnMedico.FlatAppearance.BorderSize = 0;
            this.BtnMedico.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnMedico.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnMedico.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMedico.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMedico.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnMedico.Image = global::MinLab.Properties.Resources.doctor;
            this.BtnMedico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMedico.Location = new System.Drawing.Point(-1, 102);
            this.BtnMedico.Name = "BtnMedico";
            this.BtnMedico.Size = new System.Drawing.Size(180, 50);
            this.BtnMedico.TabIndex = 9;
            this.BtnMedico.Text = "Medicos";
            this.BtnMedico.UseVisualStyleBackColor = false;
            this.BtnMedico.Click += new System.EventHandler(this.BtnMedico_Click);
            // 
            // BtnInicio
            // 
            this.BtnInicio.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnInicio.FlatAppearance.BorderSize = 0;
            this.BtnInicio.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInicio.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnInicio.Image = global::MinLab.Properties.Resources.idcard;
            this.BtnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInicio.Location = new System.Drawing.Point(-2, -1);
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
            this.BtnExamen.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.BtnExamen.Location = new System.Drawing.Point(-1, 200);
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
            this.BtnAcerca.BackColor = System.Drawing.Color.SlateGray;
            this.BtnAcerca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAcerca.FlatAppearance.BorderSize = 0;
            this.BtnAcerca.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnAcerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAcerca.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAcerca.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAcerca.Image = global::MinLab.Properties.Resources.information;
            this.BtnAcerca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAcerca.Location = new System.Drawing.Point(-1, 522);
            this.BtnAcerca.Name = "BtnAcerca";
            this.BtnAcerca.Size = new System.Drawing.Size(42, 42);
            this.BtnAcerca.TabIndex = 6;
            this.BtnAcerca.UseVisualStyleBackColor = false;
            this.BtnAcerca.Click += new System.EventHandler(this.BtnAcerca_Click);
            // 
            // BtnReporte
            // 
            this.BtnReporte.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnReporte.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.BtnReporte.FlatAppearance.BorderSize = 0;
            this.BtnReporte.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporte.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReporte.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnReporte.Image = global::MinLab.Properties.Resources.report;
            this.BtnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReporte.Location = new System.Drawing.Point(-1, 249);
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
            this.BtnOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOrden.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnOrden.FlatAppearance.BorderSize = 0;
            this.BtnOrden.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnOrden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnOrden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOrden.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOrden.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnOrden.Image = global::MinLab.Properties.Resources.agenda;
            this.BtnOrden.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnOrden.Location = new System.Drawing.Point(-1, 151);
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
            this.BtnPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPaciente.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnPaciente.FlatAppearance.BorderSize = 0;
            this.BtnPaciente.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnPaciente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnPaciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPaciente.Font = new System.Drawing.Font("Futura Bk BT", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPaciente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnPaciente.Image = global::MinLab.Properties.Resources.boy;
            this.BtnPaciente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPaciente.Location = new System.Drawing.Point(-1, 53);
            this.BtnPaciente.Name = "BtnPaciente";
            this.BtnPaciente.Size = new System.Drawing.Size(182, 48);
            this.BtnPaciente.TabIndex = 3;
            this.BtnPaciente.Text = "Paciente";
            this.BtnPaciente.UseVisualStyleBackColor = false;
            this.BtnPaciente.Click += new System.EventHandler(this.BtnPaciente_Click);
            // 
            // CheckBoxMenu
            // 
            this.CheckBoxMenu.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBoxMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CheckBoxMenu.FlatAppearance.BorderSize = 0;
            this.CheckBoxMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBoxMenu.Image = global::MinLab.Properties.Resources.menu;
            this.CheckBoxMenu.Location = new System.Drawing.Point(2, 3);
            this.CheckBoxMenu.Name = "CheckBoxMenu";
            this.CheckBoxMenu.Size = new System.Drawing.Size(38, 31);
            this.CheckBoxMenu.TabIndex = 29;
            this.CheckBoxMenu.UseVisualStyleBackColor = true;
            this.CheckBoxMenu.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1118, 661);
            this.Controls.Add(this.SplitCont);
            this.Controls.Add(this.panelBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1241, 700);
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Winchanzao";
            this.panelOpciones.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            this.SplitCont.Panel1.ResumeLayout(false);
            this.SplitCont.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCont)).EndInit();
            this.SplitCont.ResumeLayout(false);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer SplitCont;
        private System.Windows.Forms.Button BtnMedico;
        private System.Windows.Forms.CheckBox CheckBoxMenu;
        private System.Windows.Forms.Button button1;
        private ComponenteGeneral.LabelUI labelMod1;
    }
}