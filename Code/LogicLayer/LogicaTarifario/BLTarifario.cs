using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.ETarifario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinLab.Code.LogicLayer.LogicaTarifario
{
    public class BLTarifario
    {
        public void CrearTarifario(int Año, bool Vigente)
        {
            Tarifario tar=null;

            DataAnalisis enlace = new DataAnalisis();
            if (!DataAnalisis.GetCheckTarifarioByAño(Año))
            {
                tar=new Tarifario();
                tar.FechaRegistro = DateTime.Now;
                tar.Año = Año;
                tar.Vigente = Vigente;
                Dictionary<int, TarifarioDetalle> listado = new Dictionary<int, TarifarioDetalle>();
                TarifarioDetalle tarDet;
                int i = 0;
                foreach (Analisis anal in ListaAnalisis.GetInstance().Analisis.Values)
                {
                    tarDet = new TarifarioDetalle();
                    tarDet.IdPaquete = anal.IdData;
                    tarDet.Precio = 0.0;
                    listado.Add(i,tarDet);
                    i++;
                }
                tar.Listado = listado;
                DataAnalisis.AddTarifario(tar);
            }
            else throw new Exception("Ya existe un tarifario registrado para este año: "+Año);
        }

        public void CopiarTarifario(Tarifario tar, int Año, bool Vigente)
        {
            DataAnalisis enlace = new DataAnalisis();
            if (!DataAnalisis.GetCheckTarifarioByAño(Año))
            {
                Tarifario tar1 = new Tarifario();
                tar1.FechaRegistro = DateTime.Now;
                tar1.Año = Año;
                tar1.Vigente = Vigente;
                Dictionary<int, TarifarioDetalle> listado = new Dictionary<int, TarifarioDetalle>();
                TarifarioDetalle tarDet;
                int i = 0;
                foreach (TarifarioDetalle det in tar.Listado.Values)
                {
                    tarDet = new TarifarioDetalle();
                    tarDet.IdPaquete = det.IdPaquete;
                    tarDet.Precio = det.Precio;
                    listado.Add(i, tarDet);
                    i++;
                }
                tar1.Listado = listado;
                DataAnalisis.AddTarifario(tar1);
            }
            else throw new Exception("Ya existe un tarifario registrado para este año: " + tar.Año);
        }


        public Dictionary<int,Tarifario> ObtenerTarifarios()
        {
            return DataAnalisis.GetTarifarioAll();
        }

        public Tarifario ObtenerTarifario()
        {
            return DataAnalisis.GetTarifarioVigente();
        }
        public Tarifario ObtenerTarifarioPorAno(int ano)
        {
            return DataAnalisis.GetTarifarioAno(ano);
        }
        
        public TarifarioDetalle ObtenerTarifarioDetalle(Tarifario tar, int idAnalisis)
        {
            foreach(TarifarioDetalle tarD in tar.Listado.Values)
            {
                if (tarD.IdPaquete == idAnalisis)
                    return tarD;
            }
            return null;
        }

        public Dictionary<int,string> ObtenerListadoAno(Dictionary<int, Tarifario> tarifarios)
        {
            Dictionary<int, string> listado = new Dictionary<int, string>();

            foreach (Tarifario tar in tarifarios.Values)
                listado.Add(tar.IdData,tar.Año.ToString());

            return listado;
        }


        public Dictionary<int,Analisis> ObtenerListadoAnalisis()
        {
            return ListaAnalisis.GetInstance().Analisis;
        }

        public Analisis ObtenerAnalisis(int idAnalisis)
        {
            return ListaAnalisis.GetInstance().GetAnalisisById(idAnalisis);
        }

        public void ActualizarTarifario(Tarifario tar)
        {
            DataAnalisis.UpdTarifario(tar);
        }

        public void ActualizarVigenteTarifario(Tarifario tar)
        {
            DataAnalisis.UpdTarifarioVigente(tar);
        }

    }
}
