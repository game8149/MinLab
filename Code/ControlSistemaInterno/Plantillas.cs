using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer.EPlantilla;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinLab.Code.ControlSistemaInterno
{
    public class Plantillas
    {
        private static Plantillas plantillas = null;
        
        private  Dictionary<int, Plantilla> DiccionarioPlantillas;

        public static Plantillas GetInstance()
        {
            if (plantillas == null)
            {
                plantillas = new Plantillas();
            }
                

            return plantillas;
        }

        public void LoadPlantillas()
        {
            DiccionarioPlantillas = DataPlantilla.GetAllPlantillas();
        }


        public Plantilla GetPlantilla(int IdPlantilla)
        {
            return DiccionarioPlantillas[IdPlantilla];
        }

        public Dictionary<int, Plantilla> Coleccion()
        {
            return DiccionarioPlantillas;
        }

    }
}
