using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MinLab.Code.EntityLayer.EExamen
{
    public class Examen
    {
        
        private int idData;
        private int idPlantilla;
        private int idOrdenDetalle;
        private DateTime fechaRegistro;
        private DateTime fechaFinalización;
        private DateTime ultimaModificacion;
        private Dictionary<int, ExamenDetalle> detallesByItem;
        
        private EstadoExamen estado;


        public enum EstadoExamen
        {
            EnProceso = 0,
            Terminado = 1
        }

        public int IdData
        {
            get { return idData; }
            set { this.idData = value; }
        }

        public int IdCuenta
        {
            get;
            set;
        }

        public int IdPlantilla
        {
            get { return idPlantilla; }
            set { this.idPlantilla = value; }
        }

        public EstadoExamen Estado
        {
            get { return estado; }
            set { this.estado = value; }
        }

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { this.fechaRegistro = value; }
        }

        public DateTime UltimaModificacion
        {
            get { return ultimaModificacion; }
            set { this.ultimaModificacion = value; }
        }
        

        public DateTime FechaFinalizado
        {
            get { return fechaFinalización; }
            set { this.fechaFinalización = value; }
        }

        public int IdOrdenDetalle
        {
            get { return idOrdenDetalle; }
            set { this.idOrdenDetalle = value; }
        }

        public Dictionary<int,ExamenDetalle> DetallesByItem
        {
            get { return detallesByItem; }
            set { this.detallesByItem = value; }
        }

    }
}
