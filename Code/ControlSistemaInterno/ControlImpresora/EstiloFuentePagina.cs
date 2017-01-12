using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno.ControlImpresora
{
    public class EstiloFuentePagina
    {
        
        private static Font tituloCabecera = new Font("Calibri", 12f, FontStyle.Bold);//Para Titulo 

        private static Font fontTitulo = new Font("Calibri", 8f, FontStyle.Bold);//Para Titulo 

        private static Font fontSubTitulo = new Font("Calibri", 7.5f, FontStyle.Bold);//Para Titulo 

        private static Font fontFechaSub = new Font("Calibri", 7.25f, FontStyle.Regular);//Para Titulo 

        private static Font fontItem = new Font("Calibri", 7.35f, FontStyle.Regular);//Para Titulo 

        private static Font fontGrupo = new Font("Calibri", 7.45f, FontStyle.Regular);//Para Titulo 

        private static Font fontRespuesta = new Font("Calibri", 7.35f, FontStyle.Regular);//Para Titulo 


        public static Font TituloFormato { get { return tituloCabecera; } }

        public static Font TituloArea { get { return fontTitulo; } }

        public static Font TituloExamen { get { return fontSubTitulo; } }

        public static Font Fecha { get { return fontFechaSub; } }

        public static Font Item { get { return fontItem; } }

        public static Font TituloGrupo { get { return fontGrupo; } }

        public static Font Respuesta { get { return fontRespuesta; } }
    }
}
