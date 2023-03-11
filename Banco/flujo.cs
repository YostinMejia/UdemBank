using System;


namespace Banco
{
    class Flujo
    {
        public string Iniciar()
        {
            try
            {


                Console.WriteLine("¡Bienvenido care mondá! \n el menú del Banco 'UDEMBANK' tenemos varias opciones ");
                Console.WriteLine("Indique el número de la opción que desea realizar \n 1) Si es cliente \n 2) Si es administrador  ");
                string tipo_usuario = Console.ReadLine();

            

                //opcion 1 = Cliente
                if (tipo_usuario == "1")
                {
                    Console.WriteLine("1) Iniciar sesión \n 2) Registrarse \n 3) Ninguna de las anteriores porque soy rebelde ");
                    string opcion = Console.ReadLine();

                    //opcion 1 = Inicar sesion
                    if (opcion == "1")
                    {
                        Console.WriteLine("Ingrese su usuario");
                        string user = Console.ReadLine();
                        Console.WriteLine("Ingrese su contraseña");
                        string password = Console.ReadLine();

                        Customer customer = new Customer(user, password);

                        //Si no se pudo iniciar sesión correctamente
                        if (! customer.sesion)
                        {
                            return "Contraseña o usuario invalido";
                        }

                        //opciones disponibles como usuario
                        Console.WriteLine("Que quiere hacer care mondá? \n1) transferir dinero via virtual \n2) transferir dinero por medio de un atm \n3) Retirar dinero de un atm \n4) Depositar dinero en su cuenta mediante un atm");
                        string opcion_customer = Console.ReadLine();

                        //transferir dinero via virtual
                        if (opcion_customer == "1")
                        {
                            Console.WriteLine("Cuanto dinero quiere transferir");
                            double cantidad = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Id de la persona a la que le va a transferir");
                            string id_beneficiary = Console.ReadLine();

                            return customer.Money_transfer_virtual(cantidad, id_beneficiary);
                        }
                        // transferir dinero por medio de un atm
                        else if (opcion_customer == "2")
                        {
                            Console.WriteLine("Cuanto dinero quiere transferir");
                            double cantidad = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Id de la persona a la que le va a transferir");
                            string id_beneficiary = Console.ReadLine();
                            Console.WriteLine("En cual ciudad está?");
                            string ciudad = Console.ReadLine();

                            return customer.Money_transfer_atm(cantidad, ciudad, id_beneficiary);

                        }
                        //Retirar dinero de un atm
                        else if (opcion_customer == "3")
                        {
                            Console.WriteLine("Cuanto dinero quiere retirar");
                            double cantidad = Double.Parse(Console.ReadLine());

                            Console.WriteLine("En cual ciudad está?");
                            string ciudad = Console.ReadLine();

                            return customer.Withdraw_money_atm(cantidad, ciudad);

                        }
                        //Depositar dinero en su cuenta mediante un atm
                        else if (opcion_customer == "4")
                        {
                            Console.WriteLine("¿Cuanto dinero quiere depositar en su cuenta?");
                            double cantidad = Double.Parse(Console.ReadLine());

                            Console.WriteLine("En cual ciudad está?");
                            string ciudad = Console.ReadLine();

                            return customer.Add_money_own_account(cantidad);

                        }
                        else
                        {
                            return "opción invalida";
                        }

                    }
                    //Registrarse
                    else if (opcion == "2")
                    {


                        Console.WriteLine("Ingrese su nombre");
                        string name = Console.ReadLine();
                        Console.WriteLine("Cree su user");
                        string user = Console.ReadLine();
                        Console.WriteLine("Cree su contraseña");
                        string password = Console.ReadLine();

                        Admin admin = new Admin();
                        return admin.New_customer(name, 0, "regular", user, password);


                    }
                    //Si no selecciona alguno de las opciones como cliente
                    else
                    {
                        return "Los clientes aún no tienen esta función ";
                    }


                }
                else if (tipo_usuario == "2")
                {

                    Console.WriteLine("Ingrese su usuario");
                    string user = Console.ReadLine();
                    Console.WriteLine("Ingrese su contraseña");
                    string password = Console.ReadLine();
                    Admin administrador = new Admin();
                    administrador.Login("admin", user, password);

                    //Inicio de sesión correcto
                    if (!administrador.sesion)
                    {
                        return "Usuario o contraseña invalida";

                    }

                    administrador.welcome();

                    //opciones disponibles como administrador
                    //C reate
                    //R ead
                    //U pdate
                    //D elete
                    //opciones disponibles del crud
                    Console.WriteLine("Que quiere hacer admin care mondá? \n1) CD ATM \n2) CUD cliente \n2) CD admin ");
                    string opcion_admin = Console.ReadLine();

                    if (opcion_admin == "1") {

                        Console.WriteLine(" ATM \n1) agregar un nuevo atm \n2) eliminar un atm ");
                        string opcion_atm = Console.ReadLine();
                        return administrador.Manipular_admin(opcion_atm);
                    
                    }
                    else if(opcion_admin == "2")
                    {
                        Console.WriteLine(" ATM \n1) Agregar un nuevo cliente \n2) Eliminar un cliente \n3) Modificar la informacion de un cliente");
                        string opcion_customer = Console.ReadLine();
                        return administrador.Manipular_cliente(opcion_customer);
                    }
                    else if(opcion_admin == "3") {
                        Console.WriteLine(" ATM \n1) Agregar un nuevo administrador \n2) Eliminar un administrador");
                        string opcion_modificar_admin = Console.ReadLine();
                        return administrador.Manipular_cliente(opcion_modificar_admin);
                    }
                    else
                    {
                        return "por no escoger una opcion como admin valida, no se pudo hacer nichi";
                    }

                }
                else
                {
                    return "No existe ese tipo de usuario";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

