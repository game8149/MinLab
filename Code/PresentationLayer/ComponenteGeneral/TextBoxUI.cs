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
    public partial class TextBoxUI : UserControl
    {
        public TextBoxUI()
        {
            InitializeComponent();
            textBox1.SizeChanged += TextBox1_SizeChanged;
        }

        private void TextBox1_SizeChanged(object sender, EventArgs e)
        {
            this.Size = textBox1.Size;
            textBox1.Location = new Point(0,0);
        }
    }
}
