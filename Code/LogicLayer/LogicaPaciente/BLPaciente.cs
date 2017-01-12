using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MinLab.Code.LogicLayer.LogicaPaciente
{
    public class LogicaPaciente
    {
        public Paciente ObtenerPerfilPorDNI(string DNI)
        {
           return  DataPaciente.GetPacienteByDni(DNI);
        }

        public Paciente ObtenerPerfilPorHC(string HC)
        {
            return DataPaciente.GetPacienteByHistoria(HC);
        }

        public static string FormatearUbicacion(Paciente pac)
        {
            return pac.Direccion+" (" +Locaciones.GetInstance().GetDistrito(pac.IdDistrito).Sectores[pac.IdSector].Nombre+","+ Locaciones.GetInstance().GetDistrito(pac.IdDistrito).Nombre +")";
        }

        public bool ActualizarPaciente(Paciente pac)
        {
            if (ValidarDatos(pac))
            {
                DataPaciente.ActualizarPaciente(pac);
                return true;
            }
            else return false;

        }

        public bool CrearPaciente(Paciente pac)
        {
            if (ValidarDatos(pac))
            {
                if(DataPaciente.GetPacienteByDni(pac.Dni) != null)
                    throw new Exception("Ya existe una cuenta para ese DNI");
                DataPaciente.AddPaciente(pac);
                return true;
            }
            return false;
        }

        public bool EliminarPaciente(Paciente pac)
        {
           
            return  DataPaciente.DeletedPacienteById(pac.IdData);
        }

        private bool ValidarDatos(Paciente pac)
        {
            if(pac.Dni.Replace(" ", string.Empty)== string.Empty)
                throw new Exception("DNI: Es necesario especificarlo.");
            if (!Regex.IsMatch(pac.Dni, "[0-9]+"))
                throw new Exception("DNI: Formato incorrecto.");
            if (pac.PrimerApellido.Replace(" ",string.Empty) == string.Empty)
                throw new Exception("Primer Apellido: Es necesario especificarlo.");
            if (!Regex.IsMatch(pac.PrimerApellido, "[A-Za-z]+"))
                throw new Exception("Primer Apellido: Formato incorrecto.");
            if (pac.SegundoApellido.Replace(" ", string.Empty) == string.Empty)
                throw new Exception("Primer Apellido: Es necesario especificarlo.");
            if (!Regex.IsMatch(pac.SegundoApellido, "[A-Za-z]+"))
                throw new Exception("Segundo Apellido: Formato incorrecto.");
            if (pac.Direccion.Replace(" ", string.Empty)!= string.Empty)
                if (!Regex.IsMatch(pac.Direccion, "[A-Za-z0-9]+"))
                    throw new Exception("Dirección: Formato incorrecto.");

            return true;
        }



        public Dictionary<int, Paciente> ObtenerPerfilPorFiltro(string dni, string historia, string nombre, string apellidoP, string apellidoM)
        {
            return DataPaciente.GetPacientesByFiltro(dni,historia,nombre,apellidoM,apellidoP);
        }


        public Paciente ObtenerPerfilPorId(int id)
        {
            return DataPaciente.GetPacienteById(id);
        }
    }
}
