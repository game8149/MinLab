using System;
using System.Windows.Forms;
using MinLab.Code.LogicLayer.LogicaPaciente;
using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using System.Collections.Generic;
using System.Windows.Input;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class PanelCrearPaciente : UserControl
    {
        public PanelCrearPaciente()
        {
            InitializeComponent();
            comboSexo.DataSource = new BindingSource(DataEstaticaGeneral.SexoTipos, null);
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


            campDNI.KeyPress += CampDNI_KeyPress;
            campNombre.KeyUp += CampNombre_KeyUp;
            campapellido1erno.KeyUp += CampPrimerApellido_KeyUp;
            campapellido2erno.KeyUp += CampSegundoApellido_KeyUp;
            campHistoria.KeyUp += CampHistoria_KeyUp;
            campDireccion.KeyUp += CampDireccion_KeyUp;
        }


        private void CampSegundoApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                campapellido2erno.Text = campapellido2erno.Text.ToUpper();
                campapellido2erno.SelectionStart = campapellido2erno.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampPrimerApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                campapellido1erno.Text = campapellido1erno.Text.ToUpper();
                campapellido1erno.SelectionStart = campapellido1erno.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampNombre_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                campNombre.Text = campNombre.Text.ToUpper();
                campNombre.SelectionStart = campNombre.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampDireccion_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            campDireccion.Text = campDireccion.Text.ToUpper();
            campDireccion.SelectionStart = campDireccion.TextLength;
        }

        private void CampHistoria_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            campHistoria.Text = campHistoria.Text.ToUpper();
            campHistoria.SelectionStart = campHistoria.TextLength;
        }

        private void CampDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == 8 || ((Key)e.KeyChar == Key.Back) || ((Key)e.KeyChar == Key.Tab) || ((Key)e.KeyChar == Key.Delete)))
                e.Handled = true;
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
            LogicaPaciente enlace = new LogicaPaciente();
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
