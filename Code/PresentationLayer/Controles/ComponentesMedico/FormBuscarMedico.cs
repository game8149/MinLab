using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{

    public partial class FormBuscarMedico : Form
    {
        private Dictionary<int, Medico> diccionario;


        public Medico Perfil { get; set; }


        //Lista de Resultados;

        //Componentes
        private DataTable tabla;
        private BindingSource bindingSource;

        

        public FormBuscarMedico()
        {
            InitializeComponent();
            InicializarTablaOrdenDetalle();
            BtnCargar.Enabled = false;
            this.FormClosing += FormBuscarMedico_FormClosing;
        }

        private void FormBuscarMedico_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel=true;
            this.Visible = false;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BLMedico enlace = new BLMedico();
            tabla.Clear();
            diccionario = enlace.ObtenerMedico(CampNombre.Text,Campapellido1erno.Text,Campapellido2erno.Text,CheckBoxHabil.Checked);
            this.SuspendLayout();
            foreach (int key in diccionario.Keys)
            {
                Medico med = diccionario[key];
                DataRow row = tabla.NewRow();
                row[0] = med.IdData;
                row[1] = med.Colegiatura;
                row[2] = BLMedico.FormatearNombre(med);
                row[3] = med.Especialidad;
                tabla.Rows.Add(row);
            }
            this.ResumeLayout(false);
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            int idData = Convert.ToInt32(this.DGVMedico.SelectedRows[0].Cells[0].Value);
            Perfil = diccionario[idData];
            this.Visible = false;
        }
        
        private void InicializarTablaOrdenDetalle()
        {
            bindingSource = new BindingSource();
            DGVMedico.DataSource = bindingSource;
            tabla = new DataTable("Examenes");
            // Configuracion de Tablas
            
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Colegiatura", typeof(string));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Especialidad", typeof(string));
            
            //ID DATA
            this.DGVMedico.Columns[0].Visible = false;
            this.DGVMedico.Columns[0].ReadOnly = true;
            this.DGVMedico.Columns[0].DataPropertyName = "Id";
            //Colegiatura
            this.DGVMedico.Columns[1].ReadOnly = true;
            this.DGVMedico.Columns[1].Resizable = DataGridViewTriState.False;
            this.DGVMedico.Columns[1].DataPropertyName = "Colegiatura";
            //Nombre
            this.DGVMedico.Columns[2].ReadOnly = true;
            this.DGVMedico.Columns[2].Resizable = DataGridViewTriState.False;
            this.DGVMedico.Columns[2].DataPropertyName = "Nombre";
            //Especialidad
            this.DGVMedico.Columns[3].ReadOnly = true;
            this.DGVMedico.Columns[3].Resizable = DataGridViewTriState.False;
            this.DGVMedico.Columns[3].DataPropertyName = "Especialidad";

            bindingSource.DataSource = tabla;
            this.DGVMedico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            this.DGVMedico.SelectionChanged += DGVPaciente_SelectionChanged;
        }

        private void DGVPaciente_SelectionChanged(object sender, EventArgs e)
        {
            if (this.DGVMedico.SelectedRows.Count > 0)
            {
                BtnCargar.Enabled = true;
            }
            else BtnCargar.Enabled = false;
        }
        
    }
}
