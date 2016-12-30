
using MinLab.Code.ControlSistemaInterno;
using System.Collections.Generic;

namespace MinLab.Code.EntityLayer.EPlantilla
{
    public class PlantillaItem
    {
        private int idData=0;

        private TipoDato tipoDato=0;
        private TipoCampo tipoCampo=0;
        private bool tieneUnidad=false;
        private string unidad;
        private string porDefault;
        private string nombre;//Nombre del Item

        private Dictionary<int,PlantillaItemList> opciones;
        private Dictionary<int,string> opcionesByIndice;

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

        public string PorDefault
        {
            get { return porDefault; }
            set { this.porDefault = value; }
        }

        public bool TieneUnidad
        {
            get { return tieneUnidad; }
            set { this.tieneUnidad = value; }
        }

        public string Unidad
        {
            get { return unidad; }
            set { this.unidad = value; }
        }

        public int IdData
        {
            get { return idData; }
            set { this.idData = value; }
        }
        

        public TipoDato TipoDato
        {
            get { return tipoDato; }
            set { this.tipoDato = value; }
        }

        public TipoCampo TipoCampo
        {
            get { return tipoCampo; }
            set { this.tipoCampo = value; }
        }

        public Dictionary<int,PlantillaItemList> Opciones
        {
            get { return opciones; }
            set {
                this.opciones = value;
                opcionesByIndice = new Dictionary<int,string>();
                foreach (PlantillaItemList l in opciones.Values)
                {
                    opcionesByIndice.Add(l.Indice,l.Nombre);
                }
            }
        }
        
        public Dictionary<int,string > OpcionesByIndice
        {
            get { return opcionesByIndice; }
        }
    }
}
