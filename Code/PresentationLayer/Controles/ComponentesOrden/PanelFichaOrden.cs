using System;
using System.Data;
using System.Windows.Forms;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.EntityLayer.EOrden;

using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaPaciente;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesOrden
{
    public partial class PanelFichaOrden : UserControl
    {
        private DataTable tabla;
        private BindingSource bindingSource;
        private int idUniqueRowCount = 0;
        private Orden orden;
        private Paciente perfil;


        public Paciente Perfil {
            get {return perfil; }
            set {this.perfil = value;}
        }

        public Orden Orden {
            get {return orden; }
            set {
                this.orden=value;
            }

        }

        public PanelFichaOrden()
        {
            InitializeComponent();
            this.SuspendLayout();
            tabla = new DataTable("Lista");
                InicializarTablaOrdenDetalle();
            this.ResumeLayout(false);
            
            
        }
        
        public void CargarDatos()
        {
            BLMedico bl = new BLMedico();
            Medico medico = bl.ObtenerMedico(orden.IdMedico);
            CampUbicacion.Text = BLPaciente.FormatearUbicacion(perfil);
            CampDni.Text = perfil.Dni;
            CampHistoria.Text = perfil.Historia;
            CampNombre.Text = perfil.Nombre + " " + perfil.PrimerApellido + " " + perfil.SegundoApellido;
            CampBoleta.Text = orden.Boleta;
            CampSexo.Text = DiccionarioGeneral.GetInstance().TipoSexo[(int)perfil.Sexo];
            CampMedico.Text = medico.Nombre + " " + medico.PrimerApellido + " " + medico.SegundoApellido;
            CampConsultorio.Text = Consultorios.GetInstance().GetConsultorio(orden.IdConsultorio).Nombre;
            if (perfil.Sexo==Sexo.Mujer)
            {
                LabelGestacion.Visible = true;
                CampGestacion.Visible = true;
                CampGestacion.Text = orden.EnGestacion ? "Si" : "No";
            }
            else
            {
                LabelGestacion.Visible = false;
                CampGestacion.Visible = false;
            }
            PickerTime.Text = orden.FechaRegistro.ToShortDateString();
            tabla.Clear();
            foreach (OrdenDetalle ord in orden.Detalle.Values) {
                EntityLayer.Analisis p = ControlSistemaInterno.ListaAnalisis.GetInstance().GetAnalisisById(ord.IdDataPaquete);
                this.SuspendLayout();
                DataRow row = tabla.NewRow();
                row[0] = p.IdData;
                row[1] = p.Codigo;
                row[2] = p.Nombre;
                row[3] = ord.Cobertura;
                row[4] = idUniqueRowCount;
                idUniqueRowCount++;
                tabla.Rows.Add(row);
                this.ResumeLayout(false);
            }
            
        }
        
        private void InicializarTablaOrdenDetalle()
        {

            this.SuspendLayout();
            
            // Configuracion de Tablas


            tabla.Columns.Add("id", typeof(int));
            tabla.Columns.Add("codigo", typeof(string));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("cobertura", typeof(object));
            tabla.Columns.Add("idUnique", typeof(int));

            this.dataGridView.Columns[0].DataPropertyName = "id";
            this.dataGridView.Columns[0].Visible = false;
            this.dataGridView.Columns[0].ReadOnly = true;

            this.dataGridView.Columns[1].DataPropertyName = "codigo";
            this.dataGridView.Columns[1].ReadOnly = true;
            this.dataGridView.Columns[1].Resizable = DataGridViewTriState.False;
            this.dataGridView.Columns[2].DataPropertyName = "nombre";
            this.dataGridView.Columns[2].ReadOnly = true;
            this.dataGridView.Columns[2].Resizable = DataGridViewTriState.False;
            this.dataGridView.Columns[2].HeaderText = "Nombre";

            this.dataGridView.Columns[3].DataPropertyName = "cobertura";   // The DataTable column name.
            this.dataGridView.Columns[3].HeaderText = "Cobertura";
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DataSource = new BindingSource(DiccionarioGeneral.GetInstance().TipoCobertura, null);
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).DisplayMember = "Value";
            ((DataGridViewComboBoxColumn)this.dataGridView.Columns[3]).ValueMember = "Key";
            this.dataGridView.Columns[3].Resizable = DataGridViewTriState.False;


            this.dataGridView.Columns[4].DataPropertyName = "idUnique";   // The DataTable column name.
            this.dataGridView.Columns[4].Visible = false;
            this.dataGridView.Columns[4].ReadOnly = true;
            this.dataGridView.Enabled = false;

            bindingSource = new BindingSource();
            this.dataGridView.DataSource = bindingSource;
            bindingSource.DataSource = tabla;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ResumeLayout(false);
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            LogicaOrden enlaceLogicaOrden = new LogicaOrden();
            enlaceLogicaOrden.EliminarOrden(orden);
            ((ControlOrden)this.Parent.Parent).ModeBtnFuncion(true);
            this.Dispose();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            FormModificarOrden formModificarOrden = new FormModificarOrden();
            formModificarOrden.Perfil = Perfil;
            formModificarOrden.Orden = Orden;
            formModificarOrden.InicializarDatosFormulario(); 
            formModificarOrden.ShowDialog();
            LogicaOrden enlaceOrden = new LogicaOrden();
            Orden = enlaceOrden.ObtenerOrden(orden.IdData);
            CargarDatos();
        }
        
        
    }
}
