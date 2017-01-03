namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    partial class PanelRegistrarMedico
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
            this.CheckBoxHabil = new System.Windows.Forms.CheckBox();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CampColegiatura = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CampEspecialidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.campNombre = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CampSegundoApellido = new System.Windows.Forms.TextBox();
            this.CampPrimerApellido = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxHabil
            // 
            this.CheckBoxHabil.AutoSize = true;
            this.CheckBoxHabil.Font = new System.Drawing.Font("Futura Bk BT", 9.25F);
            this.CheckBoxHabil.Location = new System.Drawing.Point(369, 90);
            this.CheckBoxHabil.Name = "CheckBoxHabil";
            this.CheckBoxHabil.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CheckBoxHabil.Size = new System.Drawing.Size(60, 20);
            this.CheckBoxHabil.TabIndex = 154;
            this.CheckBoxHabil.Text = ":Habil";
            this.CheckBoxHabil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CheckBoxHabil.UseVisualStyleBackColor = true;
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
            this.BtnRegistrar.Location = new System.Drawing.Point(916, 490);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(126, 42);
            this.BtnRegistrar.TabIndex = 146;
            this.BtnRegistrar.Text = "Registrar";
            this.BtnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRegistrar.UseVisualStyleBackColor = false;
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 19);
            this.label12.TabIndex = 152;
            this.label12.Text = "Formulario de Registro";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(795, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 359);
            this.panel1.TabIndex = 153;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(205, 204);
            this.label13.TabIndex = 124;
            this.label13.Text = "El campo Colegiatura acepta un numero maximo de 8 de digitos.\r\n\r\nLos campos Nombr" +
    "e, 1er Apellido, 2do Apellido  y Especialidad aceptan maximo 100 caracteres (Sol" +
    "o letras).\r\n\r\n";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label9.Location = new System.Drawing.Point(37, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 151;
            this.label9.Text = "Colegiatura:";
            // 
            // CampColegiatura
            // 
            this.CampColegiatura.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampColegiatura.Location = new System.Drawing.Point(183, 88);
            this.CampColegiatura.MaxLength = 8;
            this.CampColegiatura.Name = "CampColegiatura";
            this.CampColegiatura.Size = new System.Drawing.Size(149, 23);
            this.CampColegiatura.TabIndex = 141;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label6.Location = new System.Drawing.Point(37, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 150;
            this.label6.Text = "Especialidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label2.Location = new System.Drawing.Point(37, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 147;
            this.label2.Text = "Nombre:";
            // 
            // CampEspecialidad
            // 
            this.CampEspecialidad.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampEspecialidad.Location = new System.Drawing.Point(183, 248);
            this.CampEspecialidad.MaxLength = 100;
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new System.Drawing.Size(374, 23);
            this.CampEspecialidad.TabIndex = 145;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label3.Location = new System.Drawing.Point(37, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 149;
            this.label3.Text = "Segundo Apellido:";
            // 
            // campNombre
            // 
            this.campNombre.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.campNombre.Location = new System.Drawing.Point(183, 127);
            this.campNombre.MaxLength = 100;
            this.campNombre.Name = "campNombre";
            this.campNombre.Size = new System.Drawing.Size(374, 23);
            this.campNombre.TabIndex = 142;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.label11.Location = new System.Drawing.Point(37, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 148;
            this.label11.Text = "Primer Apellido:";
            // 
            // CampSegundoApellido
            // 
            this.CampSegundoApellido.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampSegundoApellido.Location = new System.Drawing.Point(183, 205);
            this.CampSegundoApellido.MaxLength = 100;
            this.CampSegundoApellido.Name = "CampSegundoApellido";
            this.CampSegundoApellido.Size = new System.Drawing.Size(374, 23);
            this.CampSegundoApellido.TabIndex = 144;
            // 
            // CampPrimerApellido
            // 
            this.CampPrimerApellido.Font = new System.Drawing.Font("Futura Bk BT", 9.75F);
            this.CampPrimerApellido.Location = new System.Drawing.Point(183, 165);
            this.CampPrimerApellido.MaxLength = 100;
            this.CampPrimerApellido.Name = "CampPrimerApellido";
            this.CampPrimerApellido.Size = new System.Drawing.Size(374, 23);
            this.CampPrimerApellido.TabIndex = 143;
            // 
            // PanelRegistrarMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.CheckBoxHabil);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CampColegiatura);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CampEspecialidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campNombre);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.CampSegundoApellido);
            this.Controls.Add(this.CampPrimerApellido);
            this.Name = "PanelRegistrarMedico";
            this.Size = new System.Drawing.Size(1072, 563);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxHabil;
        private System.Windows.Forms.Button BtnRegistrar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox CampColegiatura;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CampEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campNombre;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CampSegundoApellido;
        private System.Windows.Forms.TextBox CampPrimerApellido;
    }
}
