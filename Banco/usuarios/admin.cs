using Org.BouncyCastle.Bcpg;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Banco
{
    class Admin:DbManager
    {
        //En el flujo se verifica si se inicia sesion


        public bool sesion = false;
        private string id;

        public void iniciar_sesion(string user, string password)
        {

            this.id = this.Login("admin", user, password);

            if (id.Length > 0)
            {
                this.sesion = true;

            }

        }


       public string Manipular_admin(string opcion)
       {
            //Crear un nuevo admin
            if (opcion == "crear")
            {
                Console.WriteLine("Ingrese el nombre del usuario");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese el usuario del usuario");
                string user = Console.ReadLine();
                Console.WriteLine("Ingrese la contraseña del usuario");
                string password = Console.ReadLine();
          

                return this.New_admin(name,user, password);

            }
            //Eliminar un admin
            else if(opcion == "eliminar")
            {
                Console.WriteLine("Ingrese el id del admin a eliminar");
                string id = Console.ReadLine();

                return this.Delete_customer_atm_admin(id, "admin");
            }
           
            else
            {
                return ($"La opcion {opcion} no está disponible");
            }
        }
         public string Manipular_cliente( string opcion)
        {
            opcion= opcion.ToLower();
            //Crear un nuevo cliente
            if (opcion == "signup")
            {
                Console.WriteLine("Ingrese el nombre del usuario");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese el usuario del usuario");
                string user = Console.ReadLine();
                Console.WriteLine("Ingrese la contraseña del usuario");
                string password = Console.ReadLine();
                Console.WriteLine("Ingrese el balance del usuario");
                int balance = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el tipo de cliente del usuario");
                string customer_type = Console.ReadLine();

                return this.New_customer(name, balance, customer_type, user, password);

            }
            //Eliminar un cliente
            else if (opcion == "eliminar")
            {
                Console.WriteLine("Ingrese el id del usuario a eliminar");
                string id = Console.ReadLine();

                return this.Delete_customer_atm_admin(id, "customer");
            }
            //Modificar el tipo de cliente
            else if(opcion == "modificar")
            {
                Console.WriteLine("Id del usuario a modificar");
                string id = Console.ReadLine();
                Console.WriteLine("Ingrese el tipo de cliente del usuario");
                string customer_type = Console.ReadLine();

                return this.Tipo_cliente(id, "set", customer_type);

            }
            else
            {

                return ($"La opcion {opcion} no está disponible");
            }
            
        }

        public string Manipular_atm(string opcion)
        {
            opcion = opcion.ToLower();
            //Agregar Atm
            if (opcion == "agregar")
            {

                Console.WriteLine("Ingrese el balance del atm");
                int balance = Int32.Parse(Console.ReadLine());

                if (!(this.Validar_balance(balance, "1", "banco")))
                {
                    Console.WriteLine("El banco no tiene esa cantidad de dinero");
                    return this.Manipular_atm(opcion);
                }

                Console.WriteLine("1) Si el atm ya tiene ciudad y dirección asociada");
                string atm_situado = Console.ReadLine();

                if (atm_situado == "1")
                {
                    Console.WriteLine("Ingrese la ciudad en la que está situado el atm");
                    string city = Console.ReadLine();
                    Console.WriteLine("Ingrese la direccion en la que está situado el atm");
                    string addres = Console.ReadLine();

                    return this.New_atm(balance, city, addres);
                }
                else
                {
                    return this.New_atm(balance);
                }

               

            }
            //Eliminar Atm
            else if (opcion == "eliminar")
            {
                Console.WriteLine("Id del atm que quiere eliminar");
                string id = Console.ReadLine();
                
                return this.Delete_customer_atm_admin(id, "atm");
            }

            else
            {
                return ($"La opcion {opcion} no está disponible");
            }
        }
        


    }
}
