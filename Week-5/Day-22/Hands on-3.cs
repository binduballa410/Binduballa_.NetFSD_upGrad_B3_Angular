using System;
namespace ConsoleApp2
{ 
    class Calculator
    {
        public int Divide(int numerator,int denominator)
        {
            return numerator / denominator;
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            try
            {
                Console.WriteLine("Enter Numerator: ");
                int num = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Denominator: ");
                int den = int.Parse(Console.ReadLine());

                int result = calc.Divide(num, den);
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter numbers only.");
            }
            finally
            {
                Console.WriteLine("Operation Completed Safely");
            }
            Console.ReadLine();
        }
    }
}