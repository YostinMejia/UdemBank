using System;


namespace Banco
{
    class Customer:Sesion
    {
        public bool sesion = false;
        private string id;
        
        public Customer(string user, string password) {

            this.id = this.Login("customer", user, password);

            if (id.Length > 0)
            {
                this.sesion = true;

            }
            
        }

        public void welcome()
        {
            Console.WriteLine("Binevenido care mondá");
        }

        public string Money_transfer_atm(double amount,string city, string id_atm,string id_beneficiary)
        {

            Bank banco = new Bank();
            return banco.Money_transfer_atm(amount, city, id_atm,this.id,id_beneficiary);
        }

        public string Withdraw_money_atm(double amount, string id_atm)
        {
            Bank banco = new Bank();
            return banco.Withdraw_money_atm(amount, this.id, id_atm);
        }
        public string Money_transfer_virtual(double amount, string id_beneficiary)
        {
            Bank banco = new Bank();
            return banco.Money_transfer_virtual(amount, this.id, id_beneficiary);
        }

       

   
    }
}
