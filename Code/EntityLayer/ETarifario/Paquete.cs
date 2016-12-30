
using MinLab.Code.ControlSistemaInterno;
using System.Collections.Generic;

namespace MinLab.Code.EntityLayer
{
    public class Analisis
    {
        private string nombre;
        private int idData;
        private List<int> idPlantillas;
        private string codigo;
        private TipoPaquete tipo;

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }
        

        public string Codigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }

        public List<int> PlantillasId
        {
            get { return idPlantillas;}
            set { this.idPlantillas = value; }
        }

        public int IdData
        {
            get { return idData; }
            set { this.idData = value; }
        }

        public TipoPaquete Tipo
        {
            get { return tipo; }
            set { this.tipo = value; }
        }
    }
}
