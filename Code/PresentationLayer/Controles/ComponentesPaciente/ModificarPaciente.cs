using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer;
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
        }


        public void LlenarDatosFormulario()
        {
            CampNombre.Text = perfil.Nombre;
            Campapellido1erno.Text = perfil.PrimerApellido;
            Campapellido2erno.Text=perfil.SegundoApellido;
            CampDNI.Text = perfil.Dni;
            CampHistoria.Text = perfil.Historia;
            ComboSexo.SelectedValue =perfil.Genero;
            CampFecha.Value = perfil.FechaNacimiento;
            CampDireccion.Text = perfil.Direccion;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Perfil.Dni = CampDNI.Text;
            Perfil.Direccion = CampDireccion.Text;
            Perfil.Genero = ComboSexo.SelectedIndex;
            Perfil.Historia = CampHistoria.Text;
            Perfil.Nombre = CampNombre.Text;
            Perfil.PrimerApellido = Campapellido1erno.Text;
            Perfil.SegundoApellido = Campapellido2erno.Text;
            Perfil.FechaNacimiento = CampFecha.Value;
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
