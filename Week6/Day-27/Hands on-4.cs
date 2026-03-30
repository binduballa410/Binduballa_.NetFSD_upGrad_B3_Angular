using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;

namespace ConsoleApp2
{
    interface IPrinter
    {
        void Print();
    }
    interface IScanner
    {
        void Scan();
    }
    interface IFax
    {
        void Fax();
    }
    class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing document...");
        }
    }
    class AdvancePrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advances Printer: Printing document....");
        }
        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document...");
        }
        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending fax....");
        }
    }
    class Program
    {
        static void Main(string[] args) 
        {
            BasicPrinter basic = new BasicPrinter();
            basic.Print();
            Console.WriteLine();

            AdvancePrinter advance = new AdvancePrinter();
            advance.Print();
            advance.Scan();
            advance.Fax();
        }
    }
}




