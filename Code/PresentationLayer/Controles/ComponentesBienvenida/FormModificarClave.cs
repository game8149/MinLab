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

namespace MinLab.Code.PresentationLayer.Controles.ComponentesBienvenida
{
    public partial class FormModificarClave : Form
    {

        public Cuenta Cuenta { get; set; }

        public FormModificarClave()
        {
            InitializeComponent();
        }
        
        private void BtnCancelar(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            LogicaCuenta oLCuenta = new LogicaCuenta();
            try
            {
                oLCuenta.ActualizarClave(Cuenta,CampNueva.Text,CampAntigua.Text);

                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
        
    }
}
