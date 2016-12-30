namespace MinLab.Code.PresentationLayer.GUISistema
{
    partial class FormRegistrarProfesional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarProfesional));
            this.BtnRegistra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CampAutorizacion = new System.Windows.Forms.TextBox();
            this.CampEspecialidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CampSegundoApellido = new System.Windows.Forms.TextBox();
            this.CampNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CampColegiatura = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CampPrimerApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRegistra
            // 
            this.BtnRegistra.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnRegistra.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnRegistra.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRegistra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.BtnRegistra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRegistra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistra.ForeColor = System.Drawing.SystemColors.Info;
            this.BtnRegistra.Location = new System.Drawing.Point(273, 341);
            this.BtnRegistra.Name = "BtnRegistra";
            this.BtnRegistra.Size = new System.Drawing.Size(107, 32);
            this.BtnRegistra.TabIndex = 6;
            this.BtnRegistra.Text = "Registrar";
            this.BtnRegistra.UseVisualStyleBackColor = false;
            this.BtnRegistra.Click += new System.EventHandler(this.BtnRegistra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Segundo Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Autorización:";
            // 
            // CampAutorizacion
            // 
            this.CampAutorizacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampAutorizacion.Location = new System.Drawing.Point(172, 263);
            this.CampAutorizacion.MaxLength = 5;
            this.CampAutorizacion.Name = "CampAutorizacion";
            this.CampAutorizacion.PasswordChar = '+';
            this.CampAutorizacion.Size = new System.Drawing.Size(208, 23);
            this.CampAutorizacion.TabIndex = 6;
            this.CampAutorizacion.UseSystemPasswordChar = true;
            // 
            // CampEspecialidad
            // 
            this.CampEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampEspecialidad.Location = new System.Drawing.Point(172, 183);
            this.CampEspecialidad.MaxLength = 8;
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new System.Drawing.Size(208, 23);
            this.CampEspecialidad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Especialidad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Colegiatura:";
            // 
            // CampSegundoApellido
            // 
            this.CampSegundoApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampSegundoApellido.Location = new System.Drawing.Point(172, 144);
            this.CampSegundoApellido.Name = "CampSegundoApellido";
            this.CampSegundoApellido.Size = new System.Drawing.Size(208, 23);
            this.CampSegundoApellido.TabIndex = 2;
            // 
            // CampNombre
            // 
            this.CampNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampNombre.Location = new System.Drawing.Point(172, 68);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(208, 23);
            this.CampNombre.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(172, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(212, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Necesitas  la clave de autorización del administrador.";
            // 
            // CampColegiatura
            // 
            this.CampColegiatura.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampColegiatura.Location = new System.Drawing.Point(172, 222);
            this.CampColegiatura.MaxLength = 16;
            this.CampColegiatura.Name = "CampColegiatura";
            this.CampColegiatura.PasswordChar = '*';
            this.CampColegiatura.Size = new System.Drawing.Size(208, 23);
            this.CampColegiatura.TabIndex = 4;
            this.CampColegiatura.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(189, 20);
            this.label12.TabIndex = 56;
            this.label12.Text = "Formulario de Profesional";
            // 
            // CampPrimerApellido
            // 
            this.CampPrimerApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampPrimerApellido.Location = new System.Drawing.Point(172, 106);
            this.CampPrimerApellido.Name = "CampPrimerApellido";
            this.CampPrimerApellido.Size = new System.Drawing.Size(208, 23);
            this.CampPrimerApellido.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 58;
            this.label5.Text = "Primer Apellido:";
            // 
            // FormRegistrarProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(402, 397);
            this.Controls.Add(this.CampPrimerApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CampColegiatura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CampEspecialidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.CampSegundoApellido);
            this.Controls.Add(this.BtnRegistra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CampAutorizacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormRegistrarProfesional";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Profesional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRegistra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CampAutorizacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CampSegundoApellido;
        private System.Windows.Forms.TextBox CampNombre;
        private System.Windows.Forms.TextBox CampEspecialidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CampColegiatura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CampPrimerApellido;
        private System.Windows.Forms.Label label5;
    }
}