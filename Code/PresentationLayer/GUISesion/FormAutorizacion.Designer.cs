namespace MinLab.Code.PresentationLayer.GUISesion
{
    partial class FormAutorizacion
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
            this.BtnInicia = new System.Windows.Forms.Button();
            this.CampClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CampDni = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnInicia
            // 
            this.BtnInicia.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnInicia.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.BtnInicia.FlatAppearance.CheckedBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnInicia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue;
            this.BtnInicia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.BtnInicia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInicia.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnInicia.ForeColor = System.Drawing.SystemColors.Info;
            this.BtnInicia.Location = new System.Drawing.Point(233, 193);
            this.BtnInicia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnInicia.Name = "BtnInicia";
            this.BtnInicia.Size = new System.Drawing.Size(118, 39);
            this.BtnInicia.TabIndex = 3;
            this.BtnInicia.Text = "Verificar";
            this.BtnInicia.UseVisualStyleBackColor = false;
            this.BtnInicia.Click += new System.EventHandler(this.BtnInicia_Click);
            // 
            // CampClave
            // 
            this.CampClave.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampClave.Location = new System.Drawing.Point(170, 118);
            this.CampClave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CampClave.MaxLength = 8;
            this.CampClave.Name = "CampClave";
            this.CampClave.PasswordChar = '+';
            this.CampClave.Size = new System.Drawing.Size(181, 23);
            this.CampClave.TabIndex = 2;
            this.CampClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CampClave.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 34;
            this.label3.Text = "Autorización:";
            // 
            // CampDni
            // 
            this.CampDni.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampDni.Location = new System.Drawing.Point(170, 78);
            this.CampDni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CampDni.MaxLength = 8;
            this.CampDni.Name = "CampDni";
            this.CampDni.Size = new System.Drawing.Size(181, 23);
            this.CampDni.TabIndex = 1;
            this.CampDni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 19);
            this.label2.TabIndex = 37;
            this.label2.Text = "Verificacion de Administrador";
            // 
            // FormAutorizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(379, 260);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CampDni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnInicia);
            this.Controls.Add(this.CampClave);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAutorizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autorización";
            this.Load += new System.EventHandler(this.FormAutorizacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnInicia;
        private System.Windows.Forms.TextBox CampClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CampDni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}