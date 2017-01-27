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
            this.CampEdad = new System.Windows.Forms.Label();
            this.LabelImg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TB = new System.Windows.Forms.TrackBar();
            this.BtnUI1 = new MinLab.Code.PresentationLayer.ComponenteGeneral.ButtonUI();
            this.LblUI2 = new MinLab.Code.PresentationLayer.ComponenteGeneral.LabelUI();
            this.LblUI1 = new MinLab.Code.PresentationLayer.ComponenteGeneral.LabelUI();
            ((System.ComponentModel.ISupportInitialize)(this.TB)).BeginInit();
            this.SuspendLayout();
            // 
            // DTPicker
            // 
            this.DTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPicker.Location = new System.Drawing.Point(603, 22);
            this.DTPicker.Name = "DTPicker";
            this.DTPicker.Size = new System.Drawing.Size(91, 20);
            this.DTPicker.TabIndex = 0;
            // 
            // CampEdad
            // 
            this.CampEdad.AutoSize = true;
            this.CampEdad.Location = new System.Drawing.Point(600, 80);
            this.CampEdad.Name = "CampEdad";
            this.CampEdad.Size = new System.Drawing.Size(60, 13);
            this.CampEdad.TabIndex = 2;
            this.CampEdad.Text = "LabelCamp";
            // 
            // LabelImg
            // 
            this.LabelImg.Image = global::MinLab.Properties.Resources.logo_region;
            this.LabelImg.Location = new System.Drawing.Point(600, 172);
            this.LabelImg.Name = "LabelImg";
            this.LabelImg.Size = new System.Drawing.Size(74, 71);
            this.LabelImg.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Image = global::MinLab.Properties.Resources.Tratado2;
            this.button1.Location = new System.Drawing.Point(443, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TB
            // 
            this.TB.Location = new System.Drawing.Point(590, 110);
            this.TB.Maximum = 500;
            this.TB.Minimum = 20;
            this.TB.Name = "TB";
            this.TB.Size = new System.Drawing.Size(104, 45);
            this.TB.TabIndex = 4;
            this.TB.Value = 20;
            this.TB.Scroll += new System.EventHandler(this.TB_Scroll);
            // 
            // BtnUI1
            // 
            this.BtnUI1.Location = new System.Drawing.Point(146, 172);
            this.BtnUI1.Name = "BtnUI1";
            this.BtnUI1.Size = new System.Drawing.Size(243, 114);
            this.BtnUI1.TabIndex = 7;
            // 
            // LblUI2
            // 
            this.LblUI2.Location = new System.Drawing.Point(38, 80);
            this.LblUI2.Name = "LblUI2";
            this.LblUI2.Size = new System.Drawing.Size(35, 13);
            this.LblUI2.TabIndex = 6;
            // 
            // LblUI1
            // 
            this.LblUI1.Location = new System.Drawing.Point(38, 46);
            this.LblUI1.Name = "LblUI1";
            this.LblUI1.Size = new System.Drawing.Size(35, 13);
            this.LblUI1.TabIndex = 5;
            this.LblUI1.Load += new System.EventHandler(this.labelUI1_Load);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 741);
            this.Controls.Add(this.BtnUI1);
            this.Controls.Add(this.LblUI2);
            this.Controls.Add(this.LblUI1);
            this.Controls.Add(this.TB);
            this.Controls.Add(this.LabelImg);
            this.Controls.Add(this.CampEdad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DTPicker);
            this.Name = "Test";
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.TB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CampEdad;
        private System.Windows.Forms.Label LabelImg;
        private System.Windows.Forms.TrackBar TB;
        private PresentationLayer.ComponenteGeneral.LabelUI LblUI1;
        private PresentationLayer.ComponenteGeneral.LabelUI LblUI2;
        private PresentationLayer.ComponenteGeneral.ButtonUI BtnUI1;
    }
}