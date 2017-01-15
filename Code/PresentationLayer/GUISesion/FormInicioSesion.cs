using MinLab.Code.LogicLayer.LogicaControl;
using MinLab.Code.PresentationLayer.GUISesion;
using MinLab.Code.PresentationLayer.GUISistema;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Input;

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
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            LabelVersion.Text = fvi.FileVersion;
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
            if (!Char.IsNumber(e.KeyChar)&& !(e.KeyChar==8||((Key)e.KeyChar == Key.Back) || ((Key)e.KeyChar == Key.Tab) || ((Key)e.KeyChar == Key.Delete))) 
                e.Handled = true;
           
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            FormConfigServer registro = new FormConfigServer();
            registro.ShowDialog();
            this.Visible = true;
        }
    }
}
