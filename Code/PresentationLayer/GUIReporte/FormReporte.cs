using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.ArchivoCaja;
using MinLab.Code.EntityLayer.ArchivoCaja.Encapsulado;
using MinLab.Code.EntityLayer.DatosEstaticos;
using MinLab.Code.EntityLayer.EntidadExamen;
using MinLab.Code.LogicLayer.LogicaTarifario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MinLab.Code.EntityLayer.ArchivoCaja.Orden;

namespace MinLab.Code.PresentationLayer.GUIReporte
{
    public partial class FormReporte : Form
    {

        DataTable tabla = new DataTable();
        public FormReporte()
        {
            InitializeComponent();
            this.SuspendLayout();

            comboArea.DataSource = new BindingSource(Coleccion.GetInstance().Area, null);
            comboArea.DisplayMember = "Value";
            comboArea.ValueMember = "Key";
            
            comboMes.DataSource = new BindingSource(Coleccion.GetInstance().Mes, null);
            comboMes.DisplayMember = "Value";
            comboMes.ValueMember = "Key";
            this.ResumeLayout(false);
            InicializarTabla();
        }
        

        

        private void InicializarTabla()
        {
            tabla = new DataTable("Examenes");
            // Configuracion de Tablas
            BindingSource bindingSource = new BindingSource();
            dataGridView1.DataSource = bindingSource;
            tabla.Columns.Add("examen", typeof(string));
            tabla.Columns.Add("nroP", typeof(int));
            tabla.Columns.Add("totalP", typeof(double));
            tabla.Columns.Add("acuP", typeof(int));
            tabla.Columns.Add("nroS", typeof(int));
            tabla.Columns.Add("acuS", typeof(int));
            tabla.Columns.Add("nroE", typeof(int));
            tabla.Columns.Add("acuE", typeof(int));
            tabla.Columns.Add("totalMes", typeof(int));
            tabla.Columns.Add("cob", typeof(int));
            
            this.examen.HeaderText = "Examen";
            this.examen.Name = "examen";
            this.examen.DataPropertyName = "examen";
            //this.examen.Width = 200;

            this.Column1.HeaderText = "Nro(P)";
            this.Column1.Name = "nroP";
            this.Column1.DataPropertyName = "nroP";
            //this.Column1.Width = 50;

            this.Column2.HeaderText = "S/ (P)";
            this.Column2.Name = "totalP";
            this.Column2.DataPropertyName = "totalP";
            //this.Column2.Width = 50;

            this.Column3.HeaderText = "Acum(P)";
            this.Column3.Name = "acuP";
            this.Column3.DataPropertyName = "acuP";
           // this.Column3.Width = 50;

            this.Column4.HeaderText = "Nro (SIS)";
            this.Column4.Name = "nroS";
            this.Column4.DataPropertyName = "nroS";
           // this.Column4.Width = 50;

            this.Column5.HeaderText = "Acum (SIS)";
            this.Column5.Name = "acuS";
            this.Column5.DataPropertyName = "acuS";
           // this.Column5.Width = 50;

            this.Column6.HeaderText = "Nro (EX)";
            this.Column6.Name = "nroE";
            this.Column6.DataPropertyName = "nroE";
          //  this.Column6.Width = 50;

            this.Column7.HeaderText = "Acum (EXO)";
            this.Column7.Name = "acuE";
            this.Column7.DataPropertyName = "acuE";
           // this.Column7.Width = 50;

            this.Column8.HeaderText = "Avance (COB)";
            this.Column8.Name = "cob";
            this.Column8.DataPropertyName = "cob";
          //  this.Column8.Width = 70;

            this.totalMes.HeaderText = "Total Mes";
            this.totalMes.Name = "totalMes";
            this.totalMes.DataPropertyName = "totalMes";
           // this.totalMes.Width = 50;

            bindingSource.DataSource = tabla;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        
        
        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            BLOrden enlaceOrden = new BLOrden();
            tabla.Rows.Clear();
            int mes=((KeyValuePair<int, string>)comboMes.SelectedItem).Key;
            int ano = Convert.ToInt32(campAno.Text);
            int area = ((KeyValuePair<int, string>)comboArea.SelectedItem).Key;
            List<int> contadorByTarifas = new List<int>();
            foreach (Paquete i in Tarifario.GetInstance().Paquetes.Values)
                if (area == i.IdArea)//
                    contadorByTarifas.Add(i.IdData);

            Dictionary<int, ReporteMensual> reporte = enlaceOrden.ObtenerReporteMensual(area,ano,mes);
            double[,] general = new double[4,3]; 
            

            foreach (int idTarifa in contadorByTarifas)
            {
                DataRow row = tabla.NewRow();
                row[0] = Tarifario.GetInstance().Paquetes[idTarifa].Nombre;
                row[1] = (reporte[0].ExisteId(idTarifa)? reporte[0].Detalle[idTarifa].Cantidad : 0);//contador P
                row[2] = (reporte[0].ExisteId(idTarifa) ? reporte[0].Detalle[idTarifa].Total : 0.00m);//Total P
                row[3] = (reporte[0].ExisteId(idTarifa) ? reporte[0].Detalle[idTarifa].Acumulado : 0) + (int)row[1];//acumulador P
                general[0, 0] += (int)row[1];
                general[0, 1] += (double)row[2];
                general[0, 2] += (int)row[3];

                row[4] = (reporte[1].ExisteId(idTarifa) ? reporte[1].Detalle[idTarifa].Cantidad : 0);// Contador S
                row[5] = (reporte[1].ExisteId(idTarifa) ? reporte[1].Detalle[idTarifa].Acumulado : 0) + (int)row[4];//acumulador S
                general[1, 0] += (int)row[4];
                general[1, 1] += 0;
                general[1, 2] += (int)row[5];


                row[6] = (reporte[2].ExisteId(idTarifa) ? reporte[2].Detalle[idTarifa].Cantidad : 0);//Contador Ex
                row[7] = (reporte[2].ExisteId(idTarifa) ? reporte[2].Detalle[idTarifa].Acumulado : 0) + (int)row[6];//acumulador Ex
                general[2, 0] += (int)row[6];
                general[2, 1] += 0;
                general[2, 2] += (int)row[7];


                row[8] = (int)row[1]+ (int)row[4]+ (int)row[6];
                row[9] = (int)row[3] + (int)row[5] + (int)row[7];
                general[3, 0] += (int)row[8];
                general[3, 1] += (general[0, 1] + general[1, 1] + general[2, 1]);
                general[3, 2] += (int)row[9];
                tabla.Rows.Add(row);
            }


            campCantPar.Text = general[0, 0].ToString();
            campEfec.Text = String.Format("{0:0.00}", general[0, 1]);
            campAcuPar.Text = general[0, 2].ToString();
            campCantSis.Text = general[1, 0].ToString();
            campAcuSis.Text = general[1, 2].ToString();
            campCantExo.Text = general[2, 0].ToString();
            campAcuExo.Text = general[2, 2].ToString();
            campCantTotal.Text = general[3, 0].ToString();
            campEfecTotal.Text = String.Format("{0:0.00}", general[3, 1]);
            campAcumTotal.Text = general[3, 2].ToString();
        }

        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
        private PrintDocument printDocument1 = new PrintDocument();
        
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                PrintDocument pd = new PrintDocument();
                pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1170); // all sizes are converted from mm to inches & then multiplied by 100.
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while printing", ex.ToString());
            }

        }

        int t = 0;
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            if (t < 1)
            {
                int height=ev.PageSettings.PaperSize.Height;
                int witdth = ev.PageSettings.PaperSize.Width;
                
                ev.Graphics.DrawString(0+","+0, new Font("Segoe UI", 7.25f, FontStyle.Regular), Brushes.Black, 0, 0);
                ev.Graphics.DrawString(0+","+height / 2, new Font("Segoe UI", 7.25f, FontStyle.Regular), Brushes.Black, 0, height / 2);

                ev.Graphics.DrawString(witdth / 2 +","+ 0, new Font("Segoe UI", 7.25f, FontStyle.Regular), Brushes.Black, witdth/2, 0);
                ev.Graphics.DrawString(witdth / 2 +","+ height / 2, new Font("Segoe UI", 7.25f, FontStyle.Regular), Brushes.Black, witdth/2, height/2);

                t++;
                if (t < 1)
                {
                    ev.HasMorePages = true;
                }
                else
                {
                    ev.HasMorePages = false;
                }
            }
        }

        
    }
}
