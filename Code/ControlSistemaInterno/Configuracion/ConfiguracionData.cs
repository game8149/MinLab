using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno.Configuracion
{
    public class ConfiguracionData
    {

        //Settings file default

        public static string SonidoDefault
        {
            get { return "1"; }//Encendido
        }

        public static string FontDefault
        {
            get { return "0"; }//Futura Bk BT
        }

        public static string FontSizeDefault
        {
            get { return "1"; }//Normal
        }

        public static string DaltonicDefault
        {
            get { return "0"; }//Normal
        }

        //Settings file

        public static string Sonido
        {
            get {
                Validation();
                return ConfigurationManager.AppSettings.Get("sound"); }

            set {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["sound"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        public static string Font
        {
            get {
                Validation();
                return ConfigurationManager.AppSettings["font"]; }

            set {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["font"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        public static string FontSize
        {
            get {
                Validation();
                return ConfigurationManager.AppSettings["font-size"]; }

            set {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                config.AppSettings.Settings["font-size"].Value=value;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        public static string Daltonic
        {
            get {
                Validation();
                return ConfigurationManager.AppSettings["daltonic"]; }

            set {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["daltonic"].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        public static string ConexionConfig
        {
            get { return ConfigurationManager.ConnectionStrings["Server"].ConnectionString; }

            set { ConfigurationManager.ConnectionStrings["Server"].ConnectionString = value; }
        }

        public static void Validation()
        {
            try
            {
                Convert.ToInt16(ConfigurationManager.AppSettings["font"]);
            }
            catch (Exception ex)
            {
                ConfiguracionData.Font = ConfiguracionData.FontDefault;
            }

            try
            {
                Convert.ToInt16(ConfigurationManager.AppSettings["font-size"]);
            }
            catch (Exception ex)
            {
                ConfiguracionData.FontSize = ConfiguracionData.FontSizeDefault;
            }

            try
            {
                Convert.ToInt16(ConfigurationManager.AppSettings["daltonic"]);
            }
            catch (Exception ex)
            {
                ConfiguracionData.Daltonic = ConfiguracionData.DaltonicDefault;
            }
        }
    }
}
