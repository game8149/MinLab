using MinLab.Code.DataLayer;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.LogicLayer.LogicaControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MinLab.Code.LogicLayer
{
    class LogicaCuenta
    {

        public bool CrearCuenta(Cuenta cuenta, string autorizacion)
        {
            DataCuenta oDCuenta = new DataCuenta();

            ValidarDatos(cuenta);
            
            if (!autorizacion.Equals(CuentaMaestra.CodigoMaestro))
                throw new Exception("Codigo Maestro Incorrecto");
            

            if (oDCuenta.CheckExistCuenta(cuenta.Dni))
                throw new Exception("Ya existe una cuenta para ese DNI");
            
            cuenta.Nivel = ControlSistemaInterno.Sesion.SesionNivel.Usuario;
            oDCuenta.AddCuenta(cuenta);

            return true;
        }

        private bool ValidarDatos(Cuenta cuenta)
        {
            if (!Regex.IsMatch(cuenta.Dni, "[0-9]+"))
                throw new Exception("DNI: Formato incorrecto");
            
            if (!Regex.IsMatch(cuenta.Clave, "[A-Za-z0-9]+"))
                throw new Exception("Clave: Formato incorrecto");
            
            if (cuenta.Clave.Length < 8)
                throw new Exception("Clave: Debe tener mas de 8 caracteres.");
            if (!Regex.IsMatch(cuenta.Nombre + cuenta.PrimerApellido + cuenta.SegundoApellido, "([A-Za-z]|' ')+"))
                throw new Exception("Nombre y Apellidos: Formato incorrecto");
            
            return true;
        }
        
        public void ActualizarCuenta(Cuenta cuenta)
        {
            LogicControlSistema oLControlSistema = new LogicControlSistema();
            DataCuenta oDCuenta = new DataCuenta();

            ValidarDatos(cuenta);
            
            if (oLControlSistema.GetCuentaLogin().Dni!=cuenta.Dni&&oDCuenta.CheckExistCuenta(cuenta.Dni))
            {
                throw new Exception("Ya existe una cuenta para ese DNI");
            }

            oDCuenta.UpdCuenta(cuenta);

            oLControlSistema.GetCuentaLogin().Dni = cuenta.Dni;
            oLControlSistema.GetCuentaLogin().Nombre = cuenta.Nombre;
            oLControlSistema.GetCuentaLogin().PrimerApellido = cuenta.PrimerApellido;
            oLControlSistema.GetCuentaLogin().SegundoApellido = cuenta.SegundoApellido;
            oLControlSistema.GetCuentaLogin().Especialidad = cuenta.Especialidad;
            oLControlSistema.GetCuentaLogin().CodigoPro = cuenta.CodigoPro;
        }

        public void ActualizarClave(Cuenta cuenta, string nuevaClave,string antiguaClave)
        {
            LogicControlSistema oLControlSistema = new LogicControlSistema();
            DataCuenta oDCuenta = new DataCuenta();

            if (cuenta.Clave.Trim() != antiguaClave.Trim())
                throw new Exception("Contraseña actual incorrecta.");

            if (!Regex.IsMatch(nuevaClave, "[A-Za-z0-9]+"))
                throw new Exception("Clave: Formato incorrecto");
            
            if (nuevaClave.Length < 8)
                throw new Exception("Clave: Debe tener mas de 8 caracteres.");
            

            cuenta.Clave = nuevaClave;
            oDCuenta.UpdClave(cuenta);
            oLControlSistema.GetCuentaLogin().Clave=nuevaClave;
        }


        public Cuenta ObtenerCuenta(string dni)
        {
            DataCuenta oDCuenta = new DataCuenta();
            return oDCuenta.GetCuentaByDni(dni);
        }

        public Cuenta ObtenerCuenta(int id)
        {
            DataCuenta oDCuenta = new DataCuenta();
            return oDCuenta.GetCuentaById(id);
        }
    }
}
