
using MinLab.Code.DataLayer.Recursos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MinLab.Code.EntityLayer;
using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.EntityLayer.ETarifario;
using System.Globalization;

namespace MinLab.Code.DataLayer
{
    public class DataAnalisis
    {
        public static Dictionary<int, EntityLayer.Analisis> GetAnalisis()
        {
            Dictionary<int, EntityLayer.Analisis> Analisis = new Dictionary<int, EntityLayer.Analisis>();
            EntityLayer.Analisis paquete = null;
            SqlConnection conexion = new SqlConnection();
            
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_PAQUETE_ALL;
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    paquete = new EntityLayer.Analisis();
                    paquete.Codigo = resultado["codigo"].ToString();
                    paquete.Nombre = resultado["nombre"].ToString();
                    paquete.Tipo = (TipoPaquete)Convert.ToInt32(resultado["tipo"]);
                    paquete.IdData = Convert.ToInt32(resultado["id"]);
                    paquete.PlantillasId = GetCodPruebaByPaquete(paquete.IdData);
                    Analisis.Add(paquete.IdData, paquete);
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
            return Analisis;
        }

        public static List<int> GetCodPruebaByPaquete(int idData)
        {
            List<int> cods = new List<int>();
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_PLANTILLA_COD_BYPAQUETE;
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


        public static void AddTarifario(Tarifario tar)
        {
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {

                DataTable detalleTemp = new DataTable();
                detalleTemp.Columns.Add("ID", typeof(int));
                detalleTemp.Columns.Add("PRECIO", typeof(double));
                detalleTemp.Columns.Add("IDPAQUETE", typeof(int));
                detalleTemp.Columns.Add("IDTARIFARIOCAB", typeof(int));


                foreach (TarifarioDetalle det in tar.Listado.Values)
                {
                    DataRow row = detalleTemp.NewRow();
                    row[0] = 0;
                    row[1] = det.Precio;
                    row[2] = det.IdPaquete;
                    row[3] = det.IdTarifarioCab;
                    detalleTemp.Rows.Add(row);
                }


                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcAdd.ADD_TARIFARIOCAB;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@vigente", tar.Vigente);
                comando.Parameters.AddWithValue("@ano", tar.Año);
                comando.Parameters.AddWithValue("@FECHAREG",tar.FechaRegistro);
                comando.Parameters.AddWithValue("@DETALLE", detalleTemp).SqlDbType = SqlDbType.Structured;
                MessageBox.Show("");
                comando.Connection.Open();
                comando.ExecuteNonQuery();
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
        }

        public static Tarifario GetTarifario(int idTarifario)
        {
            Tarifario tarif = null;
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;

                comando.CommandText = ProcGet.GET_TARIFARIOCAB_BYID;
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@ID",idTarifario);
                comando.Connection.Open();

                SqlDataReader resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    tarif = new Tarifario();
                    tarif.IdData = Convert.ToInt32(resultado["id"]);
                    tarif.Año = Convert.ToInt32(resultado["ano"]);
                    tarif.FechaRegistro = Convert.ToDateTime(resultado["fechaReg"]);
                    tarif.Vigente = Convert.ToBoolean(resultado["vigente"]);
                    tarif.Listado = GetTarifarioDet(tarif.IdData);
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
            return tarif;
        }



        public static void UpdTarifario(Tarifario tar)
        {
            
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;

                comando.CommandText = ProcUpd.UPD_TARIFARIO;
                comando.CommandType = CommandType.StoredProcedure;

                DataTable tarTab = new DataTable();
                tarTab.Columns.Add("ID", typeof(int));
                tarTab.Columns.Add("PRECIO", typeof(double));
                tarTab.Columns.Add("IDPAQUETE", typeof(int));
                tarTab.Columns.Add("IDTARIFARIOCAB", typeof(int));
                foreach (TarifarioDetalle det in tar.Listado.Values)
                {
                    DataRow row = tarTab.NewRow();
                    row[0] = det.IdData;
                    
                    row[1] = det.Precio;
                    row[2] = det.IdPaquete;
                    row[3] = det.IdTarifarioCab;
                    tarTab.Rows.Add(row);
                }
                comando.Parameters.AddWithValue("@ID", tar.IdData);
                comando.Parameters.AddWithValue("@ANO", tar.IdData);
                comando.Parameters.AddWithValue("@FECHAREG", tar.FechaRegistro);
                comando.Parameters.AddWithValue("@VIGENTE", tar.IdData);
                comando.Parameters.AddWithValue("@DETALLE", tarTab).SqlDbType = SqlDbType.Structured;

                comando.Connection.Open();
                comando.ExecuteNonQuery();

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
        }


        public static void UpdTarifarioVigente(Tarifario tar)
        {

            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;

                comando.CommandText = ProcUpd.UPD_TARIFARIOCAB_VIGENTE;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ID", tar.IdData);
                comando.Connection.Open();
                comando.ExecuteNonQuery();

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
        }

        public static Dictionary<int, Tarifario> GetTarifarioAll()
        {
            Dictionary<int, Tarifario> tarifarios = new Dictionary<int, Tarifario>();
            Tarifario tarif = null;
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_TARIFARIOCAB_ALL;
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    tarif = new Tarifario();
                    tarif.IdData = Convert.ToInt32(resultado["id"]);
                    tarif.Año = Convert.ToInt32(resultado["ano"]);
                    tarif.FechaRegistro = Convert.ToDateTime(resultado["fechaReg"]);
                    tarif.Vigente = Convert.ToBoolean(resultado["vigente"]);
                    tarif.Listado = GetTarifarioDet(tarif.IdData);
                    tarifarios.Add(tarif.IdData, tarif);
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
            return tarifarios;
        }

        public static Tarifario GetTarifarioAno(int ano)
        {
            Tarifario tarif = null;
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_TARIFARIOCAB_BYANO;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ano",ano);
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    tarif = new Tarifario();
                    tarif.IdData = Convert.ToInt32(resultado["id"]);
                    tarif.Año = Convert.ToInt32(resultado["ano"]);
                    tarif.FechaRegistro = Convert.ToDateTime(resultado["fechaReg"]);
                    tarif.Vigente = false;
                    tarif.Listado = GetTarifarioDet(tarif.IdData);
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
            return tarif;
        }
        public static Tarifario GetTarifarioVigente()
        {
            Tarifario tarif = null;
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_TARIFARIOCAB_HABIL;
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    tarif = new Tarifario();
                    tarif.IdData = Convert.ToInt32(resultado["id"]);
                    tarif.Año = Convert.ToInt32(resultado["ano"]);
                    tarif.FechaRegistro = Convert.ToDateTime(resultado["fechaReg"]);
                    tarif.Vigente = true;
                    tarif.Listado = GetTarifarioDet(tarif.IdData);
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
            return tarif;
        }

        public static bool GetCheckTarifarioByAño(int ano)
        {
            bool count = false;
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_TARIFARIOCAB_CHECK_BYYEAR;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@YEAR", ano);
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    count=Convert.ToBoolean(resultado["count"]);
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
            return count;
        }

        public static Dictionary<int, TarifarioDetalle> GetTarifarioDet(int id)
        {
            Dictionary<int, TarifarioDetalle> detalles = new Dictionary<int, TarifarioDetalle>();
            TarifarioDetalle detalle = null;
            SqlConnection conexion = new SqlConnection();

            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_TARIFARIODET_BYTARIFARIOCAB;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IDTARIFARIOCAB", id);
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalle = new TarifarioDetalle();
                    detalle.IdData = Convert.ToInt32(resultado["id"]);
                    detalle.IdTarifarioCab=id;
                    detalle.Precio = Convert.ToDouble(resultado["precio"]);
                    detalle.IdPaquete = Convert.ToInt32(resultado["idPaquete"]);
                    detalles.Add(detalle.IdData, detalle);
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
            return detalles;
        }

    }
}
