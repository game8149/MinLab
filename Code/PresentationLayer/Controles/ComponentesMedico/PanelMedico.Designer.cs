namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    partial class PanelMedico
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboEstado = new System.Windows.Forms.ComboBox();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.PickerEnd = new System.Windows.Forms.DateTimePicker();
            this.PickerInit = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CampHabil = new System.Windows.Forms.Label();
            this.CampColegiatura = new System.Windows.Forms.Label();
            this.CampNombre = new System.Windows.Forms.Label();
            this.DGVExamen = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.CampEspecialidad = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVExamen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.ComboEstado);
            this.panel1.Controls.Add(this.BtnPrint);
            this.panel1.Controls.Add(this.PickerEnd);
            this.panel1.Controls.Add(this.PickerInit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(21, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 34);
            this.panel1.TabIndex = 89;
            // 
            // ComboEstado
            // 
            this.ComboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboEstado.Enabled = false;
            this.ComboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboEstado.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboEstado.FormattingEnabled = true;
            this.ComboEstado.Location = new System.Drawing.Point(412, 5);
            this.ComboEstado.Name = "ComboEstado";
            this.ComboEstado.Size = new System.Drawing.Size(121, 24);
            this.ComboEstado.TabIndex = 69;
            this.ComboEstado.SelectedIndexChanged += new System.EventHandler(this.ComboEstado_SelectedIndexChanged);
            // 
            // BtnPrint
            // 
            this.BtnPrint.AutoSize = true;
            this.BtnPrint.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BtnPrint.Enabled = false;
            this.BtnPrint.FlatAppearance.BorderSize = 0;
            this.BtnPrint.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.SystemColors.Info;
            this.BtnPrint.Image = global::MinLab.Properties.Resources.printer;
            this.BtnPrint.Location = new System.Drawing.Point(985, 6);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(22, 22);
            this.BtnPrint.TabIndex = 71;
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Visible = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // PickerEnd
            // 
            this.PickerEnd.Enabled = false;
            this.PickerEnd.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PickerEnd.Location = new System.Drawing.Point(206, 6);
            this.PickerEnd.Name = "PickerEnd";
            this.PickerEnd.Size = new System.Drawing.Size(97, 23);
            this.PickerEnd.TabIndex = 64;
            this.PickerEnd.ValueChanged += new System.EventHandler(this.PickerEnd_ValueChanged);
            // 
            // PickerInit
            // 
            this.PickerInit.Enabled = false;
            this.PickerInit.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickerInit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PickerInit.Location = new System.Drawing.Point(57, 6);
            this.PickerInit.MaxDate = new System.DateTime(2110, 12, 31, 0, 0, 0, 0);
            this.PickerInit.MinDate = new System.DateTime(2016, 10, 15, 0, 0, 0, 0);
            this.PickerInit.Name = "PickerInit";
            this.PickerInit.Size = new System.Drawing.Size(98, 23);
            this.PickerInit.TabIndex = 65;
            this.PickerInit.Value = new System.DateTime(2016, 10, 15, 15, 59, 36, 0);
            this.PickerInit.ValueChanged += new System.EventHandler(this.PickerInit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Desde ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(348, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(164, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 67;
            this.label3.Text = "hasta";
            // 
            // CampHabil
            // 
            this.CampHabil.AutoSize = true;
            this.CampHabil.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampHabil.Location = new System.Drawing.Point(250, 118);
            this.CampHabil.Name = "CampHabil";
            this.CampHabil.Size = new System.Drawing.Size(40, 16);
            this.CampHabil.TabIndex = 88;
            this.CampHabil.Text = "Alexis";
            // 
            // CampColegiatura
            // 
            this.CampColegiatura.AutoSize = true;
            this.CampColegiatura.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampColegiatura.Location = new System.Drawing.Point(107, 118);
            this.CampColegiatura.Name = "CampColegiatura";
            this.CampColegiatura.Size = new System.Drawing.Size(40, 16);
            this.CampColegiatura.TabIndex = 85;
            this.CampColegiatura.Text = "Alexis";
            // 
            // CampNombre
            // 
            this.CampNombre.AutoSize = true;
            this.CampNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampNombre.Location = new System.Drawing.Point(107, 75);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(40, 16);
            this.CampNombre.TabIndex = 83;
            this.CampNombre.Text = "Alexis";
            // 
            // DGVExamen
            // 
            this.DGVExamen.AllowUserToAddRows = false;
            this.DGVExamen.AllowUserToDeleteRows = false;
            this.DGVExamen.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVExamen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVExamen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewComboBoxColumn1,
            this.lastModif,
            this.IdOrden});
            this.DGVExamen.Enabled = false;
            this.DGVExamen.Location = new System.Drawing.Point(21, 271);
            this.DGVExamen.Name = "DGVExamen";
            this.DGVExamen.ReadOnly = true;
            this.DGVExamen.Size = new System.Drawing.Size(1018, 264);
            this.DGVExamen.TabIndex = 82;
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Examen";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Abrir Examen";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Responsable";
            this.dataGridViewComboBoxColumn1.MinimumWidth = 150;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewComboBoxColumn1.Width = 150;
            // 
            // lastModif
            // 
            this.lastModif.HeaderText = "Ultima Modificación";
            this.lastModif.Name = "lastModif";
            this.lastModif.ReadOnly = true;
            // 
            // IdOrden
            // 
            this.IdOrden.HeaderText = "IdOrden";
            this.IdOrden.Name = "IdOrden";
            this.IdOrden.ReadOnly = true;
            this.IdOrden.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(18, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 19);
            this.label11.TabIndex = 81;
            this.label11.Text = "Historia de Examenes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 19);
            this.label12.TabIndex = 80;
            this.label12.Text = "Perfil de Medico";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(199, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 79;
            this.label13.Text = "Estado: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 16);
            this.label14.TabIndex = 78;
            this.label14.Text = "Colegiatura:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(20, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 16);
            this.label18.TabIndex = 74;
            this.label18.Text = "Nombre:";
            // 
            // CampEspecialidad
            // 
            this.CampEspecialidad.AutoSize = true;
            this.CampEspecialidad.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampEspecialidad.Location = new System.Drawing.Point(107, 161);
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new System.Drawing.Size(40, 16);
            this.CampEspecialidad.TabIndex = 127;
            this.CampEspecialidad.Text = "Alexis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 126;
            this.label5.Text = "Especialidad:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Futura Bk BT", 8.25F);
            this.BtnEliminar.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnEliminar.Image = global::MinLab.Properties.Resources.cancel;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(936, 75);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(103, 32);
            this.BtnEliminar.TabIndex = 129;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click_1);
            // 
            // BtnModificar
            // 
            this.BtnModificar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnModificar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.BtnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModificar.Font = new System.Drawing.Font("Futura Bk BT", 8.25F);
            this.BtnModificar.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnModificar.Image = global::MinLab.Properties.Resources.cleaner;
            this.BtnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModificar.Location = new System.Drawing.Point(936, 26);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(103, 32);
            this.BtnModificar.TabIndex = 128;
            this.BtnModificar.Text = "Editar";
            this.BtnModificar.UseVisualStyleBackColor = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // PanelMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.CampEspecialidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CampHabil);
            this.Controls.Add(this.CampColegiatura);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.DGVExamen);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label18);
            this.Name = "PanelMedico";
            this.Size = new System.Drawing.Size(1066, 560);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVExamen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ComboEstado;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.DateTimePicker PickerEnd;
        private System.Windows.Forms.DateTimePicker PickerInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CampHabil;
        private System.Windows.Forms.Label CampColegiatura;
        private System.Windows.Forms.Label CampNombre;
        private System.Windows.Forms.DataGridView DGVExamen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModif;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrden;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label CampEspecialidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnModificar;
    }
}
