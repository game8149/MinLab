using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MinLab.Code.LogicLayer.LogicaPaciente
{
    public class BLPaciente
    {
        public Paciente ObtenerPerfilPorDNI(string DNI)
        {
           return  DataPaciente.GetPacienteByDni(DNI);
        }

        public Paciente ObtenerPerfilPorHC(string HC)
        {
            return DataPaciente.GetPacienteByHistoria(HC);
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
            if (!Regex.IsMatch(pac.Dni, "[0-9]+"))
            {
                throw new Exception("Dni: Solo se aceptan numeros");
            }
            if (!Regex.IsMatch(pac.PrimerApellido, "[A-Za-z]+"))
            {
                throw new Exception("Apellido Paterno: Solo se aceptan Letras");
            }
            if (!Regex.IsMatch(pac.SegundoApellido, "[A-Za-z]+"))
            {
                throw new Exception("Apellido Materno: Solo se aceptan Letras");
            }
            if (!Regex.IsMatch(pac.Direccion, "[A-Za-z0-9]+"))
            {
                throw new Exception("Dirección: Solo se aceptan Letras y Numeros");
            }

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
