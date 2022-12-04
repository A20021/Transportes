using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Operador{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public static Operador GetById(int id)
        {
            Operador operador = new Operador();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, nombre, edad FROM operador WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        operador.Id = int.Parse(dataReader["id"].ToString());
                        operador.Nombre = dataReader["nombre"].ToString();
                        operador.Edad = int.Parse(dataReader["edad"].ToString());
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return operador;
        }

        public static List<Operador> GetAllOperadores()
        {
            List<Operador> operadores = new List<Operador>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM operador;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Operador operador = new Operador();
                        operador.Id = int.Parse(dataReader["id"].ToString());
                        operador.Nombre = dataReader["nombre"].ToString();
                        operador.Edad = int.Parse(dataReader["edad"].ToString());

                        operadores.Add(operador);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return operadores;
        }

        public static bool Guardar(int id, String nombre, int edad)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO operador (nombre, edad) Values (@nombre, @edad)";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@edad", edad);
                    }else{
                        cmd.CommandText = "UPDATE operador SET nombre = @nombre, edad = @edad WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@edad", edad);
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

        public static bool Editar(String nombre, int edad, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE operador SET nombre = @nombre, edad = @edad WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@edad", edad);
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
                    cmd.CommandText = "DELETE FROM operador WHERE id = @id;";
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
