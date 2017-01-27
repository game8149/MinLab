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
    public partial class ButtonUI : UserControl
    {
        public int Id;

        public enum ButtonTipo
        {
            Next,
            Ok,
            Cancel,
            Modify,
            Item
        }

        public ButtonTipo Tipo;

        public ButtonUI()
        {
            InitializeComponent();
            button1.SizeChanged += Button1_SizeChanged;
        }

        private void Button1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = button1.Size;
            button1.Location = new Point(0,0);
        }

        public Button ComponenteUI
        {
            get { return button1; }
        }

        private void ButtonUI_Load(object sender, EventArgs e)
        {

        }
    }
}
