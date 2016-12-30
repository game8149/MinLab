using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.EReporte
{
    public class ReporteMensualDetalle
    {
        private int id;
        private int acumulado;
        private int cantidad;

        public int Id { get {return id; } set {this.id=value; } }
        
        public int Acumulado { get { return acumulado; } set { this.acumulado = value; } }

        public int Cantidad { get { return cantidad; } set { this.cantidad = value; } }

    }
}
