
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EPlantilla;
using System.Collections.Generic;

namespace MinLab.Code.LogicLayer.BLPrueba
{

    public class BLPlantilla
    {

        public static Dictionary<int,PlantillaItem> GetAllItemsByPlantilla(int idPlantilla)
        {
             return Plantillas.GetInstance().GetPlantilla(idPlantilla).ItemsIndexed; 
        }

    }
}
