using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.EntityLayer.FormatoImpresionComponentes;
using System;
using System.Text.RegularExpressions;
using static MinLab.Code.ControlSistemaInterno.Sesion;

namespace MinLab.Code.LogicLayer.LogicaControl
{
    public class LogicControlSistema
    {

        public Cuenta GetCuentaLogin()
        {
            return SistemaControl.GetInstance().Sesion.Cuenta;
        }
        
        public void ActualizarCuentaLogin(Cuenta cuenta)
        {
            SistemaControl.GetInstance().Sesion.Cuenta = cuenta;
        }

        public bool IniciarSesion(string dni,string clave)
        {
            DataCuenta enlaceDatosCuenta = new DataCuenta();
            Cuenta cuenta = null;
            if (!enlaceDatosCuenta.CheckExistCuenta(dni))
            {
                throw new Exception("Esa cuenta no está registrada");
            }
            else
            {
                cuenta = enlaceDatosCuenta.GetCuentaByDni(dni);
                if (cuenta.Clave.Trim(' ') != clave) throw new Exception("Contraseña Incorrecta");
                SistemaControl.GetInstance().Sesion.Cuenta = cuenta;
                SistemaControl.GetInstance().Sesion.Estado = SesionEstado.Loggin;

                if(cuenta.Nivel==SesionNivel.Administrador)
                    SistemaControl.GetInstance().Sesion.Pase = true;
                else
                    SistemaControl.GetInstance().Sesion.Pase = false;
            }
            return true;
        }

        public bool EsLoggeado()
        {
            return (SistemaControl.GetInstance().Sesion.Estado==SesionEstado.Loggin);
        }


        public void AperturaAutorizacion(string dni, string autorizacion)
        {
            DataCuenta enlaceCuenta = new DataCuenta();
            Cuenta cuenta = null;
            if (!enlaceCuenta.CheckExistCuenta(dni))
            {
                throw new Exception("Esa cuenta no está registrada");
            }
            else
            {
                cuenta = enlaceCuenta.GetCuentaByDni(dni);
                if (cuenta.Nivel== SesionNivel.Administrador)
                {
                    string codigo = enlaceCuenta.GetSeguridad(cuenta);
                    if (codigo.Trim(' ') != autorizacion.Trim(' ')) throw new Exception("Codigo de autorización incorrecto.");
                    SistemaControl.GetInstance().Sesion.Pase = true;
                }
                else throw new Exception("Es necesario tener una cuenta administrador");
            }

        }

        public void CerrarAutorizacion()
        {
            SistemaControl.GetInstance().Sesion.Pase = false;
        }

        public bool GetPase()
        {
            return SistemaControl.GetInstance().Sesion.Pase;
        }

        public bool CerrarSesion()
        {
            SistemaControl.GetInstance().Sesion.Cuenta = null;
            SistemaControl.GetInstance().Sesion.Nivel = 0;
            SistemaControl.GetInstance().Sesion.Estado = SesionEstado.NoLoggin;
            return true;
        }

    }
}
