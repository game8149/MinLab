using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesExamenEditor
{
    public class ExamenEditorContenedor:Panel
    {
        private List<ExamenEditorFila> filas = new List<ExamenEditorFila>();

        public int IdExamen { get; set; }

        public ExamenEditorContenedor(int Ancho,int Alto)
        {            
            this.Width = Ancho;
            this.Height = Alto;
            
            DoubleBuffered = true;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        

        public List<ExamenEditorFila> Filas
        {
            get { return this.filas; }
            set {
                int desplazamiento = 20;
                this.filas = value;
                this.SuspendLayout();             
                foreach (ExamenEditorFila k in filas)
                {
                    k.Location = new Point(10, desplazamiento);
                    desplazamiento += k.Height+5;
                    this.Controls.Add(k);
                }
                this.AutoScroll = true;
                if (desplazamiento > this.Height)
                {
                    foreach (ExamenEditorFila k in filas)
                    {
                        k.redimensionarWidth(25);
                    }
                }
                this.HScroll = false;
                this.ResumeLayout(false);
                this.PerformLayout();
            }

        }
        
    }
}
