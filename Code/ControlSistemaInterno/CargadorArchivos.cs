using MinLab.Code.ControlSistemaInterno;
using System;

namespace MinLab.Code.ControlSistemaInterno
{
    class CargadorArchivos
    {

        public CargadorArchivos()
        {
            
        }


        public void cargar()
        {
            try
            {
                System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
                con.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                con.Open();
                Tarifario.GetInstance().LoadTarifario();
                Plantillas.GetInstance().LoadPlantillas();
                DiccionarioGeneral.GetInstance().Load();
                SistemaControl.GetInstance();
            }
            catch (Exception s)
            {
                throw new Exception("No se puede conectar con el servidor. Consulta con soporte tecnico \n :). Error: "+s.Message);
            }

        }
    }
}
