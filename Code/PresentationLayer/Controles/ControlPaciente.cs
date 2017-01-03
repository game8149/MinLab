using System;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.Controles;
using MinLab.Code.PresentationLayer.Controles.GUIBuscarPaciente;
using System.Collections.Generic;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer
{
    public partial class ControlPaciente : UserControl
    {

        UserControl control;

        public ControlPaciente()
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
            control = new PanelCrearPaciente();
            ModeBtnFuncion(false);
            PanelTrabajo.Controls.Add(control);
            control.Show();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            Paciente pac = null;
            FormBuscarPaciente form = new FormBuscarPaciente();
            form.ShowDialog();
            pac = form.Perfil;
            if (pac != null)
            {
                control = new PanelPerfil();
                control.Parent = this;
                ((PanelPerfil)control).Perfil = pac;
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

    }
}
