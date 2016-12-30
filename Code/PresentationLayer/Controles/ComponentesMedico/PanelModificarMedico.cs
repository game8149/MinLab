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

namespace MinLab.Code.PresentationLayer.Controles.ComponentesMedico
{
    public partial class PanelModificarMedico : UserControl
    {
        public PanelModificarMedico()
        {
            InitializeComponent();
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
