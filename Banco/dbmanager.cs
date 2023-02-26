using MySql.Data.MySqlClient;
using System;

namespace Banco
{
	abstract class DbManager:DbModify
	{
        public string New_admin(string name, string user, string password)
        {
            try
            {

                name = name.ToLower();

                //Se establece conexión con la BD
                Dbconnection conex = new Dbconnection();
                var bdconnect = conex.establecerconexion();

                //Se crea el objeto que tiene el metodo para correr los comandos mysql
                MySqlCommand cmd = new MySqlCommand();
                //Se le asigna la conexión a la base de datos para saber donde se ejecutarán los comandos
                cmd.Connection = bdconnect;
                //String que contendrá el comando a ejecutar
                string sql_command;

                sql_command = $"INSERT INTO customer (account_number, name, user, password, balance) VALUES('" + name + "','" + user + "','" + password + "');";


                //Se guarda el comando
                cmd.CommandText = sql_command;
                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return ("Atm ingresado a la base de datos");


            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public string New_customer(string account_number, string name, int balance, string customer_type, string user, string password)
        {
            try
            {

                name = name.ToLower();
                customer_type = customer_type.ToLower();

                //Se establece conexión con la BD
                Dbconnection conex = new Dbconnection();
                var bdconnect = conex.establecerconexion();

                //Se crea el objeto que tiene el metodo para correr los comandos mysql
                MySqlCommand cmd = new MySqlCommand();
                //Se le asigna la conexión a la base de datos para saber donde se ejecutarán los comandos
                cmd.Connection = bdconnect;
                //String que contendrá el comando a ejecutar
                string sql_command;

                sql_command = $"INSERT INTO customer (account_number, name, user, password, balance) VALUES('" + account_number + "','" + name + "','" + user + "','" + password + "', '" + balance + "');";


                //Se guarda el comando
                cmd.CommandText = sql_command;
                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return ("Atm ingresado a la base de datos");


            }catch(Exception ex)
            {
                return (ex.Message);
            }
        }

        public string New_atm(int balance, string city = null, string addres = null)
        {

            try
            {


                //Se establece conexión con la BD
                Dbconnection conex = new Dbconnection();
                var bdconnect = conex.establecerconexion();

                //Se crea el objeto que tiene el metodo para correr los comandos mysql
                MySqlCommand cmd = new MySqlCommand();
                //Se le asigna la conexión a la base de datos para saber donde se ejecutarán los comandos
                cmd.Connection = bdconnect;
                //String que contendrá el comando a ejecutar
                string sql_command;

                //si no tiene alguno de los dos, se envia solo el balance ya que los otros son opcionales
                if (city == null || addres == null)
                {
                    sql_command = $"INSERT INTO atm (balance) VALUES('" + balance + "');";
                }
                else
                {
                    city = city.ToLower();
                    addres = addres.ToLower();
                    sql_command = $"INSERT INTO atm (balance, city, addres) VALUES('" + balance + "', '" + city + "', '" + addres + "');";
                }

                //Se guarda el comando
                cmd.CommandText = sql_command;
                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return ("Atm ingresado a la base de datos");
            
            }catch(Exception ex)
            {
                return (ex.Message);
            }
        }
	}
}
