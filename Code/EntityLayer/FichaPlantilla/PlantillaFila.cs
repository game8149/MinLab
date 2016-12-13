namespace MinLab.Code.EntityLayer.FichaPlantilla
{
    public class PlantillaFila
    {

        private int posicion;
        private PlantillaFilaTipo tipo;

        public enum PlantillaFilaTipo
        {
            Simple,
            Agrupada
        }


        public int Indice { get {return posicion; } set { this.posicion = value; } }
        public PlantillaFilaTipo Tipo { get { return tipo; } set { this.tipo = value; } }

    }
}
