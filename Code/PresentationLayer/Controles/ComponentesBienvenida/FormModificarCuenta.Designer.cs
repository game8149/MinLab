namespace MinLab.Code.PresentationLayer.Controles.ComponentesBienvenida
{
    partial class FormModificarCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModificarCuenta));
            this.BtnRegistra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CampDni = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CampPrimerApellido = new System.Windows.Forms.TextBox();
            this.CampNombre = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CampSegundoApellido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CampEspecialidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CampCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRegistra
            // 
            this.BtnRegistra.BackColor = System.Drawing.Color.Green;
            this.BtnRegistra.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnRegistra.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRegistra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.BtnRegistra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnRegistra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegistra.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistra.ForeColor = System.Drawing.SystemColors.Info;
            this.BtnRegistra.Location = new System.Drawing.Point(281, 381);
            this.BtnRegistra.Name = "BtnRegistra";
            this.BtnRegistra.Size = new System.Drawing.Size(107, 32);
            this.BtnRegistra.TabIndex = 6;
            this.BtnRegistra.Text = "Guardar";
            this.BtnRegistra.UseVisualStyleBackColor = false;
            this.BtnRegistra.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Primer Apellido:";
            // 
            // CampDni
            // 
            this.CampDni.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampDni.Location = new System.Drawing.Point(180, 69);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new System.Drawing.Size(208, 22);
            this.CampDni.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "DNI:";
            // 
            // CampPrimerApellido
            // 
            this.CampPrimerApellido.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampPrimerApellido.Location = new System.Drawing.Point(180, 149);
            this.CampPrimerApellido.Name = "CampPrimerApellido";
            this.CampPrimerApellido.Size = new System.Drawing.Size(208, 22);
            this.CampPrimerApellido.TabIndex = 2;
            // 
            // CampNombre
            // 
            this.CampNombre.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampNombre.Location = new System.Drawing.Point(180, 109);
            this.CampNombre.Name = "CampNombre";
            this.CampNombre.Size = new System.Drawing.Size(208, 22);
            this.CampNombre.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(28, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 19);
            this.label12.TabIndex = 56;
            this.label12.Text = "Perfil de Usuario";
            // 
            // CampSegundoApellido
            // 
            this.CampSegundoApellido.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampSegundoApellido.Location = new System.Drawing.Point(180, 188);
            this.CampSegundoApellido.Name = "CampSegundoApellido";
            this.CampSegundoApellido.Size = new System.Drawing.Size(208, 22);
            this.CampSegundoApellido.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 58;
            this.label5.Text = "Segundo Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 15);
            this.label4.TabIndex = 59;
            this.label4.Text = "Nota: Ten en cuenta que tu DNI sera tu ID de usuario";
            // 
            // CampEspecialidad
            // 
            this.CampEspecialidad.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampEspecialidad.Location = new System.Drawing.Point(180, 229);
            this.CampEspecialidad.Name = "CampEspecialidad";
            this.CampEspecialidad.Size = new System.Drawing.Size(208, 22);
            this.CampEspecialidad.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 61;
            this.label6.Text = "Profesion:";
            // 
            // CampCodigo
            // 
            this.CampCodigo.Font = new System.Drawing.Font("Futura Bk BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampCodigo.Location = new System.Drawing.Point(180, 267);
            this.CampCodigo.Name = "CampCodigo";
            this.CampCodigo.Size = new System.Drawing.Size(208, 22);
            this.CampCodigo.TabIndex = 62;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 63;
            this.label7.Text = "Codigo:";
            // 
            // FormModificarCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(424, 446);
            this.Controls.Add(this.CampCodigo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CampEspecialidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CampSegundoApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CampDni);
            this.Controls.Add(this.CampNombre);
            this.Controls.Add(this.CampPrimerApellido);
            this.Controls.Add(this.BtnRegistra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormModificarCuenta";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actualizar Datos";
            this.Load += new System.EventHandler(this.FormModificarCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRegistra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CampPrimerApellido;
        private System.Windows.Forms.TextBox CampNombre;
        private System.Windows.Forms.TextBox CampDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CampSegundoApellido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CampEspecialidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CampCodigo;
        private System.Windows.Forms.Label label7;
    }
}