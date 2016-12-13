using MinLab.Code.EntityLayer.FichaExamen;
using System;
using System.Collections.Generic;

namespace MinLab.Code.EntityLayer
{
    public class Paciente
    {
        private int idData;
        private string nombre;
        private string apellido2erno;
        private string apellido1erno;
        private string codigoHC;
        private string dni;
        private DateTime fechaNacimiento;
        private string direccion;
        private int sexo;
        
        public string Dni
        {
            get { return dni; }
            set { this.dni = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { this.direccion = value; }
        }

        public string Nombre
        {
            get{ return nombre; }
            set { this.nombre = value; }
        }
        public string SegundoApellido
        {
            get { return apellido2erno; }
            set { this.apellido2erno = value; }
        }

        public int Genero
        {
            get { return this.sexo; }
            set { this.sexo = value; }
        }

        public string PrimerApellido
        {
            get { return apellido1erno; }
            set { this.apellido1erno = value; }
        }

        public string Historia
        {
            get { return codigoHC; }
            set { this.codigoHC = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }
       

        public int IdData
        {
            get { return this.idData; }
            set { this.idData = value; }
        }

        

    }
}
