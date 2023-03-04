using MySql.Data.MySqlClient;
using System;
using System.Linq;

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

        private long Generate_account_number()
        {

            var guid = Guid.NewGuid();

            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());

            var seed = int.Parse(justNumbers.Substring(0, 4));

            var random = new Random(seed);
            long value = random.Next(00000000001, 2147483647);

            return value;

        }
        public string New_customer(string name, int balance, string customer_type, string user, string password)
        {
            try
            {
                if (!(name.Length >= 5 && user.Length >= 5 && password.Length >= 5))
                {
                    return "Debe ingresar minimo 5 caracteres en los campos solicitados";
                }
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
                string buscar_account_number;

                long account_number = this.Generate_account_number();

                buscar_account_number = "SELECT id FROM customer WHERE account_number = @account_number";
                cmd.CommandText = buscar_account_number;
                cmd.Parameters.AddWithValue("@account_number", account_number);
                cmd.ExecuteNonQuery();

                MySqlDataReader rdr = cmd.ExecuteReader();
                int datos = 0;

                //Le las filas devueltas por la bd
                while (rdr.Read())
                {
                     datos = Int32.Parse(rdr[0].ToString());

                }
                //Si ya existe alguien con el número de cuenta se vuelve a ejecutar la función generando otro número
                if (datos > 0)
                {
                    return this.New_customer(name,balance,customer_type,user,password);
                }
                     
                //Se cierra la lectura
                rdr.Close();


                sql_command = $"INSERT INTO customer (account_number, name, user, password, balance, customer_type) VALUES('" + account_number + "','" + name + "','" + user + "','" + password + "', '" + balance + "', '" + customer_type + "');";

                cmd.CommandText = sql_command;
                //Se guarda el comando
                cmd.CommandText = sql_command;
                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return ("Cliente ingresado a la base de datos");


            }
            catch (Exception ex)
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
