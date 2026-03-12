using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            int n;
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            Console.WriteLine("Enter Number: ");
             n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                sum = sum + i;

                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            Console.WriteLine("Even numbers: " + evenCount);
            Console.WriteLine("Odd numbers: " + oddCount);
            Console.WriteLine("Sum of all Numbers is: " + sum);

        }
    }
}
