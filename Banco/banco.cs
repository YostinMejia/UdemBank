using System;
using System.Collections.Generic;

namespace Banco
{
    class Bank:DbModify
    {

        private double Comision(string id_customer, double amount)
        {
            if (this.Tipo_cliente(id_customer, "get") == "regular")
            {
                return amount * 0.015;
            }
            else
            {
                return amount * 0.005;
            }
        }

        public string Add_money_to_atm(double amount, string id_atm)
        {
            return this.Add_money_atm(amount, id_atm);
        }

        public string Withdraw_money_atm(double amount, string id_customer, string city)
        {

            List<string> atm_disponibles=  this.Atm_dispo(amount, city, "retirar");
            for(var i =0; i< atm_disponibles.Count; i+=2)
            {
                Console.WriteLine("ID: " + atm_disponibles[i] + " - Direccion: " + atm_disponibles[i + 1]);
            }

            
            Console.WriteLine("Ingrese el id del atm del que desea retirar dinero");
            string id_atm = Console.ReadLine();

            if( !(atm_disponibles.Contains(id_atm)))
            {
                return "Id seleccionado invalido";

            }

            //primero se verifica que ambos tengan suficiente dinero
            if (!(this.Validar_balance(amount,id_atm, "atm")) ) { 
                return "El cajero no tiene suficiente dinero";
            }
            else if(! (this.Validar_balance(amount, id_customer, "customer"))){
                return "esta pobre socio no tiene suficiente dinero";
            }
            
            this.Actualizar_balance(amount, "restar", id_atm, "atm");

            return this.Actualizar_balance(amount, "restar", id_customer, "customer") + "\n Recoja esa chichigua y cuidao lo roban";

        }

        public string Money_transfer_virtual(double amount, string id_sender, string id_beneficiary)
        {
            //Se le suma la comisión
            double amount_comision = amount + this.Comision(id_sender, amount);

            //primero se verifica que el remitente tenga el dinero

            if (!(this.Validar_balance(amount_comision, id_sender, "customer")))
            {
                return "esta pobre socio no tiene suficiente dinero";
            }
            
            this.Actualizar_balance(amount, "sumar", id_beneficiary, "customer");
            
            return this.Actualizar_balance(amount_comision, "restar", id_sender, "customer") ;

        }

        public string Money_transfer_atm(double amount, string city, string id_sender, string id_beneficiary)
        {

            List<string> atm_disponibles = this.Atm_dispo(amount, city, "transferir");
            for (var i = 0; i < atm_disponibles.Count; i += 2)
            {
                Console.WriteLine("ID: " + atm_disponibles[i] + " - Direccion: " + atm_disponibles[i + 1]);
            }

            Console.WriteLine("Ingrese el id del atm del que desea retirar dinero");
            string id_atm = Console.ReadLine();

            if( !(atm_disponibles.Contains(id_atm)))
            {
                return "Id seleccionado invalido";

            }

            //Se le suma la comisión
            double amount_comision = amount + this.Comision(id_sender, amount);

            //primero se verifica que el banco tenga la cantidad de dinero
            if (!(this.Validar_balance(amount, "1", "banco")) )
            {
                return "El banco está en quiebra y no tiene plata pa esa transacción";
            }
            //Se verifica que quien envia tenga suficiente dinero en su cuenta
            else if (!(this.Validar_balance(amount_comision, id_sender, "customer")))
            {
                return "esta pobre socio no tiene suficiente dinero";
            }

            //Se almacena en una lista los ATM retornados
            //string[,] atm_disponibles = this.Atm_dispo(amount, city, "transferir");


            //Se suma el dinero a la cuenta del receptor
            this.Actualizar_balance(amount, "sumar", id_beneficiary, "customer");
            //Se suma el dinero a la cuenta del atm
            this.Actualizar_balance(amount, "sumar", id_atm, "atm");

            //Se resta el dinero de la cuenta del banco
            this.Actualizar_balance(amount, "restar", "1","banco");
            //Se resta el dinero de la cuenta de quien transfiere el dinero
            this.Actualizar_balance(amount, "restar", id_sender, "customer");

            return "La transacción se realizo con exito";

        }

        public string Deposit_money_atm(double amount, string id_customer)
        {
            
            //primero se verifica que el banco tenga la cantidad de dinero
            if (!(this.Validar_balance(amount, "1", "banco")))
            {
                return "El banco está en quiebra y no tiene plata pa esa transacción";
            }


            //Se suma el dinero a la cuenta del receptor
            this.Actualizar_balance(amount, "sumar", id_customer, "customer");
          
            //Se resta el dinero de la cuenta del banco
            this.Actualizar_balance(amount, "restar", "1", "banco");
   

            return "La transacción se realizo con exito";


        }
    }
}
