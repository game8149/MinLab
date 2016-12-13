
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.LogicLayer.LogicaControl;
using MinLab.Code.PresentationLayer.GUISistema;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer
{
    static class SistemaWinchanzao
    {
        static bool isRunning=true;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CargadorArchivos cargador = new CargadorArchivos();
            // Creamos el subproceso
            Thread hiloAuxiliar = new Thread(new ThreadStart(cargador.cargar));
            // Ejecutamos el subproceso
            hiloAuxiliar.Start();
            // Esperamos a que se carguen los archivos mientras ejecuta el splash                   
            while (!hiloAuxiliar.IsAlive) ;
            PantallaDeCarga formCarga = new PantallaDeCarga(2, hiloAuxiliar);
            // -------  Cargamos y mostramos el formulario Splash durante 2 minimo  -----
            // Mostramos el formulario de forma modal.  
            formCarga.ShowDialog();
            formCarga.Dispose();

            BLControlSistema enlaceControlSistema = new BLControlSistema();
            do
            {
                try
                {
                    FormInicioSesion form = new FormInicioSesion();
                    form.ShowDialog();
                    form.Dispose();
                    if (enlaceControlSistema.EsLoggeado())
                    {
                        Principal formPrincipal = new Principal();
                        Application.Run(formPrincipal);
                        if (!formPrincipal.Visible) formPrincipal.Dispose();
                        enlaceControlSistema.CerrarSesion();
                    }
                    else isRunning = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    isRunning = false;
                }

            } while (isRunning);

            //Application.Run(new Test());

        }
    }
}
