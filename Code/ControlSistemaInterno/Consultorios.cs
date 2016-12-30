using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.EntityLayer.EUbicacion;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinLab.Code.ControlSistemaInterno
{
    public class Consultorios
    {
        private static Consultorios consultorios = null;
        
        private  Dictionary<int, Consultorio> DiccionarioConsultorios;

        public static Consultorios GetInstance()
        {
            if (consultorios == null)
            {
                consultorios = new Consultorios();
            }
                

            return consultorios;
        }

        public void LoadConsultorio()
        {
            DiccionarioConsultorios = DataConsultorio.GetConsultorioAll();
        }


        public Consultorio GetConsultorio(int IdConsultorio)
        {
            return DiccionarioConsultorios[IdConsultorio];
        }

        public Dictionary<int, Consultorio> Coleccion()
        {
            return DiccionarioConsultorios;
        }

    }
}
