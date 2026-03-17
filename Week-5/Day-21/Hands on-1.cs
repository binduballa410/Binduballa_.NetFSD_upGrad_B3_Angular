using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class BankAccount
    {
        private int _accountNumber;
        private double _balance;

        public int AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public double Balance
        {
            get { return _balance; }
        }
        public void Deposite(double amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine("Deposite Successful");
                Console.WriteLine("Current Balance = " + _balance);
            }
            else
            {
                Console.WriteLine("Invalid Deposite Amount");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid Withdrawal Amount");
            }
            else if (amount > _balance)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                _balance -= amount;
                Console.WriteLine("Withdrawal Successsfull");
                Console.WriteLine("Current Balance = " + _balance);
            }
        }
    }

    internal class Class2
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.AccountNumber = 101;

            Console.WriteLine("Enter Deposite Amount: ");
            double deposite = double.Parse(Console.ReadLine());

            account.Deposite(deposite);

            Console.WriteLine("Enter Withdraw Amount: ");
            double withdraw = double.Parse(Console.ReadLine());

            account.Withdraw(withdraw);
            Console.ReadLine();
        }

    }
}


