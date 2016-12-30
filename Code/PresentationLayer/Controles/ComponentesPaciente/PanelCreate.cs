using System;
using System.Windows.Forms;
using MinLab.Code.LogicLayer.LogicaPaciente;
using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using System.Collections.Generic;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class PanelCrearPaciente : UserControl
    {
        public PanelCrearPaciente()
        {
            InitializeComponent();
            comboSexo.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().TipoSexo, null);
            comboSexo.DisplayMember = "Value";
            comboSexo.ValueMember = "Key";

            Dictionary<int, string> ex = BLUbicacion.ObtenerListaDistritos();
            ComboBoxDistrito.DataSource = new BindingSource(ex, null);
            ComboBoxDistrito.DisplayMember = "Value";
            ComboBoxDistrito.ValueMember = "Key";

            ComboBoxDistrito.SelectedValueChanged += ComboBoxDistrito_SelectedValueChanged;
            foreach (int key in ex.Keys)
            {
                ComboBoxDistrito.SelectedValue = key;
                break;
            }

            Dictionary<int, string> ex2 = BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue);
            ComboBoxSector.DataSource = new BindingSource(ex2, null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";
            foreach (int key in ex2.Keys)
            {
                ComboBoxSector.SelectedValue = key;
                break;
            }
        }

        private void ComboBoxDistrito_SelectedValueChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> ex = BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue);
            ComboBoxSector.DataSource = new BindingSource(ex, null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";
            foreach (int key in ex.Keys)
            {
                ComboBoxSector.SelectedValue = key;
                break;
            }
        }
        

        public void limpiarCampos()
        {
            comboSexo.SelectedIndex = 0;
            campNombre.Text = "";
            campapellido2erno.Text = "";
            campapellido1erno.Text = "";
            campHistoria.Text = "";
            campDNI.Text = "";
            campFecha.Value = DateTime.Now;
            campDireccion.Text = "";
        }
        

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            BLPaciente enlace = new BLPaciente();
            try
            {
                Paciente paciente = new Paciente();
                paciente.Sexo = (Sexo)comboSexo.SelectedIndex;
                paciente.Nombre = campNombre.Text;
                paciente.SegundoApellido = campapellido2erno.Text;
                paciente.PrimerApellido = campapellido1erno.Text;
                paciente.Historia = campHistoria.Text;
                paciente.FechaNacimiento = campFecha.Value;
                paciente.Dni = campDNI.Text;
                paciente.Direccion = campDireccion.Text;
                paciente.IdDistrito = (int)ComboBoxDistrito.SelectedValue;
                paciente.IdSector = (int)ComboBoxSector.SelectedValue;
                enlace.CrearPaciente(paciente);
                MessageBox.Show("Registro Existoso");
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }

        private void ComboBoxDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
