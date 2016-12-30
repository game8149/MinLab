using MinLab.Code.EntityLayer.EExamen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesExamenEditor
{
    public class ExamenEditorGrupo: GroupBox
    {
        
        private List<ExamenEditorItem> items;



        public ExamenEditorGrupo(int Ancho, int Alto)
        {
            this.Height = Alto;
            this.Width = Ancho;
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

        public List<ExamenEditorItem> Items
        {
            get { return items; }
            set {
                this.items = value;
                addList(value);
            }
        }

        public String Nombre
        {
            get { return this.Text; }
            set { this.Text = value; }
        }

        public void redimensionarWidth(int Alto)
        {
            this.SuspendLayout();
            this.Width = Alto;
            foreach(ExamenEditorItem k in items)
            {
                k.redimensionarWidth(this.Width-10);
            }
            this.ResumeLayout(false);
        }


        private void addList(List<ExamenEditorItem> items)
        {
            int posYActual =20 ;
            this.SuspendLayout();
            foreach (ExamenEditorItem i in this.Items)
            {
                this.Controls.Add(i);
                i.Location=new Point(i.Location.X,posYActual);
                posYActual += (i.Height +2);
            }
            this.Height = posYActual+25;
            this.ResumeLayout(false);
        }

    }
}
