using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.EExamen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static MinLab.Code.EntityLayer.EExamen.Examen;
using System.Windows.Forms;
using MinLab.Code.ControlSistemaInterno;

namespace MinLab.Code.DataLayer
{
    public class DataExamen
    {
        public static void AddExamen(Dictionary<int,Examen> examenes)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {

                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                DataTable tablaExamen = new DataTable();
                DataTable tablaExamenDetalle = new DataTable();

                tablaExamen.Columns.Add("idTemp", typeof(int));
                tablaExamen.Columns.Add("idOrdenDetalle", typeof(int));
                tablaExamen.Columns.Add("idPlantilla", typeof(int));
                tablaExamen.Columns.Add("fechaRegistro", typeof(DateTime));
                tablaExamen.Columns.Add("fechaModificacion", typeof(DateTime));
                tablaExamen.Columns.Add("fechaFinalizacion", typeof(DateTime));
                tablaExamen.Columns.Add("estado", typeof(int));

                tablaExamenDetalle.Columns.Add("id", typeof(int));
                tablaExamenDetalle.Columns.Add("idExamen", typeof(int));
                tablaExamenDetalle.Columns.Add("idItem", typeof(int));
                tablaExamenDetalle.Columns.Add("respuesta", typeof(string));

                int i = 1;
                foreach (Examen r in examenes.Values)
                {
                    DataRow row = tablaExamen.NewRow();
                    row[0] = i;
                    row[1] = r.IdOrdenDetalle;
                    row[2] = r.IdPlantilla;
                    row[3] = r.FechaRegistro;
                    row[4] = r.UltimaModificacion;
                    row[5] = r.FechaFinalizado;
                    row[6] = (int)r.Estado;
                    foreach (ExamenDetalle k in r.DetallesByItem.Values)
                    {
                        DataRow rowDetalle = tablaExamenDetalle.NewRow();
                        rowDetalle[0] = 0;
                        rowDetalle[1] = i;
                        rowDetalle[2] = k.IdItem;
                        rowDetalle[3] = k.Campo;
                        tablaExamenDetalle.Rows.Add(rowDetalle);
                    }
                    tablaExamen.Rows.Add(row);
                    i++;
                }


                comando.Connection = conexion;
                comando.CommandText = ProcAdd.ADD_EXAMEN;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@examenes", tablaExamen).SqlDbType = SqlDbType.Structured;
                comando.Parameters.AddWithValue("@detalles", tablaExamenDetalle).SqlDbType = SqlDbType.Structured;
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

        public static Dictionary<int,Examen> GetExamenesByOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            Dictionary<int,Examen> examenes = new Dictionary<int,Examen>();
            Examen examen = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_EXAMENCAB_BYORDENDET;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idOrden", ordenDetalle.IdData);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                examen = new Examen();
                examen.IdData = Convert.ToInt32(resultado["id"]);
                examen.IdOrdenDetalle = ordenDetalle.IdData;
                examen.IdPlantilla = Convert.ToInt32(resultado["idPlantilla"]);
                examen.FechaRegistro = Convert.ToDateTime(resultado["fechaRegistro"]);
                examen.Estado = (EstadoExamen)Convert.ToInt32(resultado["estado"]);
                examen.FechaFinalizado = Convert.ToDateTime(resultado["fechaFinalizacion"]);
                examen.UltimaModificacion = Convert.ToDateTime(resultado["fechaModificacion"]);
                examen.DetallesByItem = GetExamenDetalleByExamen(examen);
                examenes.Add(examen.IdData,examen);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return examenes;
        }

        public static bool ExistenExamenes(OrdenDetalle ordenDetalle)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_EXAMENCAB_EXISTE;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idOrdenDetalle", ordenDetalle.IdData);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            int count = 0;
            while (resultado.Read())
                count = Convert.ToInt32(resultado["num"]);

            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return (count>0);
        }



        public static Dictionary<int, ExamenDetalle> GetExamenDetalleByExamen(Examen examen)
        {
            Dictionary<int, ExamenDetalle> examenDetalles = new Dictionary<int, ExamenDetalle>();
            Dictionary<int, ExamenDetalle> examenDetallesIndexByItem = new Dictionary<int, ExamenDetalle>();
            ExamenDetalle detalle = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_EXAMENDET_BYEXAMENCAB;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idExamen", examen.IdData);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                detalle = new ExamenDetalle();
                detalle.IdData = Convert.ToInt32(resultado["id"]);
                detalle.IdItem = Convert.ToInt32(resultado["idItem"]);
                detalle.Campo = resultado["respuesta"].ToString();
                examenDetalles.Add(detalle.IdItem, detalle);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return examenDetalles;
        }

