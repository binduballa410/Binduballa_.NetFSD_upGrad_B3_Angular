using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Product Price: ");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Discount Percentage: ");
            double discount = double.Parse(Console.ReadLine());

            double finalPrice = price = (price * discount / 100);
            Console.WriteLine("\nProduct: " + name);
            Console.WriteLine("Final Price: " + finalPrice);

        }
    }
}




