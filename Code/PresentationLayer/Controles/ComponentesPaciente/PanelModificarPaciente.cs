using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System.Windows.Input;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesPaciente
{
    public partial class PanelModificarPaciente : UserControl
    {
        public PanelModificarPaciente()
        {
            InitializeComponent();

            ComboSexo.DataSource = new BindingSource(DataEstaticaGeneral.SexoTipos, null);
            ComboSexo.DisplayMember = "Value";
            ComboSexo.ValueMember = "Key";

            ComboBoxDistrito.DataSource = new BindingSource(BLUbicacion.ObtenerListaDistritos(), null);
            ComboBoxDistrito.DisplayMember = "Value";
            ComboBoxDistrito.ValueMember = "Key";

            ComboBoxDistrito.SelectionChangeCommitted += ComboBoxDistrito_SelectionChangeCommitted;
            
            CampDNI.KeyPress += CampDNI_KeyPress;
            CampNombre.KeyUp += CampNombre_KeyUp;
            Campapellido1erno.KeyUp += CampPrimerApellido_KeyUp;
            Campapellido2erno.KeyUp += CampSegundoApellido_KeyUp;
            CampHistoria.KeyUp += CampHistoria_KeyUp;
            CampDireccion.KeyUp += CampDireccion_KeyUp;
        }

        private void CampDireccion_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            CampDireccion.Text = CampDireccion.Text.ToUpper();
            CampDireccion.SelectionStart = CampDireccion.TextLength;
        }

        private void CampSegundoApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                Campapellido2erno.Text = Campapellido2erno.Text.ToUpper();
                Campapellido2erno.SelectionStart = Campapellido2erno.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampPrimerApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                Campapellido1erno.Text = Campapellido1erno.Text.ToUpper();
                Campapellido1erno.SelectionStart = Campapellido1erno.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampNombre_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                CampNombre.Text = CampNombre.Text.ToUpper();
                CampNombre.SelectionStart = CampNombre.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampHistoria_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            CampHistoria.Text = CampHistoria.Text.ToUpper();
            CampHistoria.SelectionStart = CampHistoria.TextLength;
        }
        
        private void CampDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == 8 || ((Key)e.KeyChar == Key.Back) || ((Key)e.KeyChar == Key.Tab) || ((Key)e.KeyChar == Key.Delete)))
                e.Handled = true;
        }
        
        private void ComboBoxDistrito_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue), null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";
        }
        

        public void CargarDatos()
        {

            CampNombre.Text = ((PanelPerfil)this.Parent).Perfil.Nombre;
            Campapellido1erno.Text = ((PanelPerfil)this.Parent).Perfil.PrimerApellido;
            Campapellido2erno.Text = ((PanelPerfil)this.Parent).Perfil.SegundoApellido;
            CampDNI.Text = ((PanelPerfil)this.Parent).Perfil.Dni;
            CampHistoria.Text = ((PanelPerfil)this.Parent).Perfil.Historia;
            ComboSexo.SelectedValue = (int)((PanelPerfil)this.Parent).Perfil.Sexo;
            CampFecha.Value = ((PanelPerfil)this.Parent).Perfil.FechaNacimiento;
            CampDireccion.Text = ((PanelPerfil)this.Parent).Perfil.Direccion;

            ComboBoxDistrito.SelectedValue = ((PanelPerfil)this.Parent).Perfil.IdDistrito;

            ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue), null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";

            ComboBoxSector.SelectedValue = ((PanelPerfil)this.Parent).Perfil.IdSector;
        }
        
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {

            Paciente perfilTemp = new Paciente();
            perfilTemp.IdData = ((PanelPerfil)this.Parent).Perfil.IdData;
            perfilTemp.Dni = CampDNI.Text;
            perfilTemp.Direccion = CampDireccion.Text;
            perfilTemp.Sexo = (Sexo)ComboSexo.SelectedValue;
            perfilTemp.Historia = CampHistoria.Text;
            perfilTemp.Nombre = CampNombre.Text;
            perfilTemp.PrimerApellido = Campapellido1erno.Text;
            perfilTemp.SegundoApellido = Campapellido2erno.Text;
            perfilTemp.FechaNacimiento = CampFecha.Value;
            perfilTemp.IdDistrito = (int)ComboBoxDistrito.SelectedValue;
            perfilTemp.IdSector = (int)ComboBoxSector.SelectedValue;

            try
            {
                LogicaPaciente enlacePaciente = new LogicaPaciente();
                enlacePaciente.ActualizarPaciente(perfilTemp);
                ((PanelPerfil)this.Parent).Perfil = perfilTemp;
                ((PanelPerfil)this.Parent).CargarDatos();

                this.Visible = false;
                ((PanelPerfil)this.Parent).Visible = true;
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