        public static void GuardarExamenes(Dictionary<int,Examen> examenes,Orden orden)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                DataTable tablaExamen = new DataTable();
                DataTable tablaExamenDetalle = new DataTable();

                tablaExamen.Columns.Add("idTemp", typeof(int));
                tablaExamen.Columns.Add("idOrdenDetalle", typeof(int));
                tablaExamen.Columns.Add("idPlantilla", typeof(int));
                tablaExamen.Columns.Add("fechaRegistro", typeof(DateTime));
                tablaExamen.Columns.Add("fechaModificacion", typeof(DateTime));
                tablaExamen.Columns.Add("fechaFinalizacion", typeof(DateTime));
                tablaExamen.Columns.Add("estado", typeof(int));

                tablaExamenDetalle.Columns.Add("id", typeof(int));
                tablaExamenDetalle.Columns.Add("idExamen", typeof(int));
                tablaExamenDetalle.Columns.Add("idItem", typeof(int));
                tablaExamenDetalle.Columns.Add("respuesta", typeof(string));
                
                foreach (Examen r in examenes.Values)
                {
                    DataRow row = tablaExamen.NewRow();
                    row[0] = r.IdData;
                    row[1] = r.IdOrdenDetalle;
                    row[2] = r.IdPlantilla;
                    row[3] = r.FechaRegistro;
                    row[4] = r.UltimaModificacion;
                    row[5] = r.FechaFinalizado;
                    row[6] = (int)r.Estado;
                    foreach (ExamenDetalle k in r.DetallesByItem.Values)
                    {
                        DataRow rowDetalle = tablaExamenDetalle.NewRow();
                        rowDetalle[0] = k.IdData;
                        rowDetalle[1] = r.IdData;
                        rowDetalle[2] = k.IdItem;
                        rowDetalle[3] = k.Campo;
                        tablaExamenDetalle.Rows.Add(rowDetalle);
                    }
                    tablaExamen.Rows.Add(row);
                }


                comando.Connection = conexion;
                comando.CommandText = ProcUpd.UPD_EXAMEN;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idOrden",orden.IdData);
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Parameters.AddWithValue("@examenes", tablaExamen).SqlDbType = SqlDbType.Structured;
                comando.Parameters.AddWithValue("@detalles", tablaExamenDetalle).SqlDbType = SqlDbType.Structured;
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

        public static void GuardarExamen(Examen examen)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                DataTable tablaExamen = new DataTable();
                DataTable tablaExamenDetalle = new DataTable();

                tablaExamen.Columns.Add("idTemp", typeof(int));
                tablaExamen.Columns.Add("idOrdenDetalle", typeof(int));
                tablaExamen.Columns.Add("idPlantilla", typeof(int));
                tablaExamen.Columns.Add("fechaRegistro", typeof(DateTime));
                tablaExamen.Columns.Add("fechaModificacion", typeof(DateTime));
                tablaExamen.Columns.Add("fechaFinalizacion", typeof(DateTime));
                tablaExamen.Columns.Add("estado", typeof(int));

                tablaExamenDetalle.Columns.Add("id", typeof(int));
                tablaExamenDetalle.Columns.Add("idExamen", typeof(int));
                tablaExamenDetalle.Columns.Add("idItem", typeof(int));
                tablaExamenDetalle.Columns.Add("respuesta", typeof(string));
                
                DataRow row = tablaExamen.NewRow();
                row[0] = examen.IdData;
                row[1] = examen.IdOrdenDetalle;
                row[2] = examen.IdPlantilla;
                row[3] = examen.FechaRegistro;
                row[4] = examen.UltimaModificacion;
                row[5] = examen.FechaFinalizado;
                row[6] = (int)examen.Estado;
                foreach (ExamenDetalle k in examen.DetallesByItem.Values)
                {
                    DataRow rowDetalle = tablaExamenDetalle.NewRow();
                    rowDetalle[0] = k.IdData;
                    rowDetalle[1] = examen.IdData;
                    rowDetalle[2] = k.IdItem;
                    rowDetalle[3] = k.Campo;
                    tablaExamenDetalle.Rows.Add(rowDetalle);
                }
                tablaExamen.Rows.Add(row);
                
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.UPD_EXAMEN_SINGLE;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@examenes", tablaExamen).SqlDbType = SqlDbType.Structured;
                comando.Parameters.AddWithValue("@detalles", tablaExamenDetalle).SqlDbType = SqlDbType.Structured;
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

    }
}
