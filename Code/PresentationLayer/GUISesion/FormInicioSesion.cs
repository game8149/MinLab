using MinLab.Code.LogicLayer.LogicaControl;
using MinLab.Code.PresentationLayer.GUISesion;
using MinLab.Code.PresentationLayer.GUISistema;
using System;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer
{

    public partial class FormInicioSesion : Form
    {

        public Principal Formulario { get; set; }

        public FormInicioSesion()
        {
            InitializeComponent();
            this.CampDni.KeyPress += CampDni_KeyPress;
            this.CampClave.KeyPress += CampClave_KeyPress;
            CampDni.Focus();
        }

        private void CampClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnInicia.PerformClick();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void CampDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CampClave.Focus();
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }
        

        //ACCION QUE PERMITE INICIAR SESION
        //LLAMA FUNCIONES DEL SISTEMA INTERNO
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            LogicControlSistema enlaceControlSistema = new LogicControlSistema();
            try
            {
                if(enlaceControlSistema.IniciarSesion(CampDni.Text, CampClave.Text.Trim(' ')))              
                    this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //ACCION QUE PERMITE REGISTRAR MAS CUENTAS
        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            FormCrearCuenta registro = new FormCrearCuenta();
            registro.ShowDialog();
            this.Visible = true;
        }

        private void FormInicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
