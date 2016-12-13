namespace MinLab.Code.PresentationLayer
{
    partial class ControlPaciente
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnCrearPaciente = new System.Windows.Forms.Button();
            this.BtnBuscarPaciente = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LabelExamen = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PanelTrabajo = new System.Windows.Forms.Panel();
            this.PanelAcciones = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.PanelAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCrearPaciente
            // 
            this.BtnCrearPaciente.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCrearPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnCrearPaciente.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnCrearPaciente.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnCrearPaciente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnCrearPaciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnCrearPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCrearPaciente.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCrearPaciente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCrearPaciente.Image = global::MinLab.Properties.Resources.user__2_;
            this.BtnCrearPaciente.Location = new System.Drawing.Point(15, 46);
            this.BtnCrearPaciente.Name = "BtnCrearPaciente";
            this.BtnCrearPaciente.Size = new System.Drawing.Size(120, 42);
            this.BtnCrearPaciente.TabIndex = 75;
            this.BtnCrearPaciente.Text = "Crear Perfil";
            this.BtnCrearPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCrearPaciente.UseVisualStyleBackColor = false;
            this.BtnCrearPaciente.Click += new System.EventHandler(this.BtnCrearPaciente_Click_1);
            // 
            // BtnBuscarPaciente
            // 
            this.BtnBuscarPaciente.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnBuscarPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnBuscarPaciente.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnBuscarPaciente.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnBuscarPaciente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.BtnBuscarPaciente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarPaciente.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarPaciente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnBuscarPaciente.Image = global::MinLab.Properties.Resources.search_engine__1_;
            this.BtnBuscarPaciente.Location = new System.Drawing.Point(15, 94);
            this.BtnBuscarPaciente.Name = "BtnBuscarPaciente";
            this.BtnBuscarPaciente.Size = new System.Drawing.Size(120, 42);
            this.BtnBuscarPaciente.TabIndex = 74;
            this.BtnBuscarPaciente.Text = "Buscar Perfil";
            this.BtnBuscarPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBuscarPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBuscarPaciente.UseVisualStyleBackColor = false;
            this.BtnBuscarPaciente.Click += new System.EventHandler(this.BtnBuscarPaciente_Click_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.LabelExamen);
            this.panel4.Controls.Add(this.BtnClose);
            this.panel4.Location = new System.Drawing.Point(20, 20);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(858, 30);
            this.panel4.TabIndex = 97;
            // 
            // LabelExamen
            // 
            this.LabelExamen.AutoSize = true;
            this.LabelExamen.Font = new System.Drawing.Font("Futura Md BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExamen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelExamen.Location = new System.Drawing.Point(4, 5);
            this.LabelExamen.MaximumSize = new System.Drawing.Size(450, 0);
            this.LabelExamen.Name = "LabelExamen";
            this.LabelExamen.Size = new System.Drawing.Size(113, 16);
            this.LabelExamen.TabIndex = 76;
            this.LabelExamen.Text = "Ficha de Paciente";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Image = global::MinLab.Properties.Resources.cancel;
            this.BtnClose.Location = new System.Drawing.Point(824, 1);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(31, 27);
            this.BtnClose.TabIndex = 75;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Visible = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PanelTrabajo
            // 
            this.PanelTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTrabajo.Location = new System.Drawing.Point(20, 50);
            this.PanelTrabajo.Name = "PanelTrabajo";
            this.PanelTrabajo.Size = new System.Drawing.Size(858, 548);
            this.PanelTrabajo.TabIndex = 96;
            // 
            // PanelAcciones
            // 
            this.PanelAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAcciones.Controls.Add(this.label1);
            this.PanelAcciones.Controls.Add(this.BtnBuscarPaciente);
            this.PanelAcciones.Controls.Add(this.BtnCrearPaciente);
            this.PanelAcciones.Location = new System.Drawing.Point(898, 20);
            this.PanelAcciones.Name = "PanelAcciones";
            this.PanelAcciones.Size = new System.Drawing.Size(148, 578);
            this.PanelAcciones.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Md BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.MaximumSize = new System.Drawing.Size(450, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 77;
            this.label1.Text = "Acciones";
            // 
            // ControlPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.PanelAcciones);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.PanelTrabajo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ControlPaciente";
            this.Size = new System.Drawing.Size(1066, 617);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.PanelAcciones.ResumeLayout(false);
            this.PanelAcciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnBuscarPaciente;
        private System.Windows.Forms.Button BtnCrearPaciente;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LabelExamen;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel PanelTrabajo;
        private System.Windows.Forms.Panel PanelAcciones;
        private System.Windows.Forms.Label label1;
    }
}
