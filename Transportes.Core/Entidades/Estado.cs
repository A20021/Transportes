using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Estado{
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static Estado GetById(int id)
        {
            Estado estado = new Estado();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre FROM estado WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estado;
        }

        public static List<Estado> GetAllEstados(){
            List<Estado> estados = new List<Estado>();
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    string query = "SELECT * FROM estado;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read()) {
                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["id"].ToString());
                        estado.Nombre = dataReader["nombre"].ToString();

                        estados.Add(estado);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            return estados;
        }

        public static bool Guardar(int id, String nombre){
            bool result = false;
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO estado (nombre) Values (@nombre)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                    }else{
                        cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@id", id);
                    }

                    result = cmd.ExecuteNonQuery() == 1;
                }
            }catch(Exception ex){
                throw ex;
            }
            return result;
        }

        public static bool Editar(String nombre, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE estado SET nombre = @nombre WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
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
                    cmd.CommandText = "DELETE FROM estado WHERE id = @id;";
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
