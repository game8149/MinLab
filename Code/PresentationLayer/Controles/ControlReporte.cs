using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using MinLab.Code.LogicLayer.LogicaTarifario;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.FichaPlantilla;

namespace MinLab.Code.PresentationLayer.Controles
{
    public partial class ControlReporte : UserControl
    {
        

        public ControlReporte()
        {
            InitializeComponent();

            ComboMes.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().Mes, null);
            ComboMes.DisplayMember = "Value";
            ComboMes.ValueMember = "Key";


            ComboMes1.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().Mes, null);
            ComboMes1.DisplayMember = "Value";
            ComboMes1.ValueMember = "Key";


            ComboCobertura.DataSource = new BindingSource(DiccionarioGeneral.GetInstance().TipoCobertura, null);
            ComboCobertura.DisplayMember = "Value";
            ComboCobertura.ValueMember = "Key";
        }
        
        private System.Data.DataTable ObtenerReporteEdad(int year, int month, int cobertura, int area)
        {
            System.Data.DataTable tablaInterna = new System.Data.DataTable();
            // Configuracion de Tablas
            tablaInterna.Columns.Add("examen", typeof(string));
            tablaInterna.Columns.Add("A", typeof(int));
            tablaInterna.Columns.Add("B", typeof(int));
            tablaInterna.Columns.Add("C", typeof(int));
            tablaInterna.Columns.Add("D", typeof(int));
            tablaInterna.Columns.Add("E", typeof(int));
            tablaInterna.Columns.Add("F", typeof(int));
            tablaInterna.Columns.Add("G", typeof(int));
            tablaInterna.Columns.Add("H", typeof(int));
            tablaInterna.Columns.Add("I", typeof(int));
            tablaInterna.Columns.Add("J", typeof(int));
            tablaInterna.Columns.Add("k", typeof(int));
            tablaInterna.Columns.Add("L", typeof(int));
            tablaInterna.Columns.Add("M", typeof(int));

            try
            {
                LogicaOrden enlaceOrden = new LogicaOrden();

                List<int[]> general = enlaceOrden.ObtenerReporteEdad(cobertura, area, year, month);


                foreach (int[] fila in general)
                {
                    DataRow row = tablaInterna.NewRow();
                    row[0] = Plantillas.GetInstance().GetPlantilla(fila[0]).Nombre;
                    for (int j = 1; j < 14; j++)
                    {
                        row[j] = fila[j];
                    }

                    tablaInterna.Rows.Add(row);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tablaInterna;
        }


        private void BtnExportar_Click(object sender, EventArgs e)
        {
            int cobertura = Convert.ToInt32(ComboCobertura.SelectedValue);
            int mes = Convert.ToInt32(ComboMes.SelectedValue) + 1;
            int ano = Convert.ToInt32(NumUD.Value);

            Microsoft.Office.Interop.Excel.Application objectXL;
            _Workbook objectLibro;
            _Worksheet objectHoja;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                objectXL = new Microsoft.Office.Interop.Excel.Application();
                objectXL.Visible = false;
                Cuenta cuenta = SistemaControl.GetInstance().Sesion.Cuenta;

                //Get a new workbook.
                objectLibro = (Microsoft.Office.Interop.Excel._Workbook)(objectXL.Workbooks.Add(""));

                foreach (int key in DiccionarioGeneral.GetInstance().Area.Keys)
                {
                    objectHoja = (Microsoft.Office.Interop.Excel._Worksheet)objectLibro.Sheets.Add();
                    objectHoja.Name = DiccionarioGeneral.GetInstance().Area[key];
                    objectHoja.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                    objectHoja.PageSetup.Orientation = XlPageOrientation.xlLandscape;

                    //CABECERA INICIO
                    objectHoja.get_Range("A2").Value = "Area:";
                    objectHoja.get_Range("A3").Value = "Responsable:";
                    objectHoja.get_Range("A4").Value = "Año:";
                    objectHoja.get_Range("A5").Value = "Mes:";
                    objectHoja.get_Range("A6").Value = "Cobertura:";
                    objectHoja.get_Range("A2", "A6").Font.Bold = true;
                    
                    objectHoja.get_Range("B2", "E6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    objectHoja.get_Range("B2", "E6").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    objectHoja.get_Range("B2", "E2").Merge();
                    objectHoja.get_Range("B3", "E3").Merge();
                    objectHoja.get_Range("B4", "E4").Merge();
                    objectHoja.get_Range("B5", "E5").Merge();
                    objectHoja.get_Range("B6", "E6").Merge();
                    
                    objectHoja.get_Range("B2", "E2").Value = DiccionarioGeneral.GetInstance().Area[key];
                    objectHoja.get_Range("B3", "E3").Value = cuenta.Nombre + " " + cuenta.Apellidos;
                    objectHoja.get_Range("B4", "E4").Value = NumUD.Value;
                    objectHoja.get_Range("B5", "E5").Value = DiccionarioGeneral.GetInstance().Mes[(int)ComboMes.SelectedValue];
                    objectHoja.get_Range("B6", "E6").Value = DiccionarioGeneral.GetInstance().TipoCobertura[(int)ComboCobertura.SelectedValue];
                    
                    objectHoja.get_Range("A8", "N8").Font.Bold = true;
                    objectHoja.get_Range("A8", "N8").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    objectHoja.get_Range("A8", "N8").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    
                    objectHoja.get_Range("A8").Value = "Examen";
                    objectHoja.get_Range("B8").Value = "Recien Nac.";
                    objectHoja.get_Range("C8").Value = "<1 año";
                    objectHoja.get_Range("D8").Value = ">1 - 10";
                    objectHoja.get_Range("E8").Value = ">10 - 20";
                    objectHoja.get_Range("F8").Value = ">20 - 30";
                    objectHoja.get_Range("G8").Value = ">30 - 40";
                    objectHoja.get_Range("H8").Value = ">40 - 50";
                    objectHoja.get_Range("I8").Value = ">50 - 60";
                    objectHoja.get_Range("J8").Value = ">60 - 70";
                    objectHoja.get_Range("K8").Value = ">70 - 80";
                    objectHoja.get_Range("L8").Value = ">80 - 90";
                    objectHoja.get_Range("M8").Value = ">90 - 100";
                    objectHoja.get_Range("N8").Value = ">100 años";
                    //CABECERA FIN

                    //CUERPO INICIO
                    System.Data.DataTable tabla = ObtenerReporteEdad(ano, mes, cobertura, key);
                    int i = 9, j;
                    foreach (DataRow r in tabla.Rows)
                    {
                        j = 65;
                        foreach (object o in r.ItemArray)
                        {
                            objectHoja.get_Range(((char)j).ToString() + i).Value = o;
                            j++;
                        }
                        i++;
                    }

                    Range SourceRange = objectHoja.get_Range("A8", "N" + (i - 1));
                    objectHoja.get_Range("B8", "N" + (i - 1)).Font.Bold = true;
                    objectHoja.get_Range("B8", "N" + (i - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    objectHoja.get_Range("B8", "N" + (i - 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    ListObject objectTable = SourceRange.Worksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange, SourceRange, System.Type.Missing, XlYesNoGuess.xlYes, System.Type.Missing);
                    objectTable.Name = "T" + DiccionarioGeneral.GetInstance().Area[key];
                    SourceRange.Select();
                    SourceRange.Worksheet.ListObjects["T" + DiccionarioGeneral.GetInstance().Area[key]].TableStyle = "TableStyleLight9";
                }
                
                objectXL.UserControl = false;
                DialogFolderBuscar.ShowDialog();

                if (DialogFolderBuscar.SelectedPath != null)
                {
                    objectLibro.SaveAs(DialogFolderBuscar.SelectedPath + "\\ReporteEdad" + DateTime.Now.Month + DateTime.Now.Year + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                        false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                objectLibro.Close();
                objectXL.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objectXL = null;
            }
        }

        private void BtnExportar1_Click(object sender, EventArgs e)
        {

            int mes = Convert.ToInt32(ComboMes.SelectedValue) + 1;
            int ano = Convert.ToInt32(NumUD.Value);

            Microsoft.Office.Interop.Excel.Application objectXL;
            _Workbook objectLibro;
            _Worksheet objectHoja;
            Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                objectXL = new Microsoft.Office.Interop.Excel.Application();
                objectXL.Visible = false;
                Cuenta cuenta = SistemaControl.GetInstance().Sesion.Cuenta;

                //Get a new workbook.
                objectLibro = (Microsoft.Office.Interop.Excel._Workbook)(objectXL.Workbooks.Add(""));

                foreach (int key in DiccionarioGeneral.GetInstance().Area.Keys)
                {
                    objectHoja = (Microsoft.Office.Interop.Excel._Worksheet)objectLibro.Sheets.Add();
                    objectHoja.Name = DiccionarioGeneral.GetInstance().Area[key];
                    objectHoja.PageSetup.PaperSize = XlPaperSize.xlPaperA4;
                    objectHoja.PageSetup.Orientation = XlPageOrientation.xlLandscape;

                    //CABECERA INICIO
                    objectHoja.get_Range("A2").Value = "Area:";
                    objectHoja.get_Range("A3").Value = "Responsable:";
                    objectHoja.get_Range("A4").Value = "Año:";
                    objectHoja.get_Range("A5").Value = "Mes:";
                    objectHoja.get_Range("A2", "A5").Font.Bold = true;


                    objectHoja.get_Range("B2", "E5").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    objectHoja.get_Range("B2", "E5").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    objectHoja.get_Range("B2", "E2").Merge();
                    objectHoja.get_Range("B3", "E3").Merge();
                    objectHoja.get_Range("B4", "E4").Merge();
                    objectHoja.get_Range("B5", "E5").Merge();


                    objectHoja.get_Range("B2", "E2").Value = DiccionarioGeneral.GetInstance().Area[key];
                    objectHoja.get_Range("B3", "E3").Value = cuenta.Nombre + " " + cuenta.Apellidos;
                    objectHoja.get_Range("B4", "E4").Value = NumUD.Value;
                    objectHoja.get_Range("B5", "E5").Value = DiccionarioGeneral.GetInstance().Mes[(int)ComboMes.SelectedValue];


                    objectHoja.get_Range("A7", "I7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    objectHoja.get_Range("A7", "I7").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    objectHoja.get_Range("A7").Value = "Examen";
                    objectHoja.get_Range("B7").Value = "Total PAR";
                    objectHoja.get_Range("C7").Value = "Acum. PAR";
                    objectHoja.get_Range("D7").Value = "Total SIS";
                    objectHoja.get_Range("E7").Value = "Acum. SIS";
                    objectHoja.get_Range("F7").Value = "Total EXO";
                    objectHoja.get_Range("G7").Value = "Acum. EXO";
                    objectHoja.get_Range("H7").Value = "Total Mes";
                    objectHoja.get_Range("I7").Value = "Avance Anual";
                    //CABECERA FIN

                    //CUERPO INICIO
                    System.Data.DataTable tabla = ObtenerReporte(ano, mes, key);
                    int i = 8, j;
                    foreach (DataRow r in tabla.Rows)
                    {
                        j = 65;
                        foreach (object o in r.ItemArray)
                        {
                            Console.WriteLine(((char)j).ToString() + i);
                            objectHoja.get_Range(((char)j).ToString() + i).Value = o;
                            j++;
                        }
                        i++;
                    }

                    Range SourceRange = objectHoja.get_Range("A7", "I" + (i - 1));
                    objectHoja.get_Range("B8", "I" + (i - 1)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    objectHoja.get_Range("B8", "I" + (i - 1)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    ListObject objectTable = SourceRange.Worksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange, SourceRange, System.Type.Missing, XlYesNoGuess.xlYes, System.Type.Missing);
                    objectTable.Name = "T" + DiccionarioGeneral.GetInstance().Area[key];
                    SourceRange.Select();
                    SourceRange.Worksheet.ListObjects["T" + DiccionarioGeneral.GetInstance().Area[key]].TableStyle = "TableStyleLight9";

                    objectHoja.get_Range("A" + (i + 2)).Value = "Total de Examenes: ";
                    objectHoja.get_Range("B" + (i + 2)).Formula = "=SUM(" + "B8:B" + (i - 1) + ")";
                    objectHoja.get_Range("C" + (i + 2)).Formula = "=SUM(" + "C8:C" + (i - 1) + ")";
                    objectHoja.get_Range("D" + (i + 2)).Formula = "=SUM(" + "D8:D" + (i - 1) + ")";
                    objectHoja.get_Range("E" + (i + 2)).Formula = "=SUM(" + "E8:E" + (i - 1) + ")";
                    objectHoja.get_Range("F" + (i + 2)).Formula = "=SUM(" + "F8:F" + (i - 1) + ")";
                    objectHoja.get_Range("G" + (i + 2)).Formula = "=SUM(" + "G8:G" + (i - 1) + ")";
                    objectHoja.get_Range("H" + (i + 2)).Formula = "=SUM(" + "H8:H" + (i - 1) + ")";
                    objectHoja.get_Range("I" + (i + 2)).Formula = "=SUM(" + "I8:I" + (i - 1) + ")";


                    Console.WriteLine("A" + (i + 2));
                    Console.WriteLine("B" + (i + 2), "I" + (i + 2));
                    objectHoja.get_Range("A" + (i + 2)).Font.Bold = true;
                    objectHoja.get_Range("B" + (i + 2), "I" + (i + 2)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    objectHoja.get_Range("B" + (i + 2), "I" + (i + 2)).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                }

                objectXL.Visible = false;
                objectXL.UserControl = false;
                DialogFolderBuscar.ShowDialog();

                if (DialogFolderBuscar.SelectedPath != null)
                {
                    objectLibro.SaveAs(DialogFolderBuscar.SelectedPath + "\\ReporteMensual" + DateTime.Now.Month + DateTime.Now.Year + ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                        false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    MessageBox.Show("guardado");
                }
                objectLibro.Close();
                objectXL.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objectXL = null;
            }
        }


        public bool existDataInDictionary(int id, Dictionary<int, int> dict)
        {
            foreach (int key in dict.Keys)
                if (key == id) return true;
            return false;
        }

        private System.Data.DataTable ObtenerReporte(int ano, int mes, int area)
        {

            System.Data.DataTable tablaInterna = new System.Data.DataTable();
            try
            {
                LogicaOrden enlaceOrden = new LogicaOrden();
                List<int> codigosExamen = new List<int>();

                foreach (Plantilla p in Plantillas.GetInstance().Coleccion().Values)
                    if (area == p.Area)//
                        codigosExamen.Add(p.IdDataPlantilla);

                Dictionary<int, Dictionary<int, int>> reporteAcumulado = enlaceOrden.ObtenerReporteAcumuladoMensual(area, ano, mes);

                Dictionary<int, Dictionary<int, int>> reporteCantidad = enlaceOrden.ObtenerReporteCantidadMensual(area, ano, mes);

                tablaInterna.Columns.Add("nombre", typeof(string));
                tablaInterna.Columns.Add("nroP", typeof(int));
                tablaInterna.Columns.Add("acuP", typeof(int));
                tablaInterna.Columns.Add("nroS", typeof(int));
                tablaInterna.Columns.Add("acuS", typeof(int));
                tablaInterna.Columns.Add("nroE", typeof(int));
                tablaInterna.Columns.Add("acuE", typeof(int));
                tablaInterna.Columns.Add("totalMes", typeof(int));
                tablaInterna.Columns.Add("cob", typeof(int));

                foreach (int idExamen in codigosExamen)
                {
                    DataRow row = tablaInterna.NewRow();
                    row[0] = Plantillas.GetInstance().GetPlantilla(idExamen).Nombre;

                    row[1] = (existDataInDictionary(idExamen, reporteCantidad[0]) ? reporteCantidad[0][idExamen] : 0);//contador P
                    row[2] = (existDataInDictionary(idExamen, reporteAcumulado[0]) ? reporteAcumulado[0][idExamen] : 0);//acumulador P

                    row[3] = (existDataInDictionary(idExamen, reporteCantidad[1]) ? reporteCantidad[1][idExamen] : 0);// Contador S
                    row[4] = (existDataInDictionary(idExamen, reporteAcumulado[1]) ? reporteAcumulado[1][idExamen] : 0);//acumulador S

                    row[5] = (existDataInDictionary(idExamen, reporteCantidad[2]) ? reporteCantidad[2][idExamen] : 0);//Contador Ex
                    row[6] = (existDataInDictionary(idExamen, reporteAcumulado[2]) ? reporteAcumulado[2][idExamen] : 0);//acumulador Ex

                    row[7] = (int)row[1] + (int)row[3] + (int)row[5];
                    row[8] = (int)row[1] + (int)row[3] + (int)row[5] + (int)row[2] + (int)row[4] + (int)row[6];

                    tablaInterna.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tablaInterna;
        }
        

    }
}
