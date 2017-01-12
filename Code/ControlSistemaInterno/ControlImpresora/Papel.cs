using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno.ControlImpresora
{
    public class Sector
    {
        public SectorConfiguracion Configuracion;

        public Point Inicio;
        public Point Limite;

        public int Cabezal;

        public Sector()
        {
            Configuracion = new SectorConfiguracion();
            Configuracion.Sangria = 3;
            Configuracion.TamañoPapel = new Size();
            Configuracion.Margen = new System.Windows.Forms.Padding();

            Cabezal = 0;
            Inicio = new Point(0,0);
            Limite = new Point(0,0);
        }
        
        public bool SectorLlenable()
        {
            return Cabezal <= Limite.Y - Configuracion.Margen.Bottom;
        }

        public void ActualizarPosicion(int sector)
        {
            Cabezal = 0;
            switch (sector)
            {
                case 1:
                    Inicio.X = 0;
                    Inicio.Y = 0;

                    Limite.X = Configuracion.TamañoPapel.Width / 2;
                    Limite.Y = Configuracion.TamañoPapel.Height / 2;
                    break;
                case 2:
                    Inicio.X = Configuracion.TamañoPapel.Width / 2;
                    Inicio.Y = 0;

                    Limite.X = Configuracion.TamañoPapel.Width;
                    Limite.Y = Configuracion.TamañoPapel.Height / 2;
                    break;
                case 3:
                    Inicio.X = 0;
                    Inicio.Y = Configuracion.TamañoPapel.Height / 2;

                    Limite.X = Configuracion.TamañoPapel.Width / 2;
                    Limite.Y = Configuracion.TamañoPapel.Height;
                    break;
                case 4:
                    Inicio.X = Configuracion.TamañoPapel.Width / 2;
                    Inicio.Y = Configuracion.TamañoPapel.Height / 2;

                    Limite.X = Configuracion.TamañoPapel.Width;
                    Limite.Y = Configuracion.TamañoPapel.Height;
                    break;
            }
        }
    }
}
