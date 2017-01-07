using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.PresentationLayer.ComponentesExamen.ComponentesPrueba
{
    public class ConfiguracionExamen
    {
        private static ConfiguracionExamen config;
        public bool Changed { get; set; }
        public bool Loading { get; set; }

        public static ConfiguracionExamen GetInstance()
        {
            if (config == null)
                config = new ConfiguracionExamen();

            return config;
        }
    }
}
