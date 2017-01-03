namespace MinLab.Code.PresentationLayer.Controles.ComponentesOrden
{
    partial class PanelNuevaOrden
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PickerTime = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.LabelNombreExamen = new System.Windows.Forms.Label();
            this.ComboExamen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CampUbicacion = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.CampBoleta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnBuscarPaciente = new System.Windows.Forms.Button();
            this.CheckBoxGestante = new System.Windows.Forms.CheckBox();
            this.CampSexo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBoxConsultorio = new System.Windows.Forms.ComboBox();
            this.ComboBoxMedico = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PickerTime
            // 
            this.PickerTime.CalendarFont = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.PickerTime.Location = new System.Drawing.Point(934, 187);
            this.PickerTime.Name = "PickerTime";
            this.PickerTime.Size = new System.Drawing.Size(108, 20);
            this.PickerTime.TabIndex = 96;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.BtnEliminar);
            this.panel1.Controls.Add(this.BtnAgregar);
            this.panel1.Controls.Add(this.LabelNombreExamen);
            this.panel1.Controls.Add(this.ComboExamen);
            this.panel1.Location = new System.Drawing.Point(27, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 32);
            this.panel1.TabIndex = 95;
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
            this.BtnEliminar.Location = new System.Drawing.Point(926, 0);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(86, 32);
            this.BtnEliminar.TabIndex = 71;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
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
            this.ComboExamen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboExamen.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboExamen.FormattingEnabled = true;
            this.ComboExamen.Location = new System.Drawing.Point(88, 4);
            this.ComboExamen.Name = "ComboExamen";
            this.ComboExamen.Size = new System.Drawing.Size(304, 24);
            this.ComboExamen.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(801, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 94;
            this.label7.Text = "(Opc.)";
            // 
            // CampUbicacion
            // 
            this.CampUbicacion.AutoSize = true;
            this.CampUbicacion.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampUbicacion.Location = new System.Drawing.Point(93, 148);
            this.CampUbicacion.Name = "CampUbicacion";
            this.CampUbicacion.Size = new System.Drawing.Size(27, 16);
            this.CampUbicacion.TabIndex = 93;
            this.CampUbicacion.Text = "asd";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 92;
            this.label9.Text = "Ubicacion:";
            // 
            // CampHistoria
            // 
            this.CampHistoria.AutoSize = true;
            this.CampHistoria.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampHistoria.Location = new System.Drawing.Point(276, 107);
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new System.Drawing.Size(51, 16);
            this.CampHistoria.TabIndex = 90;
            this.CampHistoria.Text = "label11";
            // 
            // CampDni
            // 
            this.CampDni.AutoSize = true;
            this.CampDni.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampDni.Location = new System.Drawing.Point(93, 107);
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new System.Drawing.Size(43, 16);
            this.CampDni.TabIndex = 89;
            this.CampDni.Text = "label9";
            // 
            // CampNombre
            // 
            this.CampNombre.AutoSize = true;
            this.CampNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampNombre.Location = new System.Drawing.Point(93, 66);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(43, 16);
            this.CampNombre.TabIndex = 88;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codigo,
            this.nombre,
            this.cobertura,
            this.idUnique});
            this.dataGridView.Location = new System.Drawing.Point(27, 253);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.Size = new System.Drawing.Size(1015, 227);
            this.dataGridView.TabIndex = 87;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(612, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 85;
            this.label1.Text = "Boleta:";
            // 
            // CampBoleta
            // 
            this.CampBoleta.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampBoleta.Location = new System.Drawing.Point(674, 186);
            this.CampBoleta.Name = "CampBoleta";
            this.CampBoleta.Size = new System.Drawing.Size(108, 23);
            this.CampBoleta.TabIndex = 84;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 19);
            this.label12.TabIndex = 83;
            this.label12.Text = "Formulario de Registro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(216, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 16);
            this.label10.TabIndex = 77;
            this.label10.Text = "Historia:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 76;
            this.label8.Text = "DNI:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 75;
            this.label4.Text = "Nombre:";
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnRegistrar.FlatAppearance.BorderSize = 0;
            this.BtnRegistrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistrar.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnRegistrar.Location = new System.Drawing.Point(926, 497);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(116, 42);
            this.BtnRegistrar.TabIndex = 98;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRegistrar.UseVisualStyleBackColor = false;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(864, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 79;
            this.label3.Text = "Fecha:";
            // 
            // BtnBuscarPaciente
            // 
            this.BtnBuscarPaciente.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnBuscarPaciente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnBuscarPaciente.FlatAppearance.BorderSize = 0;
            this.BtnBuscarPaciente.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscarPaciente.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscarPaciente.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnBuscarPaciente.Location = new System.Drawing.Point(926, 53);
            this.BtnBuscarPaciente.Name = "BtnBuscarPaciente";
            this.BtnBuscarPaciente.Size = new System.Drawing.Size(116, 42);
            this.BtnBuscarPaciente.TabIndex = 82;
            this.BtnBuscarPaciente.Text = "Agregar Paciente";
            this.BtnBuscarPaciente.UseVisualStyleBackColor = true;
            this.BtnBuscarPaciente.Click += new System.EventHandler(this.BtnBuscarPaciente_Click);
            // 
            // CheckBoxGestante
            // 
            this.CheckBoxGestante.AutoSize = true;
            this.CheckBoxGestante.Font = new System.Drawing.Font("Futura Bk BT", 9.25F);
            this.CheckBoxGestante.Location = new System.Drawing.Point(581, 105);
            this.CheckBoxGestante.Name = "CheckBoxGestante";
            this.CheckBoxGestante.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxGestante.Size = new System.Drawing.Size(112, 20);
            this.CheckBoxGestante.TabIndex = 147;
            this.CheckBoxGestante.Text = ":En Gestancion";
            this.CheckBoxGestante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxGestante.UseVisualStyleBackColor = true;
            // 
            // CampSexo
            // 
            this.CampSexo.AutoSize = true;
            this.CampSexo.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampSexo.Location = new System.Drawing.Point(464, 107);
            this.CampSexo.Name = "CampSexo";
            this.CampSexo.Size = new System.Drawing.Size(51, 16);
            this.CampSexo.TabIndex = 149;
            this.CampSexo.Text = "label11";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(404, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 148;
            this.label6.Text = "Sexo:";
            // 
            // ComboBoxConsultorio
            // 
            this.ComboBoxConsultorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxConsultorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxConsultorio.FormattingEnabled = true;
            this.ComboBoxConsultorio.Location = new System.Drawing.Point(374, 187);
            this.ComboBoxConsultorio.Name = "ComboBoxConsultorio";
            this.ComboBoxConsultorio.Size = new System.Drawing.Size(222, 21);
            this.ComboBoxConsultorio.TabIndex = 150;
            // 
            // ComboBoxMedico
            // 
            this.ComboBoxMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBoxMedico.FormattingEnabled = true;
            this.ComboBoxMedico.Location = new System.Drawing.Point(96, 187);
            this.ComboBoxMedico.Name = "ComboBoxMedico";
            this.ComboBoxMedico.Size = new System.Drawing.Size(171, 21);
            this.ComboBoxMedico.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 152;
            this.label5.Text = "Medico:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(283, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 153;
            this.label11.Text = "Consultorio:";
            // 
            // PanelNuevaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.BtnBuscarPaciente);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComboBoxMedico);
            this.Controls.Add(this.ComboBoxConsultorio);
            this.Controls.Add(this.CampSexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CheckBoxGestante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CampBoleta);
            this.Controls.Add(this.PickerTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CampUbicacion);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CampHistoria);
            this.Controls.Add(this.CampDni);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Name = "PanelNuevaOrden";
            this.Size = new System.Drawing.Size(1072, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker PickerTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label LabelNombreExamen;
        private System.Windows.Forms.ComboBox ComboExamen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label CampUbicacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label CampHistoria;
        private System.Windows.Forms.Label CampDni;
        private System.Windows.Forms.Label CampNombre;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CampBoleta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnBuscarPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewComboBoxColumn cobertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnique;
        private System.Windows.Forms.CheckBox CheckBoxGestante;
        private System.Windows.Forms.Label CampSexo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ComboBoxConsultorio;
        private System.Windows.Forms.ComboBox ComboBoxMedico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
    }
}
