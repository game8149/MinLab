using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno
{
    public class PaletaColor
    {
        
        //Paleta de Colores

        //Botones

        //Select
        static Color cBtnBackSelect = Color.DarkOrange;
        static Color cBtnOverSelect = Color.Orange;
        static Color cBtnBorderSelect = Color.SandyBrown;
        static Color cBtnDownSelect = Color.Khaki;

        //Original
        static Color cBtnOverOriginal = Color.DeepSkyBlue;
        static Color cBtnBackOriginal = Color.DodgerBlue;
        static Color cBtnBorderOriginal = Color.SteelBlue;
        static Color cBtnDownOriginal = Color.LightSkyBlue;

        //-----------------------------------
        




        public static Color BtnSelectBack { get { return cBtnBackSelect; } }
        public static Color BtnSelectOver { get { return cBtnOverSelect; } }
        public static Color BtnSelectBorder { get { return cBtnBorderSelect; } }
        public static Color BtnSelectDown { get { return cBtnDownSelect; } }


        public static Color BtnOriginalBack { get { return cBtnBackOriginal; } }
        public static Color BtnOriginalOver { get { return cBtnOverOriginal; } }
        public static Color BtnOriginalBorder { get { return cBtnBorderOriginal; } }
        public static Color BtnOriginalDown { get { return cBtnDownOriginal; } }

    }
}
