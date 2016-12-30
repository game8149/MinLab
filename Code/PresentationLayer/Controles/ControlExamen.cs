using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.ComponentesExamen;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.LogicLayer.LogicaTarifario;
using static MinLab.Code.EntityLayer.EOrden.Orden;
using MinLab.Code.LogicLayer.LogicaPaciente;

using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.ControlSistemaInterno.ControlImpresora;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class ControlExamen : UserControl
    {
        private bool isLoadingUI = false;
        BindingSource bindingSource;
        DataTable tabla;
        Dictionary<int, Orden> ordenes;

        public ControlExamen()
        {
            isLoadingUI = true;
            InitializeComponent();
            tabla = new DataTable("Examenes");
            bindingSource = new BindingSource();

            ComboEstado.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().EstadoOrden, null);
            ComboEstado.DisplayMember = "Value";
            ComboEstado.ValueMember = "Key";

            InicializarComponenteTablaDGVOrden();

            DGVOrden.KeyPress += DGVOrden_KeyPress;
            DGVOrden.DoubleClick += DGVOrden_DoubleClick; 
            isLoadingUI = false;
            
        }
        
        private void DGVOrden_DoubleClick(object sender, EventArgs e)
        {
            IniciarEditorExamen();
        }
        
        
        private void DGVOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                IniciarEditorExamen();
            }
            else if (e.KeyChar == (char)Keys.P)
                BtnPrint.PerformClick();

        }

        private void ControlExamen_Load(object sender, EventArgs e)
        {
            PickerEnd.MaxDate = DateTime.Now;
            PickerInit.MaxDate = DateTime.Now;
            CargarDatosEnDGVOrden();
        }


        private void InicializarComponenteTablaDGVOrden()
        {
            DGVOrden.DataSource = bindingSource;
            // Configuracion de Tablas
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Dni", typeof(string));
            tabla.Columns.Add("Paciente", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Registro", typeof(string));//Fecha
            tabla.Columns.Add("Comprobante", typeof(string));//
            tabla.Columns.Add("Estado", typeof(string));

            //ID ORDEN
            this.DGVOrden.Columns[0].Visible = true;
            this.DGVOrden.Columns[0].ReadOnly = true;
            this.DGVOrden.Columns[0].DataPropertyName = "Id";
            //DNI
            this.DGVOrden.Columns[1].ReadOnly = true;
            this.DGVOrden.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[1].DataPropertyName = "Dni";
            //PACIENTE
            this.DGVOrden.Columns[2].ReadOnly = true;
            this.DGVOrden.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[2].DataPropertyName = "Paciente";
            //DESCRIPCION
            this.DGVOrden.Columns[3].ReadOnly = true;
            this.DGVOrden.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[3].DataPropertyName = "Descripcion";
            //FECHA DE REGISTRO
            this.DGVOrden.Columns[4].ReadOnly = true;
            this.DGVOrden.Columns[4].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[4].DataPropertyName = "Registro";
            //BOLETA
            this.DGVOrden.Columns[5].ReadOnly = true;
            this.DGVOrden.Columns[5].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[5].DataPropertyName = "Comprobante";
            //ESTADO
            this.DGVOrden.Columns[6].ReadOnly = true;
            this.DGVOrden.Columns[6].Resizable = DataGridViewTriState.False;
            this.DGVOrden.Columns[6].DataPropertyName = "Estado";

            bindingSource.DataSource = tabla;
            this.DGVOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVOrden.SelectionChanged += DGVOrden_SelectionChanged;
            
        }

        private void DGVOrden_SelectionChanged(object sender, EventArgs e)
        {
            if (ComboEstado.SelectedIndex == (int)EstadoOrden.Finalizado)
                BtnPrint.Visible = (DGVOrden.SelectedRows.Count > 0);
            else BtnPrint.Visible = false;
        }

        private void CargarDatosEnDGVOrden()
        {
            LogicaOrden enlaceOrden = new LogicaOrden();
            BLPaciente enlacePaciente = new BLPaciente();
            ordenes = enlaceOrden.ObtenerOrdenesByFechaByEstado(PickerInit.Value, PickerEnd.Value,(EstadoOrden)ComboEstado.SelectedIndex);
            tabla.Clear();
            this.SuspendLayout();
            DGVOrden.SuspendLayout();
            foreach (Orden orden in ordenes.Values)
            {
                DataRow row = tabla.NewRow();
                Paciente pac = enlacePaciente.ObtenerPerfilPorId(orden.IdPaciente);
                row[0] = orden.IdData;//Orden Detalle
                row[1] = pac.Dni;
                row[2] = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(pac.Nombre+" "+pac.PrimerApellido+" "+pac.SegundoApellido);//Examen
                row[3] = enlaceOrden.ObtenerDescripcion(orden);
                row[4] = orden.FechaRegistro;
                row[5] = orden.Boleta;
                row[6] = DiccionarioGeneral.GetInstance().EstadoOrden[Convert.ToInt32(orden.Estado)];
                tabla.Rows.Add(row);              
            }
            this.DGVOrden.ClearSelection();
            DGVOrden.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        
        private void IniciarEditorExamen()
        {
            int index;
            if (DGVOrden.SelectedRows.Count > 0)
            {
                index = this.DGVOrden.SelectedRows[0].Index;
                this.DGVOrden.ClearSelection();
                this.DGVOrden.Rows[index].Selected = true;
                BLPaciente enlacePac = new BLPaciente();
                FormExamenEditor VentanaOrden = new FormExamenEditor();
                VentanaOrden.Orden = ordenes[Convert.ToInt32(DGVOrden.SelectedRows[0].Cells[0].Value)];
                VentanaOrden.Paciente = enlacePac.ObtenerPerfilPorId(ordenes[Convert.ToInt32(DGVOrden.SelectedRows[0].Cells[0].Value)].IdPaciente);
                VentanaOrden.ShowDialog();
                VentanaOrden.Dispose();
                CargarDatosEnDGVOrden();
            }

            
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if(!isLoadingUI)
            CargarDatosEnDGVOrden();
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isLoadingUI)
            CargarDatosEnDGVOrden();
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if(!isLoadingUI)
            CargarDatosEnDGVOrden();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Dictionary<int, Orden> temp = new Dictionary<int, Orden>();
            foreach (DataGridViewRow r in DGVOrden.SelectedRows)
            {
                temp.Add((int)r.Cells[0].Value, ordenes[(int)r.Cells[0].Value]);
            }
            Console.WriteLine(temp.Count);
            Impresora printer = new Impresora();
            printer.ContruirVistaPrevia(temp);
        }

        private void LabelExamen_Click(object sender, EventArgs e)
        {

        }
    }
}
