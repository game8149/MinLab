using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno.Configuracion
{
    public class ConfiguracionSystem
    {
        private static Dictionary<int, string> fuentes;
        private static Dictionary<int, string> fuenteTamaños;


        //List Settings
        public static void Init()
        {
            if (fuentes == null && fuenteTamaños == null)
            {
                fuentes = new Dictionary<int, string>();
                fuenteTamaños = new Dictionary<int, string>();

                fuentes.Add(0, "Futura Bk BT");
                fuentes.Add(1, "Arial Unicode MS");

                fuenteTamaños.Add(0, "Pequeño");
                fuenteTamaños.Add(1, "Normal");
                fuenteTamaños.Add(2, "Mediano");
            }
        }

        //ListSettings
        public static Dictionary<int, string> FontList
        {
            get { return fuentes; }
        }

        public static Dictionary<int, string> FontSizeList
        {
            get { return fuenteTamaños; }
        }
        
        public static bool Daltonic
        {
            get { return Convert.ToBoolean(Convert.ToInt16(ConfiguracionData.Daltonic)); }
            set { ConfiguracionData.Daltonic = value ? "1" : "0"; }
        }

        public static bool Sound
        {
            get { return Convert.ToBoolean(Convert.ToInt16(ConfiguracionData.Sonido)); }
            set { ConfiguracionData.Sonido = value ? "1" : "0"; }
        }

        public static string Font
        {
            get{
                int id = Convert.ToInt16(ConfiguracionData.Font);
                return fuentes[id]; 
            }

            set { ConfiguracionData.Font = value.ToString();}
            
        }


        public static bool DaltonicDefault
        {
            get { return Convert.ToBoolean(Convert.ToInt16(ConfiguracionData.DaltonicDefault)); }
        }

        public static bool SoundDefault
        {
            get { return Convert.ToBoolean(Convert.ToInt16(ConfiguracionData.SonidoDefault)); }
        }
        

        public static int IncrementSize
        {
            get
            {
                int id = Convert.ToInt16(ConfiguracionData.FontSize);
                switch (id)
                {
                    case 0: //pequeño
                        return -1;
                    case 2: // mediano
                        return 1;
                }
                return 0;
            }
            set { ConfiguracionData.FontSize = value.ToString(); }
        }

        public static string ConexionConfig
        {
            get { return ConfiguracionData.ConexionConfig; }
        }
        
    }
}
