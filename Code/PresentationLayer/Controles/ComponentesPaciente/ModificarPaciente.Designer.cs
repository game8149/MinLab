namespace MinLab.Code.PresentationLayer.Controles.ComponentesPaciente
{
    partial class FormModificarPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarPaciente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CampFecha = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.CampHistoria = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CampDNI = new System.Windows.Forms.TextBox();
            this.ComboSexo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CampDireccion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CampNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Campapellido2erno = new System.Windows.Forms.TextBox();
            this.Campapellido1erno = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ComboBoxSector = new System.Windows.Forms.ComboBox();
            this.ComboBoxDistrito = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(587, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 400);
            this.panel1.TabIndex = 143;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 204);
            this.label13.TabIndex = 124;
            this.label13.Text = resources.GetString("label13.Text");
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(207, 22);
            this.label12.TabIndex = 142;
            this.label12.Text = "Formulario de Paciente";
            // 
            // CampFecha
            // 
            this.CampFecha.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.CampFecha.Location = new System.Drawing.Point(174, 267);
            this.CampFecha.Name = "CampFecha";
            this.CampFecha.RightToLeftLayout = true;
            this.CampFecha.Size = new System.Drawing.Size(149, 23);
            this.CampFecha.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label10.Location = new System.Drawing.Point(36, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 141;
            this.label10.Text = "Historia Clinica:";
            // 
            // CampHistoria
            // 
            this.CampHistoria.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampHistoria.Location = new System.Drawing.Point(174, 111);
            this.CampHistoria.MaxLength = 15;
            this.CampHistoria.Name = "CampHistoria";
            this.CampHistoria.Size = new System.Drawing.Size(149, 23);
            this.CampHistoria.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label9.Location = new System.Drawing.Point(36, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 140;
            this.label9.Text = "DNI:";
            // 
            // CampDNI
            // 
            this.CampDNI.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampDNI.Location = new System.Drawing.Point(174, 72);
            this.CampDNI.MaxLength = 8;
            this.CampDNI.Name = "CampDNI";
            this.CampDNI.Size = new System.Drawing.Size(149, 23);
            this.CampDNI.TabIndex = 1;
            // 
            // ComboSexo
            // 
            this.ComboSexo.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.ComboSexo.FormattingEnabled = true;
            this.ComboSexo.Location = new System.Drawing.Point(174, 305);
            this.ComboSexo.Name = "ComboSexo";
            this.ComboSexo.Size = new System.Drawing.Size(149, 24);
            this.ComboSexo.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label6.Location = new System.Drawing.Point(36, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 134;
            this.label6.Text = "Direccion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label2.Location = new System.Drawing.Point(36, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 124;
            this.label2.Text = "Nombre:";
            // 
            // CampDireccion
            // 
            this.CampDireccion.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampDireccion.Location = new System.Drawing.Point(174, 384);
            this.CampDireccion.MaxLength = 100;
            this.CampDireccion.Name = "CampDireccion";
            this.CampDireccion.Size = new System.Drawing.Size(374, 23);
            this.CampDireccion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label4.Location = new System.Drawing.Point(36, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 16);
            this.label4.TabIndex = 130;
            this.label4.Text = "Fecha de Nacimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label5.Location = new System.Drawing.Point(36, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 132;
            this.label5.Text = "Sexo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label3.Location = new System.Drawing.Point(36, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 127;
            this.label3.Text = "Segundo Apellido:";
            // 
            // CampNombre
            // 
            this.CampNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampNombre.Location = new System.Drawing.Point(174, 150);
            this.CampNombre.MaxLength = 100;
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(374, 23);
            this.CampNombre.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label11.Location = new System.Drawing.Point(36, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 125;
            this.label11.Text = "Primer Apellido:";
            // 
            // Campapellido2erno
            // 
            this.Campapellido2erno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.Campapellido2erno.Location = new System.Drawing.Point(174, 228);
            this.Campapellido2erno.MaxLength = 100;
            this.Campapellido2erno.Name = "Campapellido2erno";
            this.Campapellido2erno.Size = new System.Drawing.Size(374, 23);
            this.Campapellido2erno.TabIndex = 5;
            // 
            // Campapellido1erno
            // 
            this.Campapellido1erno.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.Campapellido1erno.Location = new System.Drawing.Point(174, 189);
            this.Campapellido1erno.MaxLength = 100;
            this.Campapellido1erno.Name = "Campapellido1erno";
            this.Campapellido1erno.Size = new System.Drawing.Size(374, 23);
            this.Campapellido1erno.TabIndex = 4;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.Green;
            this.BtnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Futura Bk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnGuardar.Image = global::MinLab.Properties.Resources.diskette;
            this.BtnGuardar.Location = new System.Drawing.Point(726, 452);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(105, 43);
            this.BtnGuardar.TabIndex = 9;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(357, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 15);
            this.label8.TabIndex = 147;
            this.label8.Text = "/";
            // 
            // ComboBoxSector
            // 
            this.ComboBoxSector.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.ComboBoxSector.FormattingEnabled = true;
            this.ComboBoxSector.Location = new System.Drawing.Point(371, 345);
            this.ComboBoxSector.Name = "ComboBoxSector";
            this.ComboBoxSector.Size = new System.Drawing.Size(177, 24);
            this.ComboBoxSector.TabIndex = 146;
            // 
            // ComboBoxDistrito
            // 
            this.ComboBoxDistrito.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.ComboBoxDistrito.FormattingEnabled = true;
            this.ComboBoxDistrito.Location = new System.Drawing.Point(174, 345);
            this.ComboBoxDistrito.Name = "ComboBoxDistrito";
            this.ComboBoxDistrito.Size = new System.Drawing.Size(177, 24);
            this.ComboBoxDistrito.TabIndex = 144;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label7.Location = new System.Drawing.Point(36, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 16);
            this.label7.TabIndex = 145;
            this.label7.Text = "Distrito / Sector :";
            // 
            // FormModificarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(859, 518);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ComboBoxSector);
            this.Controls.Add(this.ComboBoxDistrito);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CampFecha);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.CampHistoria);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CampDNI);
            this.Controls.Add(this.ComboSexo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CampDireccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Campapellido2erno);
            this.Controls.Add(this.Campapellido1erno);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormModificarPaciente";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar_Paciente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker CampFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox CampHistoria;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CampDNI;
        private System.Windows.Forms.ComboBox ComboSexo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CampDireccion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CampNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Campapellido2erno;
        private System.Windows.Forms.TextBox Campapellido1erno;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ComboBoxSector;
        private System.Windows.Forms.ComboBox ComboBoxDistrito;
        private System.Windows.Forms.Label label7;
    }
}