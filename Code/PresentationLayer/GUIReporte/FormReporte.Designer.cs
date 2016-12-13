namespace MinLab.Code.PresentationLayer.GUIReporte
{
    partial class FormReporte
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.examen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.campAcumTotal = new System.Windows.Forms.TextBox();
            this.campCantTotal = new System.Windows.Forms.TextBox();
            this.campEfecTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.campAcuExo = new System.Windows.Forms.TextBox();
            this.campCantExo = new System.Windows.Forms.TextBox();
            this.campEfecExo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.campAcuSis = new System.Windows.Forms.TextBox();
            this.campCantSis = new System.Windows.Forms.TextBox();
            this.campEfecSis = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.campAcuPar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.campCantPar = new System.Windows.Forms.TextBox();
            this.campEfec = new System.Windows.Forms.TextBox();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.campAno = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.examen,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.totalMes,
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(24, 8);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(928, 336);
            this.dataGridView1.TabIndex = 0;
            // 
            // examen
            // 
            this.examen.Frozen = true;
            this.examen.HeaderText = "Examen";
            this.examen.Name = "examen";
            this.examen.ReadOnly = true;
            this.examen.Width = 120;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Nro(P)";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "S/ (P)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Acum(P)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Nro (SIS)";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "Acum (SIS)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "Nro (EX)";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.Frozen = true;
            this.Column7.HeaderText = "Acum (EXO)";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 80;
            // 
            // totalMes
            // 
            this.totalMes.Frozen = true;
            this.totalMes.HeaderText = "Total Mes";
            this.totalMes.Name = "totalMes";
            this.totalMes.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Column8.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "Avance (COB)";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 513);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.campAcumTotal);
            this.groupBox1.Controls.Add(this.campCantTotal);
            this.groupBox1.Controls.Add(this.campEfecTotal);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.campAcuExo);
            this.groupBox1.Controls.Add(this.campCantExo);
            this.groupBox1.Controls.Add(this.campEfecExo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.campAcuSis);
            this.groupBox1.Controls.Add(this.campCantSis);
            this.groupBox1.Controls.Add(this.campEfecSis);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.campAcuPar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.campCantPar);
            this.groupBox1.Controls.Add(this.campEfec);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 360);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(928, 136);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RESULTADO MES";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(736, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 15);
            this.label17.TabIndex = 53;
            this.label17.Text = "Acumulado:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(736, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 15);
            this.label18.TabIndex = 52;
            this.label18.Text = "Efectivo:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(736, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 15);
            this.label19.TabIndex = 51;
            this.label19.Text = "Cantidad:";
            // 
            // campAcumTotal
            // 
            this.campAcumTotal.Enabled = false;
            this.campAcumTotal.Location = new System.Drawing.Point(824, 96);
            this.campAcumTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campAcumTotal.Name = "campAcumTotal";
            this.campAcumTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campAcumTotal.Size = new System.Drawing.Size(80, 23);
            this.campAcumTotal.TabIndex = 50;
            this.campAcumTotal.Text = "0";
            this.campAcumTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campCantTotal
            // 
            this.campCantTotal.Enabled = false;
            this.campCantTotal.Location = new System.Drawing.Point(824, 48);
            this.campCantTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campCantTotal.Name = "campCantTotal";
            this.campCantTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campCantTotal.Size = new System.Drawing.Size(80, 23);
            this.campCantTotal.TabIndex = 48;
            this.campCantTotal.Text = "0";
            this.campCantTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campEfecTotal
            // 
            this.campEfecTotal.Enabled = false;
            this.campEfecTotal.Location = new System.Drawing.Point(824, 72);
            this.campEfecTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campEfecTotal.Name = "campEfecTotal";
            this.campEfecTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campEfecTotal.Size = new System.Drawing.Size(80, 23);
            this.campEfecTotal.TabIndex = 49;
            this.campEfecTotal.Text = "0.00";
            this.campEfecTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(496, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 15);
            this.label13.TabIndex = 47;
            this.label13.Text = "Acumulado:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(496, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 15);
            this.label14.TabIndex = 46;
            this.label14.Text = "Efectivo:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(496, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 15);
            this.label15.TabIndex = 45;
            this.label15.Text = "Cantidad:";
            // 
            // campAcuExo
            // 
            this.campAcuExo.Enabled = false;
            this.campAcuExo.Location = new System.Drawing.Point(584, 96);
            this.campAcuExo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campAcuExo.Name = "campAcuExo";
            this.campAcuExo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campAcuExo.Size = new System.Drawing.Size(80, 23);
            this.campAcuExo.TabIndex = 44;
            this.campAcuExo.Text = "0";
            this.campAcuExo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campCantExo
            // 
            this.campCantExo.Enabled = false;
            this.campCantExo.Location = new System.Drawing.Point(584, 48);
            this.campCantExo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campCantExo.Name = "campCantExo";
            this.campCantExo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campCantExo.Size = new System.Drawing.Size(80, 23);
            this.campCantExo.TabIndex = 42;
            this.campCantExo.Text = "0";
            this.campCantExo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campEfecExo
            // 
            this.campEfecExo.Enabled = false;
            this.campEfecExo.Location = new System.Drawing.Point(584, 72);
            this.campEfecExo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campEfecExo.Name = "campEfecExo";
            this.campEfecExo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campEfecExo.Size = new System.Drawing.Size(80, 23);
            this.campEfecExo.TabIndex = 43;
            this.campEfecExo.Text = "0.00";
            this.campEfecExo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(264, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 15);
            this.label10.TabIndex = 41;
            this.label10.Text = "Acumulado:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(264, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 15);
            this.label11.TabIndex = 40;
            this.label11.Text = "Efectivo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(264, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 15);
            this.label12.TabIndex = 39;
            this.label12.Text = "Cantidad:";
            // 
            // campAcuSis
            // 
            this.campAcuSis.Enabled = false;
            this.campAcuSis.Location = new System.Drawing.Point(352, 96);
            this.campAcuSis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campAcuSis.Name = "campAcuSis";
            this.campAcuSis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campAcuSis.Size = new System.Drawing.Size(80, 23);
            this.campAcuSis.TabIndex = 38;
            this.campAcuSis.Text = "0";
            this.campAcuSis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campCantSis
            // 
            this.campCantSis.Enabled = false;
            this.campCantSis.Location = new System.Drawing.Point(352, 48);
            this.campCantSis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campCantSis.Name = "campCantSis";
            this.campCantSis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campCantSis.Size = new System.Drawing.Size(80, 23);
            this.campCantSis.TabIndex = 36;
            this.campCantSis.Text = "0";
            this.campCantSis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campEfecSis
            // 
            this.campEfecSis.Enabled = false;
            this.campEfecSis.Location = new System.Drawing.Point(352, 72);
            this.campEfecSis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campEfecSis.Name = "campEfecSis";
            this.campEfecSis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campEfecSis.Size = new System.Drawing.Size(80, 23);
            this.campEfecSis.TabIndex = 37;
            this.campEfecSis.Text = "0.00";
            this.campEfecSis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(736, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 15);
            this.label16.TabIndex = 29;
            this.label16.Text = "TOTAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Acumulado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Efectivo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cantidad:";
            // 
            // campAcuPar
            // 
            this.campAcuPar.Enabled = false;
            this.campAcuPar.Location = new System.Drawing.Point(112, 96);
            this.campAcuPar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campAcuPar.Name = "campAcuPar";
            this.campAcuPar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campAcuPar.Size = new System.Drawing.Size(80, 23);
            this.campAcuPar.TabIndex = 5;
            this.campAcuPar.Text = "0";
            this.campAcuPar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(496, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "EXONERADOS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "PARTICULAR";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(264, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "SIS";
            // 
            // campCantPar
            // 
            this.campCantPar.Enabled = false;
            this.campCantPar.Location = new System.Drawing.Point(112, 48);
            this.campCantPar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campCantPar.Name = "campCantPar";
            this.campCantPar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campCantPar.Size = new System.Drawing.Size(80, 23);
            this.campCantPar.TabIndex = 3;
            this.campCantPar.Text = "0";
            this.campCantPar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // campEfec
            // 
            this.campEfec.Enabled = false;
            this.campEfec.Location = new System.Drawing.Point(112, 72);
            this.campEfec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campEfec.Name = "campEfec";
            this.campEfec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.campEfec.Size = new System.Drawing.Size(80, 23);
            this.campEfec.TabIndex = 4;
            this.campEfec.Text = "0.00";
            this.campEfec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboArea
            // 
            this.comboArea.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(512, 24);
            this.comboArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(121, 21);
            this.comboArea.TabIndex = 2;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(456, 29);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(36, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Area :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Año:";
            // 
            // comboMes
            // 
            this.comboMes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Location = new System.Drawing.Point(288, 24);
            this.comboMes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboMes.Name = "comboMes";
            this.comboMes.Size = new System.Drawing.Size(121, 21);
            this.comboMes.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(872, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 4;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(680, 24);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnAbrir_Click);
            // 
            // campAno
            // 
            this.campAno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.campAno.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campAno.Location = new System.Drawing.Point(72, 24);
            this.campAno.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.campAno.MaxLength = 4;
            this.campAno.Name = "campAno";
            this.campAno.Size = new System.Drawing.Size(120, 22);
            this.campAno.TabIndex = 0;
            this.campAno.Text = "2016";
            this.campAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(972, 574);
            this.Controls.Add(this.campAno);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboMes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label);
            this.Controls.Add(this.comboArea);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(988, 613);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(988, 613);
            this.Name = "FormReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormReporte";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox campAcuPar;
        private System.Windows.Forms.TextBox campEfec;
        private System.Windows.Forms.TextBox campCantPar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox campAcumTotal;
        private System.Windows.Forms.TextBox campCantTotal;
        private System.Windows.Forms.TextBox campEfecTotal;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox campAcuExo;
        private System.Windows.Forms.TextBox campCantExo;
        private System.Windows.Forms.TextBox campEfecExo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox campAcuSis;
        private System.Windows.Forms.TextBox campCantSis;
        private System.Windows.Forms.TextBox campEfecSis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox campAno;
        private System.Windows.Forms.DataGridViewTextBoxColumn examen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}