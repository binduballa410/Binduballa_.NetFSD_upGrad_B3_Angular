using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp2
{
    class Program
    {
        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report started..");
            await Task.Delay(5000);
            Console.WriteLine("Sales Report completed..");
        }

        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Started..");
            await Task.Delay(5000);
            Console.WriteLine("Inventory Report Completed..");
        }

        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Started...");
            await Task.Delay(5000);
            Console.WriteLine("Customer Report Completed..");

        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Processing reports...\n");

            Task t1 = GenerateSalesReport();
            Task t2 = GenerateInventoryReport();
            Task t3 = GenerateCustomerReport();

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("\nAll reports generated successfully.");
          

        }
    }
}




