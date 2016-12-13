﻿using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer;
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
        //Objetos Principales
        

        //Objetos de Interfaz
        private Dictionary<int,UserControl> controles = new Dictionary<int, UserControl>();
        private Dictionary<int, Button> botones = new Dictionary<int, Button>();
        private int idControlActual;
        private FormAcerca formaAcerca = new FormAcerca();


        //Constantes

        /// <summary>
        ///  
        /// </summary>
        /// 

        public Principal()
        {
            InitializeComponent();
            this.FormClosing += Principal_FormClosing;
            this.DoubleBuffered = true;
            IniciarInterfaz();
            this.KeyPress += Principal_KeyPress;
            this.Focus();
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
            var window = MessageBox.Show("Está seguro que desear cerrar la aplicación?","Advertencia",MessageBoxButtons.YesNo);
            if (window == DialogResult.No) e.Cancel = true;
            else e.Cancel = false;
        }
        
        public void IniciarInterfaz()
        {
            controles.Clear();
            botones.Clear();

            idControlActual = 1;

            ControlBienvenida bienvenida = new ControlBienvenida();
            ControlPaciente paciente = new ControlPaciente();
            ControlOrden orden = new ControlOrden();
            ControlExamen examen = new ControlExamen();
            ControlReporte reporte = new ControlReporte();

            controles.Add(1, bienvenida);
            controles.Add(2, paciente);
            controles.Add(3, orden);
            controles.Add(4, examen);
            controles.Add(5, reporte);

            botones.Add(1, BtnInicio);
            botones.Add(2, BtnPaciente);
            botones.Add(3, BtnOrden);
            botones.Add(4, BtnExamen);
            botones.Add(5, BtnReporte);
            panelPrincipal.Controls.Add(controles[idControlActual]);
            
            RelocalizarUI();
            BLControlSistema enlaceControlSistema = new BLControlSistema();
            Cuenta cuenta = enlaceControlSistema.GetCuentaLogin();
            campUser.Text = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cuenta.Nombre + " " + cuenta.Apellidos);
            this.Show();
        }
        
        //Cambia el Color a los botones
        public void setBotonColorSelect(int id)
        {
            botones[id].BackColor = PaletaColor.BtnSelectBack;
            botones[id].FlatAppearance.BorderColor=PaletaColor.BtnSelectBorder;
            botones[id].FlatAppearance.MouseDownBackColor = PaletaColor.BtnSelectDown;
            botones[id].FlatAppearance.MouseOverBackColor = PaletaColor.BtnSelectOver;
        }

        public void setBotonColorOriginal(int id)
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

            this.BtnLogout.Location = new Point(this.Width - (this.BtnLogout.Width + 30), this.BtnLogout.Location.Y);
            this.campUser.Location = new Point(this.Width - (this.BtnLogout.Width + this.campUser.Width + 30), this.campUser.Location.Y);
            
            this.ResumeLayout(false);

        }

        private void BtnPaciente_Click(object sender, EventArgs e)
        {
            //ID: 2
            removeControl(idControlActual);
            idControlActual = 2;
            addControl(idControlActual);            
        }
        
        private void BtnOrden_Click(object sender, EventArgs e)
        {
            //ID: 3
            removeControl(idControlActual);
            idControlActual = 3;
            addControl(idControlActual);
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            removeControl(idControlActual);
            idControlActual = 5;
            addControl(idControlActual);
        }
        
        
        private void BtnInicio_Click(object sender, EventArgs e)
        {
            //ID: 1
            removeControl(idControlActual);
            idControlActual = 1;
            addControl(idControlActual);

        }
        
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        
        public void removeControl(int id)
        {
            setBotonColorOriginal(id);
            panelPrincipal.Controls.Remove(controles[id]);
        }

        public void addControl(int id)
        {
            setBotonColorSelect(idControlActual);

            panelPrincipal.SuspendLayout();
            controles[id].SuspendLayout();

            panelPrincipal.Controls.Add(controles[id]);

            controles[id].Size = panelPrincipal.Size;

            controles[id].ResumeLayout();
            controles[id].PerformLayout();
            panelPrincipal.ResumeLayout();
            panelPrincipal.PerformLayout();
        }

        private void BtnExamen_Click(object sender, EventArgs e)
        {
            removeControl(idControlActual);
            idControlActual = 4;
            addControl(idControlActual);
        }

        private void BtnAcerca_Click(object sender, EventArgs e)
        {
            formaAcerca.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}