using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.FormatoImpresionComponentes
{
    public class FormatoImpresionPaginaLinea
    {
        public enum TipoPaginaLinea
        {
            TituloExamen,
            TituloArea,
            TituloFin,
            ItemSimple,
            ItemTexto,
            TituloGrupo,
            GrupoFin,
        }

        private string nombre;
        private string resultado;
        private TipoPaginaLinea tipo;

        public TipoPaginaLinea TipoLinea
        {
            get { return tipo; }
            set { this.tipo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { this.nombre += value; }
        }
        public string Resultado
        {
            get { return resultado; }
            set { this.resultado = value; }
        }
    }
}
