using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.FichaOrden;
using MinLab.Code.EntityLayer.FichaReporte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static MinLab.Code.EntityLayer.FichaOrden.Orden;

namespace MinLab.Code.DataLayer
{
    public class DataOrden
    {

        //OPERACIONES ORDEN
        public int CrearOrdenToBD(Orden orden)
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                DataTable tabla = new DataTable();
                tabla.Columns.Add("idTemp", typeof(int));
                tabla.Columns.Add("idPaquete", typeof(int));
                tabla.Columns.Add("cobertura", typeof(int));
                foreach (OrdenDetalle k in orden.Detalle.Values)
                {
                    DataRow row = tabla.NewRow();
                    row[0] = 0;
                    row[1] = k.IdDataPaquete;
                    row[2] = k.Cobertura;
                    tabla.Rows.Add(row);
                }
                
                comando.Connection = conexion;
                comando.CommandText = ProcAdd.add_orden;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@numero", orden.Boleta);
                comando.Parameters.AddWithValue("@fecha", orden.FechaRegistro);
                comando.Parameters.AddWithValue("@ultimaModificacion", orden.UltimaModificacion);
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Parameters.AddWithValue("@idPaciente", orden.IdPaciente);
                comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@detalle", tabla).SqlDbType = SqlDbType.Structured;

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                orden.IdData = Convert.ToInt32(comando.Parameters["@id"].Value);
            }
            catch (SqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            
            return orden.IdData;
        }

        public bool ActualizarOrdenCabeceraFromBD(Orden orden)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.update_ordenCabecera;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", orden.IdData);
                comando.Parameters.AddWithValue("@numero", orden.Boleta);
                comando.Parameters.AddWithValue("@fecha", orden.FechaRegistro);
                comando.Parameters.AddWithValue("@ultimaModificacion", orden.UltimaModificacion);
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Connection.Open();

                comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }

            return true;
        }

        public bool EliminarOrdenFromBD(Orden orden)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.deleted_orden;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idOrden", orden.IdData);
                comando.Connection.Open();

                comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }

            return true;
        }


        //OPERACIONES ORDEN DETALLE

        public Dictionary<int, OrdenDetalle> ObtenerOrdenDetalleByOrden(int idData)
        {
            Dictionary<int, OrdenDetalle> ordenDetalle = new Dictionary<int, OrdenDetalle>();
            OrdenDetalle detalle = null;

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_ordenDetalleByOrden;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idOrden", idData);

                comando.Connection.Open();

                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalle = new OrdenDetalle();
                    detalle.IdData = Convert.ToInt32(resultado["id"]);
                    detalle.IdDataPaquete = Convert.ToInt32(resultado["idPaquete"]);
                    detalle.Cobertura = Convert.ToInt32(resultado["cobertura"]);

                    ordenDetalle.Add(detalle.IdData, detalle);

                }
                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return ordenDetalle;
        }

        public bool EliminarOrdenDetalleFromBD(Orden orden)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            DataTable tablaDelete = new DataTable();
            tablaDelete.Columns.Add("idTemp", typeof(int));
            tablaDelete.Columns.Add("idPaquete", typeof(int));
            tablaDelete.Columns.Add("cobertura", typeof(int));
            foreach (OrdenDetalle k in orden.Detalle.Values)
            {
                DataRow row = tablaDelete.NewRow();
                row[0] = k.IdData;
                row[1] = k.IdDataPaquete;
                row[2] = k.Cobertura;
                tablaDelete.Rows.Add(row);
            }

            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.deleted_ordenDetalle;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", orden.IdData);
                comando.Parameters.AddWithValue("@detalleDeleted", tablaDelete).SqlDbType = SqlDbType.Structured;

                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return true;
        }

        public bool ActualizarOrdenDetalleFromBD(Orden orden)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            DataTable tablaUpdate = new DataTable();
            tablaUpdate.Columns.Add("id", typeof(int));
            tablaUpdate.Columns.Add("idPaquete", typeof(int));
            tablaUpdate.Columns.Add("cobertura", typeof(int));
            foreach (OrdenDetalle k in orden.Detalle.Values)
            {
                DataRow row = tablaUpdate.NewRow();
                row[0] = k.IdData;
                row[1] = k.IdDataPaquete;
                row[2] = k.Cobertura;
                tablaUpdate.Rows.Add(row);
            }

            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.update_ordenDetalle;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", orden.IdData);
                comando.Parameters.AddWithValue("@detalleUpdate", tablaUpdate).SqlDbType = SqlDbType.Structured;

                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return true;
        }
        
        public bool AgregarOrdenDetalleFromBD(Orden orden)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            DataTable tablaInsert = new DataTable();
            tablaInsert.Columns.Add("idTemp", typeof(int));
            tablaInsert.Columns.Add("idPaquete", typeof(int));
            tablaInsert.Columns.Add("cobertura", typeof(int));
            foreach (OrdenDetalle k in orden.Detalle.Values)
            {
                DataRow row = tablaInsert.NewRow();
                row[0] = k.IdData;
                row[1] = k.IdDataPaquete;
                row[2] = k.Cobertura;
                tablaInsert.Rows.Add(row);
            }

            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcAdd.insert_ordenDetalle;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", orden.IdData);
                comando.Parameters.AddWithValue("@detalleInsert", tablaInsert).SqlDbType = SqlDbType.Structured;

                comando.Connection.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return true;
        }


        //OBTENER ORDEN POR FILTRO

        public Orden ObtenerOrdenFromBD(int Id)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            Orden orden = null;
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_ordenById;

                comando.Parameters.AddWithValue("@idOrden",Id);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    orden = new Orden();
                    orden.Boleta = resultado["numero"].ToString();
                    orden.FechaRegistro = Convert.ToDateTime(resultado["fechaRegistro"]);
                    orden.IdPaciente = Convert.ToInt32(resultado["idPaciente"]); ;
                    orden.IdData = Convert.ToInt32(resultado["id"]);
                    orden.Estado = (EstadoOrden)Convert.ToInt32(resultado["estado"]);
                    orden.UltimaModificacion = Convert.ToDateTime(resultado["ultimaModificacion"]);
                    orden.Detalle = ObtenerOrdenDetalleByOrden(orden.IdData);
                }
                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return orden;
        }


        public Dictionary<int, Orden> GetAllOrdenByFechaByEstado(DateTime init, DateTime end, EstadoOrden estado)
        {
            Dictionary<int, Orden> ordenes = new Dictionary<int, Orden>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            Orden orden = null;
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_allOrdenByFechaByEstado;
                comando.Parameters.AddWithValue("@estado", (int)estado);
                comando.Parameters.AddWithValue("@fechaInit", init.ToShortDateString());
                comando.Parameters.AddWithValue("@fechaEnd", end.ToShortDateString());
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    orden = new Orden();
                    orden.Boleta = resultado["numero"].ToString();
                    orden.FechaRegistro = Convert.ToDateTime(resultado["fechaRegistro"]);
                    orden.IdPaciente = Convert.ToInt32(resultado["idPaciente"]); ;
                    orden.IdData = Convert.ToInt32(resultado["id"]);
                    orden.Estado = (EstadoOrden)Convert.ToInt32(resultado["estado"]);
                    orden.UltimaModificacion = Convert.ToDateTime(resultado["ultimaModificacion"]);
                    orden.Detalle = ObtenerOrdenDetalleByOrden(orden.IdData);
                    ordenes.Add(orden.IdData, orden);
                }
                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return ordenes;
        }

        public Dictionary<int, Orden> GetAllOrdenByPacienteByFechaByEstado(Paciente pa, DateTime init, DateTime end, EstadoOrden estado)
        {
            Dictionary<int, Orden> ordenes = new Dictionary<int, Orden>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            Orden orden = null;
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_allOrdenByPacienteByFechaByEstado;

                comando.Parameters.AddWithValue("@idPaciente", pa.IdData);
                comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@fechaInit", init);
                comando.Parameters.AddWithValue("@fechaEnd", end);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    orden = new Orden();
                    orden.Boleta = resultado["numero"].ToString();
                    orden.FechaRegistro = Convert.ToDateTime(resultado["fechaRegistro"]);
                    orden.IdPaciente = Convert.ToInt32(resultado["idPaciente"]); ;
                    orden.IdData = Convert.ToInt32(resultado["id"]);
                    orden.Estado = (EstadoOrden)Convert.ToInt32(resultado["estado"]);
                    orden.UltimaModificacion = Convert.ToDateTime(resultado["ultimaModificacion"]);
                    orden.Detalle = ObtenerOrdenDetalleByOrden(orden.IdData);
                    ordenes.Add(orden.IdData, orden);
                }
                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return ordenes;
        }

        public Dictionary<int, int> GetReporteAcumuladoFromDB(int cobertura, int idArea, int año, int mes)
        {
            Dictionary<int, int> detalles=new Dictionary<int, int>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_reporteAcumuladoMes;
                comando.Parameters.AddWithValue("@area", idArea);
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalles.Add(Convert.ToInt32(resultado["idPlantilla"]), Convert.ToInt32(resultado["acumulado"]));
                }

                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return detalles;
        }


        public Dictionary<int, int> GetReporteCantidadFromDB(int cobertura, int idArea, int año, int mes)
        {
            Dictionary<int, int> detalles = new Dictionary<int, int>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_reporteCantidadMes;
                comando.Parameters.AddWithValue("@area", idArea);
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalles.Add(Convert.ToInt32(resultado["id"]), Convert.ToInt32(resultado["Cantidad"]));
                }

                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return detalles;
        }

        public List<int[]> GetReporteEdadFromDB(int cobertura, int idArea, int año, int mes)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<int[]> general=new List<int[]>();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_reporteEdad;
                comando.Parameters.AddWithValue("@area", idArea);
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    int[] row = new int[14];
                    row[0] = Convert.ToInt32(resultado["id"]);
                    row[1] = Convert.ToInt32(resultado["A"]);
                    row[2] = Convert.ToInt32(resultado["B"]);
                    row[3] = Convert.ToInt32(resultado["C"]);
                    row[4] = Convert.ToInt32(resultado["D"]);
                    row[5] = Convert.ToInt32(resultado["E"]);
                    row[6] = Convert.ToInt32(resultado["F"]);
                    row[7] = Convert.ToInt32(resultado["G"]);
                    row[8] = Convert.ToInt32(resultado["H"]);
                    row[9] = Convert.ToInt32(resultado["I"]);
                    row[10] = Convert.ToInt32(resultado["J"]);
                    row[11] = Convert.ToInt32(resultado["K"]);
                    row[12] = Convert.ToInt32(resultado["L"]);
                    row[13] = Convert.ToInt32(resultado["M"]);
                    general.Add(row);
                }

                resultado.Close();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexion.Close();
                comando.Dispose();
            }
            return general;
        }
    }
}
