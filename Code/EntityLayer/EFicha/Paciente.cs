using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.EExamen;
using System;
using System.Collections.Generic;

namespace MinLab.Code.EntityLayer.EFicha
{
    public class Paciente : FichaBasica
    {
        private string codigoHC;
        private string dni;
        private DateTime fechaNacimiento;
        private string direccion;
        private Sexo sexo;
        public int IdDistrito { get; set; }

        public int IdSector { get; set; }


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
        
        public Sexo Sexo
        {
            get { return this.sexo; }
            set { this.sexo = value; }
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
       

    }
}
