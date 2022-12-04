using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Municipio{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Estado Estado { get; set; }

        public static Municipio GetById(int id)
        {
            Municipio municipio = new Municipio();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, idEstado FROM municipio WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        municipio.Id = int.Parse(dataReader["id"].ToString());
                        municipio.Nombre = dataReader["nombre"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        municipio.Estado = estado;
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return municipio;
        }

        public static List<Municipio> GetAllMunicipios()
        {
            List<Municipio> municipios = new List<Municipio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM municipio;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["id"].ToString());
                        municipio.Nombre = dataReader["nombre"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        municipio.Estado = estado;

                        municipios.Add(municipio);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return municipios;
        }

        public static bool Guardar(int id, String nombre, int idEstado)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO municipio (nombre, idEstado) Values (@nombre, @idEstado)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@idEstado", idEstado);
                    }else{
                        cmd.CommandText = "UPDATE municipio SET nombre = @nombre, idEstado = @idEstado WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@idEstado", idEstado);
                        cmd.Parameters.AddWithValue("@id", id);
                    }
                    

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool Editar(String nombre,int idEstado, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE municipio SET nombre = @nombre, idEstado = @idEstado WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool Eliminar(int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM municipio WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@id", id);

                    result = cmd.ExecuteNonQuery() == 1;

                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
