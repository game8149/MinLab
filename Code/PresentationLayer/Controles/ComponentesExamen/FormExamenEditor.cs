using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.EExamen;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.LogicLayer.LogicaControl;
using MinLab.Code.LogicLayer.LogicaExamen;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.PresentationLayer.ComponentesExamenEditor;
using MinLab.Code.PresentationLayer.ComponentesExamen.ComponentesPrueba;
using MinLab.Code.PresentationLayer.GUISesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static MinLab.Code.EntityLayer.EExamen.Examen;
using static MinLab.Code.PresentationLayer.ComponentesExamenEditor.ExamenEditorFila;

using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using static MinLab.Code.ControlSistemaInterno.DiccionarioGeneral;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer.ComponentesExamen
{
    public partial class FormExamenEditor : Form
    {
        private int indexRowSelected=-1;
        private int idExamenSelected = -1;
        private ExamenEditorContenedor panelActual;
        private bool cargandoExamen = false;

        public FormExamenEditor()
        {
            InitializeComponent();
            this.SuspendLayout();

            bindingSource = new BindingSource();
            InicializarComponentesTablaDGVExamen();
            LimpiarFormulario();
            this.DoubleBuffered = true;
            this.FormClosing += FormExamenGeneral_FormClosing;
            this.ResumeLayout();
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void FormExamenGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogicaOrden logica = new LogicaOrden();
            logica.ActualizarOrden(examenes,orden);
        }


        //Objeto fijo de tabla para orden
        private DataTable tabla;
        private BindingSource bindingSource;

        //Objeto fijo de paginas para examen
        //private Dictionary<int, TabPageForm> tabsByExamen = new Dictionary<int, TabPageForm>();
        //Objetos de Uso Necesario
        private Dictionary<int, Examen> examenes;

        private Paciente paciente=null;
        private Orden orden=null;

        public Paciente Paciente
        {
            get {
                return paciente;
            }
            set {
                this.paciente=value;
                CampNombre.Text = paciente.Nombre+" "+paciente.PrimerApellido +" "+paciente.SegundoApellido;
                CampDni.Text = paciente.Dni;
                CampHistoria.Text = paciente.Historia;;
                CampSexo.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(DiccionarioGeneral.GetInstance().TipoSexo[(int)paciente.Sexo]));
                Tiempo tiempo = DiccionarioGeneral.GetInstance().CalcularEdad(paciente.FechaNacimiento);
                if (tiempo.Año < 1)
                    CampEdad.Text = tiempo.Mes + "meses " + tiempo.Dias + " dias";
                CampEdad.Text = tiempo.Año+" años";
            }
        }

        public Orden Orden
        {
            get {return orden; }
            set {
                this.orden = value;
                CampOrden.Text = "Orden "+orden.IdData+" - "+orden.Boleta;
                CampRegistro.Text = orden.FechaRegistro.ToShortDateString();
                CargarDatosEnDGVExamen(orden);
            }
        }


        private void CargarDatosEnDGVExamen(Orden orden)
        {
            LogicaOrden enlaceOrden = new LogicaOrden();
            LogicaExamen enlaceExamen = new LogicaExamen();
            DGVExamen.SuspendLayout();
            tabla.Clear();
            examenes = enlaceExamen.RecuperarExamenes(orden);
            
            foreach (Examen ex in examenes.Values)
            {
                DataRow row = tabla.NewRow();
                String nombrePaquete = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(ControlSistemaInterno.ListaAnalisis.GetInstance().GetAnalisisById(orden.Detalle[ex.IdOrdenDetalle].IdDataPaquete).Nombre));
                String nombrePlantilla = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToLower(Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Nombre));
                row[0] = (nombrePaquete == nombrePlantilla) ? nombrePaquete : (nombrePaquete + ":" + nombrePlantilla);
                row[1] = DiccionarioGeneral.GetInstance().EstadoExamen[(int)ex.Estado];
                row[2] = ex.IdData;//Examen
                tabla.Rows.Add(row);
                
            }
            DGVExamen.ResumeLayout(false);
        }
        
        private void InicializarComponentesTablaDGVExamen()
        {
            DGVExamen.SuspendLayout();
            //Init Tabla de Examenes
            tabla = new DataTable("Examenes");
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Estado", typeof(string));
            tabla.Columns.Add("IdExamen", typeof(int));

            //----------------------------
            //Init DataGridView de Examenes
            this.DGVExamen.Columns[0].DataPropertyName = "Nombre";
            this.DGVExamen.Columns[0].HeaderText = "Nombre";
            this.DGVExamen.Columns[0].ReadOnly = true;

            this.DGVExamen.Columns[1].DataPropertyName = "Estado";
            this.DGVExamen.Columns[1].HeaderText = "Estado";
            this.DGVExamen.Columns[1].ReadOnly = true;
            
            this.DGVExamen.Columns[2].DataPropertyName = "IdExamen";
            this.DGVExamen.Columns[2].HeaderText = "IdExamen";
            this.DGVExamen.Columns[2].Visible = false;
            this.DGVExamen.Columns[2].ReadOnly = true;

            //----------------------------
            //Configuracion GridView y Tabla Examen

            DGVExamen.DataSource = bindingSource;
            bindingSource.DataSource = tabla;
            this.DGVExamen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //----------------------------
            DGVExamen.CellMouseEnter += DataGridView_CellMouseEnter;
            DGVExamen.CellMouseLeave += DataGridView_CellMouseLeave;
            DGVExamen.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
            DGVExamen.CellMouseUp += DataGridView_CellMouseUp;
            DGVExamen.MultiSelect = false;
            DGVExamen.ResumeLayout(true);
        }
        

        private void LimpiarFormulario()
        {
            CampOrden.Text = "";
            CampDni.Text = "";
            CampEdad.Text = "";
            CampHistoria.Text = "";
            CampNombre.Text = "";
            CampRegistro.Text = "";
            CampSexo.Text = "";

        }

        private void DataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVExamen.Rows[e.RowIndex].Selected)
                    DGVExamen.Cursor = Cursors.Hand;
            }
        }

        private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.RowIndex > -1)
            {
                Examen ex = examenes[Convert.ToInt32(DGVExamen.Rows[e.RowIndex].Cells[2].Value)];
                idExamenSelected = ex.IdData;
                indexRowSelected = e.RowIndex;
                cargandoExamen = true;
                DGVExamen.Enabled = false;

                PanelExamen.SuspendLayout();
                CargarPlantillaEnPanel(ex);
                SetTabRespuestas(examenes[idExamenSelected]);
                

                HabilitarBarTitle();
                if (ex.Estado == EstadoExamen.Terminado)
                {
                    BlockPanelExamen();
                    DeshabilitarTools();
                }
                else
                {
                    UnblockPanelExamen();
                    HabilitarTools();
                }
                cargandoExamen = false;
                PanelExamen.ResumeLayout(false);

            }
        }
        
        private void DataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVExamen.Rows[e.RowIndex].Selected)
                    DGVExamen.Cursor = Cursors.Arrow;
            }
            
        }

        private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVExamen.Rows[e.RowIndex].Selected)
                    DGVExamen.Cursor = Cursors.Hand;
            }
        }

        private void ResetComboEstadoTabla()
        {
            foreach (DataRow r in tabla.Rows)
                r[1] = 0;
        }
       
        private void ValidarAutorizacion()
        {
            FormAutorizacion formAut = new FormAutorizacion();
            //int x=BtnAutorizacion.Location.X, y= BtnAutorizacion.Location.Y;
            //int XF=
            formAut.ShowDialog();
        }
        
        
                
        private void CargarPlantillaEnPanel(Examen examen)
        {
            Plantilla plantilla = Plantillas.GetInstance().GetPlantilla(examen.IdPlantilla);
            CheckEstado.Checked = Convert.ToBoolean((int)examen.Estado);
            LabelExamen.Text = Plantillas.GetInstance().Coleccion()[examen.IdPlantilla].Nombre;

            this.SuspendLayout();
            List<ExamenEditorFila> filas = new List<ExamenEditorFila>();
            panelActual = new ExamenEditorContenedor(PanelExamen.Width - 10, PanelExamen.Height - 10);
            PanelExamen.SuspendLayout();
            
            ExamenEditorFila filaForm = null;
            ExamenEditorItem itemForm = null;
            ExamenEditorGrupo grupoForm = null;
            PlantillaItem item;
            int posicion = 0;

            for (int indice = 0; indice < plantilla.Filas.Count; indice++)
            {
                
                if (PlantillaFila.PlantillaFilaTipo.Agrupada == plantilla.Filas[indice].Tipo)
                {
                    PlantillaFilaGrupo filaGrupo = (PlantillaFilaGrupo)plantilla.Filas[indice];
                    filaForm = new ExamenEditorFila(panelActual.Width - 10, 25);
                    filaForm.SuspendLayout();
                    filaForm.Tipo = ExamenEditorFila.TipoForm.Grupo;
                    grupoForm = new ExamenEditorGrupo(filaForm.Width - 5, 0);
                    grupoForm.SuspendLayout();
                    grupoForm.Location = new Point(0, 0);
                    grupoForm.Nombre = filaGrupo.Nombre;
                    List<ExamenEditorItem> items = new List<ExamenEditorItem>();
                    for (int j = 0; j < filaGrupo.Items.Count; j++)
                    {
                        item = filaGrupo.Items[j];
                        itemForm = new ExamenEditorItem(grupoForm.Width - 20, 25, item.TieneUnidad);
                        itemForm.SuspendLayout();
                        itemForm.TabIndex = posicion;
                        posicion++;
                        itemForm.IdItem = item.IdData;
                        itemForm.Nombre = item.Nombre;
                        itemForm.TipoDato = item.TipoDato;
                        itemForm.TipoCampo = item.TipoCampo;
                        if (item.TipoCampo == TipoCampo.Lista)
                            itemForm.Opciones = item.OpcionesByIndice;
                        else if (item.TipoCampo == TipoCampo.Texto)
                        {
                            filaForm.Height = 80;
                            itemForm.Height = 80;
                        }

                        if (item.TipoDato == TipoDato.Entero|| item.TipoDato == TipoDato.Bool)
                            itemForm.RegEx = DiccionarioGeneral.GetInstance().Expression[(int)item.TipoDato];
                        if (item.TieneUnidad)
                            itemForm.Unidad = item.Unidad;
                        itemForm.Location = new Point(10, 20);
                        items.Add(itemForm);
                        itemForm.ResumeLayout(false);
                    }
                    grupoForm.Items = items;
                    filaForm.Grupo = grupoForm;
                    filas.Add(filaForm);
                    grupoForm.ResumeLayout(false);
                    filaForm.ResumeLayout(false);
                }
                else
                {
                    item = ((PlantillaFilaSimple)plantilla.Filas[indice]).Item;
                    filaForm = new ExamenEditorFila(panelActual.Width - 10, 25);
                    filaForm.SuspendLayout();
                    filaForm.Location = new Point(10, 10);
                    filaForm.Tipo = ExamenEditorFila.TipoForm.Item;

                    itemForm = new ExamenEditorItem(filaForm.Width - 5, 25, item.TieneUnidad);
                    itemForm.SuspendLayout();
                    itemForm.Location = new Point(0, 0);
                    itemForm.IdItem = item.IdData;
                    itemForm.Nombre = item.Nombre;
                    itemForm.TabIndex = posicion;
                    posicion++;
                    itemForm.TipoCampo = item.TipoCampo;
                    itemForm.TipoDato = item.TipoDato;
                    if (item.TipoCampo == TipoCampo.Lista)
                        itemForm.Opciones = item.OpcionesByIndice;
                    else if (item.TipoCampo == TipoCampo.Texto)
                    {
                        filaForm.Height = 80;
                        itemForm.Height = 80;
                    }
                    if (item.TieneUnidad)
                        itemForm.Unidad = item.Unidad;
                    filaForm.Item = itemForm;
                    filas.Add(filaForm);
                    itemForm.ResumeLayout(false);
                    filaForm.ResumeLayout(false);
                }
            }

            panelActual.Filas = filas;
            PanelExamen.Controls.Add(panelActual);
            PanelExamen.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        //Almacenar y Recoger Info del Formulario de examen
        private void SetTabRespuestas(Examen examen)
        {
            List<ExamenEditorFila> filasByTab = panelActual.Filas;

            foreach (ExamenEditorFila detalle in filasByTab)
            {
                if (detalle.Tipo == TipoForm.Item)
                    detalle.Item.Value = examen.DetallesByItem[detalle.Item.IdItem].Campo.ToString();
                else
                    foreach (ExamenEditorItem itemG in detalle.Grupo.Items)
                        itemG.Value = examen.DetallesByItem[itemG.IdItem].Campo.ToString();
            }
        }

        private void GetTabRespuestas(Examen examen)
        {
            List<ExamenEditorFila> filasByTab = panelActual.Filas;

            foreach (ExamenEditorFila detalle in filasByTab)
            {
                if (detalle.Tipo == TipoForm.Item)
                    examen.DetallesByItem[detalle.Item.IdItem].Campo = detalle.Item.Value;
                else
                    foreach (ExamenEditorItem itemG in detalle.Grupo.Items)
                    {
                        examen.DetallesByItem[itemG.IdItem].Campo = itemG.Value;

                    }
            }
        }
        
        //update_examen_single
        private void BtnSave_Click(object sender, EventArgs e)
        {
            LogicaExamen enlace = new LogicaExamen();
            try
            {
                GetTabRespuestas(examenes[idExamenSelected]);
                enlace.ValidarExamenes(examenes[idExamenSelected]);
                enlace.GuardarExamen(examenes[idExamenSelected]);

                ConfiguracionExamen.GetInstance().Changed = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Advertencia");
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (ConfiguracionExamen.GetInstance().Changed)
            {
                var window = MessageBox.Show("Desea guardar los cambios realizados?", "Advertencia", MessageBoxButtons.YesNo);
                if (window == DialogResult.Yes) MessageBox.Show("Cambios Realizados");
                ConfiguracionExamen.GetInstance().Changed = false;
            }

            DehabilitarBarTitle();
            DeshabilitarTools();
            UnblockPanelExamen();

            PanelExamen.Controls.Remove(panelActual);
            DGVExamen.Enabled = true;
            LabelExamen.Text = "";
        }
        


        public void HabilitarTools()
        {
            CheckEstado.Visible = true;
            BtnSave.Visible = true;
        }

        public void DeshabilitarTools()
        {
            CheckEstado.Visible = false;
            BtnSave.Visible = false;
        }


        public void HabilitarBarTitle()
        {
            BtnClose.Visible = true;
            LabelExamen.Visible = true;
        }

        public void DehabilitarBarTitle()
        {
            BtnClose.Visible = false;
            LabelExamen.Visible = false;
        }
        
        public void BlockPanelExamen()
        {
            panelActual.Visible = false;
            PanelCerrado.Visible = true;
        }

        public void UnblockPanelExamen()
        {
            panelActual.Visible = true;
            PanelCerrado.Visible = false;
        }


        private void BtnAutorizacion_Click(object sender, EventArgs e)
        {
            LogicControlSistema logicaSistema = new LogicControlSistema();
            LogicaExamen enlaceExamen = new LogicaExamen();
            LogicaOrden enlaceOrden = new LogicaOrden();
            this.cargandoExamen = true;
            if (!logicaSistema.GetPase())
            {
                ValidarAutorizacion();
                CheckEstado.Checked = false;
            }
            if (logicaSistema.GetPase())
            {
                examenes[idExamenSelected].Estado = EstadoExamen.EnProceso;
                CheckEstado.Checked = false;
                enlaceExamen.GuardarExamen(examenes[idExamenSelected]);
                enlaceOrden.ActualizarOrden(examenes,orden);
                ActualizarDGVEstadoExamen();
                HabilitarTools();
                UnblockPanelExamen();
            }
            this.cargandoExamen = false;
        }


        private void ActualizarDGVEstadoExamen()
        {
            DGVExamen.SuspendLayout();
            DGVExamen.Rows[indexRowSelected].Cells[1].Value = DiccionarioGeneral.GetInstance().EstadoExamen[(int)examenes[idExamenSelected].Estado];
            DGVExamen.ResumeLayout(false);
        }

        private void CheckEstado_CheckedChanged(object sender, EventArgs e)
        {
            LogicaExamen enlaceExamen;
            if (!cargandoExamen)
            {
                if (CheckEstado.Checked)
                {
                    var window = MessageBox.Show("Esta seguro que desea dar por finalizado el examen?", "Advertencia", MessageBoxButtons.YesNo);
                    if (window == DialogResult.Yes)
                    {
                        enlaceExamen = new LogicaExamen();
                        examenes[idExamenSelected].Estado = EstadoExamen.Terminado;
                        
                        enlaceExamen.GuardarExamen(examenes[idExamenSelected]);
                        ActualizarDGVEstadoExamen();
                        DeshabilitarTools();
                        BlockPanelExamen();
                    }
                    else CheckEstado.Checked = false;
                }
                else
                {

                }
            }
        }

        private void formExamenGeneral_Load(object sender, EventArgs e)
        {
            DGVExamen.Columns["idExamen"].Visible = false;
        }
    }
}
