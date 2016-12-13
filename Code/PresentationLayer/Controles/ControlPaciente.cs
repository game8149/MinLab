using System;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.Controles;
using MinLab.Code.PresentationLayer.Controles.GUIBuscarPaciente;
using System.Collections.Generic;

namespace MinLab.Code.PresentationLayer
{
    public partial class ControlPaciente : UserControl
    {

        private int IdPanelActual=0;
        Dictionary<int, UserControl> controlesPanel;
   
        public ControlPaciente()
        {
            InitializeComponent();
            controlesPanel = new Dictionary<int, UserControl>();
            controlesPanel.Add(1,new PanelCrearPaciente());
            controlesPanel.Add(2, new PanelPerfil());
        }
        

        private void BtnCrearPaciente_Click_1(object sender, EventArgs e)
        {
            IdPanelActual = 1;

            this.PanelTrabajo.Controls.Add(controlesPanel[IdPanelActual]);
            controlesPanel[IdPanelActual].Location = new System.Drawing.Point(0,0);
            ActivarHojaTrabajo();
        }

        private void BtnBuscarPaciente_Click_1(object sender, EventArgs e)
        {

            IdPanelActual = 2;
            FormBuscarPaciente VentanaBusqueda = new FormBuscarPaciente();
            VentanaBusqueda.ShowDialog();
            if (VentanaBusqueda.Perfil != null)
            {
                controlesPanel[IdPanelActual]=new PanelPerfil();
                ((PanelPerfil)controlesPanel[IdPanelActual]).Perfil = VentanaBusqueda.Perfil;
                this.PanelTrabajo.Controls.Add(controlesPanel[IdPanelActual]);
                ActivarHojaTrabajo();
            }
            VentanaBusqueda.Close();
            
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            PanelTrabajo.Controls.Remove(controlesPanel[IdPanelActual]);
            DesactivarHojaTrabajo();
        }

        private void ActivarHojaTrabajo()
        {
            BtnClose.Visible = true;
            PanelAcciones.Enabled = false;
        }

        private void DesactivarHojaTrabajo()
        {
            IdPanelActual = 0;
            BtnClose.Visible = false;
            PanelAcciones.Enabled = true;
        }

    }
}
