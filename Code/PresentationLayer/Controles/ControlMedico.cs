using System;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.Controles;
using MinLab.Code.PresentationLayer.Controles.GUIBuscarPaciente;
using System.Collections.Generic;
using MinLab.Code.PresentationLayer.Controles.ComponentesMedico;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class ControlMedico : UserControl
    {
        
        UserControl control;

        public ControlMedico()
        {
            InitializeComponent();
            ModeBtnFuncion(true);
        }
        

        public void ModeBtnFuncion(bool mode)
        {
            BtnAbrir.Visible = mode;
            BtnCerrar.Visible = !mode;
            BtnNuevo.Visible = mode;
        }
        

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            control = new PanelRegistrarMedico();
            ModeBtnFuncion(false);
            PanelTrabajo.Controls.Add(control);
            control.Show();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            Medico med = null;
            FormBuscarMedico form = new FormBuscarMedico();
            form.ShowDialog();
            med = form.Perfil;
            if (med != null)
            {
                control = new PanelMedico();
                control.Parent = this;
                ((PanelMedico)control).Perfil = med;
                ModeBtnFuncion(false);
                PanelTrabajo.Controls.Add(control);
                control.Show();
            }
            form.Dispose();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            control.Dispose();
            ModeBtnFuncion(true);
        }

        private void PanelTrabajo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
