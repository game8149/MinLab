namespace MinLab.Code.PresentationLayer.Controles.ComponentesReporte
{
    partial class FormTarifario
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
            this.DGVTar = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.examen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTarifarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enBlancoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deExistenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LabelExamen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnVigente = new System.Windows.Forms.Button();
            this.CampRegistro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ComboBoxAno = new System.Windows.Forms.ComboBox();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVTar
            // 
            this.DGVTar.AllowUserToAddRows = false;
            this.DGVTar.AllowUserToDeleteRows = false;
            this.DGVTar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVTar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVTar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.examen,
            this.precio});
            this.DGVTar.Location = new System.Drawing.Point(12, 90);
            this.DGVTar.Name = "DGVTar";
            this.DGVTar.Size = new System.Drawing.Size(558, 478);
            this.DGVTar.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // examen
            // 
            this.examen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.examen.HeaderText = "Examen";
            this.examen.Name = "examen";
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTarifarioToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoTarifarioToolStripMenuItem
            // 
            this.nuevoTarifarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enBlancoToolStripMenuItem,
            this.deExistenteToolStripMenuItem});
            this.nuevoTarifarioToolStripMenuItem.Name = "nuevoTarifarioToolStripMenuItem";
            this.nuevoTarifarioToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nuevoTarifarioToolStripMenuItem.Text = "Nuevo tarifario";
            this.nuevoTarifarioToolStripMenuItem.Click += new System.EventHandler(this.nuevoTarifarioToolStripMenuItem_Click);
            // 
            // enBlancoToolStripMenuItem
            // 
            this.enBlancoToolStripMenuItem.Name = "enBlancoToolStripMenuItem";
            this.enBlancoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.enBlancoToolStripMenuItem.Text = "En blanco";
            this.enBlancoToolStripMenuItem.Click += new System.EventHandler(this.enBlancoToolStripMenuItem_Click);
            // 
            // deExistenteToolStripMenuItem
            // 
            this.deExistenteToolStripMenuItem.Name = "deExistenteToolStripMenuItem";
            this.deExistenteToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.deExistenteToolStripMenuItem.Text = "Copia de existente";
            this.deExistenteToolStripMenuItem.Click += new System.EventHandler(this.deExistenteToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 571);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nota: Sea prudente al manipular esta informaci\'on.  Si tiene dudas, consulte con " +
    "el jefe de area.";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.LabelExamen);
            this.panel4.Location = new System.Drawing.Point(12, 28);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 30);
            this.panel4.TabIndex = 104;
            // 
            // LabelExamen
            // 
            this.LabelExamen.AutoSize = true;
            this.LabelExamen.Font = new System.Drawing.Font("Futura Md BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExamen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelExamen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LabelExamen.Location = new System.Drawing.Point(10, 8);
            this.LabelExamen.MaximumSize = new System.Drawing.Size(450, 0);
            this.LabelExamen.Name = "LabelExamen";
            this.LabelExamen.Size = new System.Drawing.Size(59, 16);
            this.LabelExamen.TabIndex = 76;
            this.LabelExamen.Text = "Tarifario";
            this.LabelExamen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnVigente);
            this.panel1.Controls.Add(this.CampRegistro);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ComboBoxAno);
            this.panel1.Controls.Add(this.BtnModificar);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.BtnPrint);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.BtnCerrar);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 32);
            this.panel1.TabIndex = 103;
            // 
            // BtnVigente
            // 
            this.BtnVigente.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnVigente.FlatAppearance.BorderSize = 0;
            this.BtnVigente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVigente.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnVigente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnVigente.Location = new System.Drawing.Point(367, 3);
            this.BtnVigente.Name = "BtnVigente";
            this.BtnVigente.Size = new System.Drawing.Size(96, 23);
            this.BtnVigente.TabIndex = 83;
            this.BtnVigente.Text = "Hacer Vigente";
            this.BtnVigente.UseVisualStyleBackColor = false;
            this.BtnVigente.Click += new System.EventHandler(this.BtnVigente_Click);
            // 
            // CampRegistro
            // 
            this.CampRegistro.AutoSize = true;
            this.CampRegistro.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampRegistro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CampRegistro.Location = new System.Drawing.Point(247, 7);
            this.CampRegistro.Name = "CampRegistro";
            this.CampRegistro.Size = new System.Drawing.Size(58, 16);
            this.CampRegistro.TabIndex = 82;
            this.CampRegistro.Text = "--/--/----";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(192, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "Registro:";
            // 
            // ComboBoxAno
            // 
            this.ComboBoxAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxAno.FormattingEnabled = true;
            this.ComboBoxAno.Location = new System.Drawing.Point(55, 5);
            this.ComboBoxAno.Name = "ComboBoxAno";
            this.ComboBoxAno.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxAno.TabIndex = 78;
            this.ComboBoxAno.SelectedIndexChanged += new System.EventHandler(this.ComboBoxAno_SelectedIndexChanged);
            // 
            // BtnModificar
            // 
            this.BtnModificar.AutoSize = true;
            this.BtnModificar.FlatAppearance.BorderSize = 0;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Image = global::MinLab.Properties.Resources.file1;
            this.BtnModificar.Location = new System.Drawing.Point(522, 0);
            this.BtnModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(31, 30);
            this.BtnModificar.TabIndex = 76;
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Visible = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.AutoSize = true;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Image = global::MinLab.Properties.Resources.save;
            this.BtnSave.Location = new System.Drawing.Point(489, 0);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(31, 30);
            this.BtnSave.TabIndex = 75;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.FlatAppearance.BorderSize = 0;
            this.BtnPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.SystemColors.Info;
            this.BtnPrint.Image = global::MinLab.Properties.Resources.printer;
            this.BtnPrint.Location = new System.Drawing.Point(996, -1);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(33, 32);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(15, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "Año:";
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.AutoSize = true;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = global::MinLab.Properties.Resources.cancel;
            this.BtnCerrar.Location = new System.Drawing.Point(522, 0);
            this.BtnCerrar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(31, 30);
            this.BtnCerrar.TabIndex = 77;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Visible = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FormTarifario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(585, 593);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVTar);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormTarifario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuraci\'on de Tarifario";
            ((System.ComponentModel.ISupportInitialize)(this.DGVTar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVTar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoTarifarioToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LabelExamen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.ComboBox ComboBoxAno;
        private System.Windows.Forms.ToolStripMenuItem enBlancoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deExistenteToolStripMenuItem;
        private System.Windows.Forms.Label CampRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnVigente;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn examen;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
    }
}