using MinLab.Code.ControlSistemaInterno.Configuracion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.PresentationLayer.ComponenteGeneral
{
    class Decorator
    {
        public void FormatButton(ButtonUI but)
        {
            StyleUI temp = null;
            switch (but.Tipo)
            {

                case ButtonUI.ButtonTipo.Cancel:
                    temp = StylesGeneral.ButtonCancel;
                    break;
                case ButtonUI.ButtonTipo.Item:
                    temp = StylesGeneral.ButtonItem;
                    break;
                case ButtonUI.ButtonTipo.Ok:
                    temp = StylesGeneral.ButtonOK;
                    break;
                case ButtonUI.ButtonTipo.Modify:
                    temp = StylesGeneral.ButtonModify;
                    break;
                case ButtonUI.ButtonTipo.Next:
                    temp = StylesGeneral.ButtonNext;
                    break;
                default:
                    temp = StylesGeneral.ButtonDefault;
                    break;
            }

            but.ComponenteUI.Size = temp.Size;
            but.ComponenteUI.FlatAppearance.BorderColor = temp.BordeColor;
            but.ComponenteUI.FlatAppearance.BorderSize = temp.BordeSize;
            but.ComponenteUI.ForeColor = temp.FontColor;
            but.ComponenteUI.Font = new Font(ConfiguracionSystem.Font, temp.FontSize + ConfiguracionSystem.IncrementSize);
            but.ComponenteUI.BackColor = temp.BackGroundNormal;
            but.ComponenteUI.FlatAppearance.MouseDownBackColor = temp.BackGroundLight;
           //17824512

        }


        public void FormatLabel(LabelUI lbl)
        {
            StyleUI temp = null;
            switch (lbl.Tipo)
            {

                case LabelUI.LabelTipo.Titulo:
                    temp = StylesGeneral.LabelTitle;
                    break;
                case LabelUI.LabelTipo.Subtitulo:
                    temp = StylesGeneral.LabelSubtitle;
                    break;
                case LabelUI.LabelTipo.Item:
                    temp = StylesGeneral.LabelItem;
                    break;
                default:
                    temp = StylesGeneral.ButtonDefault;
                    break;
            }

            lbl.ComponenteUI.Size = temp.Size;
            lbl.ComponenteUI.ForeColor = temp.FontColor;
            lbl.ComponenteUI.Font = new Font(ConfiguracionSystem.Font, temp.FontSize + ConfiguracionSystem.IncrementSize);
        
        }
    }
}
