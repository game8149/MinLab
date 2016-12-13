using MinLab.Code.EntityLayer.FichaPlantilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.FichaPlantilla
{
    public class PlantillaFilaGrupo:PlantillaFila
    {
        private int idData;
        private string nombre;
        private Dictionary<int, PlantillaItem> items;
        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

        public int IdData
        {
            get { return idData; }
            set { this.idData = value; }
        }

        public Dictionary<int,PlantillaItem> Items
        {
            get { return items; }
            set { this.items = value; }
        }

    }
}
