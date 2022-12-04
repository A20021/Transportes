using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Destino{
        public int Id { get; set; }
        public Municipio Municipio { get; set; }

        public static Destino GetById(int id)
        {
            Destino destino = new Destino();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, idMunicipio FROM destino WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        destino.Id = int.Parse(dataReader["id"].ToString());

                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["idMunicipio"].ToString());
                        destino.Municipio = municipio;
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return destino;
        }

        public static List<Destino> GetAllDestinos()
        {
            List<Destino> destinos = new List<Destino>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM destino;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Destino destino = new Destino();
                        destino.Id = int.Parse(dataReader["id"].ToString());

                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["idMunicipio"].ToString());
                        destino.Municipio = municipio;

                        destinos.Add(destino);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return destinos;
        }

        public static bool Guardar(int id, int idMunicipio)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO destino (idMunicipio) Values (@idMunicipio)";
                        cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                    }
                    else{
                        cmd.CommandText = "UPDATE destino SET idMunicipio = @idMunicipio WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
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

        public static bool Editar(int idMunicipio, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE destino SET idMunicipio = @idMunicipio WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
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
                    cmd.CommandText = "DELETE FROM destino WHERE id = @id;";
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
