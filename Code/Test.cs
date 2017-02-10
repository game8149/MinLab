using MinLab.Code.ControlSistemaInterno;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
           
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LabelImg.Image = ScaleImage(global::MinLab.Properties.Resources.logo_region, TB.Value, TB.Value);
            

            //DiccionarioGeneral.Tiempo tiempo = DiccionarioGeneral.GetInstance().CalcularEdad(DTPicker.Value);
            ////CampEdad.Text = tiempo.Año + ", " + tiempo.Mes + ", " + tiempo.Dias;
            //CampEdad.Text= DiccionarioGeneral.GetInstance().FormatoEdad(tiempo);
            ////string cade = "(select count(*) from Examen ex join OrdenDetalle odi on odi.id = ex.idOrdenDetalle join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and ex.idPlantilla = pl.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) = ";


            //for (int i=1;i<=19 ;i ++)
            //{
            //    Console.WriteLine(cade+i+".0000 ) as c"+i+", ");
            //}

            //string cade2 = "(select count(*) from Examen ex join OrdenDetalle odi on odi.id = ex.idOrdenDetalle join Orden oi on oi.id = odi.idOrden join Paciente pa on pa.id = oi.idPaciente where odi.cobertura = @cobertura and year(oi.fechaRegistro) = @ano and month(oi.fechaRegistro) = @mes and ex.idPlantilla = pl.id and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) >= ";
            //string cade21 = " and dbo.calcularEdad(pa.fechaNacimiento, oi.fechaRegistro) <= ";
            //for (int i = 20; i < 76; i+=5)
            //{
            //    Console.WriteLine(cade2 + i + ".0000 " +cade21+(i+4)+ ".0000) as c"+i+",");
            //}
        }

        private void TB_Scroll(object sender, EventArgs e)
        {
            CampEdad.Text = TB.Value.ToString();
        }
    }
}
