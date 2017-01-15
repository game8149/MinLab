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
    public partial class PanelModificarMedico : UserControl
    {
        public PanelModificarMedico()
        {
            InitializeComponent();
            CampColegiatura.KeyPress += CampColegiatura_KeyPress;
            CampNombre.KeyUp += CampNombre_KeyUp;
            Campapellido1erno.KeyUp += CampPrimerApellido_KeyUp;
            Campapellido2erno.KeyUp += CampSegundoApellido_KeyUp;
            CampEspecialidad.KeyUp += CampEspecialidad_KeyUp;
        }


        private void CampSegundoApellido_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if(Char.IsLetter((char)e.KeyValue) || Char.IsWhiteSpace((char)e.KeyValue))
            {
                Campapellido2erno.Text = Campapellido2erno.Text.ToUpper();
                Campapellido2erno.SelectionStart = Campapellido2erno.TextLength;
            }
            else if (((Key)e.KeyValue == Key.Back) || ((Key)e.KeyValue == Key.Tab)) ;
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

        public void CargarDatos()
        {
            CampNombre.Text = ((PanelMedico)this.Parent).Perfil.Nombre;
            Campapellido1erno.Text = ((PanelMedico)this.Parent).Perfil.PrimerApellido;
            Campapellido2erno.Text = ((PanelMedico)this.Parent).Perfil.SegundoApellido;
            CampColegiatura.Text = ((PanelMedico)this.Parent).Perfil.Colegiatura;
            CampEspecialidad.Text = ((PanelMedico)this.Parent).Perfil.Especialidad;
            CheckBoxHabil.Checked = ((PanelMedico)this.Parent).Perfil.Habil;
        }
        
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Medico perfilTemp = new Medico();
            perfilTemp.IdData = ((PanelMedico)this.Parent).Perfil.IdData;
            perfilTemp.Nombre = CampNombre.Text;
            perfilTemp.PrimerApellido = Campapellido1erno.Text;
            perfilTemp.SegundoApellido = Campapellido2erno.Text;
            perfilTemp.Colegiatura = CampColegiatura.Text;
            perfilTemp.Especialidad = CampEspecialidad.Text;
            perfilTemp.Habil = CheckBoxHabil.Checked;
            try
            {
                BLMedico enlacePaciente = new BLMedico();
                enlacePaciente.ActualizarMedico(perfilTemp);
                ((PanelMedico)this.Parent).Perfil = perfilTemp;
                ((PanelMedico)this.Parent).CargarDatos();

                this.Visible = false;
                ((PanelMedico)this.Parent).Visible = true;
                this.Dispose();
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
        
    }
}
