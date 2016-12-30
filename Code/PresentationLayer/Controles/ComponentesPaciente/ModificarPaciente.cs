using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesPaciente
{
    public partial class FormModificarPaciente : Form
    {

        private Paciente perfil;


        public Paciente Perfil
        {
            set
            {
                this.perfil = value;
            }
            get
            {
                return this.perfil;
            }
        }

        public FormModificarPaciente()
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

        private void ComboBoxDistrito_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxSector.DataSource = new BindingSource(BLUbicacion.ObtenerListaSectores((int)ComboBoxDistrito.SelectedValue), null);
            ComboBoxSector.DisplayMember = "Value";
            ComboBoxSector.ValueMember = "Key";
        }

        public void LlenarDatosFormulario()
        {
            CampNombre.Text = perfil.Nombre;
            Campapellido1erno.Text = perfil.PrimerApellido;
            Campapellido2erno.Text=perfil.SegundoApellido;
            CampDNI.Text = perfil.Dni;
            CampHistoria.Text = perfil.Historia;
            ComboSexo.SelectedValue = (int)perfil.Sexo;
            CampFecha.Value = perfil.FechaNacimiento;
            CampDireccion.Text = perfil.Direccion;

            ComboBoxDistrito.SelectedValue = Perfil.IdDistrito;
            ComboBoxSector.SelectedValue= Perfil.IdSector;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Perfil.Dni = CampDNI.Text;
            Perfil.Direccion = CampDireccion.Text;
            Perfil.Sexo = (Sexo)ComboSexo.SelectedValue;
            Perfil.Historia = CampHistoria.Text;
            Perfil.Nombre = CampNombre.Text;
            Perfil.PrimerApellido = Campapellido1erno.Text;
            Perfil.SegundoApellido = Campapellido2erno.Text;
            Perfil.FechaNacimiento = CampFecha.Value;
            Perfil.IdDistrito = (int)ComboBoxDistrito.SelectedValue;
            Perfil.IdSector = (int)ComboBoxSector.SelectedValue;

            try
            {
                BLPaciente enlacePaciente = new BLPaciente();
                enlacePaciente.ActualizarPaciente(Perfil);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
