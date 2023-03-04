using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Banco
{
    class DbValidation : Sesion
    {

        public List<string> Atm_dispo(double amount, string city, string retirar_transferir)
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

                List<string> atm_disponibles = new List<string>();

                //cmd.CommandText = "";

                if (retirar_transferir == "retirar")
                {
                    //Se guarda el comando
                    cmd.CommandText = "SELECT id, addres FROM atm WHERE city = @city AND balance >= @amount ";
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@amount", amount);

                }
                else if (retirar_transferir == "transferir")
                {
                    //Se guarda el comando
                    cmd.CommandText = "SELECT id, addres FROM atm WHERE city = @city";
                    cmd.Parameters.AddWithValue("@city", city);
          
                }


                // Se ejecuta el comando
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();
                //Se cierra la lectura

                //Le las filas devueltas por la bd
                while (rdr.Read())
                {
                    atm_disponibles.Add(rdr[0].ToString());
                    atm_disponibles.Add(rdr[1].ToString());

                }


                rdr.Close();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                //Retorna si el valor es mayor o igual que su balance actual
                return atm_disponibles;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                List<string> atm_disponibles = new List<string>();

                return atm_disponibles;
            }
        }
        public bool Validar_balance(double amount, string id, string atm_customer_banco)
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

                atm_customer_banco = atm_customer_banco.ToLower();

                //Se guarda el comando
                cmd.CommandText = string.Format("SELECT balance FROM {0:D} WHERE id  = {1:D} ", atm_customer_banco, id);

                //Se ejecuta el comando
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();

                //Se asigna un balance inicial de 0 para comparar al final
                int actual_balance = 0;

                //Le las filas devueltas por la bd
                while (rdr.Read())
                {
                    actual_balance = Int32.Parse(rdr[0].ToString());

                }

                //Se cierra la lectura
                rdr.Close();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                //Retorna si el valor es mayor o igual que su balance actual
                return actual_balance >= amount;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string Tipo_cliente(string id, string get_set, string customer_type = null)
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

                if (get_set == "get")
                {
                    //Se guarda el comando
                    cmd.CommandText = "SELECT customer_type FROM customer WHERE id  = @id ";
                    cmd.Parameters.AddWithValue("@id", id);
                }
                else
                {
                    //Se guarda el comando
                    cmd.CommandText = "UPDATE customer SET customer_type = @customer_type WHERE id = @id";
                    cmd.Parameters.Add("@id", MySqlDbType.Int32);
                    cmd.Parameters["@id"].Value = id;
                    cmd.Parameters.AddWithValue("@customer_type", customer_type);
                }

                //Se ejecuta el comando
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();

                //Se asigna un balance inicial de 0 para comparar al final
                string tipo_cliente = "";

                //Le las filas devueltas por la bd
                while (rdr.Read())
                {
                    tipo_cliente = rdr[0].ToString();

                }

                //Se cierra la lectura
                rdr.Close();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                //Retorna si el valor es mayor o igual que su balance actual
                return tipo_cliente;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
