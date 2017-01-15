using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.EntityLayer.FormatoImpresionComponentes
{
    public class FormatoImpresionCabecera
    {
        private string institucion;
        private string direccion;
        private string codigoOrden;
        private string nombrePaciente;
        private string edadPaciente;
        private string fechaEmite;
        private string responsable;
        private string hcPaciente;
        private string doctor;
        private string estado;
        private string area;
        private int numero;

        public FormatoImpresionCabecera()
        {
            institucion = "CENTRO DE SALUD WICHANZAO";
            direccion = "Mz. 33 - Lote 2 - Sector 2 - Tel. 270307";
            codigoOrden = "Orden:   ";
            hcPaciente = "Historia: ";
            area = "Laboratorio:    ";
            edadPaciente = "Edad:   ";
            nombrePaciente = "Paciente: ";
            fechaEmite = "Emision:  " + DateTime.Now.ToShortDateString();
            responsable = "Responsable: ";
            estado = "Ult. Rev:   ";
            doctor = "Solicita:   ";
        }

        public string Institucion
        {
            get { return institucion; }
            set { this.institucion = value; }
        }

        public string Responsable
        {
            get { return responsable; }
            set { this.responsable += value; }
        }

        public string Doctor
        {
            get { return doctor; }
            set { this.doctor += value; }
        }

        public string UltimaRev
        {
            get { return estado; }
            set { this.estado += value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { this.direccion = value; }
        }

        public string Nombre
        {
            get { return nombrePaciente; }
            set { this.nombrePaciente += value; }
        }
        public string Edad
        {
            get { return edadPaciente; }
            set { this.edadPaciente += value; }
        }
        public string Historia
        {
            get { return hcPaciente; }
            set { this.hcPaciente += value; }
        }
        public string Area
        {
            get { return area; }
            set { this.area = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { this.numero = value; }
        }
        public string Fecha
        {
            get { return fechaEmite; }
        }

        public string Orden
        {
            get { return codigoOrden; }
            set { this.codigoOrden += value; }
        }

    }
}
