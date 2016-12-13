using MinLab.Code.EntityLayer.FichaOrden;
using MinLab.Code.EntityLayer.FichaExamen;
using System;
using System.Collections.Generic;
using static MinLab.Code.EntityLayer.FichaOrden.Orden;
using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.FichaReporte;
using MinLab.Code.ControlSistemaInterno;

namespace MinLab.Code.LogicLayer.LogicaTarifario
{
    public class LogicaOrden
    {
        // RECUPERAR ORDEN

        public Orden ObtenerOrden(int Id)
        {
            DataOrden enlaceOrden = new DataOrden();
            return enlaceOrden.ObtenerOrdenFromBD(Id);
        }



        public Dictionary<int, Orden> ObtenerOrdenesByPacienteByFechaByEstado(Paciente paciente, DateTime init, DateTime end, EstadoOrden estado)
        {
            DataOrden enlaceOrden = new DataOrden();
            return enlaceOrden.GetAllOrdenByPacienteByFechaByEstado(paciente, init, end,estado);
        }

        public Dictionary<int, Orden> ObtenerOrdenesByFechaByEstado(DateTime init, DateTime end,EstadoOrden estado)
        {
            DataOrden enlaceOrden = new DataOrden();
            return enlaceOrden.GetAllOrdenByFechaByEstado(init, end,estado);
        }


        public Dictionary<int, Dictionary<int, int>> ObtenerReporteAcumuladoMensual(int idArea, int año, int mes)
        {
            DataOrden enlaceOrden = new DataOrden();
            /// 3 diccionarios INDEXDOS por cada cobertura
            Dictionary<int, Dictionary<int,int>> porCobertura = new Dictionary<int, Dictionary<int, int>>();

            foreach (int cobertura in DiccionarioGeneral.GetInstance().TipoCobertura.Keys)
            {
                porCobertura.Add(cobertura, enlaceOrden.GetReporteAcumuladoFromDB(cobertura, idArea, año, mes));
            }

            return porCobertura;
        }

        public Dictionary<int, Dictionary<int, int>> ObtenerReporteCantidadMensual(int idArea, int año, int mes)
        {
            DataOrden enlaceOrden = new DataOrden();
            /// 3 diccionarios INDEXDOS por cada cobertura
            Dictionary<int, Dictionary<int, int>> porCobertura = new Dictionary<int, Dictionary<int, int>>();

            foreach (int cobertura in DiccionarioGeneral.GetInstance().TipoCobertura.Keys)
            {
                porCobertura.Add(cobertura, enlaceOrden.GetReporteCantidadFromDB(cobertura, idArea, año, mes));
            }

            return porCobertura;
        }

        public List<int[]> ObtenerReporteEdad(int cobertura, int idArea, int año, int mes)
        {
            DataOrden enlaceOrden = new DataOrden();
            return enlaceOrden.GetReporteEdadFromDB(cobertura, idArea, año, mes);
        }

        public string ObtenerDescripcion(Orden orden)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (OrdenDetalle det in orden.Detalle.Values)
                builder.Append("- ").Append(Tarifario.GetInstance().Paquetes[det.IdDataPaquete].Nombre).Append("\n ");
            return builder.ToString();
        }

        //OPERACIONES DE ORDEN

        public void AgregarOrden(Orden orden)
        {
            DataOrden enlaceOrden = new DataOrden();
            LogicaExamen.LogicaExamen enlaceExamen = new LogicaExamen.LogicaExamen();
            orden.Estado = EstadoOrden.EnProceso;
            int id=enlaceOrden.CrearOrdenToBD(orden);
            orden = this.ObtenerOrden(id); // Orden actualizada con ordenes
            enlaceExamen.GenerarExamenes(orden);
            Dictionary<int,Examen> examenes=enlaceExamen.RecuperarExamenes(orden);
            ActualizarOrden(examenes,orden);
        }

        public void ActualizarOrden(Orden orden)
        {
            DataOrden enlaceOrden = new DataOrden();
            enlaceOrden.ActualizarOrdenCabeceraFromBD(orden);
        }
        
        public bool ActualizarOrden(Dictionary<int, Examen> examenes, Orden orden)
        {
            int countExamTerminadas = 0;
            foreach (Examen ex in examenes.Values)
            {
                if (ex.Estado == Examen.EstadoExamen.Terminado)
                    countExamTerminadas++;
            }
            if (countExamTerminadas == examenes.Count)
                orden.Estado = EstadoOrden.Finalizado;
            else
                orden.Estado = EstadoOrden.EnProceso;
            ActualizarOrden(orden);
            return true;
        }
        
        public void EliminarOrden(Orden orden)
        {
            //ADVERTENCIA ---  SI USAN ESTE METODO SE ELIMINARAN TODOS LOS ARCHIVOS (EXAMEN y ORDEN DETALLES) REFERENCIADOS DE ESTA 
            DataOrden enlaceOrden = new DataOrden();
            enlaceOrden.EliminarOrdenFromBD(orden);
        }

        //OPERACIONES DE ORDEN DETALLE CON ORDEN EXISTENTE
        public void ActualizarOrdenDetalle(Orden orden)
        {
            DataOrden enlaceOrden = new DataOrden();
            enlaceOrden.ActualizarOrdenDetalleFromBD(orden);
        }

        public void EliminarOrdenDetalle(Orden orden)
        {
            if (orden.Detalle.Count > 0)
            {
                DataOrden enlaceOrden = new DataOrden();
                enlaceOrden.EliminarOrdenDetalleFromBD(orden);
            }
        }

        public void AgregarOrdenDetalle(Orden orden)
        {
            if (orden.Detalle.Count > 0)
            {
                DataOrden enlaceOrden = new DataOrden();
                LogicaExamen.LogicaExamen enlaceExamen = new LogicaExamen.LogicaExamen();
                enlaceOrden.AgregarOrdenDetalleFromBD(orden);
                orden = enlaceOrden.ObtenerOrdenFromBD(orden.IdData);
                enlaceExamen.GenerarExamenes(orden);
                Dictionary<int, Examen> examenes = enlaceExamen.RecuperarExamenes(orden);
                ActualizarOrden(examenes, orden);
            }
        }


    }
}
