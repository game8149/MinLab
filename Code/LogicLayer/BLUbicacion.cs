using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EUbicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.LogicLayer
{
    public class BLUbicacion
    {
        public static Dictionary<int,string> ObtenerListaDistritos()
        {

            Dictionary<int,Distrito> distritos=Locaciones.GetInstance().Coleccion();
            Dictionary<int, string> temp = new Dictionary<int, string>();

            foreach(Distrito distr in distritos.Values)
            {
                temp.Add(distr.IdData,distr.Nombre);
            }

            return temp;

        }

        public static Dictionary<int, string> ObtenerListaSectores(int idDistrito)
        {
            Dictionary<int, Sector> sectores = Locaciones.GetInstance().GetDistrito(idDistrito).Sectores;
            Dictionary<int, string> temp = new Dictionary<int, string>();

            foreach (Sector sect in sectores.Values)
            {
                temp.Add(sect.IdData, sect.Nombre);
            }

            return temp;

        }

    }
}
