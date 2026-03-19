using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp2
{
    class Class1
    {
        static void Main(string[] args)
        {
            string[] stack = new string[10];
            int top = -1;
            Console.WriteLine("Enter number of actions:");
            int n = int.Parse(Console.ReadLine());

            for (int i =0; i < n; i++)
            {
                Console.WriteLine("Enter action:");
                string action = Console.ReadLine();

                if (action.StartsWith("Type"))
                {
                    if (top < stack.Length - 1)
                    {
                        top++;
                        stack[top] = action;
                    }
                    else
                    {
                        Console.WriteLine("Stack Overflow");
                    }
                }
                else if (action == "Undo")
                {
                    if (top >= 0)
                    {
                        top--;
                    }
                    else
                    {
                        Console.WriteLine("Stack Underflow");
                    }
                }
                Console.WriteLine("Current Stack:");
                if (top == -1)
                {
                    Console.WriteLine("Empty");
                }
                else
                {
                    for (int j = 0; j <= top; j++)
                    {
                        Console.Write(stack[j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            if (top >= 0)
                Console.WriteLine("\nFinal State: " + stack[top]);
            else
                Console.WriteLine("\nFinal State: Empty");
        }

    }
}

    

