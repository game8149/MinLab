namespace MinLab.Code.PresentationLayer.Controles.ComponentesOrden
{
    partial class FormModificarOrden
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CampBoleta = new System.Windows.Forms.TextBox();
            this.PickerTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelToolDetalle = new System.Windows.Forms.Panel();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.LabelNombreExamen = new System.Windows.Forms.Label();
            this.ComboExamen = new System.Windows.Forms.ComboBox();
            this.CampDireccion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CampHistoria = new System.Windows.Forms.Label();
            this.CampDni = new System.Windows.Forms.Label();
            this.CampNombre = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cobertura = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.idUnique = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckBoxGestante = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ComboBoxMedico = new System.Windows.Forms.ComboBox();
            this.ComboBoxConsultorio = new System.Windows.Forms.ComboBox();
            this.CampSexo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.PanelToolDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 180;
            this.label2.Text = "Orden de Ingreso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 469);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 166;
            this.label3.Text = "Fecha:";
            // 
            // CampBoleta
            // 
            this.CampBoleta.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampBoleta.Location = new System.Drawing.Point(645, 174);
            this.CampBoleta.Name = "CampBoleta";
            this.CampBoleta.Size = new System.Drawing.Size(108, 23);
            this.CampBoleta.TabIndex = 168;
            // 
            // PickerTime
            // 
            this.PickerTime.CalendarFont = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PickerTime.Location = new System.Drawing.Point(84, 467);
            this.PickerTime.Name = "PickerTime";
            this.PickerTime.Size = new System.Drawing.Size(108, 20);
            this.PickerTime.TabIndex = 178;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 169;
            this.label1.Text = "Boleta:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnGuardar.Location = new System.Drawing.Point(718, 451);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(115, 39);
            this.BtnGuardar.TabIndex = 143;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(764, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 176;
            this.label7.Text = "(Opcional)";
            // 
            // PanelToolDetalle
            // 
            this.PanelToolDetalle.BackColor = System.Drawing.Color.SteelBlue;
            this.PanelToolDetalle.Controls.Add(this.BtnEliminar);
            this.PanelToolDetalle.Controls.Add(this.BtnAgregar);
            this.PanelToolDetalle.Controls.Add(this.LabelNombreExamen);
            this.PanelToolDetalle.Controls.Add(this.ComboExamen);
            this.PanelToolDetalle.Location = new System.Drawing.Point(11, 213);
            this.PanelToolDetalle.Name = "PanelToolDetalle";
            this.PanelToolDetalle.Size = new System.Drawing.Size(822, 32);
            this.PanelToolDetalle.TabIndex = 177;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnAgregar.FlatAppearance.BorderSize = 0;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAgregar.Image = global::MinLab.Properties.Resources.bag;
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(408, 0);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(90, 32);
            this.BtnAgregar.TabIndex = 61;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = false;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // LabelNombreExamen
            // 
            this.LabelNombreExamen.AutoSize = true;
            this.LabelNombreExamen.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombreExamen.ForeColor = System.Drawing.SystemColors.Window;
            this.LabelNombreExamen.Location = new System.Drawing.Point(12, 8);
            this.LabelNombreExamen.Name = "LabelNombreExamen";
            this.LabelNombreExamen.Size = new System.Drawing.Size(57, 16);
            this.LabelNombreExamen.TabIndex = 59;
            this.LabelNombreExamen.Text = "Paquete:";
            // 
            // ComboExamen
            // 
            this.ComboExamen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboExamen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ComboExamen.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExamen.FormattingEnabled = true;
            this.ComboExamen.Location = new System.Drawing.Point(88, 4);
            this.ComboExamen.Name = "ComboExamen";
            this.ComboExamen.Size = new System.Drawing.Size(304, 24);
            this.ComboExamen.TabIndex = 62;
            // 
            // CampDireccion
            // 
            this.CampDireccion.AutoSize = true;
            this.CampDireccion.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampDireccion.Location = new System.Drawing.Point(87, 135);
            this.CampDireccion.Name = "CampDireccion";
            this.CampDireccion.Size = new System.Drawing.Size(27, 16);
            this.CampDireccion.TabIndex = 175;
            this.CampDireccion.Text = "asd";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 174;
            this.label9.Text = "Dirección:";
            // 
            // CampHistoria
            // 
            this.CampHistoria.AutoSize = true;
            this.CampHistoria.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampHistoria.Location = new System.Drawing.Point(267, 95);
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new System.Drawing.Size(51, 16);
            this.CampHistoria.TabIndex = 173;
            this.CampHistoria.Text = "label11";
            // 
            // CampDni
            // 
            this.CampDni.AutoSize = true;
            this.CampDni.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampDni.Location = new System.Drawing.Point(84, 95);
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new System.Drawing.Size(43, 16);
            this.CampDni.TabIndex = 172;
            this.CampDni.Text = "label9";
            // 
            // CampNombre
            // 
            this.CampNombre.AutoSize = true;
            this.CampNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampNombre.Location = new System.Drawing.Point(84, 55);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(43, 16);
            this.CampNombre.TabIndex = 171;
            this.CampNombre.Text = "label7";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigo,
            this.nombre,
            this.cobertura,
            this.idUnique});
            this.dataGridView.Location = new System.Drawing.Point(11, 244);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Size = new System.Drawing.Size(822, 189);
            this.dataGridView.TabIndex = 170;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo";
            this.codigo.Name = "codigo";
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // cobertura
            // 
            this.cobertura.HeaderText = "Cobertura";
            this.cobertura.Name = "cobertura";
            this.cobertura.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cobertura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // idUnique
            // 
            this.idUnique.HeaderText = "idUnique";
            this.idUnique.Name = "idUnique";
            this.idUnique.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(207, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 16);
            this.label10.TabIndex = 165;
            this.label10.Text = "Historia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 164;
            this.label8.Text = "DNI:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 163;
            this.label4.Text = "Nombre:";
            // 
            // CheckBoxGestante
            // 
            this.CheckBoxGestante.AutoSize = true;
            this.CheckBoxGestante.Font = new System.Drawing.Font("Futura Bk BT", 9.25F);
            this.CheckBoxGestante.Location = new System.Drawing.Point(533, 93);
            this.CheckBoxGestante.Name = "CheckBoxGestante";
            this.CheckBoxGestante.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxGestante.Size = new System.Drawing.Size(101, 20);
            this.CheckBoxGestante.TabIndex = 181;
            this.CheckBoxGestante.Text = ":En gestacion";
            this.CheckBoxGestante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxGestante.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(269, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 185;
            this.label11.Text = "Consultorio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 184;
            this.label5.Text = "Medico:";
            // 
            // ComboBoxMedico
            // 
            this.ComboBoxMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxMedico.FormattingEnabled = true;
            this.ComboBoxMedico.Location = new System.Drawing.Point(80, 173);
            this.ComboBoxMedico.Name = "ComboBoxMedico";
            this.ComboBoxMedico.Size = new System.Drawing.Size(178, 21);
            this.ComboBoxMedico.TabIndex = 183;
            // 
            // ComboBoxConsultorio
            // 
            this.ComboBoxConsultorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxConsultorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxConsultorio.FormattingEnabled = true;
            this.ComboBoxConsultorio.Location = new System.Drawing.Point(355, 173);
            this.ComboBoxConsultorio.Name = "ComboBoxConsultorio";
            this.ComboBoxConsultorio.Size = new System.Drawing.Size(222, 21);
            this.ComboBoxConsultorio.TabIndex = 182;
            // 
            // CampSexo
            // 
            this.CampSexo.AutoSize = true;
            this.CampSexo.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampSexo.Location = new System.Drawing.Point(443, 95);
            this.CampSexo.Name = "CampSexo";
            this.CampSexo.Size = new System.Drawing.Size(51, 16);
            this.CampSexo.TabIndex = 187;
            this.CampSexo.Text = "label11";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(383, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 186;
            this.label6.Text = "Sexo:";
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.SystemColors.Info;
            this.BtnEliminar.Image = global::MinLab.Properties.Resources.delete;
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(736, 0);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(86, 31);
            this.BtnEliminar.TabIndex = 71;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // FormModificarOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(852, 512);
            this.Controls.Add(this.CampSexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComboBoxMedico);
            this.Controls.Add(this.ComboBoxConsultorio);
            this.Controls.Add(this.CheckBoxGestante);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CampBoleta);
            this.Controls.Add(this.PickerTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PanelToolDetalle);
            this.Controls.Add(this.CampDireccion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CampHistoria);
            this.Controls.Add(this.CampDni);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModificarOrden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ficha de Orden";
            this.PanelToolDetalle.ResumeLayout(false);
            this.PanelToolDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CampBoleta;
        private System.Windows.Forms.DateTimePicker PickerTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PanelToolDetalle;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label LabelNombreExamen;
        private System.Windows.Forms.ComboBox ComboExamen;
        private System.Windows.Forms.Label CampDireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label CampHistoria;
        private System.Windows.Forms.Label CampDni;
        private System.Windows.Forms.Label CampNombre;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn cobertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnique;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckBoxGestante;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ComboBoxMedico;
        private System.Windows.Forms.ComboBox ComboBoxConsultorio;
        private System.Windows.Forms.Label CampSexo;
        private System.Windows.Forms.Label label6;
    }
}