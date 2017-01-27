using MinLab.Code.ControlSistemaInterno.Configuracion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.ControlSistemaInterno
{
    public class FormPersonalizable: Form
    {

        public void CambiarFuente(Control c)
        {
            if (c.Controls.Count == 0)
            {
                c.Font = new System.Drawing.Font(ConfiguracionSystem.Font,c.Font.Size+ConfiguracionSystem.IncrementSize);
            }
            else
                foreach (Control con in c.Controls)
                {
                    CambiarFuente(con);
                }
            return;
        }
        
    }
}
