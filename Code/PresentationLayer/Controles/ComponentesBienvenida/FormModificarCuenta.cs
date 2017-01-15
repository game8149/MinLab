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
using System.Windows.Input;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesBienvenida
{
    public partial class FormModificarCuenta : Form
    {

        public Cuenta Cuenta { get; set; }

        public FormModificarCuenta()
        {
            InitializeComponent();
            CampDni.KeyPress += CampDNI_KeyPress;
            CampNombre.KeyUp += CampNombre_KeyUp;
            CampPrimerApellido.KeyUp += CampPrimerApellido_KeyUp;
            CampSegundoApellido.KeyUp += CampSegundoApellido_KeyUp;
            CampCodigo.KeyPress += CampCodigo_KeyPress; 
            CampEspecialidad.KeyUp += CampEspecialidad_KeyUp;
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


        private void CampCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == 8 || ((Key)e.KeyChar == Key.Back) || ((Key)e.KeyChar == Key.Tab) || ((Key)e.KeyChar == Key.Delete)))
                e.Handled = true;
        }
        private void CampEspecialidad_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            CampEspecialidad.Text = CampEspecialidad.Text.ToUpper();
            CampEspecialidad.SelectionStart = CampEspecialidad.TextLength;
        }

        private void CampSegundoApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                CampSegundoApellido.Text = CampSegundoApellido.Text.ToUpper();
                CampSegundoApellido.SelectionStart = CampSegundoApellido.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampPrimerApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                CampPrimerApellido.Text = CampPrimerApellido.Text.ToUpper();
                CampPrimerApellido.SelectionStart = CampPrimerApellido.TextLength;
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
        

        private void CampDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == 8 || ((Key)e.KeyChar == Key.Back) || ((Key)e.KeyChar == Key.Tab) || ((Key)e.KeyChar == Key.Delete)))
                e.Handled = true;
        }

    }
}
