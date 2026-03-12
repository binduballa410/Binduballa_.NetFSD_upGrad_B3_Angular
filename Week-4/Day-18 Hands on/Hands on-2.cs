using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            double num1, num2;
            char op;
            double result = 0;

            Console.WriteLine("Enter First Number : ");
            num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second Number :");
            num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Operator [+ - * / ]: ");
            op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;

                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    break;
            }
            Console.WriteLine("Result: " + result);
        }
    }
}
