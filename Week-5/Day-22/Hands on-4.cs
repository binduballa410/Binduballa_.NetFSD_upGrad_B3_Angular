using System;
namespace ConsoleApp2
{ 
    
    class InsufficientBalanceException: Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {

        }
    }
    class BankAccount
    {
        private double balance;
        public BankAccount(double balance)
        {
            this.balance = balance;
        }
        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds avaliable balance");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdrawal successful. Remaining Balance: " + balance);
            }
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter Balance: ");
                double balance = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Withdrawal Amount: ");
                double amount = double.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(balance);
                account.Withdraw(amount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation Completed Safely");
            }
            
        }
    }
}