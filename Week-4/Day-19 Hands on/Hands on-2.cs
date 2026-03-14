using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    internal class Class2
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            Console.WriteLine("Enter First Number :");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second Number :");
            int b = int.Parse(Console.ReadLine());

            int result1 = calculator.Add(a,b);
            int result2 = calculator.Subtract(a,b);

            Console.WriteLine("Addition = " + result1);
            Console.WriteLine("Subtraction = " + result2);

            Console.ReadLine();
        }

    }
}


