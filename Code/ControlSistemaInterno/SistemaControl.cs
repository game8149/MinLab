using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno
{
    public class SistemaControl
    {
        private static SistemaControl control;


        public static SistemaControl GetInstance()
        {
            if (control == null)
                control = new SistemaControl();

            return control;
        }


        private SistemaControl()
        {
            Sesion = new Sesion();
            Estado = SistemaEstado.SinOperar;
        }


        public enum SistemaEstado
        {
            Operando=0,
            SinOperar=0
        }


        public SistemaEstado Estado { get; set; }
        public Sesion Sesion {get; }

    }
}
