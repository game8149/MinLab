using System;
using System.Windows.Forms;
using MinLab.Code.LogicLayer.LogicaPaciente;
using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;

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
        }

        private void PanelCreate_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

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
                paciente.Genero = comboSexo.SelectedIndex;
                paciente.Nombre = campNombre.Text;
                paciente.SegundoApellido = campapellido2erno.Text;
                paciente.PrimerApellido = campapellido1erno.Text;
                paciente.Historia = campHistoria.Text;
                paciente.FechaNacimiento = campFecha.Value;
                paciente.Dni = campDNI.Text;
                paciente.Direccion = campDireccion.Text;

                enlace.CrearPaciente(paciente);
                MessageBox.Show("Registro Existoso");
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
