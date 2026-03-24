using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp2
{
    class Program
    {
        static async Task VerifyPaymentAsync()
        {
            Console.WriteLine("Payment verification started..");
            await Task.Delay(5000);
            Console.WriteLine("Payment verified.");
        }
        static async Task CheckInventoryAsync()
        {
            Console.WriteLine("Inventory check started..");
            await Task.Delay(5000);
            Console.WriteLine("Inventory available");
        }
        static async Task ConfirmOrderAsync()
        {
            Console.WriteLine("Order confirmation started..");
            await Task.Delay(5000);
            Console.WriteLine("Order confirmed.");
        }
        static async Task ProcessOrder()
        {
            Console.WriteLine("Order processing started....\n");

            await VerifyPaymentAsync();
            await CheckInventoryAsync();
            await ConfirmOrderAsync();

            Console.WriteLine("\nOrder processing completed.");
        }
        static async Task Main(string[] args)
        {
            await ProcessOrder();
        
        }
    }
}




