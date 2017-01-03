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
        List<FormatoImpresion> ficheros = new List<FormatoImpresion>();


        // ATRIBUTOS DEL PUNTERO DE IMPRESION
        Point pActual = new Point();
        Point pLimiteActual = new Point();
        int margen = 4;
        int posCabezal = 0;


        Size hojaSize = new Size();
        int spaceV = 1;

        //ATRIBUTOS DE STILO DE HOJA
        Font fontTituloCabecera = new Font("Calibri", 12f, FontStyle.Bold);//Para cabecera Titulo 
        Font fontTitulo = new Font("Calibri", 8f, FontStyle.Bold);//Para cabecera Titulo 
        Font fontSubTitulo = new Font("Calibri", 7.5f, FontStyle.Bold );//Para cabecera Titulo 
        Font fontFechaSub = new Font("Calibri", 7.25f, FontStyle.Regular);//Para cabecera Titulo 
        Font fontItem = new Font("Calibri", 7.35f, FontStyle.Regular);//Para cabecera Titulo 
        Font fontGrupo = new Font("Calibri", 7.45f, FontStyle.Regular);//Para cabecera Titulo 

        Font fontRespuesta = new Font("Calibri", 7.35f, FontStyle.Regular);//Para cabecera Titulo 
        SizeF stringSize = new SizeF();


        PrintPreviewDialog printPreviewDialog;

        public void ContruirVistaPrevia(Dictionary<int,Orden> ordenes)
        {
            BLPaciente enlace = new BLPaciente();
            LogicaExamen enlaceExamen = new LogicaExamen();
            FormatoImpresion fichero;
            PrintDocument pd = new PrintDocument();
            // all sizes are converted from mm to inches & then multiplied by 100.
            hojaSize.Width = pd.DefaultPageSettings.PaperSize.Width;
            hojaSize.Height = pd.DefaultPageSettings.PaperSize.Height;
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

            foreach (Orden orden in ordenes.Values)
            {
                fichero = ConstructorFicha.GetInstance().CrearAllDocumento(enlaceExamen.RecuperarExamenes(orden), orden,7.5f , hojaSize);
                ficheros.Add(fichero);
            }

            this.printPreviewDialog = new PrintPreviewDialog();
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Location = new System.Drawing.Point(29, 29);
            this.printPreviewDialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.printPreviewDialog.Name = "Vista Previa de Impresión";

            printPreviewDialog.Document = pd;
            printPreviewDialog.ClientSize = new Size(1100, 500);
            printPreviewDialog.ShowDialog();
            //PrintDialog printdia = new PrintDialog();
            //printdia.Document = pd;


            //if (printdia.ShowDialog() == DialogResult.OK)
            //{
            //    PrintPreviewControl prControl = new PrintPreviewControl();
            //    pd.Print();
            //}
            //else
            //{
            //    MessageBox.Show("Print Cancelled");
            //}

            indexFicheroActual = 0;
            ficheros.Clear();

        }

        //public void ContruirVistaPreviaExamenPaciente(Dictionary<int, Orden> ordenes,Dictionary<int,Examen> examenes)
        //{
        //    BLPaciente enlace = new BLPaciente();
        //    FormatoImpresion fichero;
        //    PrintDocument pd = new PrintDocument();
            
        //    pd.DefaultPageSettings.PaperSize = new PaperSize("A4", 800, 1100); // all sizes are converted from mm to inches & then multiplied by 100.
        //    hojaSize.Width = pd.DefaultPageSettings.PaperSize.Width;
        //    hojaSize.Height = pd.DefaultPageSettings.PaperSize.Height;
        //    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

        //    foreach (Orden orden in ordenes.Values)
        //    {
        //        fichero = ConstructorFicha.GetInstance().CrearDocumentoSimpleExamen(enlace.ObtenerPerfilPorId(orden.IdPaciente),examenes, orden, hojaSize.Width / 2 - 50);
        //        ficheros.Add(fichero);
        //    }

        //    this.printPreviewDialog = new PrintPreviewDialog();
        //    this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
        //    this.printPreviewDialog.Location = new System.Drawing.Point(29, 29);
        //    this.printPreviewDialog.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        //    this.printPreviewDialog.Name = "Vista Previa de Impresión";


        //    printPreviewDialog.Document = pd;
        //    printPreviewDialog.ShowDialog();
        //    indexFicheroActual = 0;
        //    ficheros.Clear();

        //}

        private int indexFicheroActual = 0;
        private int indexFila = 0;
        private int indexPagActual = 0;
        private bool ficheroActualFinalizado = true;
        private int countPages = 0;


        public FormatoImpresion getFicheroActual()
        {
            return ficheros[indexFicheroActual];
        }

        public FormatoImpresionPagina getPagActual()
        {
            return ficheros[indexFicheroActual].Paginas[indexPagActual];
        }

        public bool existenFicherosRestantes()
        {
            return indexFicheroActual < ficheros.Count;
        }
        

        public bool existenPagRestantesEnFichActual()
        {
            return indexPagActual < ficheros[indexFicheroActual].Paginas.Count;
        }
        

        public bool seleccionarFichActual()
        {
            if (!existenFicherosRestantes())
            {
                return false;
            }
            else
            {
                indexFicheroActual++;
                return true;
            }
        }

        public bool existenLineasEnPaginaActual()
        {
            return indexFila < ficheros[indexFicheroActual].Paginas[indexPagActual].Detalles.Count;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            FormatoImpresionPagina pagActual=null;

            bool parteEsLlenable = true;
            Graphics graphics = ev.Graphics;
            int part;
            // Si se puede seleccionar otro fichero continuar.
            
            for (part = 1; part < 5; part++)
            {
                if (indexFicheroActual >= ficheros.Count)
                {
                    part = 5;
                    ficheroActualFinalizado = true;
                    break; // SE ACABA TODO
                }

                parteEsLlenable = true;
                FormatoImpresion format = getFicheroActual();
                CalcularPuntos(part);
                posCabezal = PaintCabecera(format.Cabecera, graphics, pActual, pLimiteActual);
                //if (pagActualFinalizado)
                //{
                //    indexPagActual++;
                //    indexFila = 0;

                //    if (!existenPagRestantesEnFichActual())
                //    {
                //        ficheroActualFinalizado = true;
                //        indexFicheroActual++;
                //        indexFila = 0;
                //        indexPagActual = 0;

                //        if (indexFicheroActual >= ficheros.Count)
                //        {
                //            part = 5;
                //            ficheroActualFinalizado = false;
                //            break; // SE ACABA TODO
                //        }
                //    }

                //}

                if (!existenPagRestantesEnFichActual())
                {
                    ficheroActualFinalizado = true;
                    indexFicheroActual++;
                    indexFila = 0;
                    indexPagActual = 0;

                    if (indexFicheroActual >= ficheros.Count)
                    {
                        part = 5;
                        ficheroActualFinalizado = false;
                        break; // SE ACABA TODO
                    }
                }

                pagActual = getPagActual();
                do
                {
                    if (existenLineasEnPaginaActual())
                    {
                        FormatoImpresionPaginaLinea linea = pagActual.Detalles[indexFila];
                        switch (linea.TipoLinea)
                        {
                            case FormatoImpresionPaginaLinea.TipoPaginaLinea.Titulo:
                                stringSize = graphics.MeasureString(linea.Nombre, fontTitulo);
                                graphics.DrawString(linea.Nombre, fontTitulo, Brushes.Black, (pActual.X + pLimiteActual.X) / 2 - stringSize.Width / 2 + margen, posCabezal);
                                stringSize.Height += 5;//TITULO DE LABORATORIO
                                break;
                            case FormatoImpresionPaginaLinea.TipoPaginaLinea.SubTitulo:
                                graphics.DrawString(linea.Nombre, fontSubTitulo, Brushes.Black, pActual.X + margen, posCabezal);//TITULO DEL EXAMEN
                                stringSize = graphics.MeasureString(linea.Nombre, fontSubTitulo);
                                graphics.DrawString(linea.Resultado, fontFechaSub, Brushes.Black, pActual.X + margen + stringSize.Width + 2, posCabezal);// FECHA DE REV.
                                break;
                            case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple:
                                graphics.DrawString(linea.Nombre + ":  " + linea.Resultado, fontItem, Brushes.Black, pActual.X + margen * 2, posCabezal);
                                //Console.WriteLine(linea.Nombre + ":  " + linea.Resultado);
                                stringSize = graphics.MeasureString(linea.Nombre, fontItem);
                                break;
                            case FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemTexto:
                                graphics.DrawString(linea.Resultado, fontItem, Brushes.Black, pActual.X + margen * 2, posCabezal);
                                /*Console.WriteLine(linea.Resultado + "  ")*/;
                                stringSize = graphics.MeasureString(linea.Resultado, fontItem);
                                break;
                            case FormatoImpresionPaginaLinea.TipoPaginaLinea.GrupoInicio:
                                graphics.DrawString(linea.Nombre + ":  ", fontGrupo, Brushes.Black, pActual.X + margen, posCabezal);
                                //Console.WriteLine(linea.Nombre + ":  ");
                                stringSize = graphics.MeasureString(linea.Nombre, fontGrupo);
                                break;
                        }
                        posCabezal += ((int)stringSize.Height + spaceV);
                        indexFila++;
                    }
                    else
                    {
                        indexPagActual++;
                        parteEsLlenable = false;
                        if (existenPagRestantesEnFichActual()) // Si no existe paginas restantes en fich actual
                        {
                            ficheroActualFinalizado = false;
                            indexFila = 0;
                        }
                        else
                        {
                            ficheroActualFinalizado = true;
                            indexFicheroActual++;
                            indexFila = 0;
                            indexPagActual = 0;

                            if (indexFicheroActual >= ficheros.Count)
                            {
                                part = 5;
                                ficheroActualFinalizado = false;
                                break;
                            }
                        }

                    }

                    if (posCabezal >= pLimiteActual.Y - 50)
                        parteEsLlenable = false;
                }
                while (parteEsLlenable);
            }
            
            if(ficheroActualFinalizado)
            {
                ev.HasMorePages = false;
                countPages++;
                
            }
            else
            {
                ev.HasMorePages = true;
                countPages++;
            }

            if (countPages == 10) ev.HasMorePages = false;
              
        }


        private int PaintCabecera(FormatoImpresionCabecera cabecera, Graphics grafico, Point actual, Point limit)
        {

            //Image imgGR= ScaleImage(global::MinLab.Properties.Resources.GRLL,75,50);
            Image imgMR = ScaleImage(global::MinLab.Properties.Resources.Tratado2,200,200);

            int lineaPag = 0;
            
            FormatoImpresion format = getFicheroActual();
            
            //grafico.DrawImage(imgGR, (limit.X -25-imgGR.Width)  , actual.Y );
            


            stringSize = grafico.MeasureString(cabecera.Institucion, fontTituloCabecera);
            grafico.DrawString(cabecera.Institucion, fontTituloCabecera, Brushes.Black, (actual.X + limit.X) / 2 - stringSize.Width / 2, actual.Y + lineaPag);
            lineaPag += ((int)stringSize.Height);

            stringSize = grafico.MeasureString(cabecera.Direccion, fontItem);
            grafico.DrawString(cabecera.Direccion, fontItem, Brushes.Black, (actual.X + limit.X) / 2 - stringSize.Width / 2, actual.Y + lineaPag);
            lineaPag += ((int)stringSize.Height + spaceV+3);
            
            grafico.DrawString(cabecera.Nombre, fontItem, Brushes.Black, actual.X, actual.Y + lineaPag);
            stringSize = grafico.MeasureString(cabecera.Nombre, fontItem);
            lineaPag += ((int)stringSize.Height + spaceV+3);
            
            stringSize = grafico.MeasureString(cabecera.Orden, fontItem);
            grafico.DrawString(cabecera.Orden, fontItem, Brushes.Black, actual.X, actual.Y + lineaPag);
            grafico.DrawString(cabecera.Fecha, fontItem, Brushes.Black, (actual.X + limit.X) / 2, actual.Y + lineaPag);
            lineaPag += ((int)stringSize.Height + spaceV+3);

            stringSize = grafico.MeasureString(cabecera.Edad, fontItem);
            grafico.DrawString(cabecera.Edad, fontItem, Brushes.Black, actual.X, actual.Y + lineaPag);
            grafico.DrawString(cabecera.Historia, fontItem, Brushes.Black, (actual.X + limit.X) / 2, actual.Y + lineaPag);
            lineaPag += ((int)stringSize.Height + spaceV+3);
            
            //DIBUJA LA LINEA SEPARADORA
            Pen pen = new Pen(Color.Black);
            pen.Brush = Brushes.Black;
            pen.Width = 0.6f;
            grafico.DrawLine(pen, new Point(0, lineaPag + actual.Y), new Point(limit.X - margen * 2, actual.Y + lineaPag));
            lineaPag += spaceV+3;


            grafico.DrawImage(imgMR, ((actual.X + limit.X ) - imgMR.Size.Width) / 2, ((actual.Y + lineaPag) + limit.Y - imgMR.Size.Height) /2);

            Cuenta cu=SistemaControl.GetInstance().Sesion.Cuenta;
            grafico.DrawString("Responsable: " + cu.Nombre + " " + cu.PrimerApellido + " " + cu.SegundoApellido + " - " + cu.Especialidad, fontFechaSub, Brushes.Black, actual.X+5, limit.Y - 33);

            grafico.DrawLine(pen, new Point(actual.X, limit.Y - 35), new Point(limit.X - margen -10, limit.Y - 35));
            stringSize = grafico.MeasureString("Gracias por su preferencia.", fontFechaSub);
            

            return lineaPag+actual.Y;
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

        private void CalcularPuntos(int pag)
        {
            switch (pag)
            {
                case 1:
                    pActual.X = 0;
                    pActual.Y = 0;

                    pLimiteActual.X = hojaSize.Width / 2;
                    pLimiteActual.Y = hojaSize.Height / 2;
                    break;
                case 2:
                    pActual.X = hojaSize.Width / 2;
                    pActual.Y = 0;

                    pLimiteActual.X = hojaSize.Width;
                    pLimiteActual.Y = hojaSize.Height / 2;
                    break;
                case 3:
                    pActual.X = 0;
                    pActual.Y = hojaSize.Height / 2;

                    pLimiteActual.X = hojaSize.Width / 2;
                    pLimiteActual.Y = hojaSize.Height;
                    break;
                case 4:
                    pActual.X = hojaSize.Width / 2;
                    pActual.Y = hojaSize.Height / 2;

                    pLimiteActual.X = hojaSize.Width;
                    pLimiteActual.Y = hojaSize.Height;
                    break;
            }
        }



    }
}
