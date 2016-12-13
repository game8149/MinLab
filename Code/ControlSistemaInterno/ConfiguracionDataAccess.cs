using System.Configuration;

namespace MinLab.Code.ControlSistemaInterno
{
    /// <summary>
    /// Descripción breve de Configuracion
    /// </summary>
    public class ConfiguracionDataAccess
    {
        private static string DbConexionConfig;
        private static string DbProveedorConfig;
        
        static ConfiguracionDataAccess()
        {
            DbConexionConfig = ConfigurationManager.ConnectionStrings["MinLab"].ConnectionString;
            DbProveedorConfig = ConfigurationManager.ConnectionStrings["MinLab"].ProviderName;
        }
        /// <summary>
        /// Descripción breve de Configuracion
        /// </summary>
        public static string CadenaConexion
        {
            get { return DbConexionConfig; }
        }

        /// <summary>
        /// Descripción breve de Configuracion
        /// </summary>
        public static string CadenaProveedor
        {
            get { return DbProveedorConfig; }
        }
    }
}
