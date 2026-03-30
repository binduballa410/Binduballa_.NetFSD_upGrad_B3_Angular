using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10;
        }
    }
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20;
        }
    }
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.30;
        }
    }
    public class PriceCalculator
    {
        private IDiscountStrategy _discountStrategy;
        public PriceCalculator(IDiscountStrategy discountStrategy) { 
            _discountStrategy = discountStrategy;
        }
        public double CalculateFinalPrice(double amount)
        {
            double discount = _discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }
 
    class Program
    {
        
        static void Main(string[] args)
        {
            double amount = 1000;

            IDiscountStrategy strategy;
            Console.WriteLine("Select Customer Type: ");
            Console.WriteLine("1. Regular");
            Console.WriteLine("2. Premium");
            Console.WriteLine("3. VIP");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    strategy = new RegularCustomerDiscount();
                    break;
                case 2:
                    strategy = new PremiumCustomerDiscount();
                    break;
                case 3:
                    strategy = new VipCustomerDiscount();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }
            PriceCalculator calculator = new PriceCalculator(strategy);
            double finalPrice = calculator.CalculateFinalPrice(amount);
            Console.WriteLine($"Orginal Amount: {amount}");
            Console.WriteLine($"Final Price after Discount: {finalPrice}");
            Console.ReadLine();
        }
    }
}




