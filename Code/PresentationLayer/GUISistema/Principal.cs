using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.EntityLayer.FormatoImpresionComponentes;
using MinLab.Code.LogicLayer.LogicaControl;
using MinLab.Code.PresentationLayer.Controles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace MinLab.Code.PresentationLayer.GUISistema
{
    public partial class Principal : Form
    {
        public enum Vista{
            Cuenta,
            Paciente,
            Medico,
            Orden,
            Examen,
            Reporte
        }

        //Objetos Principales
        private bool modeLogout = false;

        //Objetos de Interfaz

        private Dictionary<Vista, Button> botones = new Dictionary<Vista, Button>();
        private Vista VistaActual;
        private FormAcerca formaAcerca = new FormAcerca();
        private UserControl ControlActual;


        //Constantes

        /// <summary>
        ///  
        /// </summary>
        /// 

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public Principal()
        {
            InitializeComponent();
            this.FormClosing += Principal_FormClosing;
            this.DoubleBuffered = true;
            IniciarInterfaz();
            this.KeyPress += Principal_KeyPress;
            this.Focus();
            SplitCont.VerticalScroll.Enabled = false;
        }
        
        private void Principal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
                e.Handled = true;
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!modeLogout)
            {
                var window = MessageBox.Show("¿Está seguro que desear cerrar la aplicación?", "Advertencia", MessageBoxButtons.YesNo);
                if (window == DialogResult.No) e.Cancel = true;
                else e.Cancel = false;
            }
        }
        
        public void IniciarInterfaz()
        {
            VistaActual = Vista.Cuenta;
            ControlActual = new ControlBienvenida();
            panelPrincipal.Controls.Add(ControlActual);

            botones.Add(Vista.Paciente, BtnPaciente);
            botones.Add(Vista.Orden, BtnOrden);
            botones.Add(Vista.Examen, BtnExamen);
            botones.Add(Vista.Reporte, BtnReporte);
            botones.Add(Vista.Medico, BtnMedico);
            
            RelocalizarUI();

            this.Show();
        }
        
        //Cambia el Color a los botones
        public void setBotonColorSelect(Vista id)
        {
            botones[id].BackColor = PaletaColor.BtnSelectBack;
            botones[id].FlatAppearance.BorderColor=PaletaColor.BtnSelectBorder;
            botones[id].FlatAppearance.MouseDownBackColor = PaletaColor.BtnSelectDown;
            botones[id].FlatAppearance.MouseOverBackColor = PaletaColor.BtnSelectOver;
        }

        public void setBotonColorOriginal(Vista id)
        {
            botones[id].BackColor = PaletaColor.BtnOriginalBack;
            botones[id].FlatAppearance.BorderColor = PaletaColor.BtnOriginalBorder;
            botones[id].FlatAppearance.MouseDownBackColor = PaletaColor.BtnOriginalDown;
            botones[id].FlatAppearance.MouseOverBackColor = PaletaColor.BtnOriginalOver;
        }
        
        private void RelocalizarUI()
        {
            this.SuspendLayout();
            this.panelOpciones.Location = new Point(0, 44);
            this.panelOpciones.Height = this.Height;

            this.panelBar.Width = this.Width;
            this.panelBar.Height = 44;

            //this.BtnLogout.Location = new Point(this.Width - (this.BtnLogout.Width + 30), this.BtnLogout.Location.Y);
            
            this.ResumeLayout(false);

        }

        private void BtnPaciente_Click(object sender, EventArgs e)
        {
            MostrarVista(Vista.Paciente);
        }
        
        private void BtnOrden_Click(object sender, EventArgs e)
        {
            MostrarVista(Vista.Orden);
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            MostrarVista(Vista.Reporte);
        }
        
        
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            MostrarVista(Vista.Cuenta);
        }
        
        private void MostrarVista(Vista vista)
        {
            if (VistaActual != vista)
            {
                if(VistaActual != Vista.Cuenta)
                    setBotonColorOriginal(VistaActual);
                
                panelPrincipal.Controls.Remove(ControlActual);
                ControlActual.Dispose();

                VistaActual = vista;

                switch (VistaActual)
                {
                    case Vista.Cuenta:
                        ControlActual = new ControlBienvenida();
                        break;
                    case Vista.Paciente:
                        ControlActual = new ControlPaciente();
                        break;
                    case Vista.Medico:
                        ControlActual = new ControlMedico();
                        break;
                    case Vista.Orden:
                        ControlActual = new ControlOrden();
                        break;
                    case Vista.Examen:
                        ControlActual = new ControlExamen();
                        break;
                    case Vista.Reporte:
                        ControlActual = new ControlReporte();
                        break;
                }

                if(VistaActual!=Vista.Cuenta)
                    setBotonColorSelect(VistaActual);

                panelPrincipal.Controls.Add(ControlActual);
            }
        }


        private void BtnExamen_Click(object sender, EventArgs e)
        {
            MostrarVista(Vista.Examen);
        }

        private void BtnAcerca_Click(object sender, EventArgs e)
        {
            formaAcerca.ShowDialog();
        }
        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            panelPrincipal.SuspendLayout();

            if (CheckBoxMenu.Checked)
                SplitCont.SplitterDistance = 146;
            else
                SplitCont.SplitterDistance = 40;
            panelPrincipal.ResumeLayout();
            panelPrincipal.Update();
            SplitCont.Update();
            this.ResumeLayout();
        }

        private void BtnMedico_Click(object sender, EventArgs e)
        {
            MostrarVista(Vista.Medico);
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            modeLogout = true;
            this.Close();
        }
    }
}
