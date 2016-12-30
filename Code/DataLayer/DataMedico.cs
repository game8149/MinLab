using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer.EFicha;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MinLab.Code.DataLayer
{
    public class DataMedico
    {
        public void AddMedico(Medico medico)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcAdd.ADD_MEDICO;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", medico.Nombre);
            comando.Parameters.AddWithValue("@primerApellido", medico.PrimerApellido);
            comando.Parameters.AddWithValue("@segundoApellido", medico.SegundoApellido);
            comando.Parameters.AddWithValue("@colegiatura", medico.Colegiatura);
            comando.Parameters.AddWithValue("@especialidad", medico.Especialidad);
            comando.Parameters.AddWithValue("@habil", medico.Habil);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

        public void UpdMedico(Medico medico)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcUpd.UPD_MEDICO;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", medico.IdData);
            comando.Parameters.AddWithValue("@nombre", medico.Nombre);
            comando.Parameters.AddWithValue("@primerApellido", medico.PrimerApellido);
            comando.Parameters.AddWithValue("@segundoApellido", medico.SegundoApellido);
            comando.Parameters.AddWithValue("@colegiatura", medico.Colegiatura);
            comando.Parameters.AddWithValue("@especialidad", medico.Especialidad);
            comando.Parameters.AddWithValue("@habil",medico.Habil);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

        public void DelMedico(int  idMedico)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcDel.DEL_MEDICO;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", idMedico);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            comando.Dispose();
        }

        public Dictionary<int,Medico> GetAllMedico()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();
            Dictionary<int, Medico> temp = new Dictionary<int, Medico>();
            Medico tempMed;
            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_MEDICO_ALL;
            comando.CommandType = CommandType.StoredProcedure;

            comando.Connection.Open();
            SqlDataReader d=comando.ExecuteReader();

            while (d.Read())
            {
                tempMed = new Medico();
                tempMed.IdData = Convert.ToInt32(d["id"]);
                tempMed.Nombre = d["nombre"].ToString();
                tempMed.PrimerApellido = d["primerApellido"].ToString();
                tempMed.SegundoApellido = d["segundoApellido"].ToString();
                tempMed.Colegiatura = d["colegiatura"].ToString().Trim();
                tempMed.Especialidad = d["especialidad"].ToString();
                tempMed.Habil = Convert.ToBoolean(d["habil"]);
                temp.Add(tempMed.IdData,tempMed);
            }

            conexion.Close();
            comando.Dispose();
            return temp;
        }

        public Dictionary<int, Medico> GetAllMedicoHabil()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();
            Dictionary<int, Medico> temp = new Dictionary<int, Medico>();
            Medico tempMed;
            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_MEDICO_ALL_HABIL;
            comando.CommandType = CommandType.StoredProcedure;

            comando.Connection.Open();
            SqlDataReader d = comando.ExecuteReader();

            while (d.Read())
            {
                tempMed = new Medico();
                tempMed.IdData = Convert.ToInt32(d["id"]);
                tempMed.Nombre = d["nombre"].ToString();
                tempMed.PrimerApellido = d["primerApellido"].ToString();
                tempMed.SegundoApellido = d["segundoApellido"].ToString();
                tempMed.Colegiatura = d["colegiatura"].ToString().Trim();
                tempMed.Especialidad = d["especialidad"].ToString();
                tempMed.Habil = Convert.ToBoolean(d["habil"]);
                temp.Add(tempMed.IdData, tempMed);
            }

            conexion.Close();
            comando.Dispose();
            return temp;
        }

        public Medico GetMedico(int ID)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();
            Medico tempMed=null;
            comando.Connection = conexion;
            comando.CommandText = ProcGet.GET_MEDICO;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ID",ID);
            comando.Connection.Open();
            SqlDataReader d = comando.ExecuteReader();

            while (d.Read())
            {
                tempMed = new Medico();
                tempMed.IdData = Convert.ToInt32(d["id"]);
                tempMed.Nombre = d["nombre"].ToString();
                tempMed.PrimerApellido = d["primerApellido"].ToString();
                tempMed.SegundoApellido = d["segundoApellido"].ToString();
                tempMed.Colegiatura = d["colegiatura"].ToString().Trim();
                tempMed.Especialidad = d["especialidad"].ToString();
                tempMed.Habil = Convert.ToBoolean(d["habil"]);
            }

            conexion.Close();
            comando.Dispose();

            return tempMed;
        }

        public Dictionary<int,Medico> GetMedicoByFiltro(string nombre, string primerApellido, string segundoApellido, bool habil)
        {
            Dictionary<int, Medico> temp = new Dictionary<int, Medico>();

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();
            Medico tempMed = null;
            comando.Connection = conexion;
            comando.CommandText =
                "select id,colegiatura,nombre,primerApellido,segundoApellido,Especialidad,habil " +
                "from Medico where " +
                "nombre like '" + nombre + "%' and " +
                "primerApellido like '" + primerApellido + "%' and " +
                "segundoApellido like '" + segundoApellido + "%' and " +
                "habil=" + Convert.ToInt16(habil);

            comando.CommandType = CommandType.Text;
            comando.Connection.Open();
            SqlDataReader d = comando.ExecuteReader();

            while (d.Read())
            {
                tempMed = new Medico();
                tempMed.IdData = Convert.ToInt32(d["id"]);
                tempMed.Nombre = d["nombre"].ToString();
                tempMed.PrimerApellido = d["primerApellido"].ToString();
                tempMed.SegundoApellido = d["segundoApellido"].ToString();
                tempMed.Colegiatura = d["colegiatura"].ToString().Trim();
                tempMed.Especialidad = d["especialidad"].ToString();
                tempMed.Habil = Convert.ToBoolean(d["habil"]);
                temp.Add(tempMed.IdData, tempMed);
            }

            conexion.Close();
            comando.Dispose();

            return temp;
        }

    }
}
