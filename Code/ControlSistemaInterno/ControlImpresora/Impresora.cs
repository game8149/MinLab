using MinLab.Code.EntityLayer.EExamen;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.FormatoImpresionComponentes;
using MinLab.Code.LogicLayer.LogicaExamen;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace MinLab.Code.ControlSistemaInterno.ControlImpresora
{
    public class Impresora
    {
        private BufferImpresion buffer;
        private Sector sector;
        private PrintPreviewDialog printPreviewDialog;

        public void ContruirVistaPreviaExamenPaciente(Orden orden, Dictionary<int, Examen> examenes)
        {
            sector = new Sector();
            
            PrintDocument pd = new PrintDocument();

            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            sector.Configuracion.TamañoPapel.Width = pd.DefaultPageSettings.PaperSize.Width;
            sector.Configuracion.TamañoPapel.Height = pd.DefaultPageSettings.PaperSize.Height;
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

            FormatoImpresion formato;
            List<FormatoImpresion> formatos = new List<FormatoImpresion>();

            formato = ConstructorFicha.GetInstance().CrearAllDocumento(examenes, orden, 7.5f, sector.Configuracion.TamañoPapel);
            formatos.Add(formato);

            buffer = new BufferImpresion(formatos);
            
        }

        public void ContruirVistaPrevia(Dictionary<int,Orden> ordenes)
        {
            LogicaExamen oLExamen = new LogicaExamen();
            sector = new Sector();

            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            sector.Configuracion.TamañoPapel.Width = pd.DefaultPageSettings.PaperSize.Width;
            sector.Configuracion.TamañoPapel.Height = pd.DefaultPageSettings.PaperSize.Height;
            sector.Configuracion.Margen = new Padding(5,5,5,40);

            FormatoImpresion formato;
            List<FormatoImpresion> formatos=new List<FormatoImpresion>();
            foreach (Orden orden in ordenes.Values)
            {
                formato = ConstructorFicha.GetInstance().CrearAllDocumento(oLExamen.RecuperarExamenes(orden), orden,7.5f , sector.Configuracion.TamañoPapel);
                formatos.Add(formato);
            }
            buffer= new BufferImpresion(formatos);

            PrintDialog printdia = new PrintDialog();
            printdia.Document = pd;
            
            if (printdia.ShowDialog() == DialogResult.OK)
            {
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
            }

        }
        
        

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            
            SizeF tamañoTexto= new SizeF();
            Graphics graphics = ev.Graphics;

            int indexSector;
            try
            {
                if (!buffer.EmptyListFormato())
                {
                    if (!buffer.IsModeRead)
                    {
                        buffer.SiguienteFormato();
                        buffer.SiguientePagina();
                        buffer.IsModeRead = true;
                    }

                    for (indexSector = 1; indexSector < 5; indexSector++)
                    {
                        FormatoImpresion formato = buffer.GetFormato();
                        sector.ActualizarPosicion(indexSector);
                        PaintCabecera(formato.Cabecera, graphics, this.sector);

                        FormatoImpresionPagina pagina = buffer.GetPagina();
                        do
                        {
                            if (buffer.SiguienteLinea())
                            {
                                buffer.IsModeRead = true;
                                FormatoImpresionPaginaLinea linea = buffer.GetLinea();
                                switch (linea.TipoLinea)
                                {
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloArea:
                                        tamañoTexto = graphics.MeasureString(linea.Nombre, EstiloFuentePagina.TituloArea);
                                        graphics.DrawString(linea.Nombre, EstiloFuentePagina.TituloArea, Brushes.Black, (this.sector.Inicio.X + this.sector.Limite.X) / 2 - tamañoTexto.Width / 2 + this.sector.Configuracion.Margen.Left, this.sector.Cabezal);
                                        tamañoTexto.Height += 5;//TITULO DE LABORATORIO
                                        break;
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloExamen:
                                        graphics.DrawString(linea.Nombre, EstiloFuentePagina.TituloExamen, Brushes.Black, this.sector.Inicio.X + this.sector.Configuracion.Margen.Left, this.sector.Cabezal);//TITULO DEL EXAMEN
                                        tamañoTexto = graphics.MeasureString(linea.Nombre, EstiloFuentePagina.TituloExamen);
                                        break;
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple:
                                        graphics.DrawString(linea.Nombre + ":  " + linea.Resultado, EstiloFuentePagina.Item, Brushes.Black, this.sector.Inicio.X + this.sector.Configuracion.Margen.Left * 2, this.sector.Cabezal);
                                        tamañoTexto = graphics.MeasureString(linea.Nombre, EstiloFuentePagina.Item);
                                        break;
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemTexto:
                                        graphics.DrawString(linea.Resultado, EstiloFuentePagina.Item, Brushes.Black, this.sector.Inicio.X + this.sector.Configuracion.Margen.Left * 2, this.sector.Cabezal);
                                        tamañoTexto = graphics.MeasureString(linea.Resultado, EstiloFuentePagina.Item);
                                        break;
                                    case FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloGrupo:
                                        graphics.DrawString(linea.Nombre + ":  ", EstiloFuentePagina.TituloGrupo, Brushes.Black, this.sector.Inicio.X + this.sector.Configuracion.Margen.Left, this.sector.Cabezal);

                                        tamañoTexto = graphics.MeasureString(linea.Nombre, EstiloFuentePagina.TituloGrupo);
                                        break;
                                }
                                this.sector.Cabezal += ((int)tamañoTexto.Height + this.sector.Configuracion.Sangria);

                            }
                            else
                            {
                                buffer.IsModeRead = false;
                                if (!buffer.SiguientePagina())
                                {
                                    if (!buffer.SiguienteFormato())
                                    {
                                        indexSector = 5;
                                        break;
                                    }
                                    else
                                    {
                                        buffer.SiguientePagina();
                                        buffer.IsModeRead = true;
                                        break;
                                    }
                                }
                                else {
                                    buffer.IsModeRead = true;
                                    break;
                                }
                            }
                        }
                        while (sector.SectorLlenable());
                    }
                }

                ev.HasMorePages = buffer.IsModeRead;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PaintCabecera(FormatoImpresionCabecera cabecera, Graphics grafico, Sector hoja)
        {
            SizeF tamañoTexto;
            Image imgGR= ScaleImage(global::MinLab.Properties.Resources.logo_regionbn,50,50);
            Image imgMR = ScaleImage(global::MinLab.Properties.Resources.Tratado2,200,200);

            hoja.Cabezal = 0;
            Point pInit = hoja.Inicio;
            Point pLimit = hoja.Limite;

            grafico.DrawImage(imgGR, (pLimit.X -25-imgGR.Width)  , pInit.Y );

            tamañoTexto = grafico.MeasureString(cabecera.Institucion, EstiloFuentePagina.TituloFormato);
            grafico.DrawString(cabecera.Institucion, EstiloFuentePagina.TituloFormato, Brushes.Black, (pInit.X + pLimit.X) / 2 - tamañoTexto.Width / 2, pInit.Y + hoja.Cabezal);
            hoja.Cabezal += ((int)tamañoTexto.Height);

            tamañoTexto = grafico.MeasureString(cabecera.Direccion, EstiloFuentePagina.Item);
            grafico.DrawString(cabecera.Direccion, EstiloFuentePagina.Item, Brushes.Black, (pInit.X + pLimit.X) / 2 - tamañoTexto.Width / 2, pInit.Y + hoja.Cabezal);
            hoja.Cabezal += ((int)tamañoTexto.Height + hoja.Configuracion.Sangria+3);
            
            grafico.DrawString(cabecera.Nombre, EstiloFuentePagina.Item, Brushes.Black, pInit.X, pInit.Y + hoja.Cabezal);
            tamañoTexto = grafico.MeasureString(cabecera.Nombre, EstiloFuentePagina.Item);
            hoja.Cabezal += ((int)tamañoTexto.Height + hoja.Configuracion.Sangria);
            
            tamañoTexto = grafico.MeasureString(cabecera.Orden, EstiloFuentePagina.Item);
            grafico.DrawString(cabecera.Orden, EstiloFuentePagina.Item, Brushes.Black, pInit.X, pInit.Y + hoja.Cabezal);
            grafico.DrawString(cabecera.Fecha, EstiloFuentePagina.Item, Brushes.Black, pInit.X+ ( pLimit.X- pInit.X ) /3 - 30, pInit.Y + hoja.Cabezal);
            grafico.DrawString(cabecera.UltimaRev, EstiloFuentePagina.Item, Brushes.Black, pInit.X + 2*( pLimit.X- pInit.X ) / 3 - 55, pInit.Y + hoja.Cabezal);
            hoja.Cabezal += ((int)tamañoTexto.Height + hoja.Configuracion.Sangria);

            tamañoTexto = grafico.MeasureString(cabecera.Edad, EstiloFuentePagina.Item);
            grafico.DrawString(cabecera.Edad, EstiloFuentePagina.Item, Brushes.Black, pInit.X, pInit.Y + hoja.Cabezal);
            grafico.DrawString(cabecera.Historia, EstiloFuentePagina.Item, Brushes.Black, pInit.X + ( pLimit.X- pInit.X ) / 3 - 30, pInit.Y + hoja.Cabezal);
            grafico.DrawString(cabecera.Doctor, EstiloFuentePagina.Item, Brushes.Black, pInit.X + 2 * ( pLimit.X- pInit.X) / 3 - 55, pInit.Y + hoja.Cabezal);
            hoja.Cabezal += ((int)tamañoTexto.Height + hoja.Configuracion.Sangria);
            
            //DIBUJA LA LINEA SEPARADORA
            Pen pen = new Pen(Color.Black);
            pen.Brush = Brushes.Black;
            pen.Width = 0.6f;
            grafico.DrawLine(pen, new Point(0, hoja.Cabezal + pInit.Y), new Point(pLimit.X - hoja.Configuracion.Margen.Left * 2, pInit.Y + hoja.Cabezal));
            hoja.Cabezal += hoja.Configuracion.Sangria;


            grafico.DrawImage(imgMR, ((pInit.X + pLimit.X ) - imgMR.Size.Width) / 2, ((pInit.Y + hoja.Cabezal) + pLimit.Y - imgMR.Size.Height) /2);
            
            grafico.DrawString(cabecera.Responsable, EstiloFuentePagina.Fecha, Brushes.Black, pInit.X+5, pLimit.Y - 33);

            grafico.DrawLine(pen, new Point(pInit.X, pLimit.Y - 35), new Point(pLimit.X - hoja.Configuracion.Margen.Left -10, pLimit.Y - 35));


            hoja.Cabezal += pInit.Y;
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
        
        



    }
}
