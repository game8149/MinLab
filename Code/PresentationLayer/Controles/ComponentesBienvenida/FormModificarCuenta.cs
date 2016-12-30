using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesBienvenida
{
    public partial class FormModificarCuenta : Form
    {

        public Cuenta Cuenta { get; set; }

        public FormModificarCuenta()
        {
            InitializeComponent();
        }
        
        
        private void BtnCancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            LogicaCuenta logica = new LogicaCuenta();
            Cuenta cuentaTemp = new Cuenta();
            cuentaTemp.IdData = Cuenta.IdData;
            cuentaTemp.Nombre = CampNombre.Text;
            cuentaTemp.PrimerApellido = CampPrimerApellido.Text;
            cuentaTemp.SegundoApellido = CampSegundoApellido.Text;
            cuentaTemp.Dni = CampDni.Text;
            cuentaTemp.Especialidad = CampEspecialidad.Text;
            cuentaTemp.CodigoPro = CampCodigo.Text;
            cuentaTemp.Clave = "asdlel23ld";
            try
            {
                logica.ActualizarCuenta(cuentaTemp);
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }

        private void FormModificarCuenta_Load(object sender, EventArgs e)
        {
            CampDni.Text = Cuenta.Dni;
            CampNombre.Text=Cuenta.Nombre;
            CampPrimerApellido.Text=Cuenta.PrimerApellido;
            CampSegundoApellido.Text=Cuenta.SegundoApellido;
            CampEspecialidad.Text = Cuenta.Especialidad;
            CampCodigo.Text = Cuenta.CodigoPro;
        }
    }
}
