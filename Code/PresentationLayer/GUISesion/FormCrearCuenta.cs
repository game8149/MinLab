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

namespace MinLab.Code.PresentationLayer.GUISesion
{
    public partial class FormCrearCuenta : Form
    {
        
        public FormCrearCuenta()
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
        private void BtnRegistra_Click(object sender, EventArgs e)
        {
            LogicaCuenta oLCuenta = new LogicaCuenta();
            Cuenta cuenta = new Cuenta();
            cuenta.Nombre = CampNombre.Text;
            cuenta.PrimerApellido = CampPrimerApellido.Text;
            cuenta.SegundoApellido = CampSegundoApellido.Text;
            cuenta.Clave = CampClave.Text.Trim(' ');
            cuenta.Dni = CampDni.Text;
            cuenta.Especialidad = CampEspecialidad.Text;
            cuenta.CodigoPro = CampCodigo.Text;
            try
            {
                if (oLCuenta.CrearCuenta(cuenta, CampAutorizacion.Text))
                {
                    MessageBox.Show("Registro Finalizado", "Mensaje");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
