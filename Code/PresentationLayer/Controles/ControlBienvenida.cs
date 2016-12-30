using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinLab.Code.PresentationLayer.Controles.ComponentesBienvenida;
using MinLab.Code.LogicLayer.LogicaControl;
using MinLab.Code.EntityLayer.EFicha;

namespace MinLab.Code.PresentationLayer
{
    public partial class ControlBienvenida : UserControl
    {
        public ControlBienvenida()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogicControlSistema enlace = new LogicControlSistema();
            FormModificarCuenta form = new FormModificarCuenta();
            form.Cuenta = enlace.GetCuentaLogin();
            form.ShowDialog();
            ActualizarVistaCuenta();
        }


        private void ActualizarVistaCuenta()
        {
            LogicControlSistema enlace = new LogicControlSistema();
            Cuenta cuent = enlace.GetCuentaLogin();
            CampNombre.Text = cuent.Nombre + " " + cuent.PrimerApellido + " " + cuent.SegundoApellido;
            CampNivel.Text = cuent.Nivel.ToString();
        }

        private void ControlBienvenida_Load(object sender, EventArgs e)
        {
            ActualizarVistaCuenta();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LogicControlSistema enlace = new LogicControlSistema();
            FormModificarClave form = new FormModificarClave();
            form.Cuenta = enlace.GetCuentaLogin();
            form.ShowDialog();
        }
    }
}
