
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Banco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Bienvenido care mondá! \n el menú del Banco 'UDEMBANK' tenemos varias opciones ");
            Console.WriteLine("Indique el número de la opción que desea realizar");
            Console.WriteLine("1) Iniciar sesión \n 2) Registrarse \n 3) Ninguna de las anteriores porque soy rebelde ");
            string opcion = Console.ReadLine();
            if ( opcion == "1")
            {

            }
            


            //DbManager dbmanager = new DbManager();
            //Console.WriteLine(dbmanager.New_atm(123));

            //DbValidation dbValidation= new DbValidation();
            //dbValidation.Validar_balance(100, "3", "atm");
            //Console.WriteLine(dbValidation.Login("admin", "rhlm", "brrraa"));
            //Console.WriteLine(dbValidation.Validar_balance(3, "2", "atm"));
            //Console.WriteLine(dbValidation.Tipo_cliente("1"));
            Admin adm = new Admin();
            //Console.WriteLine(adm.Validar_balance(3,"2","atm"));
            //Console.WriteLine(adm.Actualizar_balance(10,"restar","2","atm"));
            Console.WriteLine(adm.Delete_customer_atm_admin();
          
        }
    }
}
