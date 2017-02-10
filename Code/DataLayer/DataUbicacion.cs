using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer.EUbicacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MinLab.Code.DataLayer
{
    public class DataUbicacion
    {
        public Dictionary<int,Distrito> GetDistritoAll()
        {
            Distrito distrito = null;
            Dictionary<int, Distrito> temp = new Dictionary<int, Distrito>();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_DISTRITO_ALL;
            comando.CommandType = CommandType.StoredProcedure;

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                distrito = new Distrito();
                distrito.IdData = Convert.ToInt32(resultado["id"]);
                distrito.Nombre = resultado["nombre"].ToString();
                distrito.Sectores = GetSectorAll(distrito.IdData);
                temp.Add(distrito.IdData,distrito);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return temp;
        }
        public Dictionary<int, Sector> GetSectorAll(int idDistrito)
        {
            Sector sector = null;
            Dictionary<int, Sector> temp = new Dictionary<int, Sector>();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_SECTOR_BYDISTRITO;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("idDistrito",idDistrito);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                sector = new Sector();
                sector.IdData = Convert.ToInt32(resultado["id"]);
                sector.Nombre = resultado["nombre"].ToString();
                sector.IdDistrito= Convert.ToInt32(resultado["idDistrito"]);
                

                temp.Add(sector.IdData, sector);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return temp;
        }
    }
}
