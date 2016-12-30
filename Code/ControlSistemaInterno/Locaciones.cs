using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.EntityLayer.EUbicacion;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinLab.Code.ControlSistemaInterno
{
    public class Locaciones
    {
        private static Locaciones locaciones = null;
        
        private  Dictionary<int, Distrito> DiccionarioLocaciones;

        public static Locaciones GetInstance()
        {
            if (locaciones == null)
            {
                locaciones = new Locaciones();
            }
                

            return locaciones;
        }

        public void LoadLocaciones()
        {
            DataUbicacion enlace = new DataUbicacion();
            DiccionarioLocaciones = enlace.GetDistritoAll();
        }


        public Distrito GetDistrito(int IdDistrito)
        {
            return DiccionarioLocaciones[IdDistrito];
        }

        public Dictionary<int, Distrito> Coleccion()
        {
            return DiccionarioLocaciones;
        }

    }
}
