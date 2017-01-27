using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.EntityLayer.EExamen;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.LogicLayer.LogicaExamen;
using static MinLab.Code.EntityLayer.EOrden.Orden;
using MinLab.Code.PresentationLayer.Controles.ComponentesPaciente;
using MinLab.Code.LogicLayer.LogicaPaciente;

using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using static MinLab.Code.ControlSistemaInterno.DataEstaticaGeneral;
using MinLab.Code.ControlSistemaInterno.ControlImpresora;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    public partial class PanelMedico : UserControl
    {
        
        private bool isLoadingUI = false;
        private DataTable tabla;
        private BindingSource bindingSource;
        private Medico perfil;
        public UserControl controlSecondActive;

        public Medico Perfil {
            get { return this.perfil; }
            set {
                this.perfil=value;
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
                CampNombre.Text = BLMedico.FormatearNombre(Perfil);
                CampHabil.Text = Perfil.Habil ? "Activo" : "Inactivo";
                CampColegiatura.Text = Perfil.Colegiatura;
                CampEspecialidad.Text = Perfil.Especialidad;
                RellenarExamenesEnTabla();
        }

        public PanelMedico()
        {
            InitializeComponent();

            isLoadingUI = true;
            InicializarTablaOrdenDetalle();
            limpiarCamps();

            this.SuspendLayout();
            ComboEstado.DataSource = new BindingSource(DataEstaticaGeneral.OrdenEstados, null);
            ComboEstado.DisplayMember = "Value";
            ComboEstado.ValueMember = "Key";
            this.ResumeLayout(false);


            isLoadingUI = false;
            
        }
        

        private void RellenarExamenesEnTabla()
        {
            //LogicaOrden enlaceOrden = new LogicaOrden();
            //LogicaExamen enlaceExamen = new LogicaExamen();
            //tabla.Clear();


            ////ordenes = enlaceOrden.ObtenerOrdenesByPacienteByFechaByEstado(Perfil, PickerInit.Value, PickerEnd.Value, (EstadoOrden)ComboEstado.SelectedIndex);
            //ordenes = null;

            //examenesGeneral = new Dictionary<int, Examen>();
            //foreach (Orden orden in ordenes.Values)
            //{
            //    Dictionary<int, Examen> temp = enlaceExamen.RecuperarExamenes(orden);
            //    foreach (Examen ex in temp.Values)
            //    {
            //        if (ex.Estado == Examen.EstadoExamen.Terminado)
            //        {
            //            this.SuspendLayout();
            //            examenesGeneral.Add(ex.IdData, ex);
            //            DataRow row = tabla.NewRow();
            //            row[0] = ex.IdOrdenDetalle; //Orden Detalle
            //            row[1] = ex.IdData; //Examen
            //            String nombrePaquete = Tarifario.GetInstance().GetPaqueteById(orden.Detalle[ex.IdOrdenDetalle].IdDataPaquete).Nombre;
            //            String nombrePlantilla = Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Nombre;
            //            row[2] = (nombrePaquete == nombrePlantilla) ? nombrePaquete : (nombrePaquete + ":" + nombrePlantilla);
            //            row[3] = ex.DniResponsable;
            //            row[4] = ex.UltimaModificacion;
            //            row[5] = orden.IdData;
            //            tabla.Rows.Add(row);
            //            this.ResumeLayout(false);
            //        }
            //    }
            //}
            //BtnPrint.Visible = examenesGeneral.Count > 0;
        }



        private void InicializarTablaOrdenDetalle()
        {
            bindingSource = new BindingSource();
            DGVExamen.DataSource = bindingSource;
            tabla = new DataTable("Examenes");
            // Configuracion de Tablas

            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Codigo", typeof(int));
            tabla.Columns.Add("Examen", typeof(string));
            tabla.Columns.Add("Responsable", typeof(string));
            tabla.Columns.Add("UltimaModificacion", typeof(string));
            tabla.Columns.Add("IdOrden", typeof(int));

            //ID DATA
            this.DGVExamen.Columns[0].Visible = false;
            this.DGVExamen.Columns[0].ReadOnly = true;
            this.DGVExamen.Columns[0].DataPropertyName = "Id";
            //DNI
            this.DGVExamen.Columns[1].ReadOnly = true;
            this.DGVExamen.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[1].DataPropertyName = "Codigo";
            //HISTORIA
            this.DGVExamen.Columns[2].ReadOnly = true;
            this.DGVExamen.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[2].DataPropertyName = "Examen";
            //NOMBRE
            this.DGVExamen.Columns[3].ReadOnly = true;
            this.DGVExamen.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[3].DataPropertyName = "Responsable";
            //APELLIDO PATERNO
            this.DGVExamen.Columns[4].ReadOnly = true;
            this.DGVExamen.Columns[4].Resizable = DataGridViewTriState.False;
            this.DGVExamen.Columns[4].DataPropertyName = "UltimaModificacion";

            this.DGVExamen.Columns[5].Visible = false;
            this.DGVExamen.Columns[5].ReadOnly = true;
            this.DGVExamen.Columns[5].DataPropertyName = "IdOrden";

            bindingSource.DataSource = tabla;
            this.DGVExamen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }


        public void limpiarCamps()
        {
            CampNombre.Text = "";
            CampColegiatura.Text = "";
            CampHabil.Text = "";
            BtnPrint.Visible = false;
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarExamenesEnTabla();
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarExamenesEnTabla();
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarExamenesEnTabla();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {

        }
        
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            controlSecondActive = new PanelModificarMedico();
            controlSecondActive.Parent = this;
            this.Controls.Add(controlSecondActive);
            controlSecondActive.Location = new System.Drawing.Point(0, 0);
            ((PanelModificarMedico)controlSecondActive).CargarDatos();
            controlSecondActive.BringToFront();
            controlSecondActive.Show();
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {

            BLMedico enlacePaciente = new BLMedico();
            this.Visible = false;
            enlacePaciente.EliminarMedico(perfil.IdData);
            ((ControlMedico)this.Parent.Parent).ModeBtnFuncion(true);
            this.Dispose();
        }
    }
}
