using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp2
{
        class Program
        {
        static async Task WriteLogAsync(string message)
        {
            await Task.Delay(2000);
            Console.WriteLine($"Log Wirtten: {message}");
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Loggging started...");

            Task t1 = WriteLogAsync("User logged in");
            Task t2 = WriteLogAsync("File uploded");
            Task t3 = WriteLogAsync("Error ocurred");

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("All logs completed.");
        }

                
             
        }
}




