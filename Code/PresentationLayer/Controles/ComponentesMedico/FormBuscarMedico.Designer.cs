namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    partial class FormBuscarMedico

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
            this.BtnCargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CampNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Campapellido2erno = new System.Windows.Forms.TextBox();
            this.Campapellido1erno = new System.Windows.Forms.TextBox();
            this.DGVMedico = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colegiatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CheckBoxHabil = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVMedico)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCargar
            // 
            this.BtnCargar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnCargar.FlatAppearance.BorderSize = 0;
            this.BtnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCargar.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCargar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCargar.Location = new System.Drawing.Point(566, 431);
            this.BtnCargar.Name = "BtnCargar";
            this.BtnCargar.Size = new System.Drawing.Size(97, 31);
            this.BtnCargar.TabIndex = 8;
            this.BtnCargar.Text = "Cargar";
            this.BtnCargar.UseVisualStyleBackColor = false;
            this.BtnCargar.Click += new System.EventHandler(this.BtnCargar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(332, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido Materno:";
            // 
            // CampNombre
            // 
            this.CampNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampNombre.Location = new System.Drawing.Point(132, 60);
            this.CampNombre.MaxLength = 99;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(169, 23);
            this.CampNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido Paterno:";
            // 
            // Campapellido2erno
            // 
            this.Campapellido2erno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Campapellido2erno.Location = new System.Drawing.Point(452, 93);
            this.Campapellido2erno.MaxLength = 99;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new System.Drawing.Size(169, 23);
            this.Campapellido2erno.TabIndex = 3;
            // 
            // Campapellido1erno
            // 
            this.Campapellido1erno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Campapellido1erno.Location = new System.Drawing.Point(132, 93);
            this.Campapellido1erno.MaxLength = 99;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new System.Drawing.Size(169, 23);
            this.Campapellido1erno.TabIndex = 2;
            // 
            // DGVMedico
            // 
            this.DGVMedico.AllowUserToAddRows = false;
            this.DGVMedico.AllowUserToDeleteRows = false;
            this.DGVMedico.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVMedico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVMedico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.colegiatura,
            this.Nombre,
            this.especialidad});
            this.DGVMedico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVMedico.Location = new System.Drawing.Point(3, 19);
            this.DGVMedico.Name = "DGVMedico";
            this.DGVMedico.ReadOnly = true;
            this.DGVMedico.Size = new System.Drawing.Size(640, 225);
            this.DGVMedico.TabIndex = 7;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // colegiatura
            // 
            this.colegiatura.HeaderText = "Colegiatura";
            this.colegiatura.Name = "colegiatura";
            this.colegiatura.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // especialidad
            // 
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.Name = "especialidad";
            this.especialidad.ReadOnly = true;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnBuscar.Location = new System.Drawing.Point(566, 132);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(97, 31);
            this.BtnBuscar.TabIndex = 6;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVMedico);
            this.groupBox1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 247);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 19);
            this.label11.TabIndex = 40;
            this.label11.Text = "Filtro de Busqueda";
            // 
            // CheckBoxHabil
            // 
            this.CheckBoxHabil.AutoSize = true;
            this.CheckBoxHabil.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxHabil.Location = new System.Drawing.Point(332, 63);
            this.CheckBoxHabil.Name = "CheckBoxHabil";
            this.CheckBoxHabil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxHabil.Size = new System.Drawing.Size(87, 20);
            this.CheckBoxHabil.TabIndex = 41;
            this.CheckBoxHabil.Text = ":Habilitado";
            this.CheckBoxHabil.UseVisualStyleBackColor = true;
            // 
            // FormBuscarMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(685, 482);
            this.Controls.Add(this.CheckBoxHabil);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCargar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.Campapellido1erno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Campapellido2erno);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuscarMedico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Paciente";
            ((System.ComponentModel.ISupportInitialize)(this.DGVMedico)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnCargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CampNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Campapellido2erno;
        private System.Windows.Forms.TextBox Campapellido1erno;
        private System.Windows.Forms.DataGridView DGVMedico;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn colegiatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad;
        private System.Windows.Forms.CheckBox CheckBoxHabil;
    }
}