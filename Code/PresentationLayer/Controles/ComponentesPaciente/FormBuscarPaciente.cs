using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.Controles.GUIBuscarPaciente
{

    public partial class FormBuscarPaciente : Form
    {
        private Dictionary<int, Paciente> diccionario;


        public Paciente Perfil { get; set; }


        //Lista de Resultados;

        //Componentes
        private DataTable tabla;
        private BindingSource bindingSource;

        

        public FormBuscarPaciente()
        {
            InitializeComponent();
            InicializarTablaOrdenDetalle();
            BtnCargar.Enabled = false;
        }

        private void FormBuscarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BLPaciente enlace = new BLPaciente();
            tabla.Clear();
            diccionario = enlace.ObtenerPerfilPorFiltro(CampDni.Text, CampHistoria.Text, CampNombre.Text, Campapellido1erno.Text, Campapellido2erno.Text);
            this.SuspendLayout();
            foreach (int key in diccionario.Keys)
            {
                Paciente pac = diccionario[key];
                DataRow row = tabla.NewRow();
                row[0] = pac.IdData;
                row[1] = pac.Dni;
                row[2] = pac.Historia;
                row[3] = pac.Nombre;
                row[4] = pac.PrimerApellido;
                row[5] = pac.SegundoApellido;
                tabla.Rows.Add(row);
            }
            this.ResumeLayout(false);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            int idData=Convert.ToInt32(this.DGVPaciente.SelectedRows[0].Cells[0].Value);
            Perfil=diccionario[idData];
            this.Visible=false;
        }
        
        private void InicializarTablaOrdenDetalle()
        {
            bindingSource = new BindingSource();
            DGVPaciente.DataSource = bindingSource;
            tabla = new DataTable("Examenes");
            // Configuracion de Tablas
            
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Dni", typeof(string));
            tabla.Columns.Add("Historia", typeof(string));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("ApellidoP", typeof(string));
            tabla.Columns.Add("ApellidoM", typeof(string));
            
            //ID DATA
            this.DGVPaciente.Columns[0].Visible = false;
            this.DGVPaciente.Columns[0].ReadOnly = true;
            this.DGVPaciente.Columns[0].DataPropertyName = "Id";
            //DNI
            this.DGVPaciente.Columns[1].ReadOnly = true;
            this.DGVPaciente.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[1].DataPropertyName = "Dni";
            //HISTORIA
            this.DGVPaciente.Columns[2].ReadOnly = true;
            this.DGVPaciente.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[2].DataPropertyName = "Historia";
            //NOMBRE
            this.DGVPaciente.Columns[3].ReadOnly = true;
            this.DGVPaciente.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[3].DataPropertyName = "Nombre";
            //APELLIDO PATERNO
            this.DGVPaciente.Columns[4].ReadOnly = true;
            this.DGVPaciente.Columns[4].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[4].DataPropertyName = "ApellidoP";
            //APELLIDO PATERNO
            this.DGVPaciente.Columns[5].ReadOnly = true;
            this.DGVPaciente.Columns[5].Resizable = DataGridViewTriState.False;
            this.DGVPaciente.Columns[5].DataPropertyName = "ApellidoM";

            bindingSource.DataSource = tabla;
            this.DGVPaciente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            this.DGVPaciente.SelectionChanged += DGVPaciente_SelectionChanged;
        }

        private void DGVPaciente_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DGVPaciente.SelectedRows.Count > 0)
            {
                BtnCargar.Enabled = true;
            }
            else BtnCargar.Enabled = false;
        }
    }
}
