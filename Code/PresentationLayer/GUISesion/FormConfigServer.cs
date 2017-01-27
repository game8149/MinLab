﻿using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.ControlSistemaInterno.Configuracion;
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
    public partial class FormConfigServer : Form
    {
        
        public FormConfigServer()
        {
            InitializeComponent();
            this.FormClosing += FormConfigServer_FormClosing;

            CampConexion.Text = ConfiguracionSystem.ConexionConfig;
        }

        private void FormConfigServer_FormClosing(object sender, FormClosingEventArgs e)
        {

            this.Visible = true;
            e.Cancel = false;
        }

        private void BtnInicia_Click(object sender, EventArgs e)
        {
            //ConfiguracionSystem.ConexionConfig = CampConexion.Text;
        }

        private void FormAutorizacion_Load(object sender, EventArgs e)
        {

        }
    }
}
