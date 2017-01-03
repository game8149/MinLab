namespace MinLab.Code
{
    partial class Test
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
            this.DTPicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.CampEdad = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DTPicker
            // 
            this.DTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker.Location = new System.Drawing.Point(27, 38);
            this.DTPicker.Name = "DTPicker";
            this.DTPicker.Size = new System.Drawing.Size(91, 20);
            this.DTPicker.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Image = global::MinLab.Properties.Resources.Tratado2;
            this.button1.Location = new System.Drawing.Point(148, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CampEdad
            // 
            this.CampEdad.AutoSize = true;
            this.CampEdad.Location = new System.Drawing.Point(24, 96);
            this.CampEdad.Name = "CampEdad";
            this.CampEdad.Size = new System.Drawing.Size(35, 13);
            this.CampEdad.TabIndex = 2;
            this.CampEdad.Text = "label1";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CampEdad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DTPicker);
            this.Name = "Test";
            this.Text = "Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CampEdad;
    }
}