﻿using System;using System.Collections.Generic;using System.Data.Common;using System.Data.SqlClient;using System.Linq;using System.Text;using System.Threading.Tasks;namespace Banco{    internal class Program    {        static void Main(string[] args)        {            Flujo comenzar = new Flujo();            Console.WriteLine(comenzar.Iniciar());            //string m = string.Format("");            //Console.WriteLine();            //DbManager dbmanager = new DbManager();            //Console.WriteLine(dbmanager.New_atm(123));            //DbValidation dbValidation= new DbValidation();            //dbValidation.Validar_balance(100, "3", "atm");            //Console.WriteLine(dbValidation.Login("admin", "rhlm", "brrraa"));            //Console.WriteLine(dbValidation.Validar_balance(3, "2", "atm"));            //Console.WriteLine(dbValidation.Tipo_cliente("1"));            //DbValidation validacion = new DbValidation();            //Console.WriteLine(validacion.Validar_balance(12, "2", "atm"));            //Console.WriteLine(validacion.Atm_dispo(123, "medellin", "retirar")[1]);            //Admin admin = new Admin();            //Console.WriteLine(admin.Validar_balance(12,"5","customer"));            //Bank banco = new Bank();            //Console.WriteLine(banco.Withdraw_money_atm(12, "1", "medellin"));            //Console.WriteLine(adm.Validar_balance(3,"2","atm"));            //Console.WriteLine(adm.Actualizar_balance(10,"restar","2","atm"));            //Console.WriteLine(adm.Delete_customer_atm_admin();        }    }}