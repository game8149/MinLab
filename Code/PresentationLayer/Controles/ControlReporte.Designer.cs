namespace MinLab.Code.PresentationLayer.Controles
{
    partial class ControlReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlReporte));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LinkLabelTarifario = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBoxMesEcono = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.NumericUDEcono = new System.Windows.Forms.NumericUpDown();
            this.BtnExportEcono = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBoxEcono = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBoxResult = new System.Windows.Forms.ComboBox();
            this.BtnExportResult = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.NumericUDResult = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ComboBoxMesResult = new System.Windows.Forms.ComboBox();
            this.DialogFolderBuscar = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDEcono)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LinkLabelTarifario);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1072, 623);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LinkLabelTarifario
            // 
            this.LinkLabelTarifario.ActiveLinkColor = System.Drawing.Color.DimGray;
            this.LinkLabelTarifario.AutoSize = true;
            this.LinkLabelTarifario.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabelTarifario.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LinkLabelTarifario.Location = new System.Drawing.Point(876, 42);
            this.LinkLabelTarifario.Name = "LinkLabelTarifario";
            this.LinkLabelTarifario.Size = new System.Drawing.Size(157, 16);
            this.LinkLabelTarifario.TabIndex = 163;
            this.LinkLabelTarifario.TabStop = true;
            this.LinkLabelTarifario.Text = "Configuracion de Tarifario";
            this.LinkLabelTarifario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTarifario_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.ComboBoxMesEcono);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.NumericUDEcono);
            this.panel4.Controls.Add(this.BtnExportEcono);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.ComboBoxEcono);
            this.panel4.Location = new System.Drawing.Point(231, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(273, 546);
            this.panel4.TabIndex = 162;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(272, 44);
            this.panel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 10.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(14, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 132;
            this.label2.Text = "Reporte Economico";
            // 
            // ComboBoxMesEcono
            // 
            this.ComboBoxMesEcono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMesEcono.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxMesEcono.FormattingEnabled = true;
            this.ComboBoxMesEcono.Location = new System.Drawing.Point(112, 133);
            this.ComboBoxMesEcono.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxMesEcono.Name = "ComboBoxMesEcono";
            this.ComboBoxMesEcono.Size = new System.Drawing.Size(147, 24);
            this.ComboBoxMesEcono.TabIndex = 125;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Futura Bk BT", 9.5F);
            this.label10.Location = new System.Drawing.Point(17, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(242, 293);
            this.label10.TabIndex = 150;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // NumericUDEcono
            // 
            this.NumericUDEcono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUDEcono.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUDEcono.Location = new System.Drawing.Point(112, 95);
            this.NumericUDEcono.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.NumericUDEcono.Minimum = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.NumericUDEcono.Name = "NumericUDEcono";
            this.NumericUDEcono.Size = new System.Drawing.Size(147, 23);
            this.NumericUDEcono.TabIndex = 128;
            this.NumericUDEcono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUDEcono.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // BtnExportEcono
            // 
            this.BtnExportEcono.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportEcono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnExportEcono.FlatAppearance.BorderSize = 0;
            this.BtnExportEcono.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnExportEcono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportEcono.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportEcono.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnExportEcono.Image = global::MinLab.Properties.Resources.export;
            this.BtnExportEcono.Location = new System.Drawing.Point(146, 490);
            this.BtnExportEcono.Name = "BtnExportEcono";
            this.BtnExportEcono.Size = new System.Drawing.Size(113, 37);
            this.BtnExportEcono.TabIndex = 137;
            this.BtnExportEcono.Text = "Exportar";
            this.BtnExportEcono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportEcono.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExportEcono.UseVisualStyleBackColor = false;
            this.BtnExportEcono.Click += new System.EventHandler(this.BtnExportEcono_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label4.Location = new System.Drawing.Point(14, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 127;
            this.label4.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(14, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 126;
            this.label3.Text = "Mes:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label8.Location = new System.Drawing.Point(14, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 140;
            this.label8.Text = "Filtro:";
            // 
            // ComboBoxEcono
            // 
            this.ComboBoxEcono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxEcono.FormattingEnabled = true;
            this.ComboBoxEcono.Items.AddRange(new object[] {
            "General",
            "Por Edad",
            "Por Medico"});
            this.ComboBoxEcono.Location = new System.Drawing.Point(112, 60);
            this.ComboBoxEcono.Name = "ComboBoxEcono";
            this.ComboBoxEcono.Size = new System.Drawing.Size(147, 21);
            this.ComboBoxEcono.TabIndex = 139;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.ComboBoxResult);
            this.panel2.Controls.Add(this.BtnExportResult);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.NumericUDResult);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.ComboBoxMesResult);
            this.panel2.Location = new System.Drawing.Point(542, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 545);
            this.panel2.TabIndex = 161;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 44);
            this.panel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 10.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(16, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 18);
            this.label6.TabIndex = 158;
            this.label6.Text = "Reporte de Resultados";
            // 
            // ComboBoxResult
            // 
            this.ComboBoxResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxResult.FormattingEnabled = true;
            this.ComboBoxResult.Items.AddRange(new object[] {
            "General"});
            this.ComboBoxResult.Location = new System.Drawing.Point(114, 58);
            this.ComboBoxResult.Name = "ComboBoxResult";
            this.ComboBoxResult.Size = new System.Drawing.Size(147, 21);
            this.ComboBoxResult.TabIndex = 159;
            // 
            // BtnExportResult
            // 
            this.BtnExportResult.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExportResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnExportResult.FlatAppearance.BorderSize = 0;
            this.BtnExportResult.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnExportResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportResult.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnExportResult.Image = global::MinLab.Properties.Resources.export;
            this.BtnExportResult.Location = new System.Drawing.Point(148, 489);
            this.BtnExportResult.Name = "BtnExportResult";
            this.BtnExportResult.Size = new System.Drawing.Size(113, 37);
            this.BtnExportResult.TabIndex = 149;
            this.BtnExportResult.Text = "Exportar";
            this.BtnExportResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExportResult.UseVisualStyleBackColor = false;
            this.BtnExportResult.Click += new System.EventHandler(this.BtnExportResult_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label5.Location = new System.Drawing.Point(16, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 160;
            this.label5.Text = "Filtro:";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 9.5F);
            this.label11.Location = new System.Drawing.Point(16, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 283);
            this.label11.TabIndex = 151;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // NumericUDResult
            // 
            this.NumericUDResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumericUDResult.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUDResult.Location = new System.Drawing.Point(114, 93);
            this.NumericUDResult.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.NumericUDResult.Minimum = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.NumericUDResult.Name = "NumericUDResult";
            this.NumericUDResult.Size = new System.Drawing.Size(147, 23);
            this.NumericUDResult.TabIndex = 155;
            this.NumericUDResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumericUDResult.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label12.Location = new System.Drawing.Point(16, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 16);
            this.label12.TabIndex = 154;
            this.label12.Text = "Año:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label9.Location = new System.Drawing.Point(16, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 153;
            this.label9.Text = "Mes:";
            // 
            // ComboBoxMesResult
            // 
            this.ComboBoxMesResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMesResult.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBoxMesResult.FormattingEnabled = true;
            this.ComboBoxMesResult.Location = new System.Drawing.Point(114, 131);
            this.ComboBoxMesResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxMesResult.Name = "ComboBoxMesResult";
            this.ComboBoxMesResult.Size = new System.Drawing.Size(147, 24);
            this.ComboBoxMesResult.TabIndex = 152;
            // 
            // ControlReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Name = "ControlReporte";
            this.Size = new System.Drawing.Size(1072, 623);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDEcono)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUDResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBoxMesEcono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NumericUDEcono;
        private System.Windows.Forms.Button BtnExportEcono;
        private System.Windows.Forms.FolderBrowserDialog DialogFolderBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboBoxEcono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBoxMesResult;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown NumericUDResult;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnExportResult;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.LinkLabel LinkLabelTarifario;
    }
}
