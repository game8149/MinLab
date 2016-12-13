
using MinLab.Code.DataLayer.Recursos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;

namespace MinLab.Code.DataLayer
{
    public class DataPaquete
    {
        public static Dictionary<int, Paquete> GetTarifario()
        {
            Dictionary<int,Paquete> paquetes = new Dictionary<int, Paquete>();
            Paquete paquete = null;
            SqlConnection conexion = new SqlConnection();
            
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_paquetes;
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    paquete = new Paquete();
                    paquete.Codigo = resultado["codigo"].ToString();
                    paquete.Nombre = resultado["nombre"].ToString();
                    paquete.Tipo = (TipoPaquete)Convert.ToInt32(resultado["tipo"]);
                    paquete.IdData = Convert.ToInt32(resultado["id"]);
                    paquete.PlantillasId = GetCodPruebaByPaquete(paquete.IdData);
                    paquetes.Add(paquete.IdData, paquete);
                }
                resultado.Close();


            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return paquetes;
        }

        public static List<int> GetCodPruebaByPaquete(int idData)
        {
            List<int> cods = new List<int>();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_codPlantillaByPaquete;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idPaquete", idData);

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    cods.Add(Convert.ToInt32(resultado["id"]));
                }
                resultado.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return cods;
        }



    }
}
