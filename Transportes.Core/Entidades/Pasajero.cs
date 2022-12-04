using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Pasajero{
        public int Id { get; set; }
        public Boleto Boleto { get; set; }
        public int NumeroAsiento { get; set; }

        public static Pasajero GetById(int id)
        {
            Pasajero pasajero = new Pasajero();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, idBoleto, numeroAsiento FROM pasajero WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        pasajero.Id = int.Parse(dataReader["id"].ToString());

                        Boleto boleto = new Boleto();
                        boleto.Id = int.Parse(dataReader["idBoleto"].ToString());
                        pasajero.Boleto = boleto;

                        pasajero.NumeroAsiento = int.Parse(dataReader["numeroAsiento"].ToString());
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pasajero;
        }

        public static List<Pasajero> GetAllPasajeros()
        {
            List<Pasajero> pasajeros = new List<Pasajero>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM pasajero;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Pasajero pasajero = new Pasajero();
                        pasajero.Id = int.Parse(dataReader["id"].ToString());
                        
                        Boleto boleto = new Boleto();
                        boleto.Id = int.Parse(dataReader["idBoleto"].ToString());
                        pasajero.Boleto = boleto;

                        pasajero.NumeroAsiento = int.Parse(dataReader["numeroAsiento"].ToString());

                        pasajeros.Add(pasajero);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pasajeros;
        }

        public static bool Guardar(int id, int idBoleto, int numeroAsiento)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO pasajero (idBoleto, numeroAsiento) Values (@idBoleto, @numeroAsiento)";
                        cmd.Parameters.AddWithValue("@idBoleto", idBoleto);
                        cmd.Parameters.AddWithValue("@numeroAsiento", numeroAsiento);
                    }
                    else{
                        cmd.CommandText = "UPDATE pasajero SET idBoleto = @idBoleto, numeroAsiento = @numeroAsiento WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@idBoleto", idBoleto);
                        cmd.Parameters.AddWithValue("@numeroAsiento", numeroAsiento);
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

        public static bool Editar(int idBoleto, int numeroAsiento, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE pasajero SET idBoleto = @idBoleto, numeroAsiento = @numeroAsiento WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@idBoleto", idBoleto);
                    cmd.Parameters.AddWithValue("@numeroAsiento", numeroAsiento);
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
                    cmd.CommandText = "DELETE FROM pasajero WHERE id = @id;";
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
