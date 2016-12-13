using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesExamenEditor
{
    public  partial class ExamenEditorFila : Panel
    {
        private int index;
        private TipoForm tipo;
        private ExamenEditorItem item;
        private ExamenEditorGrupo grupo;

        public enum TipoForm
        {
            Grupo,
            Item
        }

        public ExamenEditorFila(int Ancho,int Alto)
        {
            this.Width = Ancho;
            this.Height = Alto;
            this.Size = new Size(Width,Height);
            DoubleBuffered = true;
        }
        
        public int Indice
        {
            get { return this.index; }
            set { this.index = value; }
        }
        public ExamenEditorItem Item
        {
            get { return item; }
            set {
                this.SuspendLayout();
                this.item = value;
                this.item.Location = new Point(0, 0);
                this.Height = item.Height;
                this.Width = item.Width;
                this.Controls.Add(item);
                this.ResumeLayout(false);
            }
        }

        public TipoForm Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }

        public void redimensionarWidth(int diferencia)
        {
            this.Width = this.Width-diferencia;
            switch (tipo)
            {
                case TipoForm.Grupo:
                    grupo.redimensionarWidth(this.Width);
                    break;
                case TipoForm.Item:
                    item.redimensionarWidth(this.Width);
                    break;
            }
        }

        public ExamenEditorGrupo Grupo
        {
            get { return this.grupo; }
            set {
                this.SuspendLayout();
                this.grupo = value;

                this.Height = grupo.Height;
                this.Width = grupo.Width;

                this.Controls.Add(grupo);
                this.ResumeLayout(false);
            }
        } 
        
    }
}
