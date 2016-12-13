using MinLab.Code.ControlSistemaInterno;
using MinLab.Code.DataLayer.Recursos;
using MinLab.Code.EntityLayer.FichaPlantilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MinLab.Code.DataLayer
{
    public class DataPlantilla
    {
        public static Dictionary<int,Plantilla> GetAllPlantillas()
        {
            Dictionary<int,Plantilla> plantillas =new Dictionary<int, Plantilla>();
            Plantilla plantilla=null;

            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader resultado;

            conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_all_plantilla;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Connection.Open();
            resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                plantilla = new Plantilla();
                plantilla.IdDataPlantilla = Convert.ToInt32(resultado["id"]);
                plantilla.Codigo = resultado["codigo"].ToString();
                plantilla.Nombre = resultado["nombre"].ToString();
                plantilla.Area = Convert.ToInt32(resultado["area"]);
                plantilla.TieneItems = Convert.ToBoolean(resultado["tieneItem"]);
                plantilla.TieneGrupos = Convert.ToBoolean(resultado["tieneGrupo"]);

                plantilla.Filas = new Dictionary<int,PlantillaFila>();
                Dictionary<int,PlantillaFila> temp;
                if (plantilla.TieneGrupos)
                {
                    temp = GetPlantillaFilasGrupo(plantilla.IdDataPlantilla);
                    foreach(PlantillaFila detalle in temp.Values)
                        plantilla.Filas.Add(detalle.Indice,detalle);
                }
                    
                 if (plantilla.TieneItems)
                {
                    temp= GetPlantillaFilaSimple(plantilla.IdDataPlantilla);
                    foreach(PlantillaFila detalle in temp.Values)
                        plantilla.Filas.Add(detalle.Indice,detalle);
                }
                plantilla.IndexarByItem();
                plantillas.Add(plantilla.IdDataPlantilla,plantilla);
            }
            resultado.Close();
            comando.Connection.Close();
            comando.Dispose();
            return plantillas;
        }

        public static Plantilla GetPlantilla(string codigo) {
            Plantilla plantilla=null;

            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader resultado = null;
            
            conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_plantilla;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@codigo", codigo);

            comando.Connection.Open();
            resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                plantilla = new Plantilla();
                plantilla.IdDataPlantilla = Convert.ToInt32(resultado["id"]);
                plantilla.Codigo = resultado["codigo"].ToString();
                plantilla.Nombre = resultado["nombre"].ToString();

                plantilla.TieneItems = Convert.ToBoolean(resultado["tieneItem"]);
                plantilla.TieneGrupos = Convert.ToBoolean(resultado["tieneGrupo"]);
                plantilla.Filas = new Dictionary<int,PlantillaFila>();

                Dictionary<int,PlantillaFila> temp;
                if (plantilla.TieneGrupos)
                {
                    temp = GetPlantillaFilasGrupo(plantilla.IdDataPlantilla);
                    foreach (PlantillaFila detalle in temp.Values)
                        plantilla.Filas.Add(detalle.Indice,detalle);
                }

                if (plantilla.TieneItems)
                {
                    temp = GetPlantillaFilaSimple(plantilla.IdDataPlantilla);
                    foreach (PlantillaFila detalle in temp.Values)
                        plantilla.Filas.Add(detalle.Indice,detalle);
                }
                plantilla.IndexarByItem();
            }
            resultado.Close();
            comando.Connection.Close();
            comando.Dispose();
            return plantilla;
        }

        public static Dictionary<int,PlantillaItem> GetAllItemsByPlantillaFromDB(int IdPlantilla)
        {
            PlantillaItem item = new PlantillaItem();
            Dictionary<int, PlantillaItem> items = new Dictionary<int, PlantillaItem>();
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader resultado = null;

            conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_allItemsByPlantilla;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPlantilla", IdPlantilla);

            comando.Connection.Open();
            resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                item.IdData = Convert.ToInt32(resultado["id"]);
                item.TipoDato = (TipoDato)Convert.ToInt32(resultado["tipoDato"]);
                items.Add(item.IdData,item);
            }
            resultado.Close();
            comando.Connection.Close();
            comando.Dispose();
            return items;
        }

        //SE OBTIENE UN DICTIONARY INDEXADA POR POSICION DE FILAS GRUPO
        public static Dictionary<int,PlantillaFila> GetPlantillaFilasGrupo(int idData)
        {
            Dictionary<int, PlantillaFila> detalles = new Dictionary<int, PlantillaFila>();
            PlantillaFilaGrupo fila;

            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_grupoByPlantilla;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPlantilla", idData);
            comando.Connection.Open();

            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                fila = new PlantillaFilaGrupo();
                fila.Tipo = PlantillaFila.PlantillaFilaTipo.Agrupada;
                fila.Indice = Convert.ToInt32(resultado["indice"]);
                fila.IdData = Convert.ToInt32(resultado["id"]);
                fila.Nombre = resultado["nombre"].ToString();
                fila.Items = GetItemByGrupo(((PlantillaFilaGrupo)fila).IdData);
                detalles.Add(fila.Indice,fila);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();
            conexion.Dispose();

            return detalles;
        }

        //SE OBTIENE UN DICTIONARY INDEXADA POR POSICION DE FILAS SIMPLES
        public static Dictionary<int,PlantillaFila> GetPlantillaFilaSimple(int idData)
        {
            Dictionary<int, PlantillaFila> detalles = new Dictionary<int, PlantillaFila>();
            PlantillaFilaSimple fila;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            int indiceItem = 0, idPlantilla = idData;
            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_itemByPlantilla;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idPlantilla", idData);
            comando.Connection.Open();

            SqlDataReader resultado = comando.ExecuteReader();

            while (resultado.Read())
            {
                fila = new PlantillaFilaSimple();
                fila.Indice = Convert.ToInt32(resultado["indice"]);
                fila.Tipo = PlantillaFila.PlantillaFilaTipo.Simple;

                fila.Item = new PlantillaItem();
                fila.Item.IdData = Convert.ToInt32(resultado["id"]);
                fila.Item.Nombre = resultado["nombre"].ToString();
                fila.Item.PorDefault = resultado["porDefault"].ToString();
                fila.Item.TipoDato = (TipoDato)Convert.ToInt32(resultado["idTipoItem"]);
                fila.Item.TipoCampo = (TipoCampo)Convert.ToInt32(resultado["idTipoCampo"]);
                fila.Item.TieneUnidad = Convert.ToBoolean(resultado["tieneUnidad"]);
                fila.Item.Unidad = resultado["unidad"].ToString();
                switch (fila.Item.TipoCampo)
                {
                    case TipoCampo.Lista:
                        fila.Item.Opciones = GetListItemByItem(fila.Item.IdData);
                        break;
                }

                try
                {
                    indiceItem = fila.Indice;
                    detalles.Add(fila.Indice,fila);
                }
                catch (SqlException e)
                {
                    throw new Exception(e.Message);
                }

            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return detalles;
        }

        public static Dictionary<int,PlantillaItem> GetItemByGrupo(int idData)
        {
            Dictionary<int,PlantillaItem> items = new Dictionary<int,PlantillaItem>();
            PlantillaItem item = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_itemByGrupo;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idGrupo", idData);
            int indiceItem = 0, idGrupo = idData;
            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                item = new PlantillaItem();
                item.IdData = Convert.ToInt32(resultado["id"]);
                item.Nombre = resultado["nombre"].ToString();
                item.PorDefault = resultado["porDefault"].ToString();
                item.TipoDato = (TipoDato)Convert.ToInt32(resultado["idTipoItem"]);
                item.TipoCampo = (TipoCampo)Convert.ToInt32(resultado["idTipoCampo"]);
                item.TieneUnidad = Convert.ToBoolean(resultado["tieneUnidad"]);
                item.Unidad = resultado["unidad"].ToString();
                int indice = Convert.ToInt32(resultado["indice"]);
                indiceItem = indice;
                switch (item.TipoCampo)
                {
                    case TipoCampo.Lista:
                        item.Opciones = GetListItemByItem(item.IdData);
                        break;
                }
                items.Add(indice,item);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return items;
        }

        public static Dictionary<int, PlantillaItemList> GetListItemByItem(int idData)
        {
            Dictionary<int, PlantillaItemList> opciones = new Dictionary<int, PlantillaItemList>();
            PlantillaItemList opcion = null;
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = ConfiguracionDataAccess.CadenaConexion;
            SqlCommand comando = new SqlCommand();

            comando.Connection = conexion;
            comando.CommandText = ProcGet.get_listaByItem;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idItem", idData);

            comando.Connection.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                opcion = new PlantillaItemList();
                opcion.IdData = Convert.ToInt32(resultado["id"]);
                opcion.Nombre = resultado["nombre"].ToString();
                opcion.Indice = Convert.ToInt32(resultado["indice"]);
                opciones.Add(opcion.IdData, opcion);
            }
            resultado.Close();
            conexion.Close();
            comando.Dispose();

            return opciones;
        }



    }

}
