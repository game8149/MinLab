using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinLab.Code.EntityLayer.FichaPlantilla
{
    public class PlantillaItemList
    {
        private int idData;
        private int indice;//para el orden ..
        private string nombre;

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

        public int Indice
        {
            get { return indice; }
            set { this.indice = value; }
        }
    }
}
