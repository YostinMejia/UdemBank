using System;
using MySql.Data.MySqlClient;

namespace Banco
{
    abstract class Sesion
    {
        public string Login(string admin_customer, string user, string password)
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

                //Se usa Format porque retorna una copia del string y así se puede modificar la consulta a gusto
                //Se guarda el comando
                cmd.CommandText = string.Format("SELECT user, password, id FROM {0:D} ", admin_customer);

                //Se ejecuta el comando
                cmd.ExecuteNonQuery();
                MySqlDataReader rdr = cmd.ExecuteReader();

                string coincide="";
                //Le las filas devueltas por la bd
                while (rdr.Read())
                {
                    //pos 0 = user ---- pos 1 = password
                    if (rdr[0].ToString() == user && password == rdr[1].ToString())
                    {
                        coincide = rdr[2].ToString();
                    }

                }

                //Se cierra la lectura
                rdr.Close();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                //Retorna si el valor es mayor o igual que su balance actual
                return coincide;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }

    
    }
}
