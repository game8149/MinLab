using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.FichaReporte
{
    public class ReporteMensual
    {
        
        private Dictionary<int, ReporteMensualDetalle> detalles = null;

        public int Area { get; set; }

        public Dictionary<int,ReporteMensualDetalle> Detalle { get {return detalles; } set { this.detalles = value; } }


        public bool ExisteId(int id)
        {
            foreach(ReporteMensualDetalle det in detalles.Values)
            {
                if (id == det.Id) return true;
            }
            return false;
        }

    }
}
