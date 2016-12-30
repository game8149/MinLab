using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.EOrden
{

    public class OrdenDetalle
    {
        private int idData;
        private int idDataTarifa;
        private int cobertura;

        public int IdData
        {
            get { return this.idData; }
            set { this.idData = value; }
        }

        public int IdDataPaquete
        {
            get { return this.idDataTarifa; }
            set { this.idDataTarifa = value; }
        }


        public int Cobertura
        {
            get { return this.cobertura; }
            set { this.cobertura = value; }
        }

    }

}
