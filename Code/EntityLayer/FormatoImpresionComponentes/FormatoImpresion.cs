
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinLab.Code.EntityLayer.FormatoImpresionComponentes
{
    public class FormatoImpresion
    {
        private Size tamaño;
        private FormatoImpresionCabecera cabecera;
        private List<FormatoImpresionPagina> paginas;

        public FormatoImpresion()
        {
           
            paginas = new List<FormatoImpresionPagina>();
        }

        
        public Size Tamaño { get; set; }

        public int Alto { get { return tamaño.Height; } set { tamaño.Height = value; } }

        public int Ancho { get { return tamaño.Width; } set { tamaño.Width = value; } }




        public FormatoImpresionCabecera Cabecera
        {
            get {return cabecera; }
            set {this.cabecera=value; }

        }
        public List<FormatoImpresionPagina> Paginas
        {
            get { return paginas; }
            set { this.paginas = value; }
        }

        
    }
}
