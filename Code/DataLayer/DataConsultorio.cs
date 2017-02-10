using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MinLab.Code.DataLayer
{
    public class DataConsultorio
    {

        public static Dictionary<int, Consultorio> GetConsultorioAll()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();
            Dictionary<int, Consultorio> temp = new Dictionary<int, Consultorio>();
            Consultorio tempConsul;
            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_CONSULTORIO_ALL;
            comando.CommandType = CommandType.StoredProcedure;

            comando.Connection.Open();
            SqlDataReader d = comando.ExecuteReader();

            while (d.Read())
            {
                tempConsul = new Consultorio();
                tempConsul.IdData = Convert.ToInt32(d["id"]);
                tempConsul.Nombre = d["nombre"].ToString();
                temp.Add(tempConsul.IdData, tempConsul);
            }

            conexion.Close();
            comando.Dispose();
            return temp;
        }
    }
}
