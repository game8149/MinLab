using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.FichaOrden;
using System.Collections.Generic;

namespace MinLab.Code.ControlSistemaInterno
{
    public  class Tarifario
    {
        private static Tarifario tarifario;
        private Dictionary<int, Paquete> paquetes;
        private Dictionary<int, string> diccionario;

        public static Tarifario GetInstance()
        {
            if (tarifario == null)
                tarifario = new Tarifario();

            return tarifario;
        }

        public void LoadTarifario()
        {
            paquetes = DataPaquete.GetTarifario();
            diccionario = new Dictionary<int, string>();
            foreach (Paquete p in paquetes.Values)
                diccionario.Add(p.IdData, p.Nombre);
        }

        public Dictionary<int, Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
        }

        public Dictionary<int,string> Coleccion
        {
            get { return diccionario; }
        }


        public Paquete GetPaqueteById(int id)
        {
            return paquetes[id];
        }


    }
}
