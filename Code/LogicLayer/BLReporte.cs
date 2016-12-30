using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.EntityLayer.ETarifario;
using MinLab.Code.LogicLayer.LogicaTarifario;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinLab.Code.LogicLayer
{
    class BLReporte
    {
        public enum FiltroReporteEconomico{
            General=0,
            Edad=1,
            Medico=2
        }

        public enum FiltroReporteResultados
        {
            General = 0
        }

        public bool GenerarReporteEconomico(FiltroReporteEconomico filt, int year, int month, string @direccion)
        {
            try
            {
                switch (filt)
                {
                    case FiltroReporteEconomico.General:
                        return GenerarExcelReporteEconomicoGeneral(year, month, @direccion);
                    case FiltroReporteEconomico.Edad:
                        return ExportarReporteEconomicoEdad(year, month, @direccion);
                    case FiltroReporteEconomico.Medico:
                        return ExportarReporteEconomicoMedico(year, month, @direccion);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //REPORTE GENERAL
            return false;
        }
        
        public bool GenerarReporteResultados(FiltroReporteResultados filt, int year, int month, string @direccion)
        {
            try
            {
                switch (filt)
                {
                    case FiltroReporteResultados.General:
                        return ExportarReporteResultadoGeneral(year, month, @direccion);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //REPORTE GENERAL
            return false;
        }


        private bool ExportarReporteResultadoGeneral(int year, int month, string @direccion)
        {
            ExcelPackage excel = null;
            string @dir = null;

            if (@direccion != null)
            {
                @dir = @direccion + "\\ReporteResultadoGeneral-" + DiccionarioGeneral.GetInstance().Mes[month - 1] + "-" + year + ".xlsx";
                if (File.Exists(@dir))
                    File.Delete(@dir);

                excel = new ExcelPackage(new FileInfo(@dir));

                ExcelWorksheet hojaActual = null;

                try
                {
                    Cuenta cuenta = SistemaControl.GetInstance().Sesion.Cuenta;

                    hojaActual = excel.Workbook.Worksheets.Add("Reporte Resultado General");
                    hojaActual.PrinterSettings.PaperSize = ePaperSize.A4;
                    hojaActual.PrinterSettings.Orientation = eOrientation.Portrait;

                    //CABECERA INICIO
                    hojaActual.Cells["A3"].Value = "Responsable:";
                    hojaActual.Cells["A4"].Value = "Año:";
                    hojaActual.Cells["A5"].Value = "Mes:";
                    hojaActual.Cells["A2:A5"].Style.Font.Bold = true;


                    hojaActual.Cells["B2:E5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    hojaActual.Cells["B2:E5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    hojaActual.Cells["B3:E3"].Merge = true;
                    hojaActual.Cells["B4:E4"].Merge = true;
                    hojaActual.Cells["B5:E5"].Merge = true;


                    hojaActual.Cells["B3:E3"].Value = cuenta.Nombre + " " + cuenta.PrimerApellido + " " + cuenta.SegundoApellido;
                    hojaActual.Cells["B4:E4"].Value = year;
                    hojaActual.Cells["B5:E5"].Value = DiccionarioGeneral.GetInstance().Mes[month - 1];


                    hojaActual.Cells[7, 1, 7, 12].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    hojaActual.Cells[7, 1, 7, 12].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    
                    hojaActual.Cells[7, 1].Value = "DNI";
                    hojaActual.Cells[7, 2].Value = "Nombre";
                    hojaActual.Cells[7, 3].Value = "Prim. Apellido";
                    hojaActual.Cells[7, 4].Value = "Seg. Apellido";
                    hojaActual.Cells[7, 5].Value = "Edad";
                    hojaActual.Cells[7, 6].Value = "Sexo";
                    hojaActual.Cells[7, 7].Value = "Gestante";
                    hojaActual.Cells[7, 8].Value = "Examen";
                    hojaActual.Cells[7, 9].Value = "Resultado";
                    hojaActual.Cells[7, 10].Value = "Unidad";
                    hojaActual.Cells[7, 11].Value = "Cobertura";
                    hojaActual.Cells[7, 12].Value = "Estado";
                    //CABECERA FIN

                    //CUERPO INICIO
                    System.Data.DataTable tabla = ObtenerTablaFormatoDatosReporteResultado(year, month);
                    int i = 8, j;
                    foreach (DataRow r in tabla.Rows)
                    {
                        j = 1;
                        foreach (object o in r.ItemArray)
                        {
                            hojaActual.Cells[i, j].Value = o;
                            j++;
                        }
                        i++;
                    }

                    ExcelRange rangoTabla = hojaActual.Cells[7, 1, i - 1, 12];
                    rangoTabla.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    rangoTabla.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    string nombreT = "TabGeneral";
                    hojaActual.Tables.Add(rangoTabla, nombreT);
                    hojaActual.Tables[nombreT].TableStyle = OfficeOpenXml.Table.TableStyles.Light9;
                    excel.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;

        }
        
        private bool GenerarExcelReporteEconomicoGeneral(int year, int month, string @direccion)
        {
            ExcelPackage excel = null;
            string @dir = null;

            if (@direccion != null)
            {
                @dir = @direccion + "\\ReporteEconomicoGeneral-" + DiccionarioGeneral.GetInstance().Mes[month - 1] + "-" + year + ".xlsx";
                if (File.Exists(@dir))
                    File.Delete(@dir);

                excel = new ExcelPackage(new FileInfo(@dir));

                ExcelWorksheet hojaActual = null;

                try
                {
                    Cuenta cuenta = SistemaControl.GetInstance().Sesion.Cuenta;

                    System.Data.DataTable tabla = ObtenerTablaFormatoReporteEconomicoGeneral(year, month);
                    

                    hojaActual = excel.Workbook.Worksheets.Add("Reporte General");
                    hojaActual.PrinterSettings.PaperSize = ePaperSize.A4;
                    hojaActual.PrinterSettings.Orientation = eOrientation.Portrait;

                    //CABECERA INICIO
                    hojaActual.Cells["A3"].Value = "Responsable:";
                    hojaActual.Cells["A4"].Value = "Año:";
                    hojaActual.Cells["A5"].Value = "Mes:";
                    hojaActual.Cells["A2:A5"].Style.Font.Bold = true;


                    hojaActual.Cells["B2:E5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    hojaActual.Cells["B2:E5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        
                    hojaActual.Cells["B3:E3"].Merge = true;
                    hojaActual.Cells["B4:E4"].Merge = true;
                    hojaActual.Cells["B5:E5"].Merge = true;

                        
                    hojaActual.Cells["B3:E3"].Value = cuenta.Nombre + " " + cuenta.PrimerApellido + " " + cuenta.SegundoApellido;
                    hojaActual.Cells["B4:E4"].Value = year;
                    hojaActual.Cells["B5:E5"].Value = DiccionarioGeneral.GetInstance().Mes[month-1];


                    hojaActual.Cells[7, 1,7,11].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    hojaActual.Cells["A7:J7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    hojaActual.Cells[7,1].Value = "Codigo";
                    hojaActual.Cells[7,2].Value = "Examen";
                    hojaActual.Cells[7,3].Value = "Particular";
                    hojaActual.Cells[7,4].Value = "Acum. Par";
                    hojaActual.Cells[7,5].Value = "SIS";
                    hojaActual.Cells[7,6].Value = "Acum. SIS";
                    hojaActual.Cells[7,7].Value = "Exonerado";
                    hojaActual.Cells[7,8].Value = "Acum. Exo";
                    hojaActual.Cells[7,9].Value = "Unit.(S/.)";
                    hojaActual.Cells[7,10].Value = "Total Mes(S/.)";
                    hojaActual.Cells[7,11].Value = "Avance";
                    //CABECERA FIN

                    //CUERPO INICIO
                    int i = 8, j;
                    foreach (DataRow r in tabla.Rows)
                    {
                        j = 1;
                        foreach (object o in r.ItemArray)
                        {
                            hojaActual.Cells[i,j].Value = o;
                            j++;
                        }
                        i++;
                    }

                    ExcelRange rangoTabla = hojaActual.Cells[7, 1, i - 1, 11];
                    rangoTabla.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    rangoTabla.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    string nombreT = "TabGeneral";
                    hojaActual.Tables.Add(rangoTabla, nombreT);
                    hojaActual.Tables[nombreT].TableStyle = OfficeOpenXml.Table.TableStyles.Light9;


                    hojaActual.Cells[(i + 1), 2].Value = "Examen";
                    hojaActual.Cells[(i + 1), 3].Value = "Particular";
                    hojaActual.Cells[(i + 1), 4].Value = "Acum. Par";
                    hojaActual.Cells[(i + 1), 5].Value = "SIS";
                    hojaActual.Cells[(i + 1), 6].Value = "Acum SIS";
                    hojaActual.Cells[(i + 1), 7].Value = "Exonerado";
                    hojaActual.Cells[(i + 1), 8].Value = "Acum. Exo";
                    hojaActual.Cells[(i + 1), 10].Value = "Total Mes(S/.)";
                    hojaActual.Cells[(i + 1), 11].Value = "Avance";

                    hojaActual.Cells[(i + 2), 2].Value = "Todos";
                    hojaActual.Cells[(i + 2), 3].Formula = "=SUM(" + "C8:C" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 4].Formula = "=SUM(" + "D8:D" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 5].Formula = "=SUM(" + "E8:E" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 6].Formula = "=SUM(" + "F8:F" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 7].Formula = "=SUM(" + "G8:G" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 8].Formula = "=SUM(" + "H8:H" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 9].Formula = "=SUM(" + "J8:J" + (i - 1) + ")";
                    hojaActual.Cells[(i + 2), 10].Formula = "=SUM(" + "K8:K" + (i - 1) + ")";


                    ExcelRange rangoTablaTotal = hojaActual.Cells[i + 1, 2, (i + 2), 11];
                    rangoTablaTotal.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    rangoTablaTotal.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    string nombreTo = "TTotal";
                    hojaActual.Tables.Add(rangoTablaTotal, nombreTo);
                    hojaActual.Tables[nombreTo].TableStyle = OfficeOpenXml.Table.TableStyles.Light9;

                    excel.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;

        }

        private bool ExportarReporteEconomicoEdad(int year, int month, string @direccion)
        {
            ExcelPackage excel = null;
            string @dir = null;
            if (@direccion != null)
            {

                DateTime first = DateTime.Now;

                @dir = @direccion + "\\ReporteMensualGrupoEtareo-" + DiccionarioGeneral.GetInstance().Mes[month - 1] + "-" + year + ".xlsx";
                if (File.Exists(@dir))
                    File.Delete(@dir);

                excel = new ExcelPackage(new FileInfo(@dir));

                ExcelWorksheet hojaActual = null;

                try
                {
                    Cuenta cuenta = SistemaControl.GetInstance().Sesion.Cuenta;

                    foreach (int cobertura in DiccionarioGeneral.GetInstance().TipoCobertura.Keys)
                    {
                        hojaActual = excel.Workbook.Worksheets.Add(DiccionarioGeneral.GetInstance().TipoCobertura[cobertura]);
                        hojaActual.PrinterSettings.PaperSize = ePaperSize.A4;
                        hojaActual.PrinterSettings.Orientation = eOrientation.Landscape;


                        //CABECERA INICIO
                        hojaActual.Cells["A3"].Value = "Responsable:";
                        hojaActual.Cells["A4"].Value = "Año:";
                        hojaActual.Cells["A5"].Value = "Mes:";
                        hojaActual.Cells["A6"].Value = "Cobertura:";
                        hojaActual.Cells["A3:A6"].Style.Font.Bold = true;


                        hojaActual.Cells["B3:E6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        hojaActual.Cells["B3:E6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;


                        hojaActual.Cells["B3:E3"].Merge = true;
                        hojaActual.Cells["B4:E4"].Merge = true;
                        hojaActual.Cells["B5:E5"].Merge = true;
                        hojaActual.Cells["B6:E6"].Merge = true;

                        hojaActual.Cells["B3:E3"].Value = cuenta.Nombre + " " + cuenta.PrimerApellido + " " + cuenta.SegundoApellido;
                        hojaActual.Cells["B4:E4"].Value = year;
                        hojaActual.Cells["B5:E5"].Value = DiccionarioGeneral.GetInstance().Mes[month-1];
                        hojaActual.Cells["B6:E6"].Value = DiccionarioGeneral.GetInstance().TipoCobertura[cobertura];


                        int it = 4;

                        hojaActual.Cells["A8"].Value = "ID";
                        hojaActual.Cells["B8"].Value = "Examen";
                        hojaActual.Cells["C8"].Value = "< 1 año";

                        for (; it <= 19+3; it++)
                            hojaActual.Cells[8, it].Value = it-3 + " años";

                        for (int ni = 20; ni < 76; ni += 5, it++)
                            hojaActual.Cells[8, it].Value = ni + " - " + (ni + 4) + " años";

                        hojaActual.Cells[8, it].Value = "> 80 años";

                        hojaActual.Cells[8, 1, 8, it].Style.Font.Bold = true;
                        hojaActual.Cells[8, 1, 8, it].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        hojaActual.Cells[8, 1, 8, it].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;


                        //CABECERA FIN

                        //CUERPO INICIO
                        System.Data.DataTable tabla = ObtenerTablaFormatoReporteEdad(year, month, cobertura);
                        int i = 9, j;
                        foreach (DataRow row in tabla.Rows)
                        {
                            j = 1;
                            foreach (object o in row.ItemArray)
                            {
                                hojaActual.Cells[i, j].Value = o;
                                j++;
                            }
                            i++;
                        }
                        ExcelRange rangoTabla = hojaActual.Cells[8, 1, i - 1, it];
                        rangoTabla.Style.Font.Bold = true;
                        rangoTabla.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        rangoTabla.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;


                        string nombreT = "T" + DiccionarioGeneral.GetInstance().TipoCobertura[cobertura].Replace(' ', '_') + DiccionarioGeneral.GetInstance().TipoCobertura[cobertura].Replace(' ', '_');
                        hojaActual.Tables.Add(rangoTabla, nombreT);
                        hojaActual.Tables[nombreT].TableStyle = OfficeOpenXml.Table.TableStyles.Light9;

                    }

                    excel.Save();

                    DateTime second = DateTime.Now;
                    TimeSpan r = (second - first);
                    //MessageBox.Show(r.Milliseconds.ToString());
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            return false;
        }

        private bool ExportarReporteEconomicoMedico(int year, int month, string @direccion)
        {
            ExcelPackage excel = null;
            string @dir = null;

            if (@direccion != null)
            {
                @dir = @direccion + "\\ReporteMensualMedico-" + DiccionarioGeneral.GetInstance().Mes[month - 1] + "-" + year + ".xlsx";
                if (File.Exists(@dir))
                    File.Delete(@dir);

                excel = new ExcelPackage(new FileInfo(@dir));

                ExcelWorksheet hojaActual = null;

                try
                {
                    BLMedico blMed = new BLMedico();
                    Dictionary<int, Medico> dicMedicos = blMed.ObtenerMedicosHabil();
                    Cuenta cuenta = SistemaControl.GetInstance().Sesion.Cuenta;
                    foreach (int key in dicMedicos.Keys)
                    {

                        hojaActual = excel.Workbook.Worksheets.Add(BLMedico.FormatearNombre(dicMedicos[key]));
                        hojaActual.PrinterSettings.PaperSize = ePaperSize.A4;
                        hojaActual.PrinterSettings.Orientation = eOrientation.Portrait;

                        //CABECERA INICIO
                        hojaActual.Cells["A2"].Value = "Profesional:";
                        hojaActual.Cells["A3"].Value = "Coleg./Especial:";
                        hojaActual.Cells["A4"].Value = "Año:";
                        hojaActual.Cells["A5"].Value = "Mes:";
                        hojaActual.Cells["A2:A5"].Style.Font.Bold = true;


                        hojaActual.Cells["B2:E5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        hojaActual.Cells["B2:E5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        hojaActual.Cells["B2:E2"].Merge = true;
                        hojaActual.Cells["B3:E3"].Merge = true;
                        hojaActual.Cells["B4:E4"].Merge = true;
                        hojaActual.Cells["B5:E5"].Merge = true;


                        hojaActual.Cells["B2:E2"].Value = BLMedico.FormatearNombre(dicMedicos[key]);
                        hojaActual.Cells["B3:E3"].Value = dicMedicos[key].Colegiatura+"/"+ dicMedicos[key].Especialidad;
                        hojaActual.Cells["B4:E4"].Value = year;
                        hojaActual.Cells["B5:E5"].Value = DiccionarioGeneral.GetInstance().Mes[month-1];


                        hojaActual.Cells["A7:I7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        hojaActual.Cells["A7:I7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        hojaActual.Cells[7, 1].Value = "Codigo";
                        hojaActual.Cells[7,2].Value = "Examen";
                        hojaActual.Cells[7,3].Value = "Paricular";
                        hojaActual.Cells[7,4].Value = "Acum. Par";
                        hojaActual.Cells[7,5].Value = "SIS";
                        hojaActual.Cells[7,6].Value = "Acum SIS";
                        hojaActual.Cells[7,7].Value = "Exonerado";
                        hojaActual.Cells[7,8].Value = "Acum. Exo";
                        hojaActual.Cells[7,9].Value = "Unit.(S/.)";
                        hojaActual.Cells[7,10].Value = "Total Mes(S/.)";
                        hojaActual.Cells[7,11].Value = "Avance";
                        //CABECERA FIN

                        //CUERPO INICIO
                        System.Data.DataTable tabla = ObtenerTablaFormatoDatosReporteEconomicoMedico(year, month, key);
                        int i = 8, j;
                        foreach (DataRow r in tabla.Rows)
                        {
                            j = 1;
                            foreach (object o in r.ItemArray)
                            {
                                hojaActual.Cells[i,j].Value = o;
                                j++;
                            }
                            i++;
                        }

                        ExcelRange rangoTabla = hojaActual.Cells[7,1,i-1,11];
                        rangoTabla.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        rangoTabla.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        string nombreT = "T" + BLMedico.FormatearNombre(dicMedicos[key]).Replace(' ', '_');
                        hojaActual.Tables.Add(rangoTabla, nombreT);
                        hojaActual.Tables[nombreT].TableStyle = OfficeOpenXml.Table.TableStyles.Light9;

                        
                        hojaActual.Cells[(i + 1), 2].Value = "Examen";
                        hojaActual.Cells[(i + 1), 3].Value = "Particular";
                        hojaActual.Cells[(i + 1), 4].Value = "Acum. Par";
                        hojaActual.Cells[(i + 1), 5].Value = "SIS";
                        hojaActual.Cells[(i + 1), 6].Value = "Acum SIS";
                        hojaActual.Cells[(i + 1), 7].Value = "Exonedado";
                        hojaActual.Cells[(i + 1), 8].Value = "Acum. Exo";
                        hojaActual.Cells[(i + 1), 9].Value = "Total Mes(S/.)";
                        hojaActual.Cells[(i + 1), 10].Value = "Avance";

                        hojaActual.Cells[(i + 2), 2].Value = "Todos";
                        hojaActual.Cells[(i + 2), 3].Formula = "=SUM(" + "C8:C" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 4].Formula = "=SUM(" + "D8:D" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 5].Formula = "=SUM(" + "E8:E" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 6].Formula = "=SUM(" + "F8:F" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 7].Formula = "=SUM(" + "G8:G" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 8].Formula = "=SUM(" + "H8:H" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 9].Formula = "=SUM(" + "J8:J" + (i - 1) + ")";
                        hojaActual.Cells[(i + 2), 10].Formula = "=SUM(" + "K8:K" + (i - 1) + ")";


                        ExcelRange rangoTablaTotal = hojaActual.Cells[i + 1, 2, (i + 2), 10];
                        rangoTablaTotal.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                        rangoTablaTotal.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        string nombreTo = "TTotal" + BLMedico.FormatearNombre(dicMedicos[key]).Replace(' ', '_');
                        hojaActual.Tables.Add(rangoTablaTotal, nombreTo);
                        hojaActual.Tables[nombreTo].TableStyle = OfficeOpenXml.Table.TableStyles.Light9;
                        
                    }


                    excel.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;

        }


        private System.Data.DataTable ObtenerTablaFormatoReporteEdad(int year, int month, int cobertura)
        {
            System.Data.DataTable tablaInterna = new System.Data.DataTable();
            // Configuracion de Tablas
            tablaInterna.Columns.Add("id", typeof(int));
            tablaInterna.Columns.Add("examen", typeof(string));

            for (int i = 0; i <= 19; i++)
                tablaInterna.Columns.Add("c" + i, typeof(int));
            for (int i = 20; i < 76; i += 5)
                tablaInterna.Columns.Add("c" + i, typeof(int));
            tablaInterna.Columns.Add("c80", typeof(int));

            try
            {
                LogicaOrden enlaceOrden = new LogicaOrden();

                List<int[]> general = enlaceOrden.ObtenerReporteEdad(cobertura, year, month);

                foreach (int[] fila in general)
                {
                    DataRow row = tablaInterna.NewRow();
                    row[0] = fila[0];
                    row[1] = ListaAnalisis.GetInstance().Analisis[fila[0]].Nombre;
                    for (int j = 1; j < fila.Length; j++)
                    {
                        row[j+1] = fila[j];
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


        private bool existDataInDictionary(int id, Dictionary<int, int> dict)
        {
            foreach (int key in dict.Keys)
                if (key == id) return true;
            return false;
        }

        private System.Data.DataTable ObtenerTablaFormatoReporteEconomicoGeneral(int ano, int mes)
        {
            BLTarifario enlace = new BLTarifario();
            Tarifario tar=enlace.ObtenerTarifarioPorAno(ano);
            System.Data.DataTable tablaInterna = new System.Data.DataTable();
            if (tar == null) throw new Exception("No existe tarifario para este año");
            try
            {
                LogicaOrden enlaceOrden = new LogicaOrden();
                List<int> codigosExamen = new List<int>();
                

                Dictionary<int, Dictionary<int, int>> reporteAcumulado = enlaceOrden.ObtenerReporteAcumuladoMensual(ano, mes);

                Dictionary<int, Dictionary<int, int>> reporteCantidad = enlaceOrden.ObtenerReporteCantidadMensual(ano, mes);

                tablaInterna.Columns.Add("id", typeof(int));
                tablaInterna.Columns.Add("nombre", typeof(string));
                tablaInterna.Columns.Add("nroP", typeof(int));
                tablaInterna.Columns.Add("acuP", typeof(int));
                tablaInterna.Columns.Add("nroS", typeof(int));
                tablaInterna.Columns.Add("acuS", typeof(int));
                tablaInterna.Columns.Add("nroE", typeof(int));
                tablaInterna.Columns.Add("acuE", typeof(int));
                tablaInterna.Columns.Add("precioUn", typeof(double));
                tablaInterna.Columns.Add("totalMes", typeof(double));
                tablaInterna.Columns.Add("cob", typeof(int));

                foreach (int idAnalisis in ListaAnalisis.GetInstance().Coleccion.Keys)
                {
                    DataRow row = tablaInterna.NewRow();

                    row[0] = idAnalisis;
                    row[1] = ListaAnalisis.GetInstance().Analisis[idAnalisis].Nombre;

                    row[2] = (existDataInDictionary(idAnalisis, reporteCantidad[0]) ? reporteCantidad[0][idAnalisis] : 0);//contador P
                    row[3] = (existDataInDictionary(idAnalisis, reporteAcumulado[0]) ? reporteAcumulado[0][idAnalisis] : 0);//acumulador P

                    row[4] = (existDataInDictionary(idAnalisis, reporteCantidad[1]) ? reporteCantidad[1][idAnalisis] : 0);// Contador S
                    row[5] = (existDataInDictionary(idAnalisis, reporteAcumulado[1]) ? reporteAcumulado[1][idAnalisis] : 0);//acumulador S

                    row[6] = (existDataInDictionary(idAnalisis, reporteCantidad[2]) ? reporteCantidad[2][idAnalisis] : 0);//Contador Ex
                    row[7] = (existDataInDictionary(idAnalisis, reporteAcumulado[2]) ? reporteAcumulado[2][idAnalisis] : 0);//acumulador Ex

                    row[8] = enlace.ObtenerTarifarioDetalle(tar, idAnalisis).Precio;
                    row[9] = (int)row[2] * enlace.ObtenerTarifarioDetalle(tar, idAnalisis).Precio;


                    row[10] = (int)row[2] + (int)row[4] + (int)row[6] + (int)row[3] + (int)row[5] + (int)row[7];

                    tablaInterna.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tablaInterna;
        }

        private System.Data.DataTable ObtenerTablaFormatoDatosReporteEconomicoMedico(int ano, int mes, int idMedico)
        {
            BLTarifario enlace = new BLTarifario();
            Tarifario tar = enlace.ObtenerTarifario();
            System.Data.DataTable tablaInterna = new System.Data.DataTable();
            try
            {
                LogicaOrden enlaceOrden = new LogicaOrden();
                List<int> codigosExamen = new List<int>();


                Dictionary<int, Dictionary<int, int>> reporteAcumulado = enlaceOrden.ObtenerReporteAcumuladoMensual(ano, mes, idMedico);

                Dictionary<int, Dictionary<int, int>> reporteCantidad = enlaceOrden.ObtenerReporteCantidadMensual(ano, mes, idMedico);

                tablaInterna.Columns.Add("id", typeof(int));
                tablaInterna.Columns.Add("nombre", typeof(string));
                tablaInterna.Columns.Add("nroP", typeof(int));
                tablaInterna.Columns.Add("acuP", typeof(int));
                tablaInterna.Columns.Add("nroS", typeof(int));
                tablaInterna.Columns.Add("acuS", typeof(int));
                tablaInterna.Columns.Add("nroE", typeof(int));
                tablaInterna.Columns.Add("acuE", typeof(int));
                tablaInterna.Columns.Add("precioUn", typeof(double));
                tablaInterna.Columns.Add("totalMes", typeof(double));
                tablaInterna.Columns.Add("cob", typeof(int));

                foreach (int idAnalisis in ListaAnalisis.GetInstance().Coleccion.Keys)
                {
                    DataRow row = tablaInterna.NewRow();

                    row[0] = idAnalisis;
                    row[1] = ListaAnalisis.GetInstance().Analisis[idAnalisis].Nombre;

                    row[2] = (existDataInDictionary(idAnalisis, reporteCantidad[0]) ? reporteCantidad[0][idAnalisis] : 0);//contador P
                    row[3] = (existDataInDictionary(idAnalisis, reporteAcumulado[0]) ? reporteAcumulado[0][idAnalisis] : 0);//acumulador P
                
                    row[4] = (existDataInDictionary(idAnalisis, reporteCantidad[1]) ? reporteCantidad[1][idAnalisis] : 0);// Contador S
                    row[5] = (existDataInDictionary(idAnalisis, reporteAcumulado[1]) ? reporteAcumulado[1][idAnalisis] : 0);//acumulador S

                    row[6] = (existDataInDictionary(idAnalisis, reporteCantidad[2]) ? reporteCantidad[2][idAnalisis] : 0);//Contador Ex
                    row[7] = (existDataInDictionary(idAnalisis, reporteAcumulado[2]) ? reporteAcumulado[2][idAnalisis] : 0);//acumulador Ex

                    row[8] = enlace.ObtenerTarifarioDetalle(tar, idAnalisis).Precio;
                    row[9] = (int)row[2] * enlace.ObtenerTarifarioDetalle(tar, idAnalisis).Precio;


                    row[10] = (int)row[2] + (int)row[4] + (int)row[6] + (int)row[3] + (int)row[5] + (int)row[7];

                    tablaInterna.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tablaInterna;
        }

        private System.Data.DataTable ObtenerTablaFormatoDatosReporteResultado(int ano, int mes)
        {
            BLTarifario enlace = new BLTarifario();
            Tarifario tar = enlace.ObtenerTarifario();
            System.Data.DataTable tablaInterna = new System.Data.DataTable();
            try
            {
                LogicaOrden enlaceOrden = new LogicaOrden();
                List<object[]> resultados = enlaceOrden.ObtenerReporteResultado(ano,mes);
                
                tablaInterna.Columns.Add("dni", typeof(string));
                tablaInterna.Columns.Add("nombre", typeof(string));
                tablaInterna.Columns.Add("apellido1", typeof(string));
                tablaInterna.Columns.Add("apellido2", typeof(string));
                tablaInterna.Columns.Add("edad", typeof(double));
                tablaInterna.Columns.Add("sexo", typeof(string));
                tablaInterna.Columns.Add("gestante", typeof(string));
                tablaInterna.Columns.Add("Examen", typeof(string));
                tablaInterna.Columns.Add("respuesta", typeof(string));
                tablaInterna.Columns.Add("nota", typeof(string));
                tablaInterna.Columns.Add("cobertura", typeof(string));
                tablaInterna.Columns.Add("estado", typeof(string));

                foreach (object[] obt in resultados)
                {
                    DataRow row = tablaInterna.NewRow();
                    row[0] = obt[1].ToString();
                    row[1] = obt[2].ToString();
                    row[2] = obt[3].ToString();
                    row[3] = obt[4].ToString();
                    row[4] = obt[5];
                    row[5] = DiccionarioGeneral.GetInstance().TipoSexo[(int)obt[6]];
                    row[6] = Convert.ToBoolean(obt[7])?"SI":"NO";
                    row[7] = Plantillas.GetInstance().GetPlantilla((int)obt[0]).Nombre;
                    row[8] = obt[8].ToString().Replace('.',',');
                    row[9] = obt[9];
                    row[10] = DiccionarioGeneral.GetInstance().TipoCobertura[(int)obt[10]];
                    row[11] = DiccionarioGeneral.GetInstance().EstadoExamen[(int)obt[11]];

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
