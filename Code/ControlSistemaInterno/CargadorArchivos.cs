using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.ControlSistemaInterno.Configuracion;
using MinLab.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Data.SqlClient;

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
                StylesGeneral.Init();
                //ListaAnalisis.GetInstance().LoadAnalisis();
                //Locaciones.GetInstance().LoadLocaciones();
                //Consultorios.GetInstance().LoadConsultorio();
                //Plantillas.GetInstance().LoadPlantillas();

                DataEstaticaGeneral.Init();
                ConfiguracionSystem.Init();

                //SistemaControl.GetInstance();
            }
            catch (SqlException s)
            {
                throw new Exception("No se puede conectar con el servidor. Consulta con soporte tecnico \n :). Error: "+s.Message);
            }

        }
    }
}
