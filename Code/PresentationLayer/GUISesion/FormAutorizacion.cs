using MinLab.Code.LogicLayer.LogicaControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.GUISesion
{
    public partial class FormAutorizacion : Form
    {
        
        public FormAutorizacion()
        {
            InitializeComponent();
            this.FormClosing += FormAutorizacion_FormClosing;
        }

        private void FormAutorizacion_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Visible = true;
            e.Cancel = false;
        }

        private void BtnInicia_Click(object sender, EventArgs e)
        {
            BLControlSistema enlace = new BLControlSistema();
            try
            {
                enlace.AperturaAutorizacion(CampDni.Text, CampClave.Text);
                this.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Acceso Denegado");
            }
            
        }

    }
}
