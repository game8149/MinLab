namespace MinLab.Code.PresentationLayer.GUISesion
{
    partial class FormConfigServer
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
            this.CampConexion = new System.Windows.Forms.TextBox();
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
            this.BtnInicia.Location = new System.Drawing.Point(230, 223);
            this.BtnInicia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnInicia.Name = "BtnInicia";
            this.BtnInicia.Size = new System.Drawing.Size(109, 36);
            this.BtnInicia.TabIndex = 3;
            this.BtnInicia.Text = "Conectar";
            this.BtnInicia.UseVisualStyleBackColor = false;
            this.BtnInicia.Click += new System.EventHandler(this.BtnInicia_Click);
            // 
            // CampConexion
            // 
            this.CampConexion.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampConexion.Location = new System.Drawing.Point(32, 98);
            this.CampConexion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CampConexion.MaxLength = 300;
            this.CampConexion.Multiline = true;
            this.CampConexion.Name = "CampConexion";
            this.CampConexion.Size = new System.Drawing.Size(307, 103);
            this.CampConexion.TabIndex = 1;
            this.CampConexion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Servidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Futura Bk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 19);
            this.label2.TabIndex = 37;
            this.label2.Text = "Configuracion de Conexion";
            // 
            // FormConfigServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(374, 287);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CampConexion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnInicia);
            this.Font = new System.Drawing.Font("Futura Bk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfigServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autorización";
            this.Load += new System.EventHandler(this.FormAutorizacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnInicia;
        private System.Windows.Forms.TextBox CampConexion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}