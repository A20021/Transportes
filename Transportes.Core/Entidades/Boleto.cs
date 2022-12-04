using Transportes.Core.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportes.core.Entidades
{
    public class Boleto
    {

        public int Id { get; set; }
        public int NumeroBoleto { get; set; }

        public static Boleto GetById(int id)
        {
            Boleto boleto = new Boleto();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT id, numeroBoleto FROM boleto WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion.Connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        boleto.Id = int.Parse(dataReader["id"].ToString());
                        boleto.NumeroBoleto = int.Parse(dataReader["numeroBoleto"].ToString());
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return boleto;
        }

        public static List<Boleto> GetAllBoletos()
        {
            List<Boleto> boletos = new List<Boleto>();
            try{
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection()){
                    string query = "SELECT * FROM boleto;";
                    MySqlCommand commnd = new MySqlCommand(query, conexion.Connection);
                    MySqlDataReader dataReader = commnd.ExecuteReader();
                    while (dataReader.Read()){
                        Boleto boleto = new Boleto();
                        boleto.Id = int.Parse(dataReader["id"].ToString());
                        boleto.NumeroBoleto = int.Parse(dataReader["numeroBoleto"].ToString());

                        boletos.Add(boleto);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex){
                throw ex;
            }
            return boletos;
        }

        public static bool Guardar(int id, int numeroBoleto)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();

                    if (id == 0){
                        cmd.CommandText = "INSERT INTO boleto (numeroBoleto) Values (@numeroBoleto)";
                        cmd.Parameters.AddWithValue("@numeroBoleto", numeroBoleto);
                    }
                    else{
                        cmd.CommandText = "UPDATE boleto SET numeroBoleto = @numeroBoleto WHERE id = @id;";
                        cmd.Parameters.AddWithValue("@numeroBoleto", numeroBoleto);
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

        public static bool Editar(int numeroBoleto, int id)
        {
            bool result = false;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    MySqlCommand cmd = conexion.Connection.CreateCommand();
                    cmd.CommandText = "UPDATE boleto SET numeroBoleto = @numeroBoleto WHERE id = @id;";
                    cmd.Parameters.AddWithValue("@numeroBoleto", numeroBoleto);
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
                    cmd.CommandText = "DELETE FROM boleto WHERE id = @id;";
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
