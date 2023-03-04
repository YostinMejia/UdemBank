using System;
using MySql.Data.MySqlClient;

namespace Banco
{
    public class Dbconnection
    {
        MySqlConnection dbconexion = new MySqlConnection();
        static string servidor = "localhost";
        static string db = "banco";
        static string usuario = "root";
        static string password = "1234";
        static string puerto = "3306";


        static string connectionstring = $"Server={servidor};Port={puerto};User ID={usuario};Password={password};Database={db}";
        public MySqlConnection establecerconexion()
        {
            try
            {
                dbconexion.ConnectionString = connectionstring;
                dbconexion.Open();
                Console.WriteLine("Conexión a la base de datos exitosa");

            }
            catch (MySqlException e)
            {
                Console.WriteLine("No se pudo establecer la conexión" + e);
            }

            return dbconexion;
        }
        


    }
}