using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Ruta{
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public Pasajero Pasajero { get; set; }
        public Destino Destino { get; set; }
        public Partida Partida { get; set; }

        public static Ruta GetById(int id)
        {
            Ruta ruta = new Ruta();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, descripcion, idEstado, idPasajero, idDestino, idPartida FROM ruta WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ruta.Id = int.Parse(dataReader["id"].ToString());
                        ruta.Descripcion = dataReader["descripcion"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        ruta.Estado = estado;

                        Pasajero pasajero = new Pasajero();
                        pasajero.Id = int.Parse(dataReader["idPasajero"].ToString());
                        ruta.Pasajero = pasajero;

                        Destino destino = new Destino();
                        destino.Id = int.Parse(dataReader["idDestino"].ToString());
                        ruta.Destino = destino;

                        Partida partida = new Partida();
                        partida.Id = int.Parse(dataReader["idPartida"].ToString());
                        ruta.Partida = partida;

                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ruta;
        }

        public static List<Ruta> GetAllRutas()
        {
            List<Ruta> rutas = new List<Ruta>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT * FROM ruta;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Ruta ruta = new Ruta();
                        ruta.Id = int.Parse(dataReader["id"].ToString());
                        ruta.Descripcion = dataReader["descripcion"].ToString();

                        Estado estado = new Estado();
                        estado.Id = int.Parse(dataReader["idEstado"].ToString());
                        ruta.Estado = estado;

                        Pasajero pasajero = new Pasajero();
                        pasajero.Id = int.Parse(dataReader["idPasajero"].ToString());
                        ruta.Pasajero = pasajero;

                        Destino destino = new Destino();
                        destino.Id = int.Parse(dataReader["idDestino"].ToString());
                        ruta.Destino = destino;

                        Partida partida = new Partida();
                        partida.Id = int.Parse(dataReader["idPartida"].ToString());
                        ruta.Partida = partida;

                        rutas.Add(ruta);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rutas;
        }

        public static bool Guardar(int id, String descripcion, int idEstado, int idPasajero, int idDestino, int idPartida)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO ruta (descripcion, idEstado, idPasajero, idDestino, idPartida) Values (@descripcion, @idEstado, @idPasajero, @idDestino, @idPartida)";
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@idEstado", idEstado);
                        cmd.Parameters.AddWithValue("@idPasajero", idPasajero);
                        cmd.Parameters.AddWithValue("@idDestino", idDestino);
                        cmd.Parameters.AddWithValue("@idPartida", idPartida);
                    }
                    else{
                        cmd.CommandText = "UPDATE ruta SET descripcion = @descripcion, idEstado = @idEstado, idPasajero = @idPasajero, idDestino = @idDestino, idPartida = @idPartida WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@idEstado", idEstado);
                        cmd.Parameters.AddWithValue("@idPasajero", idPasajero);
                        cmd.Parameters.AddWithValue("@idDestino", idDestino);
                        cmd.Parameters.AddWithValue("@idPartida", idPartida);
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

        public static bool Editar(String descripcion, int idEstado, int idPasajero, int idDestino, int idPartida, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE ruta SET descripcion = @descripcion, idEstado = @idEstado, idPasajero = @idPasajero, idDestino = @idDestino, idPartida = @idPartida WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);
                    cmd.Parameters.AddWithValue("@idPasajero", idPasajero);
                    cmd.Parameters.AddWithValue("@idDestino", idDestino);
                    cmd.Parameters.AddWithValue("@idPartida", idPartida);
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
                    cmd.CommandText = "DELETE FROM ruta WHERE id = @id;";
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
