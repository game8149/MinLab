using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.ETarifario
{
    public class Tarifario
    {
        public int IdData { get; set; }

        public Dictionary<int,TarifarioDetalle> Listado { get; set; }

        public int Año { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Vigente { get; set; }
    }
}
