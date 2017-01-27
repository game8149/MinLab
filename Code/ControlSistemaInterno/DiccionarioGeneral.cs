using MinLab.Code.EntityLayer.EUbicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno
{
    public class DataEstaticaGeneral
    {
        
        public class Tiempo
        {
            public int Año { get; set; }
            public int Mes { get; set; }
            public int Dias { get; set; }
        }
        
        private static Dictionary<int, string> regexs = new Dictionary<int, string>();
        private static Dictionary<int, string> sexoList = new Dictionary<int, string>();
        private static Dictionary<int, string> ordenStates = new Dictionary<int, string>();
        private static Dictionary<int, string> docTipos = new Dictionary<int, string>();
        private static Dictionary<int, string> coberturaTipos = new Dictionary<int, string>();
        private static Dictionary<int, string> diccionarioAño= new Dictionary<int, string>();
        private static Dictionary<int, string> meses = new Dictionary<int, string>();
        private static Dictionary<int, string> areas = new Dictionary<int, string>();
        private static Dictionary<int, string> examenStates = new Dictionary<int, string>();
        private static Dictionary<int, Distrito> ubicaciones = new Dictionary<int, Distrito>();
        
        
        public static void Init()
        {

            sexoList.Add((int)Sexo.Hombre, "HOMBRE");
            sexoList.Add((int)Sexo.Mujer, "MUJER");

            docTipos.Add(0, "DNI");
            docTipos.Add(1, "HC");

            coberturaTipos.Add(0, "PARTICULAR");
            coberturaTipos.Add(1, "SIS");
            coberturaTipos.Add(2, "EXONERADO");

            areas.Add(0, "BIOQUIMICA");
            areas.Add(1, "ESTUDIO DE SECRECIONES");
            areas.Add(2, "HEMATOLOGIA");
            areas.Add(3, "INMUNOLOGIA");
            areas.Add(4, "MICROBIOLOGIA");
            areas.Add(5, "PARASITOLOGIA");
            areas.Add(6, "UROANALISIS");
            
            ordenStates.Add(0, "EN PROCESO");
            ordenStates.Add(1, "TERMINADO");
            
            examenStates.Add(0, "EN PROCESO");
            examenStates.Add(1, "TERMINADO");

            meses.Add(0, "ENERO");
            meses.Add(1, "FEBRERO");
            meses.Add(2, "MARZO");
            meses.Add(3, "ABRIL");
            meses.Add(4, "MAYO");
            meses.Add(5, "JUNIO");
            meses.Add(6, "JULIO");
            meses.Add(7, "AGOSTO");
            meses.Add(8, "SEPTIEMBRE");
            meses.Add(9, "OCTUBRE");
            meses.Add(10, "NOVIEMBRE");
            meses.Add(11, "DICIEMBRE");

            
            regexs.Add(2, @"(\b[0-9]+$)");
            regexs.Add(3, @"(\b[0-9]+$|(\b[0-9]+.[0-9]+$))");
            
        }

        public static Dictionary<int,string> SexoTipos
        {
            get { return sexoList; }
        }

        public static Dictionary<int, string> OrdenEstados
        {
            get { return ordenStates; }
        }

        public static Dictionary<int, string> CoberturaTipos
        {
            get { return coberturaTipos; }
        }

        public static Dictionary<int, string> DocTipos
        {
            get { return docTipos; }
        }

        public static Dictionary<int, string> Meses
        {
            get { return meses; }
        }

        public static Dictionary<int, string> Expressions
        {
            get { return regexs; }
        }

        public static Dictionary<int, string> Areas
        {
            get { return areas; }
        }

        public static Dictionary<int, string> ExamenEstados
        {
            get { return examenStates; }
        }
        
    }
}
