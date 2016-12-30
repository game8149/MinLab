using MinLab.Code.ControlSistemaInterno;
using System;
using System.Collections.Generic;

namespace MinLab.Code.EntityLayer.EOrden
{
    public class Orden
    {
        public enum EstadoOrden
        {
            EnProceso=0,
            Finalizado=1
        }

        private int idData;
        private string codigo;
        private DateTime fechaRegistro;
        private DateTime ultimaModificacion;
        private Dictionary<int,OrdenDetalle> detalle;
        private int idPaciente;
        private EstadoOrden estado;

        public bool EnGestacion { get; set; }

        public int IdMedico { get; set; }

        public int IdConsultorio { get; set; }

        public string Boleta{
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        public int IdData
        {
            get
            {
                return this.idData;
            }
            set
            {
                this.idData = value;
            }
        }

        public int IdPaciente
        {
            get
            {
                return this.idPaciente;
            }
            set
            {
                this.idPaciente = value;
            }
        }

        public EstadoOrden Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }

        }

        public PacienteEstado EstadoPaciente { get; set; }

        public DateTime FechaRegistro
        {
            get
            {
                return this.fechaRegistro;
            }
            set
            {
                this.fechaRegistro = value;
            }
        }

        public DateTime UltimaModificacion
        {
            get
            {
                return this.ultimaModificacion;
            }
            set
            {
                this.ultimaModificacion = value;
            }
        }

        public Dictionary<int,OrdenDetalle> Detalle
        {
            get
            {
                return this.detalle;
            }
            set
            {
                this.detalle = value;
            }
        }


    }
}
