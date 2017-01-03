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

namespace MinLab.Code.PresentationLayer.Controles.ComponentesPaciente
{
    public partial class PanelModificarPaciente : UserControl
    {
        public PanelModificarPaciente()
        {
            InitializeComponent();
            ComboSexo.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().TipoSexo, null);
            ComboSexo.DisplayMember = "Value";
            ComboSexo.ValueMember = "Key";

            ComboBoxDistrito.DataSource = new BindingSource(BLUbicacion.ObtenerListaDistritos(), null);
            ComboBoxDistrito.DisplayMember = "Value";
            ComboBoxDistrito.ValueMember = "Key";
            
            ComboBoxDistrito.SelectedValueChanged += ComboBoxDistrito_SelectedValueChanged;

        }

        public Paciente Perfil
        {
            set;
            get;
        }
        

        private void ComboBoxDistrito_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue), null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";
        }

        public void LlenarDatosFormulario()
        {
            CampNombre.Text = Perfil.Nombre;
            Campapellido1erno.Text = Perfil.PrimerApellido;
            Campapellido2erno.Text = Perfil.SegundoApellido;
            CampDNI.Text = Perfil.Dni;
            CampHistoria.Text = Perfil.Historia;
            ComboSexo.SelectedValue = (int)Perfil.Sexo;
            CampFecha.Value = Perfil.FechaNacimiento;
            CampDireccion.Text = Perfil.Direccion;

            ComboBoxDistrito.SelectedValue = Perfil.IdDistrito;

            ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue), null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";

            ComboBoxSector.SelectedValue = Perfil.IdSector;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BLPaciente enlacePaciente = new BLPaciente();
                enlacePaciente.ActualizarPaciente(Perfil);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {

            Paciente perfilTemp = new Paciente();

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
                BLPaciente enlacePaciente = new BLPaciente();
                enlacePaciente.ActualizarPaciente(Perfil);
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
