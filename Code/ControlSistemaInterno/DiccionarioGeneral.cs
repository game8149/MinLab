using MinLab.Code.EntityLayer.EUbicacion;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno
{
    public class DiccionarioGeneral
    {
        

        public class Tiempo
        {
            public int Año { get; set; }
            public int Mes { get; set; }
            public int Dias { get; set; }
        }

        private static DiccionarioGeneral coleccion = null;

        private  Dictionary<int, string> diccionarioRegex = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioSexo = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioEstadoOrden = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioDoc = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioCobertura = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioAño= new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioMes = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioArea = new Dictionary<int, string>();
        private  Dictionary<int, string> diccionarioEstadoExamen = new Dictionary<int, string>();
        private Dictionary<int, Distrito> diccionarioUbicacion = new Dictionary<int, Distrito>();
        
        public static DiccionarioGeneral GetInstance()
        {
            if (coleccion == null)
                coleccion = new DiccionarioGeneral();


            return coleccion;
        }
        
        public void Load()
        {

            diccionarioSexo.Add((int)Sexo.Hombre, "HOMBRE");
            diccionarioSexo.Add((int)Sexo.Mujer, "MUJER");

            diccionarioDoc.Add(0, "DNI");
            diccionarioDoc.Add(1, "HC");

            diccionarioCobertura.Add(0, "PARTICULAR");
            diccionarioCobertura.Add(1, "SIS");
            diccionarioCobertura.Add(2, "EXONERADO");

            diccionarioArea.Add(0, "BIOQUIMICA");
            diccionarioArea.Add(1, "ESTUDIO DE SECRECIONES");
            diccionarioArea.Add(2, "HEMATOLOGIA");
            diccionarioArea.Add(3, "INMUNOLOGIA");
            diccionarioArea.Add(4, "MICROBIOLOGIA");
            diccionarioArea.Add(5, "PARASITOLOGIA");
            diccionarioArea.Add(6, "UROANALISIS");
            
            diccionarioEstadoOrden.Add(0, "EN PROCESO");
            diccionarioEstadoOrden.Add(1, "TERMINADO");
            
            diccionarioEstadoExamen.Add(0, "EN PROCESO");
            diccionarioEstadoExamen.Add(1, "TERMINADO");

            diccionarioMes.Add(0, "ENERO");
            diccionarioMes.Add(1, "FEBRERO");
            diccionarioMes.Add(2, "MARZO");
            diccionarioMes.Add(3, "ABRIL");
            diccionarioMes.Add(4, "MAYO");
            diccionarioMes.Add(5, "JUNIO");
            diccionarioMes.Add(6, "JULIO");
            diccionarioMes.Add(7, "AGOSTO");
            diccionarioMes.Add(8, "SEPTIEMBRE");
            diccionarioMes.Add(9, "OCTUBRE");
            diccionarioMes.Add(10, "NOVIEMBRE");
            diccionarioMes.Add(11, "DICIEMBRE");

            
            diccionarioRegex.Add(2, @"(\b[0-9]+$)");
            diccionarioRegex.Add(3, @"(\b[0-9]+$|(\b[0-9]+.[0-9]+$))");
            
        }

        public  Dictionary<int,string> TipoSexo
        {
            get { return diccionarioSexo; }
        }

        public Dictionary<int, string> EstadoOrden
        {
            get { return diccionarioEstadoOrden; }
        }

        public  Dictionary<int, string> TipoCobertura
        {
            get { return diccionarioCobertura; }
        }

        public  Dictionary<int, string> TipoDoc
        {
            get { return diccionarioDoc; }
        }

        public  Dictionary<int, string> Mes
        {
            get { return diccionarioMes; }
        }

        public Dictionary<int, string> Expression
        {
            get { return diccionarioRegex; }
        }

        public  Dictionary<int, string> Area
        {
            get { return diccionarioArea; }
        }

        public Dictionary<int, string> EstadoExamen
        {
            get { return diccionarioEstadoExamen; }
        }



        public Tiempo CalcularEdad(DateTime fechaNacimiento)
        {
            
            int anos;
            int meses;
            int dias;

            DateTime actual = DateTime.Now;

            anos = (actual.Year - fechaNacimiento.Year);
            meses = (actual.Month - fechaNacimiento.Month);
            dias = (actual.Day - fechaNacimiento.Day);

            if (meses < 0)
            {
                anos -= 1;
                meses += 12;
            }

            if (dias < 0)
            {
                meses -= 1;
                int DiasAno = actual.Year;
                int DiasMes = actual.Month;

                if ((actual.Month - 1) == 0)
                {
                    DiasAno = DiasAno - 1;
                    DiasMes = 12;
                }
                else
                {
                    DiasMes = DiasMes - 1;
                }

                dias += DateTime.DaysInMonth(DiasAno, DiasMes);
            }
            

            Tiempo tiempo = new Tiempo();
            tiempo.Año = anos;
            tiempo.Dias = dias;
            tiempo.Mes = meses;

            return tiempo;
        }
        

        public string FormatoEdad(Tiempo edad)
        {
            bool ano1 = false;
            bool mes1 = false;
            StringBuilder bs = new StringBuilder();
            if (edad.Año > 1)
                bs.Append(edad.Año + " años ");
            else {

                if (ano1 = edad.Año == 1)
                    bs.Append(edad.Año + " año ");

                if (edad.Mes > 1)
                    bs.Append(edad.Mes + " meses ");
                else {
                    if(mes1=edad.Mes == 1)
                        bs.Append(edad.Mes + " mes ");
                    if (edad.Dias > 1|| (!mes1&&!ano1))
                        bs.Append(edad.Dias + " días");
                    else if (edad.Dias == 1)
                        bs.Append(edad.Dias + " día");
                }
                
            }

            return bs.ToString();
        }

    }
}
