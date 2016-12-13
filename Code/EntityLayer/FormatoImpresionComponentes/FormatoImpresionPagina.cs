
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.FormatoImpresionComponentes
{
    public class FormatoImpresionPagina
    {
        private Dictionary<int, FormatoImpresionPaginaLinea> detalle = new Dictionary<int, FormatoImpresionPaginaLinea>();

        public Dictionary<int,FormatoImpresionPaginaLinea> Detalles { get{return detalle; } set{this.detalle=value; } }

    }
}
