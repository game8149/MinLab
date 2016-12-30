using MinLab.Code.DataLayer;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer.EFicha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MinLab.Code.LogicLayer
{
    public class BLMedico
    {

        public bool CrearMedico(Medico medico)
        {
            ValidarDatos(medico);
            

            DataMedico enlaceCuenta = new DataMedico();

            enlaceCuenta.AddMedico(medico);

            return true;

        }

        public bool ActualizarMedico(Medico medico)
        {
            ValidarDatos(medico);
            

            DataMedico enlaceCuenta = new DataMedico();

            enlaceCuenta.UpdMedico(medico);

            return true;

        }
        
        public Dictionary<int,string> ObtenerListaHabil()
        {

            DataMedico enlaceCuenta = new DataMedico();

            Dictionary<int,Medico> medicos=enlaceCuenta.GetAllMedicoHabil();
            Dictionary<int, string> temp = new Dictionary<int, string>();

            foreach (Medico med in medicos.Values)
                temp.Add(med.IdData,FormatearNombre(med));

            return temp;

        }

        public Dictionary<int, Medico> ObtenerMedicosHabil()
        {

            DataMedico enlaceCuenta = new DataMedico();

            Dictionary<int, Medico> medicos = enlaceCuenta.GetAllMedicoHabil();

            return medicos;

        }

        public Dictionary<int, string> ObtenerListaGeneral()
        {

            DataMedico enlaceCuenta = new DataMedico();

            Dictionary<int, Medico> medicos = enlaceCuenta.GetAllMedico();
            Dictionary<int, string> temp = new Dictionary<int, string>();

            foreach (Medico med in medicos.Values)
                temp.Add(med.IdData, med.PrimerApellido + " " + med.SegundoApellido + ", " + med.Nombre);

            return temp;

        }

        public Dictionary<int,Medico> ObtenerMedico(string nombre, string primerApellido, string segundoApellido, bool habil)
        {
            DataMedico enlaceCuenta = new DataMedico();
            return enlaceCuenta.GetMedicoByFiltro(nombre,primerApellido,segundoApellido,habil);
        }

        public Medico ObtenerMedico(int id)
        {
            DataMedico enlaceCuenta = new DataMedico();
            return enlaceCuenta.GetMedico(id);

        }

        public bool EliminarMedico(int id)
        {
            DataMedico enlaceCuenta = new DataMedico();
            enlaceCuenta.DelMedico(id);
            return true;
        }

        public bool ValidarDatos(Medico medico)
        {
            DataMedico enlaceCuenta = new DataMedico();

            if (!Regex.IsMatch(medico.Colegiatura, "[0-9]+"))
            {
                throw new Exception("Colegiatura: Solo caracteres numericos");
            }
            if (!Regex.IsMatch(medico.Nombre + medico.PrimerApellido + medico.SegundoApellido, "([A-Za-z]|' ')+"))
            {
                throw new Exception("Nombre y Apellidos: Solo caracteres alfabeticos");
            }
           
            return true;

        }

        public static string FormatearNombre(Medico medico)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(medico.Nombre + " " + medico.PrimerApellido + " " + medico.SegundoApellido);
        }
    }
}
