using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.GUISistema
{
    public partial class PantallaDeCarga : Form
    {
        private Thread _subProceso;
        private StringBuilder loading=new StringBuilder();
        public PantallaDeCarga(int time, Thread hilo)
        {
            this._subProceso = hilo;
            InitializeComponent();
            timer1.Interval = time * 1000;

            if (!timer1.Enabled)
                timer1.Enabled = true;

            timer1.Tick += Timer1_Tick;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            LabelVersion.Text = fvi.FileVersion;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            if (_subProceso.IsAlive)
            {
                // Una vez transcurrido el tiempo inicialmente establecido
                // establezco un intervalo de un segundo para mirar si el proceso a terminado.

                if (timer1.Interval != 1000)
                {
                    timer1.Interval = 1000;
                    
                }
                else
                {
                    if (loading.Length >= 4)
                        loading.Clear();
                    loading.Append(".");
                    campPoint.Text = loading.ToString();
                }

                timer1.Start();
            }
            else
                this.Close();      // Cerramos el formulario.
        }
    }
}
