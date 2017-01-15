using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinLab.Code.LogicLayer;
using MinLab.Code.EntityLayer.EFicha;
using System.Windows.Input;

namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    public partial class PanelRegistrarMedico : UserControl
    {
        public PanelRegistrarMedico()
        {
            InitializeComponent();
            CampColegiatura.KeyPress += CampColegiatura_KeyPress;
            campNombre.KeyUp += CampNombre_KeyUp;
            CampPrimerApellido.KeyUp += CampPrimerApellido_KeyUp;
            CampSegundoApellido.KeyUp += CampSegundoApellido_KeyUp;
            CampEspecialidad.KeyUp += CampEspecialidad_KeyUp;
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
                campNombre.Text = campNombre.Text.ToUpper();
                campNombre.SelectionStart = campNombre.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }

        private void CampEspecialidad_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                CampEspecialidad.Text = CampEspecialidad.Text.ToUpper();
                CampEspecialidad.SelectionStart = CampEspecialidad.TextLength;
            }
            else if ((Key)e.KeyValue == Key.Back || (Key)e.KeyValue == Key.Tab) ;
            else e.SuppressKeyPress = true;
        }
        
        

        private void CampColegiatura_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == 8 || ((Key)e.KeyChar == Key.Back) || ((Key)e.KeyChar == Key.Tab) || ((Key)e.KeyChar == Key.Delete)))
                e.Handled = true;

        }

        public void limpiarCampos()
        {
            campNombre.Text = "";
            CampSegundoApellido.Text = "";
            CampPrimerApellido.Text = "";
            CampColegiatura.Text = "";
            CampEspecialidad.Text = "";
            CheckBoxHabil.Checked = false;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            BLMedico enlace = new BLMedico();
            try
            {
                Medico med = new Medico();
                med.Nombre = campNombre.Text;
                med.SegundoApellido = CampSegundoApellido.Text;
                med.PrimerApellido = CampPrimerApellido.Text;
                med.Colegiatura = CampColegiatura.Text;
                med.Especialidad = CampEspecialidad.Text;
                med.Habil = CheckBoxHabil.Checked;

                enlace.CrearMedico(med);
                MessageBox.Show("Registro Existoso");
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }



        private void CampColegiatura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
