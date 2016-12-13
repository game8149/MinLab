using MinLab.Code.DataLayer.AccesoControl;
using MinLab.Code.EntityLayer.ArchivoCaja;
using MinLab.Code.LogicLayer.LogicaExamen;
using MinLab.Code.LogicLayer.LogicaPaciente;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.PresentationLayer.GUIHistorial.ComponenteImpresion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using static MinLab.Code.PresentationLayer.GUIHistorial.ComponenteImpresion.FormatoImpresion;

namespace MinLab.Code.PresentationLayer.GUIExamen
{
    public partial class FormEmitirExamen : Form
    {

        private DataTable tabla;
        private BindingSource bindingSource;
        private Dictionary<int, Orden> ordenes;
        
        public FormEmitirExamen()
        {
            InitializeComponent();
            InicializarTablaOrdenes();
        }

        private void InicializarTablaOrdenes()
        {
            bindingSource = new BindingSource();
            dataGridView.DataSource = bindingSource;
            tabla = new DataTable("Ordenes");
            // Configuracion de Tablas

            tabla.Columns.Add("check", typeof(int));
            tabla.Columns.Add("historia", typeof(string));
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("detalle", typeof(string));
            tabla.Columns.Add("fechaFinal", typeof(string));
            tabla.Columns.Add("emitida", typeof(string));
            tabla.Columns.Add("idOrden", typeof(int));

            this.Check.Frozen = true;
            this.Historia.ReadOnly = false;
            this.Check.HeaderText = "";
            this.Check.Name = "check";
            this.Check.DataPropertyName = "check";
            // 
            // Historia
            // 
            this.Historia.Frozen = true;
            this.Historia.HeaderText = "Historia";
            this.Historia.Name = "historia";
            this.Historia.DataPropertyName = "historia";
            this.Historia.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "codigo";
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Detalle
            // 
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "detalle";
            this.Detalle.DataPropertyName = "detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Width = 300;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Finalizado";
            this.Fecha.Name = "fechaFinal";
            this.Fecha.DataPropertyName = "fechaFinal";
            this.Fecha.ReadOnly = true;
            // 
            // Emitida
            // 
            this.Emitida.HeaderText = "Emitida";
            this.Emitida.Name = "emitida";
            this.Emitida.DataPropertyName = "emitida";
            this.Emitida.ReadOnly = true;
            
            this.idOrden.Name ="idOrden";
            this.idOrden.DataPropertyName ="idOrden";   // The DataTable column name.
            this.idOrden.ReadOnly = false;
            
            bindingSource.DataSource = tabla;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Location = new System.Drawing.Point(11, 64);
        }
        
        public void AddOrdenesToTB(Dictionary<int,Orden> ordenes)
        {
            BLPaciente enlace = new BLPaciente();
            this.SuspendLayout();
            foreach (Orden orden in ordenes.Values)
            {
                //DataRow row = tabla.NewRow();
                //row[0] = Convert.ToInt32(!orden.EsEmitido);
                //row[1] = enlace.ObtenerPerfilPorId(orden.IdPaciente).CodigoHC;
                //row[2] = orden.Codigo;
                //row[3] = BLOrden.ObtenerDescripcion(orden);
                //row[4] = orden.UltimaModificacion ;
                //row[5] = (orden.EsEmitido? "SI":"NO");
                //row[6] = orden.IdData;
                //tabla.Rows.Add(row);
            }
            this.ResumeLayout(false);
        }

        public Dictionary<int,Orden> GetOrdenesFromTB()
        {
            Dictionary<int, Orden> temp = new Dictionary<int, Orden>();
            foreach (DataRow row in tabla.Rows)
                if (Convert.ToBoolean((int)row[0])) //Solo si es seleccionado 
                    temp.Add((int)row[6], ordenes[(int)row[6]]);

            return temp;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Dictionary<int, Orden> temp = GetOrdenesFromTB();
            //Impresora printer = new Impresora();
            //printer.ContruirVistaPrevia(temp);
            //foreach (Orden o in temp.Values)
            ////{
            ////    o.EsEmitido = true;
            //    BLOrden.ActualizarOrdenEstado(o);
            //}
            
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            BLOrden enlaceOrden = new BLOrden();
            tabla.Clear();
            ordenes = enlaceOrden.ObtenerOrdenesTerminadas(dateTimePicker.Value);
            AddOrdenesToTB(ordenes);
        }
    }
}


