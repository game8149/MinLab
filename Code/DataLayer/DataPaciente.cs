using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MinLab.Code.DataLayer
{
    public class DataPaciente
    {
        public static int AddPaciente(Paciente paciente)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();


            comando.Connection = conexion;
            comando.CommandText = ProcAdd.add_paciente;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@hc", paciente.Historia);
            comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@apellidoP", paciente.PrimerApellido);
            comando.Parameters.AddWithValue("@apellidoM", paciente.SegundoApellido);
            comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@sexo", paciente.Genero);
            comando.Parameters.AddWithValue("@fechaNac", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@dni", paciente.Dni);
            comando.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
            
            comando.Connection.Open();
            comando.ExecuteNonQuery();
            int idPaciente = Convert.ToInt32(comando.Parameters["@id"].Value);
            conexion.Close();
            comando.Dispose();
            return idPaciente;
        }
        public static bool ActualizarPaciente(Paciente paciente)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();
            
            comando.Connection = conexion;
            comando.CommandText = ProcUpd.update_paciente;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", paciente.IdData);
            comando.Parameters.AddWithValue("@hc", paciente.Historia);
            comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
            comando.Parameters.AddWithValue("@apellidoP", paciente.PrimerApellido);
            comando.Parameters.AddWithValue("@apellidoM", paciente.SegundoApellido);
            comando.Parameters.AddWithValue("@direccion", paciente.Direccion);
            comando.Parameters.AddWithValue("@sexo", paciente.Genero);
            comando.Parameters.AddWithValue("@fechaNac", paciente.FechaNacimiento);
            comando.Parameters.AddWithValue("@dni", paciente.Dni);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
            return true;
        }

        public static Dictionary<int,Paciente> GetPacientesByFiltro(string dni,string historia,string nombre, string apellidoM,string apellidoP)
        {
            Dictionary<int, Paciente> diccionario = new Dictionary<int, Paciente>();
            //Por el momento no se pudo hacer en procedimiento almacenado...
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = 
                "select id,hclinica,nombre,apellido2,apellido1,Paciente.direccion,Paciente.fechaNacimiento,dni,Paciente.sexo "+
                "from Paciente where " +
                "hclinica like '"+historia+"%' and "+
                "dni like '"+ dni+"%' and "+
                "nombre like '"+nombre+"%' and "+
                "apellido2 like '"+apellidoM+"%' and "+
                "apellido1 like '"+apellidoP+"%'";

            comando.CommandType = CommandType.Text;
            
            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                Paciente paciente = new Paciente();
                paciente.IdData = Convert.ToInt32(resultado["id"]);
                paciente.Nombre = resultado["nombre"].ToString();
                paciente.SegundoApellido = resultado["apellido2"].ToString();
                paciente.PrimerApellido = resultado["apellido1"].ToString();
                paciente.Direccion = resultado["direccion"].ToString();
                paciente.Historia = resultado["hclinica"].ToString();
                paciente.Dni = resultado["dni"].ToString();
                paciente.Genero = Convert.ToInt32(resultado["sexo"]);
                paciente.FechaNacimiento = Convert.ToDateTime(resultado["fechaNacimiento"]);

                diccionario.Add(paciente.IdData,paciente);

            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return diccionario;
        }
        
        public static Paciente GetPacienteByHistoria(string historia)
        {

            Paciente paciente= null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_pacienteByHistoria;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@historia", historia);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                paciente = new Paciente();
                paciente.IdData = Convert.ToInt32(resultado["id"]);
                paciente.Nombre = resultado["nombre"].ToString();
                paciente.SegundoApellido = resultado["apellido2"].ToString();
                paciente.PrimerApellido = resultado["apellido1"].ToString();
                paciente.Direccion = resultado["direccion"].ToString();
                paciente.Historia = resultado["hclinica"].ToString();
                paciente.Dni = resultado["dni"].ToString();
                paciente.Genero =Convert.ToInt32(resultado["sexo"]);
                paciente.FechaNacimiento = Convert.ToDateTime(resultado["fechaNacimiento"]);
                
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return paciente;
        }

        public static Paciente GetPacienteByDni(string Dni)
        {

            Paciente paciente = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_pacienteByDni;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Dni", Dni);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                paciente = new Paciente();
                paciente.IdData = Convert.ToInt32(resultado["id"]);
                paciente.Nombre = resultado["nombre"].ToString();
                paciente.SegundoApellido = resultado["apellido2"].ToString();
                paciente.PrimerApellido = resultado["apellido1"].ToString();
                paciente.Direccion = resultado["direccion"].ToString();
                paciente.Historia = resultado["hclinica"].ToString();
                paciente.Dni = resultado["dni"].ToString();
                paciente.Genero = Convert.ToInt32(resultado["sexo"]);
                paciente.FechaNacimiento = Convert.ToDateTime(resultado["fechaNacimiento"]);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return paciente;
        }


        public static Paciente GetPacienteById(int idData)
        {

            Paciente paciente = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_pacienteById;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPaciente", idData);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                paciente = new Paciente();
                paciente.IdData = Convert.ToInt32(resultado["id"]);
                paciente.Nombre = resultado["nombre"].ToString();
                paciente.SegundoApellido = resultado["apellido2"].ToString();
                paciente.PrimerApellido = resultado["apellido1"].ToString();
                paciente.Direccion = resultado["direccion"].ToString();
                paciente.Historia = resultado["hclinica"].ToString();
                paciente.Dni = resultado["dni"].ToString();
                paciente.Genero = Convert.ToInt32(resultado["sexo"]);
                paciente.FechaNacimiento = Convert.ToDateTime(resultado["fechaNacimiento"]);

            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return paciente;
        }

        public static bool DeletedPacienteById(int idData)
        {
            
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcUpd.deleted_paciente;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPaciente", idData);

            comando.Connection.Open();
            comando.ExecuteReader();
            conexion.Close();
            comando.Dispose();

            return true;
        }
    }
}
