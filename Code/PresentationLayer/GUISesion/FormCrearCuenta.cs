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

namespace MinLab.Code.PresentationLayer.GUISesion
{
    public partial class FormCrearCuenta : Form
    {
        
        public FormCrearCuenta()
        {
            InitializeComponent();
        }
        
        private void BtnCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void BtnRegistra_Click(object sender, EventArgs e)
        {
            LogicaCuenta oLCuenta = new LogicaCuenta();
            Cuenta cuenta = new Cuenta();
            cuenta.Nombre = CampNombre.Text;
            cuenta.PrimerApellido = CampPrimerApellido.Text;
            cuenta.SegundoApellido = CampSegundoApellido.Text;
            cuenta.Clave = CampClave.Text.Trim(' ');
            cuenta.Dni = CampDni.Text;
            cuenta.Especialidad = CampEspecialidad.Text;
            cuenta.CodigoPro = CampCodigo.Text;
            try
            {
                if (oLCuenta.CrearCuenta(cuenta, CampAutorizacion.Text))
                {
                    MessageBox.Show("Registro Finalizado", "Mensaje");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia");
            }
        }
    }
}
