using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void ValidateOrder()
        {
            Trace.WriteLine("Validating order..");
            Console.WriteLine("Order validated.");
        }
        static void ProcessPayment()
        {
            Trace.TraceInformation("Processing payment...");
            Console.WriteLine("Payment processed.");
        }
        static void UpdateInventory()
        {
            Trace.WriteLine("Updating Inventory..");
            Console.WriteLine("Inventory updated.");
        }
        static void GenerateInvoice()
        {
            Trace.TraceInformation("Generating invoice...");
            Console.WriteLine("Invoice generated.");
        }
        static async Task Main(string[] args)
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;

            Console.WriteLine("Order Processing Started...\n");

            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Console.WriteLine("\nOrder Processing Completed.");

            Trace.Close();
            
        
        }
    }
}




