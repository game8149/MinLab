using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using MinLab.Code.EntityLayer.EOrden;
using MinLab.Code.EntityLayer.EReporte;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static MinLab.Code.EntityLayer.EOrden.Orden;

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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
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
                comando.CommandText = ProcAdd.ADD_ORDENCAB;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@numero", orden.Boleta);
                comando.Parameters.AddWithValue("@fecha", orden.FechaRegistro);
                comando.Parameters.AddWithValue("@ultimaModificacion", orden.UltimaModificacion);
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Parameters.AddWithValue("@idPaciente", orden.IdPaciente);
                comando.Parameters.AddWithValue("@gestante", orden.EnGestacion);
                comando.Parameters.AddWithValue("@idConsultorio", orden.IdConsultorio);
                comando.Parameters.AddWithValue("@idMedico", orden.IdMedico);
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.UPD_ORDENCAB;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", orden.IdData);
                comando.Parameters.AddWithValue("@numero", orden.Boleta);
                comando.Parameters.AddWithValue("@fecha", orden.FechaRegistro);
                comando.Parameters.AddWithValue("@ultimaModificacion", orden.UltimaModificacion);
                comando.Parameters.AddWithValue("@estado", orden.Estado);
                comando.Parameters.AddWithValue("@gestante", orden.EnGestacion);
                comando.Parameters.AddWithValue("@idConsultorio", orden.IdConsultorio);
                comando.Parameters.AddWithValue("@idMedico", orden.IdMedico);

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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcDel.DEL_ORDENCAB;
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_ORDENDET_BYORDENCAB;
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcDel.DEL_ORDENDET;
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcUpd.UPD_ORDENDET;
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcAdd.ADD_ORDENDET;
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_ORDENCAB_BYID;

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
                    orden.EnGestacion = Convert.ToBoolean(resultado["gestante"]);
                    orden.IdMedico=Convert.ToInt32(resultado["idMedico"]);
                    orden.IdConsultorio=Convert.ToInt32(resultado["idConsultorio"]);
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_ORDENCAB_ALL_BYFECHA_BYESTADO;
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
                    orden.EnGestacion = Convert.ToBoolean(resultado["gestante"]);
                    orden.IdMedico = Convert.ToInt32(resultado["idMedico"]);
                    orden.IdConsultorio = Convert.ToInt32(resultado["idConsultorio"]);
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
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_ORDENCAB_ALL_BYPACIENTE_BYFECHA_BYESTADO;

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
                    orden.EnGestacion = Convert.ToBoolean(resultado["gestante"]);
                    orden.IdMedico = Convert.ToInt32(resultado["idMedico"]);
                    orden.IdConsultorio = Convert.ToInt32(resultado["idConsultorio"]);
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

        public Dictionary<int, int> GetReporteAcumuladoFromDB(int cobertura, int año, int mes)
        {
            Dictionary<int, int> detalles=new Dictionary<int, int>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_REPORTE_ACUMULADOMES;
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalles.Add(Convert.ToInt32(resultado["idPaquete"]), Convert.ToInt32(resultado["cantidad"]));
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


        public Dictionary<int, int> GetReporteCantidadFromDB(int cobertura, int año, int mes)
        {
            Dictionary<int, int> detalles = new Dictionary<int, int>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_REPORTE_CANTIDADMES;
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalles.Add(Convert.ToInt32(resultado["idPaquete"]), Convert.ToInt32(resultado["cantidad"]));
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


        public Dictionary<int, int> GetReporteAcumuladoFromDB(int cobertura, int año, int mes, int idMedico)
        {
            Dictionary<int, int> detalles = new Dictionary<int, int>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_REPORTE_MEDICO_ACUMULADOMES;
                comando.Parameters.AddWithValue("@idMedico", idMedico);
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalles.Add(Convert.ToInt32(resultado["idPaquete"]), Convert.ToInt32(resultado["cantidad"]));
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


        public Dictionary<int, int> GetReporteCantidadFromDB(int cobertura, int año, int mes,int idMedico)
        {
            Dictionary<int, int> detalles = new Dictionary<int, int>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_REPORTE_MEDICO_CANTIDADMES;
                comando.Parameters.AddWithValue("@idMedico", idMedico);
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    detalles.Add(Convert.ToInt32(resultado["idPaquete"]), Convert.ToInt32(resultado["cantidad"]));
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


        public List<int[]> GetReporteEdadFromDB(int cobertura, int año, int mes)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<int[]> general=new List<int[]>();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_REPORTE_EDAD;
                comando.Parameters.AddWithValue("@cobertura", cobertura);
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    int[] row = new int[34];

                    int i = 0;
                    row[i] = Convert.ToInt32(resultado["idPaquete"]);
                    i++;
                    for (; i <= 20; i++)
                        row[i]=Convert.ToInt32(resultado["c" + (i-1)]);
                    for (int k = 20; k < 76; k += 5,i++)
                        row[i] = Convert.ToInt32(resultado["c" + k]);
                    row[i] = Convert.ToInt32(resultado["c80"]);
                    
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


        public List<object[]> GetReporteResultadoFromDB(int año, int mes)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            List<object[]> general = new List<object[]>();
            try
            {
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_REPORTE_RESULTADO;
                comando.Parameters.AddWithValue("@ano", año);
                comando.Parameters.AddWithValue("@mes", mes);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    object[] row = new object[12];
                    
                    row[0] = Convert.ToInt32(resultado["idPlantilla"]);
                    row[1] = resultado["dni"];
                    row[2] = resultado["nombre"].ToString();
                    row[3] = resultado["apellido1"].ToString();
                    row[4] = resultado["apellido2"].ToString();
                    row[5] = Convert.ToDouble(resultado["edad"]);
                    row[6] = Convert.ToInt32(resultado["sexo"]);
                    row[7] = Convert.ToBoolean(resultado["gestante"]);
                    row[8] = resultado["respuesta"].ToString();
                    row[9] = resultado["unidad"].ToString();
                    row[10] = Convert.ToInt32(resultado["cobertura"]);
                    row[11] = Convert.ToInt32(resultado["estado"]);
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
