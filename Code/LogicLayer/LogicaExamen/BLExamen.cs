using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.EExamen;
using MinLab.Code.EntityLayer.EPlantilla;
using MinLab.Code.LogicLayer.BLPrueba;
using System;
using System.Collections.Generic;

using MinLab.Code.DataLayer;
using MinLab.Code.ControlSistemaInterno;

namespace MinLab.Code.LogicLayer.LogicaExamen
{
    public class LogicaExamen
    {

        public void GenerarExamenes(Orden orden)
        {
            Dictionary<int,Examen> examenesPreparados = new Dictionary<int,Examen>();
            Examen examenTemp;
            ExamenDetalle detalle;
            int idTemp = 0;
            foreach (OrdenDetalle detalleOrden in orden.Detalle.Values)
            {
                if (!DataExamen.ExistenExamenes(detalleOrden)) {
                    foreach (int idPlantilla in ListaAnalisis.GetInstance().GetAnalisisById(detalleOrden.IdDataPaquete).PlantillasId)
                    {
                        //Obteniendo Items de Plantilla Id
                        Dictionary<int, PlantillaItem> items = BLPlantilla.GetAllItemsByPlantilla(idPlantilla);

                        examenTemp = new Examen();
                        //Complentado Datos Principales
                        examenTemp.Estado = Examen.EstadoExamen.EnProceso;
                        examenTemp.FechaFinalizado = DateTime.Now;
                        examenTemp.FechaRegistro = DateTime.Now;
                        examenTemp.UltimaModificacion = DateTime.Now;
                        examenTemp.IdOrdenDetalle = detalleOrden.IdData;
                        examenTemp.IdPlantilla = idPlantilla;
                        //examenTemp.DniResponsable = Sesion.GetInstance().Cuenta.Dni;
                        examenTemp.IdData = 0;
                        examenTemp.DetallesByItem = new Dictionary<int, ExamenDetalle>();
                        //Agregando Items a los detalles del examen
                        int indiceTemp = 0;
                        foreach (PlantillaItem item in items.Values)
                        {
                            detalle = new ExamenDetalle();
                            detalle.IdItem = item.IdData;
                            detalle.Campo = item.PorDefault;
                            examenTemp.DetallesByItem.Add(indiceTemp, detalle);
                            indiceTemp++;
                        }
                        examenesPreparados.Add(idTemp, examenTemp);
                        idTemp++;
                    }
                }
            }
            DataExamen.AddExamen(examenesPreparados);
        }
        
        public Dictionary<int,Examen> RecuperarExamenes(Orden orden)
        {

            Dictionary<int,Examen> examenesRegistrados=null;
            foreach (OrdenDetalle detalleOrden in orden.Detalle.Values)
            {
                if(examenesRegistrados==null)
                    examenesRegistrados=DataExamen.GetExamenesByOrdenDetalle(detalleOrden);
                else
                {
                    Dictionary<int,Examen> registroTemp=  DataExamen.GetExamenesByOrdenDetalle(detalleOrden);
                    foreach(Examen exa in registroTemp.Values)
                    {
                        examenesRegistrados.Add(exa.IdData,exa);
                    }
                }
            }
            return examenesRegistrados;
        }
        

        public bool ValidarExamenes(Examen examen)
        {
            Clasificador clas = new Clasificador();
            clas.Controlar(examen);

            return true;
        }

        public bool GuardarExamen(Examen ex)
        {
            if(ex.Estado==Examen.EstadoExamen.Terminado)
                ex.FechaFinalizado=DateTime.Now;
                
            DataExamen.GuardarExamen(ex);
            return true;
        }
        
    }
}
