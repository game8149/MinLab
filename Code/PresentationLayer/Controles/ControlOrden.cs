using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.Controles.ComponentesOrden;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class ControlOrden : UserControl
    {

        private Dictionary<int, UserControl> controlesPanel;
        private int IdPanelActual=0;

        public ControlOrden()
        {
            InitializeComponent();
            PanelFichaOrden panelOrden = new PanelFichaOrden();
            PanelNuevaOrden panelNuevaOrden = new PanelNuevaOrden();
            panelOrden.Location = new Point(0,0);
            panelNuevaOrden.Location = new Point(0,0);
            
            controlesPanel = new Dictionary<int, UserControl>();
            controlesPanel.Add(1,panelNuevaOrden);
            controlesPanel.Add(2,panelOrden);
            this.KeyPress += ControlOrden_KeyPress;
        }

        private void ControlOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                MessageBox.Show("Form.KeyPress: '" +
                    e.KeyChar.ToString() + "' pressed.");

                switch (e.KeyChar)
                {
                    case (char)49:
                    case (char)52:
                    case (char)55:
                        MessageBox.Show("Form.KeyPress: '" +
                            e.KeyChar.ToString() + "' consumed.");
                        e.Handled = true;
                        break;
                }
            }
        }

        private void ControlOrden_Load(object sender, EventArgs e)
        {

        }

        private void BtnCrearOrden_Click(object sender, EventArgs e)
        {
            IdPanelActual = 1;
            this.PanelTrabajo.Controls.Add(controlesPanel[IdPanelActual]);
            this.ActivarHojaTrabajo();
        }

        private void BtnBuscarPaciente_Click(object sender, EventArgs e)
        {
            FormBuscarOrden formOrden = new FormBuscarOrden();
            formOrden.ShowDialog();
            if (formOrden.Perfil!=null&&formOrden.Orden != null)
            {
                IdPanelActual = 2;
                (controlesPanel[IdPanelActual]) = new PanelFichaOrden();
                ((PanelFichaOrden)controlesPanel[IdPanelActual]).Orden = formOrden.Orden;
                ((PanelFichaOrden)controlesPanel[IdPanelActual]).Perfil = formOrden.Perfil;
                this.PanelTrabajo.Controls.Add(controlesPanel[IdPanelActual]);
                ((PanelFichaOrden)controlesPanel[IdPanelActual]).InicializarDatosFormulario();
                ActivarHojaTrabajo();
            }
            formOrden.Dispose();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.PanelTrabajo.Controls.Remove(controlesPanel[IdPanelActual]);
            this.DesactivarHojaTrabajo();
            IdPanelActual = 0;
        }


        private void ActivarHojaTrabajo()
        {
            BtnClose.Visible = true;
            PanelAcciones.Enabled = false;
        }

        private void DesactivarHojaTrabajo()
        {
            BtnClose.Visible = false;
            PanelAcciones.Enabled = true;
        }

    }
}
