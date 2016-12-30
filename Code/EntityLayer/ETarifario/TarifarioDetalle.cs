using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.ETarifario
{
    public class TarifarioDetalle
    {
        public int IdData { get; set; }

        public int IdTarifarioCab { get; set; }

        public int IdPaquete { get; set; }

        public double Precio { get; set; }

    }
}
