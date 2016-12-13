using MinLab.Code.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.ControlSistemaInterno
{
    public class Sesion
    {
        private Cuenta cuentaActual;
        private DateTime horaInicio;
        private bool permiso = false;
        private SesionEstado estado = 0;
        private SesionNivel nivel;

        public enum SesionEstado
        {
            NoLoggin = 0,
            Loggin = 1
        }

        public enum SesionNivel
        {
            Usuario = 1,
            Administrador = 0
        }


        public SesionEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        public SesionNivel Nivel
        {
            get { return this.nivel; }
            set { this.nivel = value; }
        }
        
        public void Login(Cuenta cuenta)
        {
            this.cuentaActual = cuenta;
            horaInicio = DateTime.Now;
        }

        public void Logout()
        {
            this.cuentaActual = null;
            this.horaInicio = DateTime.MinValue;
            this.permiso = false;
        }

        public DateTime HoraInicio
        {
            get { return horaInicio; }
        }

        public Cuenta Cuenta
        {
            get { return cuentaActual; }
            set{
                this.horaInicio = DateTime.Now;
                this.cuentaActual = value;
            }
        }

        public bool Pase { get {return this.permiso; } set {this.permiso=value; } }

    }
}
