using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
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
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();
            
            comando.Connection = conexion;
            comando.CommandText = ProcAdd.add_cuenta;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", cuenta.Nombre);
            comando.Parameters.AddWithValue("@apellidos", cuenta.Apellidos);
            comando.Parameters.AddWithValue("@dni", cuenta.Dni);
            comando.Parameters.AddWithValue("@clave", cuenta.Clave);
            comando.Parameters.AddWithValue("@nivel", cuenta.Nivel);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }


        public Cuenta GetCuentaByDni(string dni)
        {
            Cuenta cuenta = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_cuenta;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dni", dni);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while(resultado.Read())
            {
                cuenta = new Cuenta();
                cuenta.IdData = Convert.ToInt32(resultado["id"]);
                cuenta.Nombre = resultado["nombre"].ToString();
                cuenta.Apellidos = resultado["apellidos"].ToString();
                cuenta.Dni = dni;
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
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_seguridad;
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
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcUpd.update_seguridad;
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
                conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
                SqlCommand comando = new SqlCommand();

                comando.Connection = conexion;
                comando.CommandText = ProcGet.get_exist;
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
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcAdd.add_seguridad;
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
