using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.Controles.ComponentesOrden;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class ControlOrden : UserControl
    {

        UserControl control;
        

        public ControlOrden()
        {
            InitializeComponent();
            this.KeyPress += ControlOrden_KeyPress;
            ModeBtnFuncion(true);
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

        public void ModeBtnFuncion(bool mode)
        {
            BtnAbrir.Visible = mode;
            BtnCerrar.Visible = !mode;
            BtnNuevo.Visible = mode;
        }


        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            control = new PanelNuevaOrden();
            ModeBtnFuncion(false);
            control.Parent = this;
            PanelTrabajo.Controls.Add(control);
            control.Show();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            Orden orden = null;
            Paciente perfil = null;

            FormBuscarOrden form = new FormBuscarOrden();
            form.ShowDialog();
            orden = form.Orden;
            perfil = form.Perfil;
            if (orden != null && perfil!=null)
            {
                control = new PanelFichaOrden();
                control.Parent = this;
                ((PanelFichaOrden)control).Perfil = perfil;
                ((PanelFichaOrden)control).Orden = orden;
                ModeBtnFuncion(false);
                PanelTrabajo.Controls.Add(control);
                ((PanelFichaOrden)control).CargarDatos();
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
