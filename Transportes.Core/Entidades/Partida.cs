using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Partida{
        public int Id { get; set; }
        public Municipio Municipio { get; set; }

        public static Partida GetById(int id)
        {
            Partida partida = new Partida();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, idMunicipio FROM partida WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        partida.Id = int.Parse(dataReader["id"].ToString());
                        
                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["idMunicipio"].ToString());
                        partida.Municipio = municipio;
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return partida;
        }

        public static List<Partida> GetAllPartidas()
        {
            List<Partida> partidas = new List<Partida>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM partida ORDER BY id;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Partida partida = new Partida();
                        partida.Id = int.Parse(dataReader["id"].ToString());

                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["idMunicipio"].ToString());
                        partida.Municipio = municipio;

                        partidas.Add(partida);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return partidas;
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

                    if(id == 0){
                        cmd.CommandText = "INSERT INTO partida (idMunicipio) Values (@idMunicipio)";
                        cmd.Parameters.AddWithValue("@idMunicipio", idMunicipio);
                    }
                    else{
                        cmd.CommandText = "UPDATE partida SET idMunicipio = @idMunicipio WHERE id = @id;";
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
                    cmd.CommandText = "UPDATE partida SET idMunicipio = @idMunicipio WHERE id = @id;";
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
                    cmd.CommandText = "DELETE FROM partida WHERE id = @id;";
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
