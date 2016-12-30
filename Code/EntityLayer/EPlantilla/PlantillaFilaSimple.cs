using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.EPlantilla
{
    public class PlantillaFilaSimple:PlantillaFila
    {

        private PlantillaItem item;
        
        public PlantillaItem Item
        {
            get { return item; }
            set { this.item = value; }
        }
        
    }
}
