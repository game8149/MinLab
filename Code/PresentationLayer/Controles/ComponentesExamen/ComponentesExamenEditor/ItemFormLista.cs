using MinLab.Code.PresentationLayer.ComponentesExamenEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponentesExamen.ComponentesPrueba
{
    public class ItemFormLista : ExamenEditorItem
    {
        private ComboBox combo;

        public ItemFormLista(int Ancho, int Alto, bool tieneUnidad) : base(Ancho, Alto, tieneUnidad)
        {

            combo = new ComboBox();
        }

        
        public void SetCollection(Dictionary<int,string> Coleccion)
        {

        }


    }
}
