using System;
using MySql.Data.MySqlClient;

namespace Banco
{
	abstract class DbModify:DbValidation
	{

        public string Add_money_atm(double amount, string id_atm)
        {
            try
            {
                if (!(this.Validar_balance(amount, "1", "banco")))
                {
                    return "El banco no tiene saldo suficiente";
                }

                //Se establece conexión con la BD
                Dbconnection conex = new Dbconnection();
                var bdconnect = conex.establecerconexion();

                //Se crea el objeto que tiene el metodo para correr los comandos mysql
                MySqlCommand cmd = new MySqlCommand();
                //Se le asigna la conexión a la base de datos para saber donde se ejecutarán los comandos
                cmd.Connection = bdconnect;

                //Se elimina el seleccionado mediante el id
              

                cmd.CommandText = "UPDATE atm SET balance =  balance + @amount WHERE  id = @id_atm ";
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@id_atm", id_atm);

                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return $"Se le sumo {amount} al atm con id {id_atm}";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

		public string Actualizar_balance(double amount, string sumar_restar,string id, string atm_customer_banco)
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


                atm_customer_banco = atm_customer_banco.ToLower();


                if (sumar_restar == "sumar")
                {
                    //string comando = string.Format("UPDATE {0:nq} SET balance =  balance + {1:n} WHERE  id = {2:n} ", atm_customer_banco, amount, id);

                    //Primero se necesita validar el balance
                    
                    cmd.CommandText = string.Format("UPDATE {0} SET balance =  balance + {1} WHERE  id = {2} ",atm_customer_banco, amount,id);
                }
                else if (sumar_restar == "restar")
                {
                    //Primero se necesita validar el balance
                    cmd.CommandText = string.Format("UPDATE {0} SET balance =  balance - {1} WHERE  id = {2} ",atm_customer_banco, amount, id);
                }
                else
                {
                    return $"No se puede ralizar esa operación en el balance {sumar_restar}";
                }


                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return $"Se {sumar_restar} el balance del {atm_customer_banco} con el id {id}";
            }catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete_customer_atm_admin(string id, string customer_atm_admin)
        {
            try
            {
                customer_atm_admin = customer_atm_admin.ToLower();

                //Se establece conexión con la BD
                Dbconnection conex = new Dbconnection();
                var bdconnect = conex.establecerconexion();


                //Se crea el objeto que tiene el metodo para correr los comandos mysql
                MySqlCommand cmd = new MySqlCommand();
                //Se le asigna la conexión a la base de datos para saber donde se ejecutarán los comandos
                cmd.Connection = bdconnect;

                //Se elimina el seleccionado mediante el id

                cmd.CommandText = string.Format ("DELETE FROM {0} WHERE id = {1}", customer_atm_admin, id);

                //Se ejecuta el comando
                cmd.ExecuteNonQuery();

                //Se cierra la conexión a la BD
                bdconnect.Close();

                return $"{customer_atm_admin} con el id {id} ha sido eliminado de la base de datos";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
    }
}
