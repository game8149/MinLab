using System.Collections.Generic;

namespace MinLab.Code.EntityLayer.FichaPlantilla
{
    public class Plantilla
    {
        private int idDataPlantilla;
        private string codigo;
        private string nombre;
        private Dictionary<int,PlantillaFila> filas; //FILAS INDEXADAS POR POSICION
        private Dictionary<int, PlantillaItem> itemsIndexed=new Dictionary<int, PlantillaItem>(); //INDEXADAS POR ID PLANTILLA
        private bool hasItem = false;
        private bool hasItemGrupo = false;
        

        public int Area { get; set; }

        public int IdDataPlantilla
        {
            get { return idDataPlantilla; }
            set { this.idDataPlantilla = value; }
        }
        
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
        
        public bool TieneItems
        {
            get { return this.hasItem; }
            set { this.hasItem = value; }
        }
        public bool TieneGrupos
        {
            get { return this.hasItemGrupo; }
            set { this.hasItemGrupo = value; }
        }




        public Dictionary<int, PlantillaItem> ItemsIndexed
        {
            get { return itemsIndexed; }
            set { this.itemsIndexed = value; }
        }

        public Dictionary<int,PlantillaFila> Filas
        {
            get { return filas; }
            set {
                this.filas = value;
            }
        }
        

        public void IndexarByItem()
        {
            foreach (PlantillaFila detalle in filas.Values)
            {
                switch (detalle.Tipo)
                {
                    case PlantillaFila.PlantillaFilaTipo.Simple:
                        itemsIndexed.Add(((PlantillaFilaSimple)detalle).Item.IdData, ((PlantillaFilaSimple)detalle).Item);
                        break;
                    case PlantillaFila.PlantillaFilaTipo.Agrupada:
                        foreach (PlantillaItem item in ((PlantillaFilaGrupo)detalle).Items.Values)
                            itemsIndexed.Add(item.IdData, item);
                        break;
                }
            }
        }


    }
}
