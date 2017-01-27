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
using MinLab.Code.ControlSistemaInterno.Util;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class PanelPerfil : UserControl
    {
        
        private bool isLoadingUI = false;
        private DataTable tabla;
        private BindingSource bindingSource;
        private Dictionary<int, Examen> examenesGeneral;
        private Dictionary<int, Orden> ordenes;
        public UserControl controlSecondActive;

        private Paciente perfil;

        public Paciente Perfil
        {
            get
            {
                return this.perfil;
            }
            set
            {
                this.perfil = value;
                CargarDatos();
            }
        }

        public void CargarDatos()
        {
            CampNombre.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(perfil.Nombre + " " + perfil.PrimerApellido + " " + perfil.SegundoApellido);
            CampDni.Text = perfil.Dni;
            CampHistoria.Text = perfil.Historia;
            CampSexo.Text = DataEstaticaGeneral.SexoTipos[(int)perfil.Sexo];
            Tiempo tiempo = Utilidad.CalcularEdad(perfil.FechaNacimiento);
            CampEdad.Text = Utilidad.FormatoEdad(tiempo);
            CampDireccion.Text = perfil.Direccion;
            CampUbicacion.Text = Locaciones.GetInstance().GetDistrito(perfil.IdDistrito).Nombre + ", " + Locaciones.GetInstance().GetDistrito(perfil.IdDistrito).Sectores[perfil.IdSector].Nombre;
            RellenarOrdenes();
        }


        public PanelPerfil()
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

        private void PanelPerfil_Load(object sender, EventArgs e)
        {

        }

        private void RellenarOrdenes()
        {
            LogicaOrden enlaceOrden = new LogicaOrden();
            ordenes = enlaceOrden.ObtenerOrdenesByPacienteByFechaByEstado(perfil, PickerInit.Value, PickerEnd.Value, (EstadoOrden)ComboEstado.SelectedIndex);
            if (ordenes.Count > 0)
            {
                Dictionary<int, string> listOrden = new Dictionary<int, string>();
                foreach (Orden or in ordenes.Values)
                {
                    listOrden.Add(or.IdData, or.IdData + "-" + (or.Boleta == "" ? "Sin Boleta" : or.Boleta) + " (" + or.FechaRegistro + ")");
                }

                ComboBoxOrden.DataSource = new BindingSource(listOrden, null);
                ComboBoxOrden.DisplayMember = "Value";
                ComboBoxOrden.ValueMember = "Key";

                foreach (int k in listOrden.Keys)
                    ComboBoxOrden.SelectedValue = k;
            }
            ComboBoxOrden.Visible = ordenes.Count > 0;
            LabelOrden.Visible = ordenes.Count > 0;
        }
        private void RellenarExamenesEnTabla()
        {
            
            LogicaCuenta oLCuenta = new LogicaCuenta();
            LogicaExamen enlaceExamen = new LogicaExamen();
            if (ordenes.Count > 0)
            {
                
                tabla.Clear();

                Cuenta account;

                examenesGeneral = new Dictionary<int, Examen>();
                Orden orden = ordenes[(int)ComboBoxOrden.SelectedValue];
                Dictionary<int, Examen> temp = enlaceExamen.RecuperarExamenes(orden);
                foreach (Examen ex in temp.Values)
                {
                    if (ex.Estado == Examen.EstadoExamen.Terminado)
                    {
                        this.SuspendLayout();
                        examenesGeneral.Add(ex.IdData, ex);
                        DataRow row = tabla.NewRow();
                        row[0] = ex.IdOrdenDetalle; //Orden Detalle
                        row[1] = ex.IdData; //Examen
                        String nombrePaquete = ControlSistemaInterno.ListaAnalisis.GetInstance().GetAnalisisById(orden.Detalle[ex.IdOrdenDetalle].IdDataPaquete).Nombre;
                        String nombrePlantilla = Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Nombre;
                        row[2] = (nombrePaquete == nombrePlantilla) ? nombrePaquete : (nombrePaquete + ":" + nombrePlantilla);
                        account = oLCuenta.ObtenerCuenta(ex.IdCuenta);
                        row[3] = (account.Nombre + account.PrimerApellido).ToUpper() + " (" + account.Dni + ")";
                        row[4] = ex.UltimaModificacion;
                        row[5] = orden.IdData;
                        tabla.Rows.Add(row);
                        this.ResumeLayout(false);
                    }
                }

                BtnPrint.Visible = examenesGeneral.Count > 0;
            }


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
            CampDireccion.Text = "";
            CampEdad.Text = "";
            CampHistoria.Text = "";
            CampSexo.Text = "";
            CampDni.Text = "";
            BtnPrint.Visible = false;
        }

        private void ComboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarOrdenes();
        }

        private void PickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarOrdenes();
        }

        private void PickerInit_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarOrdenes();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            LogicaOrden enlace = new LogicaOrden();
            
            Dictionary<int, Examen> examenes = new Dictionary<int, Examen>();
            Orden orden = ordenes[(int)ComboBoxOrden.SelectedValue];
            foreach (DataGridViewRow r in DGVExamen.SelectedRows)
            {
                examenes.Add((int)r.Cells[1].Value, examenesGeneral[(int)r.Cells[1].Value]);
            }
            Impresora printer = new Impresora();
            printer.ContruirVistaPreviaExamenPaciente(orden, examenes);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            controlSecondActive = new PanelModificarPaciente();
            controlSecondActive.Parent = this;
            this.Controls.Add(controlSecondActive);
            controlSecondActive.Location = new System.Drawing.Point(0, 0);
            ((PanelModificarPaciente)controlSecondActive).CargarDatos();
            controlSecondActive.BringToFront();
            controlSecondActive.Show();            
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            LogicaPaciente enlacePaciente = new LogicaPaciente();

            enlacePaciente.EliminarPaciente(perfil);
            ((ControlPaciente)this.Parent.Parent).ModeBtnFuncion(true);
            this.Dispose();
        }

        private void ComboBoxOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoadingUI)
                RellenarExamenesEnTabla();
        }
    }
}
