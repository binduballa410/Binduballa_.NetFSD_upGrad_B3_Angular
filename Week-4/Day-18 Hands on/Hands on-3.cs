using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            string name;
            double salary, finalSalary;
            int experience;

            Console.WriteLine("Enter Employee Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary: ");
            salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience (years): ");
            experience = int.Parse(Console.ReadLine());

            double bonus;

            if (experience < 2)
            {
                bonus = salary * 0.05;
            }
            else if (experience <= 5)
            {
                bonus = salary * 0.10;
            }
            else
            {
                bonus = salary * 0.15;
            }

            finalSalary = salary + bonus;

            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Final Salary: " + finalSalary);
        }
    }
}
