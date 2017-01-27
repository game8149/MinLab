using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponenteGeneral
{
    public partial class LabelUI : UserControl
    {
        public enum LabelTipo
        {
            Titulo,
            Subtitulo,
            Item
        }

        public LabelTipo Tipo;

        public LabelUI()
        {
            InitializeComponent();
            label1.SizeChanged += LabelUI_SizeChanged;
        }

        private void LabelUI_SizeChanged(object sender, EventArgs e)
        {
            this.Size=label1.Size;
            label1.Location = new Point(0,0);
        }
        public Label ComponenteUI
        {
            get { return label1; }
        }
    }
}
