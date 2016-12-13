using MinLab.Code.ControlSistemaInterno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiccionarioGeneral.Tiempo tiempo=DiccionarioGeneral.GetInstance().CalcularEdad(DTPicker.Value);
            CampEdad.Text = tiempo.Año +", "+ tiempo.Mes + ", "+ tiempo.Dias;
        }
    }
}
