using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.EUbicacion
{
    public class Distrito
    {
        public int IdData { get; set; }

        public Dictionary<int,Sector> Sectores { get; set; }

        public string Nombre { get; set; }
    }
}
