using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinLab.Code.EntityLayer.FichaExamen
{
    public class ExamenDetalle
    {
        private int idData = 0;
        private int idItem;
       
        private string campo;//Respuesta

        public string Campo
        {
            get { return campo; }
            set { this.campo = value; }
        }
        
        public int IdData
        {
            get { return idData; }
            set { this.idData = value; }
        }

        public int IdItem
        {
            get { return idItem; }
            set { this.idItem = value; }
        }


    }

}
