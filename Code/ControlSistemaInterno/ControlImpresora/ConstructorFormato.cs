using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EExamen;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.EntityLayer.FormatoImpresionComponentes;
using MinLab.Code.LogicLayer;
using MinLab.Code.LogicLayer.LogicaPaciente;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Media;
using static MinLab.Code.ControlSistemaInterno.DiccionarioGeneral;

namespace MinLab.Code.ControlSistemaInterno.ControlImpresora
{
    public class ConstructorFicha
    {
        private static ConstructorFicha clasificador = null;
        private StringBuilder cadena = new StringBuilder();
        private Dictionary<Area, List<int>> repositorio;

        public static ConstructorFicha GetInstance()
        {
            if (clasificador == null)
                clasificador = new ConstructorFicha();
            clasificador.LimpiarRepositorio();
            return clasificador;
        }

        private ConstructorFicha()
        {
            Inicializar();
        }

        public void Inicializar()
        {
            repositorio = new Dictionary<Area, List<int>>();
            repositorio.Add(Area.BIOQUIMICA, new List<int>());
            repositorio.Add(Area.ESTUDIODESECRECIONES, new List<int>());
            repositorio.Add(Area.HEMATOLOGIA, new List<int>());
            repositorio.Add(Area.INMUNOLOGIA, new List<int>());
            repositorio.Add(Area.MICROBIOLOGIA, new List<int>());
            repositorio.Add(Area.PARASITOLOGIA, new List<int>());
            repositorio.Add(Area.UROANALISIS, new List<int>());
        }

        public void LimpiarRepositorio()
        {
            repositorio[Area.BIOQUIMICA].Clear();
            repositorio[Area.ESTUDIODESECRECIONES].Clear();
            repositorio[Area.HEMATOLOGIA].Clear();
            repositorio[Area.INMUNOLOGIA].Clear();
            repositorio[Area.MICROBIOLOGIA].Clear();
            repositorio[Area.PARASITOLOGIA].Clear();
            repositorio[Area.UROANALISIS].Clear();

        }

        public static List<string> AcoplarTexto(string text, string fontFamily, float emSize, double pixels)
        {
            string[] originalLines = text.Split(new string[] { " " },
                StringSplitOptions.None);
            List<string> wrappedLines = new List<string>();

            StringBuilder actualLine = new StringBuilder();
            double actualWidth = 0;

            foreach (var item in originalLines)
            {
                FormattedText formatted = new FormattedText(item, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight, new Typeface(fontFamily), emSize, System.Windows.Media.Brushes.Black);
                actualLine.Append(item + " ");
                actualWidth += formatted.Width;

                if (actualWidth > pixels)
                {
                    wrappedLines.Add(actualLine.ToString());
                    actualLine.Clear();
                    actualWidth = 0;
                }
            }

            if (actualLine.Length > 0)
                wrappedLines.Add(actualLine.ToString());



            return wrappedLines;
        }
        
