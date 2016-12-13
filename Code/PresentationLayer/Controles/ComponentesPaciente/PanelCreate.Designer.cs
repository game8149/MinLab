namespace MinLab.Code.PresentationLayer.Controles
{
    partial class PanelCrearPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelCrearPaciente));
            this.panel2 = new System.Windows.Forms.Panel();
            this.CheckEstado = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LabelExamen = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.campFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.campHistoria = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.campDNI = new System.Windows.Forms.TextBox();
            this.comboSexo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.campDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.campNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.campapellido2erno = new System.Windows.Forms.TextBox();
            this.campapellido1erno = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.CheckEstado);
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Location = new System.Drawing.Point(82, -51);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(505, 32);
            this.panel2.TabIndex = 98;
            // 
            // CheckEstado
            // 
            this.CheckEstado.AutoSize = true;
            this.CheckEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckEstado.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckEstado.ForeColor = System.Drawing.SystemColors.Window;
            this.CheckEstado.Location = new System.Drawing.Point(416, 5);
            this.CheckEstado.Name = "CheckEstado";
            this.CheckEstado.Size = new System.Drawing.Size(85, 20);
            this.CheckEstado.TabIndex = 100;
            this.CheckEstado.Text = "Terminado";
            this.CheckEstado.UseVisualStyleBackColor = true;
            this.CheckEstado.Visible = false;
            // 
            // BtnSave
            // 
            this.BtnSave.AutoSize = true;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Image = global::MinLab.Properties.Resources.save;
            this.BtnSave.Location = new System.Drawing.Point(3, 2);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(31, 27);
            this.BtnSave.TabIndex = 74;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel4.Controls.Add(this.LabelExamen);
            this.panel4.Controls.Add(this.BtnClose);
            this.panel4.Location = new System.Drawing.Point(82, -80);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(505, 30);
            this.panel4.TabIndex = 100;
            // 
            // LabelExamen
            // 
            this.LabelExamen.AutoSize = true;
            this.LabelExamen.Font = new System.Drawing.Font("Futura Md BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelExamen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabelExamen.Location = new System.Drawing.Point(4, 5);
            this.LabelExamen.MaximumSize = new System.Drawing.Size(450, 0);
            this.LabelExamen.Name = "LabelExamen";
            this.LabelExamen.Size = new System.Drawing.Size(41, 16);
            this.LabelExamen.TabIndex = 76;
            this.LabelExamen.Text = "Titulo";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Image = global::MinLab.Properties.Resources.cancel;
            this.BtnClose.Location = new System.Drawing.Point(471, 0);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(31, 27);
            this.BtnClose.TabIndex = 75;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Visible = false;
            // 
            // campFecha
            // 
            this.campFecha.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.campFecha.Location = new System.Drawing.Point(166, 256);
            this.campFecha.Name = "campFecha";
            this.campFecha.RightToLeftLayout = true;
            this.campFecha.Size = new System.Drawing.Size(149, 23);
            this.campFecha.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label10.Location = new System.Drawing.Point(20, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 119;
            this.label10.Text = "Historia Clinica:";
            // 
            // campHistoria
            // 
            this.campHistoria.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campHistoria.Location = new System.Drawing.Point(166, 128);
            this.campHistoria.MaxLength = 15;
            this.campHistoria.Name = "campHistoria";
            this.campHistoria.Size = new System.Drawing.Size(149, 23);
            this.campHistoria.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label9.Location = new System.Drawing.Point(20, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 118;
            this.label9.Text = "DNI:";
            // 
            // campDNI
            // 
            this.campDNI.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campDNI.Location = new System.Drawing.Point(166, 96);
            this.campDNI.MaxLength = 8;
            this.campDNI.Name = "campDNI";
            this.campDNI.Size = new System.Drawing.Size(149, 23);
            this.campDNI.TabIndex = 1;
            // 
            // comboSexo
            // 
            this.comboSexo.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.comboSexo.FormattingEnabled = true;
            this.comboSexo.Location = new System.Drawing.Point(166, 287);
            this.comboSexo.Name = "comboSexo";
            this.comboSexo.Size = new System.Drawing.Size(149, 24);
            this.comboSexo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label6.Location = new System.Drawing.Point(20, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 111;
            this.label6.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label2.Location = new System.Drawing.Point(20, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 101;
            this.label2.Text = "Nombre:";
            // 
            // campDireccion
            // 
            this.campDireccion.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campDireccion.Location = new System.Drawing.Point(166, 320);
            this.campDireccion.MaxLength = 100;
            this.campDireccion.Name = "campDireccion";
            this.campDireccion.Size = new System.Drawing.Size(374, 23);
            this.campDireccion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label4.Location = new System.Drawing.Point(20, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 16);
            this.label4.TabIndex = 107;
            this.label4.Text = "Fecha de Nacimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label5.Location = new System.Drawing.Point(20, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 109;
            this.label5.Text = "Sexo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label3.Location = new System.Drawing.Point(20, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 104;
            this.label3.Text = "Segundo Apellido:";
            // 
            // campNombre
            // 
            this.campNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campNombre.Location = new System.Drawing.Point(166, 160);
            this.campNombre.MaxLength = 100;
            this.campNombre.Name = "campNombre";
            this.campNombre.Size = new System.Drawing.Size(374, 23);
            this.campNombre.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label11.Location = new System.Drawing.Point(20, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 102;
            this.label11.Text = "Primer Apellido:";
            // 
            // campapellido2erno
            // 
            this.campapellido2erno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campapellido2erno.Location = new System.Drawing.Point(166, 224);
            this.campapellido2erno.MaxLength = 100;
            this.campapellido2erno.Name = "campapellido2erno";
            this.campapellido2erno.Size = new System.Drawing.Size(374, 23);
            this.campapellido2erno.TabIndex = 5;
            // 
            // campapellido1erno
            // 
            this.campapellido1erno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campapellido1erno.Location = new System.Drawing.Point(166, 192);
            this.campapellido1erno.MaxLength = 100;
            this.campapellido1erno.Name = "campapellido1erno";
            this.campapellido1erno.Size = new System.Drawing.Size(374, 23);
            this.campapellido1erno.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 22);
            this.label12.TabIndex = 122;
            this.label12.Text = "Formulario de Paciente";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(597, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 414);
            this.panel1.TabIndex = 123;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 204);
            this.label13.TabIndex = 124;
            this.label13.Text = resources.GetString("label13.Text");
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 19);
            this.label1.TabIndex = 123;
            this.label1.Text = "Indicaciones Generales";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.BtnLimpiar);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 32);
            this.panel3.TabIndex = 124;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.FlatAppearance.BorderSize = 0;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Font = new System.Drawing.Font("Futura Bk BT", 8.25F);
            this.BtnLimpiar.ForeColor = System.Drawing.SystemColors.Window;
            this.BtnLimpiar.Image = global::MinLab.Properties.Resources.cleaner;
            this.BtnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLimpiar.Location = new System.Drawing.Point(744, 0);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(114, 32);
            this.BtnLimpiar.TabIndex = 10;
            this.BtnLimpiar.Text = "Limpiar Orden";
            this.BtnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLimpiar.UseVisualStyleBackColor = false;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnRegistrar.FlatAppearance.BorderSize = 0;
            this.BtnRegistrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistrar.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnRegistrar.Image = global::MinLab.Properties.Resources.search_engine__1_;
            this.BtnRegistrar.Location = new System.Drawing.Point(715, 496);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(126, 42);
            this.BtnRegistrar.TabIndex = 9;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRegistrar.UseVisualStyleBackColor = false;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // PanelCrearPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.campFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.campHistoria);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.campDNI);
            this.Controls.Add(this.comboSexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campDireccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campNombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.campapellido2erno);
            this.Controls.Add(this.campapellido1erno);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Name = "PanelCrearPaciente";
            this.Size = new System.Drawing.Size(858, 554);
            this.Load += new System.EventHandler(this.PanelCreate_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox CheckEstado;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LabelExamen;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.DateTimePicker campFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox campHistoria;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox campDNI;
        private System.Windows.Forms.ComboBox comboSexo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox campDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox campapellido2erno;
        private System.Windows.Forms.TextBox campapellido1erno;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnRegistrar;
    }
}
