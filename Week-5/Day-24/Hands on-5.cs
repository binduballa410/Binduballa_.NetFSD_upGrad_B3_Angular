using System;
using System.IO;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Text;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Monthly Sales Amount: ");
            int sales = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine()); 
            var result = GetPerformanceData(sales, rating);

            string performance = result switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 500000, >= 3) => "Average Performer",
                _ => "Needs Improvment"
            };

            Console.WriteLine("\n----Employee Details----");
            Console.WriteLine($"EMployee Name: {name}");
            Console.WriteLine($"Sales Amount: {result.sales}");
            Console.WriteLine($"Rating: {result.rating}");
            Console.WriteLine($"Performance: {performance}");
        }
        static (int sales,int rating)GetPerformanceData(int sales,int rating)
        {
            return (sales,rating);
        }

    }
}