        public FormatoImpresion CrearAllDocumento(Dictionary<int, Examen> examenes, Orden orden, float tamañoFuente, Size tamañoPag)
        {
            LogicaPaciente enlacePaciente = new LogicaPaciente();
            Clasificador clasificador = new Clasificador();
            FormatoImpresion formato;
            tamañoPag.Height = tamañoPag.Height / 2;
            tamañoPag.Width = tamañoPag.Width / 2;
            Paciente paciente = enlacePaciente.ObtenerPerfilPorId(orden.IdPaciente);
            
            int idLastResponsable = 0;
            DateTime tempTime = DateTime.MinValue;
            foreach (Examen ex in examenes.Values)
            {
                Area area = (Area)Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Area;
                repositorio[area].Add(ex.IdData);
                if (ex.UltimaModificacion >= tempTime) {
                    tempTime = ex.UltimaModificacion;
                    idLastResponsable = ex.IdCuenta;
                }
            }
            

            //CONSTRUCCION DE CABECERA 
            formato = new FormatoImpresion();
            FormatoImpresionCabecera cab = new FormatoImpresionCabecera();
            Dictionary<int, FormatoImpresionPagina> paginas = new Dictionary<int, FormatoImpresionPagina>();
            LogicaCuenta oLCuenta = new LogicaCuenta();
            BLMedico oLMedico = new BLMedico();
            Medico med = oLMedico.ObtenerMedico(orden.IdMedico);
            Cuenta cu = oLCuenta.ObtenerCuenta(idLastResponsable);
            Tiempo tiempo = DiccionarioGeneral.GetInstance().CalcularEdad(paciente.FechaNacimiento);
            
            cab.Edad = DiccionarioGeneral.GetInstance().FormatoEdad(tiempo);
            cab.Orden = "No "+orden.IdData;
            cab.Nombre = (paciente.Nombre + " " + paciente.PrimerApellido + " " + paciente.SegundoApellido).ToUpper();
            cab.Historia = paciente.Historia;
            
            cab.Responsable = (cu.Nombre + " " + cu.PrimerApellido + " " + cu.SegundoApellido + " - " + cu.Especialidad);
            cab.Doctor = (med.PrimerApellido + " " + med.SegundoApellido).ToUpper();
            cab.Estado = (orden.EnGestacion? "GESTANTE" : "NORMAL");
            formato.Cabecera = cab;

            Dictionary<int, FormatoImpresionPaginaLinea> lineas=null;
            FormatoImpresionPagina pagina=null;
            FormatoImpresionPaginaLinea linea=null;
            int indexLinea = 0;

            foreach (Area key in repositorio.Keys)
            {
                
                if (repositorio[key].Count > 0)
                {
                    pagina = new FormatoImpresionPagina();
                    lineas = new Dictionary<int, FormatoImpresionPaginaLinea>();
                    pagina.Detalles = lineas;
                    indexLinea = 0;
                    //CONSTRUCCION DE PAGINAS

                    linea = new FormatoImpresionPaginaLinea();
                    linea.Nombre = "LABORATORIO DE " + DiccionarioGeneral.GetInstance().Area[(int)key];
                    linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloArea;

                    lineas.Add(indexLinea, linea);
                    indexLinea++;
                    

                    foreach (int idEx in repositorio[key])
                    {
                        Examen ex = examenes[idEx];
                        linea = new FormatoImpresionPaginaLinea();
                        linea.Nombre = Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Nombre;
                        linea.Resultado = " Rev. " + ex.FechaFinalizado.ToShortDateString();
                        linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloExamen;
                        lineas.Add(indexLinea, linea);
                        indexLinea++;

                        Dictionary<int, PlantillaFila> plantillaFila = Plantillas.GetInstance().GetPlantilla(ex.IdPlantilla).Filas;
                        for (int i = 0; i < plantillaFila.Count; i++)
                        {
                            switch (plantillaFila[i].Tipo)
                            {
                                case PlantillaFila.PlantillaFilaTipo.Agrupada:
                                    
                                    PlantillaFilaGrupo filaGrupo = (PlantillaFilaGrupo)plantillaFila[i];
                                    linea = new FormatoImpresionPaginaLinea();
                                    linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.TituloGrupo;
                                    linea.Nombre = filaGrupo.Nombre;

                                    lineas.Add(indexLinea, linea);
                                    indexLinea++;

                                    if (filaGrupo.IdData == 4)//Para el grupo especial Medicina // Luego se puede mejorar Agregando un elemento deseado incorporandolo 
                                    {
                                        foreach (PlantillaItem itemG in filaGrupo.Items.Values)
                                        {
                                            linea = new FormatoImpresionPaginaLinea();
                                            linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple;
                                            linea.Nombre = " * " + itemG.Nombre;
                                            int indice = Convert.ToInt32(ex.DetallesByItem[itemG.IdData].Campo);
                                            if (indice != 0)
                                            {
                                                linea.Resultado = itemG.OpcionesByIndice[indice];
                                                lineas.Add(indexLinea, linea);
                                                indexLinea++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        foreach (PlantillaItem itemG in filaGrupo.Items.Values)
                                        {
                                            switch (itemG.TipoCampo)
                                            {
                                                case TipoCampo.Input:
                                                    linea = new FormatoImpresionPaginaLinea();
                                                    linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple;
                                                    linea.Nombre = " * " + itemG.Nombre;
                                                    linea.Resultado = ex.DetallesByItem[itemG.IdData].Campo.ToString();
                                                    if (itemG.TieneUnidad)
                                                        linea.Resultado += itemG.Unidad;
                                                    linea.Resultado += clasificador.Clasificar(paciente, ex.IdData, ex.DetallesByItem[itemG.IdData]);
                                                    lineas.Add(indexLinea, linea);
                                                    indexLinea++;
                                                    break;
                                                case TipoCampo.Lista:
                                                    linea = new FormatoImpresionPaginaLinea();
                                                    linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple;
                                                    linea.Nombre = " * " + itemG.Nombre;
                                                    linea.Resultado = itemG.OpcionesByIndice[Convert.ToInt32(ex.DetallesByItem[itemG.IdData].Campo)];
                                                    lineas.Add(indexLinea, linea);
                                                    indexLinea++;
                                                    break;
                                                case TipoCampo.Texto:
                                                    if (!ex.DetallesByItem[itemG.IdData].Campo.Equals(""))
                                                    {
                                                        linea = new FormatoImpresionPaginaLinea();
                                                        linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple;
                                                        linea.Nombre = " * " + itemG.Nombre;
                                                        string temp = "";
                                                        List<string> lista = ConstructorFicha.AcoplarTexto(linea.Nombre + ": " + ex.DetallesByItem[itemG.IdData].Campo.ToString(), "Futura Bk BT", 7.5f, (double)tamañoPag.Width);
                                                        for (int ind = 0; ind < lista.Count; ind++)
                                                        {
                                                            linea = new FormatoImpresionPaginaLinea();
                                                            linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemTexto;

                                                            if (itemG.TieneUnidad && indexLinea + 1 == lista.Count)
                                                                temp += itemG.Unidad;
                                                            linea.Resultado = lista[ind];

                                                            lineas.Add(indexLinea, linea);
                                                            indexLinea++;
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                case PlantillaFila.PlantillaFilaTipo.Simple:
                                    PlantillaItem item = ((PlantillaFilaSimple)plantillaFila[i]).Item;
                                    switch (item.TipoCampo)
                                    {
                                        case TipoCampo.Input:
                                            linea = new FormatoImpresionPaginaLinea();
                                            linea.Nombre = item.Nombre;
                                            linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple;
                                            linea.Resultado = ex.DetallesByItem[item.IdData].Campo.ToString();
                                            if (item.TieneUnidad)
                                                linea.Resultado += "  " + item.Unidad;
                                            switch (item.TipoDato)
                                            {
                                                case TipoDato.Entero:
                                                    linea.Resultado += clasificador.Clasificar(paciente, ex.IdData, ex.DetallesByItem[item.IdData]);
                                                    break;
                                                case TipoDato.Decimal:
                                                    linea.Resultado += clasificador.Clasificar(paciente, ex.IdData, ex.DetallesByItem[item.IdData]);
                                                    break;
                                            }

                                            lineas.Add(indexLinea, linea);
                                            indexLinea++;
                                            break;
                                        case TipoCampo.Lista:

                                            linea = new FormatoImpresionPaginaLinea();
                                            linea.Nombre = item.Nombre;
                                            linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemSimple;
                                            linea.Resultado = item.OpcionesByIndice[Convert.ToInt32(ex.DetallesByItem[item.IdData].Campo)];
                                            lineas.Add(indexLinea, linea);
                                            indexLinea++;
                                            break;
                                        case TipoCampo.Texto:
                                            if (!ex.DetallesByItem[item.IdData].Campo.Equals(""))
                                            {
                                                linea = new FormatoImpresionPaginaLinea();
                                                linea.Nombre = item.Nombre;
                                                string temp = "";
                                                List<string> lista = ConstructorFicha.AcoplarTexto(linea.Nombre + ": " + ex.DetallesByItem[item.IdData].Campo, "Futura Bk BT", 7.5f, (double)tamañoPag.Width);

                                                for (int ind = 0; ind < lista.Count; ind++)
                                                {
                                                    linea = new FormatoImpresionPaginaLinea();
                                                    linea.TipoLinea = FormatoImpresionPaginaLinea.TipoPaginaLinea.ItemTexto;

                                                    if (item.TieneUnidad && ind + 1 == lista.Count)
                                                        temp += item.Unidad;
                                                    linea.Resultado = lista[ind];

                                                    lineas.Add(indexLinea, linea);
                                                    indexLinea++;
                                                }
                                            }
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                    formato.Paginas.Add(pagina);
                }
            }
            return formato;
        }
        


    }
}
