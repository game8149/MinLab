using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
using MinLab.Code.EntityLayer.EFicha;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static MinLab.Code.ControlSistemaInterno.Sesion;

namespace MinLab.Code.DataLayer
{
    public class DataCuenta
    {
        public void AddCuenta(Cuenta cuenta)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();
            
            comando.Connection = conexion;
            comando.CommandText = ProcAdd.ADD_CUENTA;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", cuenta.Nombre);
            comando.Parameters.AddWithValue("@primerApellido", cuenta.PrimerApellido);
            comando.Parameters.AddWithValue("@segundoApellido", cuenta.SegundoApellido);
            comando.Parameters.AddWithValue("@especialidad", cuenta.Especialidad);
            comando.Parameters.AddWithValue("@codigo", cuenta.CodigoPro);
            comando.Parameters.AddWithValue("@dni", cuenta.Dni);
            comando.Parameters.AddWithValue("@clave", cuenta.Clave);
            comando.Parameters.AddWithValue("@nivel", cuenta.Nivel);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

        public void UpdCuenta(Cuenta cuenta)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcUpd.UPD_CUENTA;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCuenta", cuenta.IdData);
            comando.Parameters.AddWithValue("@nombre", cuenta.Nombre);
            comando.Parameters.AddWithValue("@primerApellido", cuenta.PrimerApellido);
            comando.Parameters.AddWithValue("@segundoApellido", cuenta.SegundoApellido);
            comando.Parameters.AddWithValue("@especialidad", cuenta.Especialidad);
            comando.Parameters.AddWithValue("@codigo", cuenta.CodigoPro);
            comando.Parameters.AddWithValue("@dni", cuenta.Dni);
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

        public void UpdClave(Cuenta cuenta)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcUpd.UPD_CUENTA_CLAVE;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCuenta", cuenta.IdData);
            comando.Parameters.AddWithValue("@clave", cuenta.Clave);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

        public Cuenta GetCuentaByDni(string dni)
        {
            Cuenta cuenta = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_CUENTA;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dni", dni);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while(resultado.Read())
            {
                cuenta = new Cuenta();
                cuenta.IdData = Convert.ToInt32(resultado["id"]);
                cuenta.Nombre = resultado["nombre"].ToString();
                cuenta.PrimerApellido = resultado["primerApellido"].ToString();
                cuenta.SegundoApellido = resultado["segundoApellido"].ToString();
                cuenta.Especialidad = resultado["especialidad"].ToString();
                cuenta.CodigoPro = resultado["codigo"].ToString();
                cuenta.Dni = dni;
                cuenta.Clave = resultado["clave"].ToString();
                cuenta.Nivel = (SesionNivel)Convert.ToInt32((resultado["nivel"].ToString()));
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return cuenta;
        }

        public Cuenta GetCuentaById(int id)
        {
            Cuenta cuenta = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_CUENTA_BYID;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCuenta", id);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                cuenta = new Cuenta();
                cuenta.IdData = Convert.ToInt32(resultado["id"]);
                cuenta.Nombre = resultado["nombre"].ToString();
                cuenta.PrimerApellido = resultado["primerApellido"].ToString();
                cuenta.SegundoApellido = resultado["segundoApellido"].ToString();
                cuenta.Especialidad = resultado["especialidad"].ToString();
                cuenta.CodigoPro = resultado["codigo"].ToString();
                cuenta.Dni = resultado["dni"].ToString();
                cuenta.Clave = resultado["clave"].ToString();
                cuenta.Nivel = (SesionNivel)Convert.ToInt32((resultado["nivel"].ToString()));
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return cuenta;
        }

        public string GetSeguridad(Cuenta cuenta)
        {
            string codigo = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_SEGURIDAD;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCuenta", cuenta.IdData);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                codigo=resultado["code"].ToString();
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return codigo;
        }

        public bool UpdateSeguridad(Cuenta cuenta,string code)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcUpd.UPD_SEGURIDAD;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCuenta", cuenta.IdData);
            comando.Parameters.AddWithValue("@codigo",code);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();

            return true;
        }


        public bool CheckExistCuenta(string dni)
        {
            bool existe=false;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = ProcGet.GET_CUENTA_EXISTE;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@dni", dni);

                comando.Connection.Open();
                SqlDataReader resultado = comando.ExecuteReader();
                while (resultado.Read())
                {
                    existe = (Convert.ToInt32(resultado["num"]) > 0);
                }
                resultado.Close();
                conexion.Close();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return existe;
        }

        public void AddSeguridad(Cuenta cuenta, string code)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.GetInstance().CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcAdd.ADD_SEGURIDAD;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idCuenta", cuenta.IdData);
            comando.Parameters.AddWithValue("@codigo", code);
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

    }
}
