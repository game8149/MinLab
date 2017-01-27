using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MinLab.Code.ControlSistemaInterno.DataEstaticaGeneral;

namespace MinLab.Code.ControlSistemaInterno.Util
{
    public class Utilidad
    {

        public static Tiempo CalcularEdad(DateTime fechaNacimiento)
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


        public static string FormatoEdad(Tiempo edad)
        {
            bool ano1 = false;
            bool mes1 = false;
            StringBuilder bs = new StringBuilder();
            if (edad.Año > 1)
                bs.Append(edad.Año + " años ");
            else
            {

                if (ano1 = edad.Año == 1)
                    bs.Append(edad.Año + " año ");

                if (edad.Mes > 1)
                    bs.Append(edad.Mes + " meses ");
                else
                {
                    if (mes1 = edad.Mes == 1)
                        bs.Append(edad.Mes + " mes ");
                    if (edad.Dias > 1 || (!mes1 && !ano1))
                        bs.Append(edad.Dias + " días");
                    else if (edad.Dias == 1)
                        bs.Append(edad.Dias + " día");
                }

            }

            return bs.ToString();
        }

    }
}
