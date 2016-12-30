using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.LogicLayer
{
    class BLConsultorio
    {
        public Dictionary<int, string> ObtenerLista()
        {

            Dictionary<int,Consultorio> consul=Consultorios.GetInstance().Coleccion();
            
            Dictionary<int, string> temp = new Dictionary<int, string>();

            foreach (Consultorio con in consul.Values)
                temp.Add(con.IdData, con.Nombre);

            return temp;

        }


    }
}
