using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EOrden;
using System.Collections.Generic;

namespace MinLab.Code.ControlSistemaInterno
{
    public  class ListaAnalisis
    {
        private static ListaAnalisis analisis;
        private Dictionary<int, EntityLayer.Analisis> paquetes;
        private Dictionary<int, string> diccionario;

        public static ListaAnalisis GetInstance()
        {
            if (analisis == null)
                analisis = new ListaAnalisis();

            return analisis;
        }

        public void LoadAnalisis()
        {
            paquetes = DataAnalisis.GetAnalisis();
            diccionario = new Dictionary<int, string>();
            foreach (EntityLayer.Analisis p in paquetes.Values)
                diccionario.Add(p.IdData, p.Nombre);
        }

        public Dictionary<int, EntityLayer.Analisis> Analisis
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

        public EntityLayer.Analisis GetAnalisisById(int id)
        {
            return paquetes[id];
        }
    }
}
