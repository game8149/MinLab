using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinLab.Code.EntityLayer.ArchivoPrueba;

namespace MinLab.Code.PresentationLayer.ComponentesPrueba
{
    public partial class ControlComboBox : UserControl
    {
        private int Alto = 25;
        private int Ancho = 400;

        public ControlComboBox(Item item, string respuesta)
        {
            this.Height = Alto;
            this.Width = Ancho;
            InitializeComponent(item, respuesta);
        }
    }
}
